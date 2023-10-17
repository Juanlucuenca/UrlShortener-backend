using UrlShorter.Models;

namespace UrlShorter;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<XYZ>? Urls { get; set; }

}
