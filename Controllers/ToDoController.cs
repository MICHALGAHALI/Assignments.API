using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using assignments_api.Models;
using assignments_api.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        public async Task<IEnumerable<object>> Get()
        {        
          var s= await this.context.Assignments.Join(this.context.Types,t => t.IdType, 
              assign => assign.Id, (assign, t) => new 
              {                 
                    id=assign.IdAssignment,
                    title=assign.Title,
                    completed=assign.Completed ,
                    type=t.Title,
                    description=assign.Description,//תיאור משימה
                    startDate=assign.StartDate,
                    finishDate=assign.FinishDate,//תאריך סיום
                    isRepeated=assign.IsRepeated//חוזרת /חד -פעמי תדירות
              }).OrderBy(p=>p.id).ToListAsync();
              return s;
        }
        [HttpGet("/api/todo/{id}")]
        public async Task<ActionResult<Assignment>> Get(int id)
        {
            var assignment=await this.context.Assignments.FirstOrDefaultAsync<Assignment>(p=>p.IdAssignment==id);
             if (assignment == null)
             {
               //_logger.LogError("Owner object sent from client is null.");
                return NotFound();
             }
             return assignment;             
        }
        [HttpPost("/api/todo/{id}")]
        public async Task<ActionResult<Assignment>> POST (int id,[FromBody]Assignment assignment)
        {
             context.Assignments.Add(assignment);
             await context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = assignment.IdAssignment }, assignment);
            //DateTime.ParseExact(query.From, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
        }
        [HttpPut("/api/todo/{id}")]
        public async Task<ActionResult<Assignment>> Put (int id,[FromBody] Assignment assignment)
        {
            if (id != assignment.IdAssignment)
            {
                return BadRequest();
            }
            context.Entry<Assignment>(assignment).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // if (!StudentExists(id))
                // {
                //     return NotFound();
                // }
                // else
                // {
                    throw e;
                //}
            } 
             return NoContent();           
        }
        [HttpDelete("/api/todo/{id}")]
        public async Task<ActionResult<Assignment>> Delete(int id)
        {
            var assignment = await context.Assignments.FindAsync(id);
                if (assignment == null)
                {
                    return NotFound();
                }
                context.Assignments.Remove(assignment);
                await context.SaveChangesAsync();
                return assignment;
        }
    }

}