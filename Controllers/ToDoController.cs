using System;
using System.Collections.Generic;
using assignments_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignments_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController:ControllerBase
    {   
        // private readonly IJwtAuthorization _jwtAuthorization;
        // private readonly IMapper _mapper;
        // public JwtController(IJwtAuthorization jwtAuthorization,IMapper mapper)
        // {
        //     _jwtAuthorization = jwtAuthorization;
        //     _mapper = mapper;
        // }  
        [HttpGet("/api/todo")]   
        public IEnumerable<Assignment> Get()
        {          
            Assignment assignment=new Assignment(){Completed=false,Description="ffdsaf",FinishDate=DateTime.Now,IsRepeated=false
            ,StartDate=DateTime.Now,Id=1,Title="העברת חפצים",Type=""};
            List<Assignment> assignments= new List<Assignment>();
            assignments.Add(assignment);
            return assignments;
        }
        [HttpGet("/api/todo/{id}")]
        public Assignment Get(int id)
        {
            return new Assignment{Completed=false,Description="ffdsaf",FinishDate=DateTime.Now,IsRepeated=false
            ,StartDate=DateTime.Now,Id=1,Title="העברת חפצים",Type=""};
        }
        [HttpPost("/api/todo/{id}")]
        public void POST (int id,[FromBody]string value)
        {

        }
        [HttpPut("/api/todo/{id}")]
        public void Put (int id,[FromBody]string value)
        {

        }
        [HttpDelete("/api/todo/{id}")]
        public void Delete(int id)
        {

        }
    }

}

// id: number;
//    title: string;//שם משימה
//    completed: boolean
//    type?: string//סוג משימה אישית/ עבודה /לימודים
//    description?: string;//תיאור משימה
//    beginDate?: string;//התחלת משימה
//    endDate?: string;//תאריך סיום
//    isRepeated?: boolean;//חוזרת /חד -פעמי תדירות