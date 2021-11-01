using System;
using System.Collections.Generic;
using assignments_api.EF.Models;
using System.Linq;

namespace assignments_api.Models
{
    public class AssignmentModel
    {
      public int? Id { get; set; }  
      public string Title { get; set; }
      public bool? Completed { get; set; }  
      public string Description { get; set; }
      public RangeDates RangeDates  { get; set; }
      public bool IsRepeated { get; set; }
      public TypeTask Type { get; set; }
      public AssignmentModel()
      {
         RangeDates=new RangeDates(); 
      }
      public AssignmentModel(Assignment assign,List<TypeTask> typeTasks)
      {
           Id=assign.IdAssignment;
           Title=assign.Title;
           Completed=assign.Completed;
           Type= typeTasks.FirstOrDefault(t=>t.Id.Equals(assign.IdType));       
           Description=assign.Description;
           RangeDates.StartDate=assign.StartDate;
           RangeDates.FinishDate=assign.FinishDate;
           IsRepeated=assign.IsRepeated;
      }
    }
}