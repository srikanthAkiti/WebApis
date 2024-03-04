using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public interface IStudentService
{
    // CRUD operations
    List<Student> Get();
    Student Get(string id);
    Student Create(Student student);
    void Update(string id, Student student);
    void Remove(string id);

    // Additional methods for action results
    ActionResult<List<Student>> GetAll();
    ActionResult<Student> GetById(string id);
}



