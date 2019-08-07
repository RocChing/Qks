using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Qks.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace Qks.Web.Host.Controllers
{
    public class HomeController : QksControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IApplicationLifetime _app;

        public HomeController(INotificationPublisher notificationPublisher, IApplicationLifetime applicationLifetime)
        {
            _notificationPublisher = notificationPublisher;
            _app = applicationLifetime;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        public IActionResult Stop()
        {
            _app.StopApplication();
            return new EmptyResult();
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }
    }
}
