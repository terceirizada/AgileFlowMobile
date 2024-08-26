using AgileFlowMobile.front.Pages;
using AgileFlowMobile.backend.Services;

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
            string email    = _entryNome.Text?.Trim();
            string password = _entrySenha.Text?.Trim();

            // Verificação dos campos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Aviso", "Email e Senha são necessários", "Retornar");
                return;
            }

            // Instanciação direta do AuthService
            var authService = new AuthService();
            bool isAuthenticated = await authService.AuthenticateAsync(email, password);

            if (!isAuthenticated)
            {
                await DisplayAlert("Aviso", "E-mail ou senha incorretos.", "Retornar");
                return;
            }

            await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
            // await Shell.Current.GoToAsync("paginaProtegida");
        }

        // Comportamento de Focar e Desfocar das Entries
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
            // Navegar para a página de cadastro
            await Shell.Current.GoToAsync($"{nameof(PageCadastro)}");
        }


    }
}


