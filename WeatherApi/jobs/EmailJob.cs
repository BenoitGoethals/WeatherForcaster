using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Quartz;

namespace WeatherApi.jobs
{
    public class EmailJob : IJob
    {
        public  Task Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("benoit.goethals@gmail.com", "benoit.goethals@gmail.com"))
            {
                message.Subject = "Test";
                message.Body = "Test at " + DateTime.Now;
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.gmail.be",
                    Port = 587,
                    Credentials = new NetworkCredential("benoit.goethals@gmail.com", "paracommando14")
                })
                {
              //  client.Send(message);
                    Console.WriteLine("message");
                }
            }
            return null;

        }
    }
}