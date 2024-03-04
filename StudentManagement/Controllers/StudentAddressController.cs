using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class StudentAddressController : ControllerBase
{
    private readonly IStudentAddressService _studentAddressService;

    public StudentAddressController(IStudentAddressService studentAddressService)
    {
        _studentAddressService = studentAddressService;
    }

    [HttpGet]
    public ActionResult<List<StudentAddress>> Get()
    {
        List < StudentAddress > studList =_studentAddressService.Get();

        return studList;
    }

    [HttpGet("{studentId}")]
    public ActionResult<StudentAddress> Get(string studentId)
    {
        var address = _studentAddressService.GetByStudentId(studentId);

        if (address == null)
        {
            return NotFound($"Address for student with ID = {studentId} not found");
        }

        return address;
    }

    [HttpPost]
    public ActionResult<StudentAddress> Post([FromBody] StudentAddress studentAddress)
    {
        if (studentAddress == null || string.IsNullOrEmpty(studentAddress.StudentId) || string.IsNullOrEmpty(studentAddress.Address))
        {
            return BadRequest("StudentId and Address must be provided.");
        }

        _studentAddressService.Create(studentAddress);

        return CreatedAtAction(nameof(Get), new { studentId = studentAddress.StudentId }, studentAddress);
    }

    [HttpPut("{studentId}")]
    public ActionResult Put(string studentId, [FromBody] StudentAddress studentAddress)
    {
        var existingAddress = _studentAddressService.GetByStudentId(studentId);

        if (existingAddress == null)
        {
            return NotFound($"Address for student with ID = {studentId} not found");
        }

        // Update the address with the provided StudentId
        studentAddress.StudentId = studentId;
        _studentAddressService.Update(studentId, studentAddress);

        return NoContent();
    }

    [HttpDelete("{studentId}")]
    public ActionResult Delete(string studentId)
    {
        var address = _studentAddressService.GetByStudentId(studentId);

        if (address == null)
        {
            return NotFound($"Address for student with ID = {studentId} not found");
        }

        _studentAddressService.Remove(studentId);

        return Ok($"Address for student with ID = {studentId} deleted");
    }
}
