using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.DTOs
{
    /// <summary>
    /// Why record ? 
    /// because i'm looking for sth which is immutable snapshots 
    /// which is used for API requests and responses, messaging and inter-service contracts.
    /// They shouldn't change state after creation, and they should be compared based on their values rather than their references.
    /// </summary>
    public record ProductDto(
        string Id, 
        string Name, 
        string Summary,
        string Description,
        string ImageFile, 
        BrandDto Brand, 
        TypeDto Type, 
        decimal Price, 
        DateTimeOffset CreatedDate); 

    public record BrandDto(string Id, string Name);
    public record TypeDto(string Id, string Name);

    /// <summary>
    /// Using init means that the properties can only be set during object initialization, making the object immutable after creation.
    /// as for record class instead of record struct, it is because record class is a reference type, 
    /// which is more suitable for DTOs that may contain complex data and relationships.
    /// </summary>
    public record class CreateProductDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Summary { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public string ImageFile { get; init; }
        [Required]
        public string BrandId { get; init; }
        [Required]
        public string TypeId { get; init; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; init; }
    }

    public record class UpdateProductDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Summary { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public string ImageFile { get; init; }
        [Required]
        public string BrandId { get; init; }
        [Required]
        public string TypeId { get; init; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; init; }
    }

}
