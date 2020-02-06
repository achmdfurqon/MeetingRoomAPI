using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingRoomClient.Startup))]
namespace MeetingRoomClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
