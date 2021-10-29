using System;
using System.Collections.Generic;
using assignments_api.EF.Models;
using System.Linq;

namespace assignments_api.Models
{
    public class Model
    {
      public int Id { get; set; }  
      public string Title { get; set; }
      public bool Completed { get; set; }    
      public string Description { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime FinishDate { get; set; }
      public bool IsRepeated { get; set; }
      public string Type { get; set; }
      public Model()
      {
          
      }
      public Model(Assignment assign,List<TypeTask> typeTasks)
      {
           Id=assign.IdAssignment;
           Title=assign.Title;
           Completed=assign.Completed;
           Type= typeTasks.FirstOrDefault(t=>t.Id.Equals(assign.IdType)).Title;       
           Description=assign.Description;
           StartDate=assign.StartDate;
           FinishDate=assign.FinishDate;
           IsRepeated=assign.IsRepeated;
      }
    }
}