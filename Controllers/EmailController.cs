using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class EmailController : Controller
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendEmail()
    {
        try
        {
            await _emailService.SendEmailAsync("Thông báo", "Đây là huy vip đẹp zai");
            return Json(new { success = true, message = "Email đã được gửi thành công!" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Lỗi: " + ex.Message });
        }
    }
}
