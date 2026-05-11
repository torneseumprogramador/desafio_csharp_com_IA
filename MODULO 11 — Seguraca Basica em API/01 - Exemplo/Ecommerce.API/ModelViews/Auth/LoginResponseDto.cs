namespace primeiraApi.ModelViews;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Bearer";
    public DateTime ExpiraEm { get; set; }
}
