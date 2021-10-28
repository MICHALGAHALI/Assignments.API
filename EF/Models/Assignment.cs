using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignments_api.EF.Models
{
  [Table("Assignments")]
    public class Assignment
    {
      /// <summary>
      /// מזהה רשימה
      /// </summary>
      /// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  [Key]
      [Key]
      public int IdAssignment { get; set; }  
      /// <summary>
      /// שם משימה
      /// </summary>
      [Required(ErrorMessage = "שם משימה שדה חובה")]
      [StringLength(255)]
      public string Title { get; set; }
      /// <summary>
      /// האם משימה הסתיימה
      /// </summary>
      /// <value></value>
      public bool Completed { get; set; }
      
      /// <summary>
      /// תיאור משימה
      /// </summary>
      [Required]
      [StringLength(255)]
      
      //[Column(TypeName = "varchar(20)")]
      public string Description { get; set; }
      /// <summary>
      /// תאריך התחלה
      /// </summary>
      public DateTime StartDate { get; set; }
      /// <summary>
      /// תאריך סיום
      /// </summary>
      public DateTime FinishDate { get; set; }
      /// <summary>
      /// האם משימה חוזרת
      /// </summary>
      public bool IsRepeated { get; set; }
      /// <summary>
      /// סוג משימה אישית/ עבודה /לימודים מזהה
      /// </summary>
      [ForeignKey("FK_Show")]
      public int IdType { get; set; }

    }
}