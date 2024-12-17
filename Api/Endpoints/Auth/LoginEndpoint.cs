using System;
using YamlDotNet.Core.Tokens;

namespace reymani_web_api.Api.Endpoints.Auth;

public class LoginEndpoint : Endpoint<LoginRequest>
{
  private readonly IAuthService _authService;

  public LoginEndpoint(IAuthService authService)
  {
    _authService = authService;
  }

  public override void Configure()
  {
    Verbs(Http.POST);
    Routes("/auth/login");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Iniciar sesión";
      s.Description = "Inicia sesión en la aplicación";
      s.ExampleRequest = new LoginRequest
      {
        UsernameOrPhone = "johndoe",
        Password = "Jhondoe123"
      };
    });
  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {
    try
    {
      var token = await _authService.LoginAsync(req);
      await SendOkAsync(new { token }, ct);
    }
    catch (UnauthorizedAccessException)
    {
      AddError("Credenciales inválidas");
      ThrowIfAnyErrors();
    }
  }
}
