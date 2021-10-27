using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using assignments_api.Models;
using assignments_api.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignments_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController:ControllerBase
    {   
        private readonly AssignmentDbContext context;
        public ToDoController(AssignmentDbContext context){
            this.context=context;
        }
        // private readonly IJwtAuthorization _jwtAuthorization;
        // private readonly IMapper _mapper;
        // public JwtController(IJwtAuthorization jwtAuthorization,IMapper mapper)
        // {
        //     _jwtAuthorization = jwtAuthorization;
        //     _mapper = mapper;
        // }  
        [HttpGet("/api/todos")]   
        public async Task<IEnumerable<Assignment>> Get()
        {        
           return await this.context.Assignments.ToListAsync<Assignment>();
        }
        [HttpGet("/api/todo/{id}")]
        public async Task<Assignment> Get(int id)
        {
            return await this.context.Assignments.FirstOrDefaultAsync(p=>p.Id==id);
        }
        [HttpPost("/api/todo/{id}")]
        public void POST (int id,[FromBody]string value)
        {
            //DateTime.ParseExact(query.From, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
        }
        [HttpPut("/api/todo/{id}")]
        public async Task<Assignment> Put (int id)
        {
           return await this.context.Assignments.FirstOrDefaultAsync(p=>p.Id==id);
            // _context.Entry(student).State = EntityState.Modified;
             //NoContent();

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