using System;

using reymani_web_api.Data.Models;

namespace ReymaniWebApi.Data.Models
{
  public class Vehicle : BaseEntity
  {
    public int Id { get; set; }
    public required int UserId { get; set; } // Courier
    public User? User { get; set; }
    public required string Name { get; set; }
    public required string? Description { get; set; }
    public required bool IsAvailable { get; set; }
    public required bool IsActive { get; set; }
    public required string? Picture { get; set; }
    public required int VehicleTypeId { get; set; }
    public VehicleType? VehicleType { get; set; }
  }
}