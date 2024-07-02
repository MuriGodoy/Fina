using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories;

public class GetCategoryByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}
