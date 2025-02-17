using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Controllers.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/TaskClasses")]
    [ApiController]
    public class TaskClassesController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskClassesController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/TaskClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskClass>>> GetTaskItems()
        {
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/TaskClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskClass>> GetTaskClass(long id)
        {
            var taskClass = await _context.TaskItems.FindAsync(id);

            if (taskClass == null)
            {
                return NotFound();
            }

            return taskClass;
        }

        // PUT: api/TaskClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskClass(long id, TaskClass taskClass)
        {
            if (id != taskClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskClass>> PostTaskClass(TaskClass taskClass)
        {
            _context.TaskItems.Add(taskClass);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTaskClass", new { id = taskClass.Id }, taskClass);
            return CreatedAtAction(nameof(GetTaskClass), new { id = taskClass.Id }, taskClass);
        }

        // DELETE: api/TaskClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskClass(long id)
        {
            var taskClass = await _context.TaskItems.FindAsync(id);
            if (taskClass == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskClassExists(long id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }
    }
}
