using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FunctionApp1
{
    public static class SendEmailViaHttpTrigger
    {
        [FunctionName("SendEmailViaHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var apiKeyFromEnv = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var apiKey_DIRECT = "ACTUAL_API_KEY_FOR_LOCAL_TESTING_ONLY";

            var client = new SendGridClient(apiKey_DIRECT);
            var from = new EmailAddress("sender@somefakedomain.com", "Email Sender");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("receiver@somefakedomain.com", "Email Receiver");
            var plainTextContent = "my plain text content";
            var htmlContent = "<strong>my bolded html content</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return (ActionResult)new OkObjectResult("Done");
        }
    }
}
