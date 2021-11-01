using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using assignments_api.EF.Persistence;
using assignments_api.EF.Models;
using assignments_api.Models;
using System.Text.Json;

namespace assignments_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly AssignmentDbContext context;
        public ToDoController(AssignmentDbContext context)
        {
            this.context = context;
        }
        // private readonly IJwtAuthorization _jwtAuthorization;
        // private readonly IMapper _mapper;
        // public JwtController(IJwtAuthorization jwtAuthorization,IMapper mapper)
        // {
        //     _jwtAuthorization = jwtAuthorization;
        //     _mapper = mapper;
        // }  
        [HttpGet("/api/todos")]
        public async Task<IEnumerable<AssignmentModel>> Get()
        {
            IEnumerable<AssignmentModel> s = await this.context.Assignments.Join
            (this.context.Types, t => t.IdType,
                assign => assign.Id, (assign, t) => new AssignmentModel
                {
                    Id = assign.IdAssignment,
                    Title = assign.Title,
                    Completed = assign.Completed,
                    Type = t,
                    Description = assign.Description,//תיאור משימה
                    RangeDates=new RangeDates{StartDate=assign.StartDate,FinishDate=assign.FinishDate},
                    IsRepeated = assign.IsRepeated//חוזרת /חד -פעמי תדירות
              }).OrderByDescending(p => p.RangeDates.StartDate).ToListAsync<AssignmentModel>();
            return s;
        }
        [HttpGet("/api/todo/{id}")]
        public async Task<ActionResult<AssignmentModel>> Get(int id)
        {
            var assignment = await this.context.Assignments.FirstOrDefaultAsync<Assignment>(p => p.IdAssignment == id);
            var types = await this.context.Types.ToListAsync<TypeTask>();
            AssignmentModel model = new AssignmentModel(assignment, types);
            if (model == null)
                return NotFound();
            return model;
        }
        [HttpPost("/api/todo/")]
        public async Task<ActionResult<AssignmentModel>> POST([FromBody] AssignmentModel model)
        {
           try{
            var types = await this.context.Types.ToListAsync<TypeTask>();
            Assignment assignment = new Assignment(model, types);
            context.Assignments.Add(assignment);
            await context.SaveChangesAsync();
            return Ok();
            //CreatedAtAction("Get", new { id = assignment.IdAssignment }, assignment);
             }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }
        }

        [HttpPut("/api/todo/{id}")]
        public async Task<ActionResult<Assignment>> Put(int id, [FromBody] AssignmentModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest();
                }
                var types = await this.context.Types.ToListAsync<TypeTask>();
                Assignment assignment = new Assignment(model, types);
                int a=model.Id==null?0:(int)model.Id;
                assignment.IdAssignment=a;
                context.Assignments.Update(assignment);
                context.Entry<Assignment>(assignment).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }
            return Ok();
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