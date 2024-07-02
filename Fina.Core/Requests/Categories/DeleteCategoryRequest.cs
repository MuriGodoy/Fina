using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories;

public class DeleteCategoryRequest : Request
{
    [Required]
    public long Id { get; set; }
}
