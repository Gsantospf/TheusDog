namespace TheusDog.Api.Controllers;

using TheusDog.Application.DTOs.Tutor;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ITutorService _tutorService;

    public TutorController(ITutorService tutorService)
    {
        _tutorService = tutorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tutors = await _tutorService.GetAllAsync();
        return Ok(tutors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tutor = await _tutorService.GetByIdAsync(id);
        if (tutor is null) return NotFound();

        return Ok(tutor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTutorDto dto)
    {
        var tutor = await _tutorService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = tutor.Id }, tutor);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTutorDto dto)
    {
        var tutor = await _tutorService.UpdateAsync(id, dto);
        return Ok(tutor);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tutorService.DeleteAsync(id);
        return NoContent();
    }
}