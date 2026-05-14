using Ecommerce.Web.Client.Models;

namespace Ecommerce.Web.Client.Services;

public class AdminAuthState
{
    private readonly AuthApiService _authApi;
    private readonly AdminBffAccessTokenHolder _accessToken;

    public AdminAuthState(AuthApiService authApi, AdminBffAccessTokenHolder accessToken)
    {
        _authApi = authApi;
        _accessToken = accessToken;
    }

    /// <summary>Dispara quando Nome, Email, token ou sessão mudam (para o layout atualizar).</summary>
    public event Action? Changed;

    public string? Nome { get; private set; }
    public string? Email { get; private set; }
    public AdministradorRule? Rule { get; private set; }

    /// <summary>Texto para o header (evita <c>Nome</c> vazio ocultar o e-mail).</summary>
    public string DisplayName =>
        !string.IsNullOrWhiteSpace(Nome) ? Nome.Trim()
        : !string.IsNullOrWhiteSpace(Email) ? Email.Trim()
        : "—";

    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Email);

    public async Task RestoreFromStorageAsync(CancellationToken cancellationToken = default)
    {
        if (IsAuthenticated && !string.IsNullOrWhiteSpace(_accessToken.Token))
        {
            return;
        }

        var alterou = false;
        try
        {
            if (!IsAuthenticated)
            {
                var session = await _authApi.GetSessionAsync(cancellationToken);
                if (session is null || string.IsNullOrWhiteSpace(session.Email))
                {
                    return;
                }

                Nome = session.Nome;
                Email = session.Email;
                Rule = session.Rule;
                alterou = true;
            }

            if (string.IsNullOrWhiteSpace(_accessToken.Token))
            {
                var token = await _authApi.FetchAccessTokenAsync(cancellationToken);
                _accessToken.SetToken(token);
                alterou = alterou || !string.IsNullOrWhiteSpace(token);
            }
        }
        catch
        {
            // Pré-renderização ou rede indisponível.
        }

        if (alterou)
        {
            NotifyChanged();
        }
    }

    public void SetFromLogin(LoginResponse response)
    {
        Nome = response.Nome;
        Email = response.Email;
        Rule = response.Rule;
        _accessToken.SetToken(response.Token);
        NotifyChanged();
    }

    public async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _authApi.LogoutAsync(cancellationToken);
        }
        catch
        {
            // Garante limpeza local mesmo se o BFF falhar.
        }

        _accessToken.Clear();
        Nome = null;
        Email = null;
        Rule = null;
        NotifyChanged();
    }

    private void NotifyChanged() => Changed?.Invoke();
}
