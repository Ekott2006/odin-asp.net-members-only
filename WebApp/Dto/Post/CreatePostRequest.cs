using System.ComponentModel.DataAnnotations;

namespace WebApp.Dto.Post;

public class CreatePostRequest
{
    public Guid Id { get; set; }
    [Required, StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }
    [Required, MinLength(5)]
    public string Body { get; set; }
}