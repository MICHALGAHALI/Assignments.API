using System.ComponentModel.DataAnnotations;

namespace assignments_api.Models
{
    public class Type
    {
      public int Id { get; set; } 
      [Required]
      [StringLength(255)]
      public string Title { get; set; }
    }
}