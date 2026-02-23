namespace TheusDog.Api.Controllers;

using TheusDog.Application.DTOs.Dog;

[ApiController]
[Route("api/[controller]")]
public class DogController : ControllerBase
{
    private readonly IDogService _dogService;

    public DogController(IDogService dogService)
    {
        _dogService = dogService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dog = await _dogService.GetByIdAsync(id);
        if (dog is null) return NotFound();

        return Ok(dog);
    }

    [HttpGet("tutor/{tutorId:guid}")]
    public async Task<IActionResult> GetByTutor(Guid tutorId)
    {
        var dogs = await _dogService.GetByTutorIdAsync(tutorId);
        return Ok(dogs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDogDto dto)
    {
        var dog = await _dogService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dog.Id }, dog);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDogDto dto)
    {
        var dog = await _dogService.UpdateAsync(id, dto);
        return Ok(dog);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _dogService.DeleteAsync(id);
        return NoContent();
    }
}