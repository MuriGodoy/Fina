namespace Fina.Core.Models;

public class Category
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } //Acrescenta o ? para permitir que a descrição seja nula
    public string UserId { get; set; } = string.Empty;
}
