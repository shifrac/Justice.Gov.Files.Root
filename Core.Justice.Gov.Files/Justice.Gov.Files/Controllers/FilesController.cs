using Justice.Gov.Files.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Justice.Gov.Files.BL;

namespace Justice.Gov.Files.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public FilesController(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddFile([FromBody] FileModel fileData)
        {
            try
            {
                if (IsLargeFile(fileData.FileSize))
                {
                    SendMail();
                }
                SetFileData(fileData);
                return Ok(fileData);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"AddFile Service Exception: {ex.Message}", DateTime.UtcNow.ToLongTimeString());
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }
        }

        private void SendMail()
        {
            string Server = _configuration.GetValue<string>(Constants.EmailSetting.ServerKeyName);
            int Port = _configuration.GetValue<int>(Constants.EmailSetting.PortKeyName);
            string Subject = _configuration.GetValue<string>(Constants.EmailSetting.SubjectKeyName);
            string Body = _configuration.GetValue<string>(Constants.EmailSetting.BodyKeyName);
            string Sender = _configuration.GetValue<string>(Constants.EmailSetting.SenderKeyName);
            string Password = _configuration.GetValue<string>(Constants.EmailSetting.PasswordKeyName);

            var smtpClient = new SmtpClient(Server)
            {
                Port = Port,
                Credentials = new NetworkCredential(Sender, Password),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(Sender, Sender, Subject, Body);
        }

        private void SetFileData(FileModel fileData)
        {
            string JsonFilePat = _configuration.GetValue<string>(Constants.DBSetting.JsonFilePathKeyName);
            FilesBL.SetFileData(fileData, JsonFilePat);
        }

        private bool IsLargeFile(int fileSize)
        {
            int LimitMegaBytes = 100 * 1024 * 1024;
            if (fileSize > LimitMegaBytes)
            {
                return true;
            }
            return false;
        }

    }
}
