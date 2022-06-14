using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Data;
using Tasks.Api.Models;

namespace Tasks.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{

    private readonly ILogger<TasksController> _logger;
    private readonly TasksDbContext _dbContext;

    public TasksController(ILogger<TasksController> logger, TasksDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult> GetOne(int id)
    {
        return Ok(await _dbContext.Assignment.Include(a => a.Owner).SingleOrDefaultAsync(a => a.Id == id));
    }

    [HttpGet(Name = "GetTasks")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _dbContext.Assignment.Include(a => a.Owner).ToListAsync());
    }

    [HttpPost(Name = "CreateTasks")]
    public async Task<ActionResult> Create(Assignment assignment)
    {
        var result = _dbContext.Assignment.Add(assignment).Entity;
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result.Id);
    }
}
