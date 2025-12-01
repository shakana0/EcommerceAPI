using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Domain;

public class Category
{
    public int Id {get; private set;}
    [Required]
    [MaxLength(100)]
    public string Name { get; private set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; private set; } = string.Empty;

    protected Category() { }

    public Category(string name, string description, int? parentCategoryId = null)
    {
        Name = name;
        Description = description;
    }
}