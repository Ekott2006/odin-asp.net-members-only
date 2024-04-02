using Microsoft.AspNetCore.Identity;

namespace WebApp.Model;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}