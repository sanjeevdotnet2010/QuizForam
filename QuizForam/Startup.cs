using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizForam.Startup))]
namespace QuizForam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
