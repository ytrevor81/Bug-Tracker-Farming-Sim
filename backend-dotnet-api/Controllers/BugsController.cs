using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BugsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BugsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bug>>> GetBugs()
    {
        var bugs = await _dbContext.Bugs.ToListAsync();
        return Ok(bugs);
    }

    [HttpPost]
    public async Task<ActionResult<Bug>> CreateBug([FromBody] Bug bug)
    {
        _dbContext.Bugs.Add(bug);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBugs), null, bug);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bug>> GetSingleBug(int id)
    {
        var bug = await _dbContext.Bugs.FindAsync(id);

        if (bug == null)
            return NotFound();

        return Ok(bug);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Bug>> UpdateBug(int id, [FromBody] Bug bug)
    {
        if (id != bug.Id)
            return BadRequest();

        var existingBug = await _dbContext.Bugs.FindAsync(id);
        
        if (existingBug == null)
            return NotFound();
        
        existingBug.DisplayID = bug.DisplayID;
        existingBug.Title = bug.Title;
        existingBug.Description = bug.Description;
        existingBug.Status = bug.Status;
        existingBug.Priority = bug.Priority;

        await _dbContext.SaveChangesAsync();
        return Ok(existingBug);
    }
}