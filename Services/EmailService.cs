using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspnetCoreMvcStarter.Models;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Data;

public class EmailService
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;

    public EmailService(IConfiguration configuration, ApplicationDbContext context)
    {
      _config = configuration;
        _context = context;
    }

    public async Task SendEmailAsync(string subject, string body, string recipientEmail)
    {
        try
        {
            var smtpServer = _config["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
            var senderEmail = _config["EmailSettings:SenderEmail"];
            var senderPassword = _config["EmailSettings:SenderPassword"];

            // If no specific recipient is provided, use the default from config
            if (string.IsNullOrEmpty(recipientEmail))
            {
                recipientEmail = _config["EmailSettings:ReceiverEmail"];
            }

            using (var client = new SmtpClient(smtpServer, smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;

                var message = new MailMessage(senderEmail, recipientEmail, subject, body)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error sending email: {ex.Message}");
            throw;
        }
    }

    public async Task SendRequestCreationNotificationAsync(Request request)
    {
        if (request == null || !request.FacilityId.HasValue)
        {
            throw new ArgumentException("Invalid request or missing facility information");
        }

        // Load the facility with its head
        var facility = await _context.Facilities
            .Include(f => f.FacilityHead)
            .FirstOrDefaultAsync(f => f.FacilityId == request.FacilityId.Value);

        if (facility == null || facility.FacilityHeadId == null || facility.FacilityHead == null || string.IsNullOrEmpty(facility.FacilityHead.Email))
        {
            throw new InvalidOperationException("Cannot find facility head's email");
        }

        // Load the requestor information
        var requestor = await _context.Users.FindAsync(request.RequestorId);
        var requestorName = requestor != null ? requestor.FullName : "Unknown User";

        // Load the facility item information
        var facilityItem = await _context.FacilityItems.FindAsync(request.FacilityItemId);
        var itemName = facilityItem != null ? facilityItem.ItemName : "Unknown Item";

        // Build email content
        string subject = $"New Request #{request.RequestId} for {facility.FacilityName}";
        string body = $@"
            <html>
            <body>
                <h2>New Request Notification</h2>
                <p>A new request has been created for your facility.</p>
                <div style='margin: 20px 0; padding: 15px; border: 1px solid #ddd; border-radius: 5px;'>
                    <p><strong>Request ID:</strong> {request.RequestId}</p>
                    <p><strong>Facility:</strong> {facility.FacilityName}</p>
                    <p><strong>Item Requested:</strong> {itemName}</p>
                    <p><strong>Quantity:</strong> {request.QuantityRequested}</p>
                    <p><strong>Requestor:</strong> {requestorName}</p>
                    <p><strong>Priority:</strong> {request.SeverityLevel}</p>
                    <p><strong>Status:</strong> {request.Status}</p>
                    <p><strong>Request Date:</strong> {request.RequestDate}</p>
                    <p><strong>Description:</strong> {request.Description}</p>
                </div>
                <p>Please log in to the system to process this request.</p>
            </body>
            </html>";

        // Send email to facility head
        await SendEmailAsync(subject, body, facility.FacilityHead.Email);
    }

    public async Task SendAssignmentNotificationAsync(Request request)
    {
      if (request == null || !request.AssigneeId.HasValue)
      {
          throw new ArgumentException("Invalid request or missing assignee information");
      }

      try
      {
          // Load the assignee information - sử dụng AsNoTracking để tránh tracking entities không cần thiết
          var assignee = await _context.Users
              .AsNoTracking()
              .FirstOrDefaultAsync(u => u.UserId == request.AssigneeId.Value);

          if (assignee == null || string.IsNullOrEmpty(assignee.Email))
          {
              throw new InvalidOperationException("Cannot find assignee's email");
          }

          // Load the facility information
          var facility = await _context.Facilities
              .AsNoTracking()
              .FirstOrDefaultAsync(f => f.FacilityId == request.FacilityId);

          var facilityName = facility != null ? facility.FacilityName : "Unknown Facility";

          // Load the facility item information
          var facilityItem = await _context.FacilityItems
              .AsNoTracking()
              .FirstOrDefaultAsync(f => f.FacilityItemId == request.FacilityItemId);

          var itemName = facilityItem != null ? facilityItem.ItemName : "Unknown Item";

          // Build email content
          string subject = $"Request #{request.RequestId} Assigned to You";
          string body = $@"
              <html>
              <body>
                  <h2>Request Assignment Notification</h2>
                  <p>A request has been assigned to you.</p>
                  <div style='margin: 20px 0; padding: 15px; border: 1px solid #ddd; border-radius: 5px;'>
                      <p><strong>Request ID:</strong> {request.RequestId}</p>
                      <p><strong>Facility:</strong> {facilityName}</p>
                      <p><strong>Item Requested:</strong> {itemName}</p>
                      <p><strong>Quantity:</strong> {request.QuantityRequested}</p>
                      <p><strong>Priority:</strong> {request.SeverityLevel}</p>
                      <p><strong>Status:</strong> {request.Status}</p>
                      <p><strong>Request Date:</strong> {request.RequestDate}</p>
                      <p><strong>Description:</strong> {request.Description}</p>
                  </div>
                  <p>Please log in to the system to manage this request.</p>
              </body>
              </html>";

          // Send email to assignee
          await SendEmailAsync(subject, body, assignee.Email);
      }
      catch (Exception ex)
      {
          Console.WriteLine($"Error in SendAssignmentNotificationAsync: {ex.Message}");
          throw; // Re-throw to make sure the controller knows there was an error
      }
    }
}
