using AgileFlowMobile.front.Pages;

namespace AgileFlowMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Registro de Rotas
            Routing.RegisterRoute(nameof(PageCadastro), typeof(PageCadastro));
        }
    }
}
