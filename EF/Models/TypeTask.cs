using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace assignments_api.EF.Models
{
    public class TypeTask
    {
      [Key]
      public int Id { get; set; } 
      [Required]
      [StringLength(255)]
      public string Title { get; set; }
      public IEnumerable<Assignment> Assignments { get; set; }
    }
}