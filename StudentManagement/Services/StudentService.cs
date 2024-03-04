using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using StudentManagement.Models;
using System;
using System.Collections.Generic;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;

    public StudentService(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentCoursesCollectionName);
    }

    public List<Student> Get()
    {
        return _students.Find(student => true).ToList();
    }

    public Student Get(string id)
    {
        return _students.Find<Student>(student => student.StudentId == id).FirstOrDefault();
    }

    public Student Create(Student student)
    {
        _students.InsertOne(student);
        return student;
    }

    public void Update(string id, Student student)
    {
        _students.ReplaceOne(s => s.StudentId == id, student);
    }

    public void Remove(string id)
    {
        _students.DeleteOne(student => student.StudentId == id);
    }

    public ActionResult<List<Student>> GetAll()
    {
        var students = _students.Find(student => true).ToList();
        return Ok(students);
    }

    private ActionResult<List<Student>> Ok(List<Student> students)
    {
        throw new NotImplementedException();
    }

    public ActionResult<Student> GetById(string id)
    {
        var student = _students.Find<Student>(s => s.StudentId == id).FirstOrDefault();
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    private ActionResult<Student> Ok(Student student)
    {
        throw new NotImplementedException();
    }

    private ActionResult<Student> NotFound()
    {
        throw new NotImplementedException();
    }
}
