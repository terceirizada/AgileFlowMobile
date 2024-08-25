using AgileFlowMobile.front.Pages;

namespace AgileFlowMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Btn_Login(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }

        //Comportamento de Focar e Desfocar das Entries - ReturnType - Done
        private void _entryNome_Focused(object sender, FocusEventArgs e)
        {
            _entryNome.Completed += (s, e) =>
            {
                _entrySenha.Focus();
            };
        }
        private void _entrySenha_Focused(object sender, FocusEventArgs e)
        {
            _entrySenha.Completed += (s, e) =>
            {
                _entrySenha.IsEnabled = false;
                _entrySenha.Unfocus();
                _entrySenha.IsEnabled = true;
            };
        }

        private async void Btn_Cadastro(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(PageCadastro)}");
        }
    }

}
