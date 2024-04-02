using System.ComponentModel.DataAnnotations;

namespace WebApp.Model.AccountDto;

public class LoginRequest: BaseAccountRequest
{
    [Display(Name = "Remember me?")] public bool RememberMe { get; set; }
}
