using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoEstudoBancoDeDados.Startup))]
namespace ProjetoEstudoBancoDeDados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
