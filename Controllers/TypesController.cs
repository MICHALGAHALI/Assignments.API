using System.Collections.Generic;
using System.Threading.Tasks;
using assignments_api.EF.Models;
using assignments_api.EF.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignments_api.Controllers
{
    [ApiController]
    public class TypesController: ControllerBase
    {
        private readonly AssignmentDbContext context;
        public TypesController(AssignmentDbContext context)
        {
            this.context = context;
        } 
         [HttpGet("/api/Types")]
        public async Task<IEnumerable<TypeTask>> Get()
        {
           return await this.context.Types.ToListAsync<TypeTask>();
        }
    }
}