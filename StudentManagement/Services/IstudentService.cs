using System;
namespace StudentManagement.Services
{
	public interface IstudentService
    {
		
    List<Student> Get();
        Student Get(string id);
        Student Create(Student student);
        void Update(string id, Student student);
        void Remove(string id);
    }
}


