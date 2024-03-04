using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/<StudentsController>
    [HttpGet]
    public ActionResult<List<Student>> Get()
    {
        return _studentService.Get();
    }

    

    // POST api/<StudentsController>
    [HttpPost]
    public ActionResult<Student> Post([FromBody] Student student)
    {
        _studentService.Create(student);

        return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student);
    }

    // PUT api/<StudentsController>/5
    [HttpPut("{id}")]
    public ActionResult Put(string StudentId, [FromBody] Student student)
    {
        var existingStudent = _studentService.Get(StudentId);

        if (existingStudent == null)
        {
            return NotFound($"Student with Id = {StudentId} not found");
        }

        _studentService.Update(StudentId, student);

        return NoContent();
    }

    // DELETE api/<StudentsController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(string StudentId)
    {
        var student = _studentService.Get(StudentId);

        if (student == null)
        {
            return NotFound($"Student with Id = {StudentId} not found");
        }

        _studentService.Remove(student.StudentId);

        return Ok($"Student with Id = {StudentId} deleted");
    }
}
