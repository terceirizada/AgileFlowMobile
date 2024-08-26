using AgileFlowMobile.backend.Services;
namespace AgileFlowMobile.front.Pages;

public partial class PageCadastro : ContentPage
{
    public PageCadastro()
    {
        InitializeComponent();
    }

    private async void Btn_Cadastro(object sender, EventArgs e)
    {
        string email    = _entryNome.Text?.Trim();
        string password = _entrySenha.Text?.Trim();
        string confirmPassword = _entryRepetirSenha.Text?.Trim();

        // Verificação dos campos vazios
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            await DisplayAlert("Aviso", "Todos os campos são necessários", "Retornar");
            return;
        }

        if (!password.Equals(confirmPassword))
        {
            await DisplayAlert("Aviso", "As senhas não coincidem", "Retornar");
            return;
        }

        if (password.Length < 8)
        {
            await DisplayAlert("Aviso", "A senha deve ter pelo menos 8 caracteres", "Retornar");
            return;
        }

        // Instanciação do AuthService
        var  authService = new AuthService();
        bool emailExists = await authService.CheckIfEmailExistsAsync(email);

        if (emailExists)
        {
            await DisplayAlert("Aviso", "Este e-mail já está cadastrado", "Retornar");
            return;
        }

        // Se todas as verificações passarem, registre o novo usuário
        bool isRegistered = await authService.RegisterUserAsync(email, password);

        if (isRegistered)
        {
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");
            // Navegue para a página de login ou outra página desejada
            await Shell.Current.GoToAsync(".."); // Volta para a página anterior (Login)
        }
        else
        {
            await DisplayAlert("Erro", "Ocorreu um erro ao tentar cadastrar. Tente novamente.", "Retornar");
        }
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
            _entryRepetirSenha.Focus();
        };
    }

    private void _entryConfirmSenha_Focused(object sender, FocusEventArgs e)
    {
        _entryRepetirSenha.IsEnabled = false;
        _entryRepetirSenha.Unfocus();
        _entryRepetirSenha.IsEnabled = true;
    }
}
