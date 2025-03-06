using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AspnetCoreMvcStarter.Helpers
{
    public class NotificationHelper
    {
        private readonly EmailService _emailService;
        private readonly ApplicationDbContext _context;

        public NotificationHelper(EmailService emailService, ApplicationDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        public async Task NotifyRequestStatusChangeAsync(Request request, string oldStatus)
        {
            if (request == null)
                return;

            try
            {
                // Ensure request has all needed data
                if (request.Facility == null || request.FacilityItem == null)
                {
                    request = await _context.Requests
                        .Include(r => r.Facility)
                        .Include(r => r.FacilityItem)
                        .FirstOrDefaultAsync(r => r.RequestId == request.RequestId);

                    if (request == null)
                        return;
                }

                // Notify requestor
                if (request.RequestorId.HasValue)
                {
                    var requestor = await _context.Users.FindAsync(request.RequestorId);
                    if (requestor != null && !string.IsNullOrEmpty(requestor.Email))
                    {
                        string subject = $"Request #{request.RequestId} Status Updated";
                        string body = $@"
                            <html>
                            <body>
                                <h2>Request Status Update</h2>
                                <p>Your request status has been changed from <strong>{oldStatus}</strong> to <strong>{request.Status}</strong>.</p>
                                <div style='margin: 20px 0; padding: 15px; border: 1px solid #ddd; border-radius: 5px;'>
                                    <p><strong>Request ID:</strong> {request.RequestId}</p>
                                    <p><strong>Facility:</strong> {request.Facility?.FacilityName ?? "Unknown"}</p>
                                    <p><strong>Item:</strong> {request.FacilityItem?.ItemName ?? "Unknown"}</p>
                                    <p><strong>Status:</strong> {request.Status}</p>
                                </div>
                                <p>Please log in to the system to view the details.</p>
                            </body>
                            </html>";

                        await _emailService.SendEmailAsync(subject, body, requestor.Email);
                    }
                }

                // Notify facility head for certain status changes
                if ((request.Status == "Resolved" || request.Status == "Closed") &&
                    request.FacilityId.HasValue)
                {
                    var facility = await _context.Facilities
                        .Include(f => f.FacilityHead)
                        .FirstOrDefaultAsync(f => f.FacilityId == request.FacilityId);

                    if (facility?.FacilityHeadId != null && facility.FacilityHead != null &&
                        !string.IsNullOrEmpty(facility.FacilityHead.Email))
                    {
                        string subject = $"Request #{request.RequestId} for {facility.FacilityName} is {request.Status}";
                        string body = $@"
                            <html>
                            <body>
                                <h2>Request Status Update</h2>
                                <p>A request for your facility has been marked as <strong>{request.Status}</strong>.</p>
                                <div style='margin: 20px 0; padding: 15px; border: 1px solid #ddd; border-radius: 5px;'>
                                    <p><strong>Request ID:</strong> {request.RequestId}</p>
                                    <p><strong>Facility:</strong> {facility.FacilityName}</p>
                                    <p><strong>Item:</strong> {request.FacilityItem?.ItemName ?? "Unknown"}</p>
                                    <p><strong>Status:</strong> {request.Status}</p>
                                </div>
                                <p>Please log in to the system to view the details.</p>
                            </body>
                            </html>";

                        await _emailService.SendEmailAsync(subject, body, facility.FacilityHead.Email);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't throw it up
                Console.WriteLine($"Error in NotifyRequestStatusChangeAsync: {ex.Message}");
            }
        }
    }
}
