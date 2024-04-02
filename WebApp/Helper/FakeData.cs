using Bogus;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Post;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Helper;

public static class FakeData
{
    public static async Task FillDb(PostRepository postRepository, UserManager<IdentityUser> userManager)
    {
        Random random = new();
        List<IdentityUser> users = new UserFaker().Generate(5);
        foreach (IdentityUser user in users)
        {
            await userManager.CreateAsync(user, new Faker().Internet.Password());
            List<CreatePostRequest> posts = new PostFaker().Generate(random.Next(5, 30));
            foreach (CreatePostRequest post in posts)
            {
                await postRepository.Create(user.Id, post);
            }
        }
    }


    private sealed class UserFaker : Faker<IdentityUser>
    {
        public UserFaker()
        {
            RuleFor(e => e.Email, f => f.Internet.Email());
            RuleFor(e => e.UserName, f => f.Internet.UserName());
        }
    }

    private sealed class PostFaker : Faker<CreatePostRequest>
    {
        public PostFaker()
        {
            RuleFor(e => e.Body, f => f.Lorem.Paragraphs(3, "\n"));
            RuleFor(e => e.Title, f => f.Lorem.Sentence());
            RuleFor(e => e.Id, _ => Guid.NewGuid());
        }
    }
}