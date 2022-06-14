using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.Models;

namespace Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    private readonly UsersDbContext _dbContext;

    public UsersController(ILogger<UsersController> logger, UsersDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult> GetOne(int id)
    {
        return Ok(await _dbContext.Account.Include(a => a.Profile).SingleOrDefaultAsync(a => a.Id == id));
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _dbContext.Account.Include(a => a.Profile).ToListAsync());
    }

    [HttpPost(Name = "CreateUsers")]
    public async Task<ActionResult> Create(Account account)
    {
        var result = _dbContext.Account.Add(account).Entity;
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result.Id);
    }
}
