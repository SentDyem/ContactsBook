using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Book.Startup))]
namespace Book
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}