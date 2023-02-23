using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JobPortal.Areas.Identity.IdentityHostingStartup))]
namespace JobPortal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}