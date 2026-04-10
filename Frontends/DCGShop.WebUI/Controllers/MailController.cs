using DCGShop.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace DCGShop.WebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{ 
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("DCGShop Test", "d.cangokcen@gmail.com");

			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);
			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = mailRequest.MailContent;
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = mailRequest.Subject;
			SmtpClient smtpClient = new SmtpClient();

			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("d.cangokcen@gmail.com", "catelnaufqrvkajh");
			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);
			return View();
		}
	}
}
