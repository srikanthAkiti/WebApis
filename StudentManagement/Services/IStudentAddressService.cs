using System.Collections.Generic;

public interface IStudentAddressService
{
    List<StudentAddress> Get();
    StudentAddress GetByStudentId(string studentId);
    StudentAddress Create(StudentAddress studentAddress);
    void Update(string studentId, StudentAddress studentAddress);
    void Remove(string studentId);
}
