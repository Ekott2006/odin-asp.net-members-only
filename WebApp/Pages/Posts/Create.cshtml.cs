using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Dto.Post;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Posts;

[Authorize]
public class CreateModel(PostRepository repository) : PageModel
{
    [BindProperty]
    public CreatePostRequest CreatePostRequest { get; set; }
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        Claim? claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim is null) return Forbid();
        await repository.Create(claim.Value, CreatePostRequest);
        return RedirectToPage("./Index");
    }}