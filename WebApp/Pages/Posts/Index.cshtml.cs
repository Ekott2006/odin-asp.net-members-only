using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helper;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Posts;

public class IndexModel(PostRepository repository) : PageModel
{
    public IList<Post> PostList { get; set; } = default!;

    public async Task OnGet()
    {
        PostList = await repository.Get();
    }
}