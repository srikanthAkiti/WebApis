using MongoDB.Driver;
using StudentManagement.Models;
using System.Collections.Generic;

public class StudentAddressService : IStudentAddressService
{
    private readonly IMongoCollection<StudentAddress> _studentAddresses;

    public StudentAddressService(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _studentAddresses = database.GetCollection<StudentAddress>(settings.StudentAddressesCollectionName);
    }

    public List<StudentAddress> Get()
    {
        List < StudentAddress > studList = _studentAddresses.Find(address => true).ToList();
        return studList;
    }

    public StudentAddress GetByStudentId(string studentId)
    {
        return _studentAddresses.Find(address => address.StudentId == studentId).FirstOrDefault();
    }

    public StudentAddress Create(StudentAddress studentAddress)
    {
        _studentAddresses.InsertOne(studentAddress);
        return studentAddress;
    }

    public void Update(string studentId, StudentAddress studentAddress)
    {
        _studentAddresses.ReplaceOne(address => address.StudentId == studentId, studentAddress);
    }

    public void Remove(string studentId)
    {
        _studentAddresses.DeleteOne(address => address.StudentId == studentId);
    }
}
