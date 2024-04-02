using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Dto.Post;
using WebApp.Model;

namespace WebApp.Repository;

public class PostRepository(DataContext context)
{
    public async Task<List<Post>> Get() => await context.Posts.Include(x => x.User).OrderByDescending(x => x.CreatedAt).ToListAsync();

    public async Task Create(string userId, CreatePostRequest request)
    {
        Post post = new() { Id = request.Id, Body = request.Body, Title = request.Title, UserId = userId };
        await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
    }
}