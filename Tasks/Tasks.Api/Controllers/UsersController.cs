using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Data;
using Tasks.Api.Models;
using Tasks.Api.SyncDataServices.Http;

namespace Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<UsersController> _logger;
    private readonly TasksDbContext _dbContext;

    private readonly ICommandDataClient _commandDataClient;

    public UsersController(ILogger<UsersController> logger, TasksDbContext dbContext, ICommandDataClient commandDataClient)
    {
        _logger = logger;
        _dbContext = dbContext;
        _commandDataClient = commandDataClient;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOne(int id)
    {
        return Ok(await _dbContext.Users.Include(a => a.Assignment).SingleOrDefaultAsync(a => a.Id == id));
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _dbContext.Users.Include(a => a.Assignment).ToListAsync());
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult> Create(User request)
    {

        try
        {
            await _commandDataClient.SendPlatformToCommand(request);

            var result = _dbContext.Users.Add(request).Entity;
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result.Id);
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
