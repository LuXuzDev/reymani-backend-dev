using reymani_web_api.Data.Models;

namespace ReymaniWebApi.Data.Models
{
  public class Product : BaseEntity
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string? Description { get; set; }
    public required int BusinessId { get; set; }
    public Business? Business { get; set; }
    public required bool IsAvailable { get; set; }
    public required bool IsActive { get; set; }
    public required List<string>? Images { get; set; }
    public required decimal Price { get; set; }
    public required decimal? DiscountPrice { get; set; }
    public required int CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
    public required Capacity Capacity { get; set; }
  }
}