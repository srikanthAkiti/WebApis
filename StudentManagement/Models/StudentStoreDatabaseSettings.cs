using System;

namespace StudentManagement.Models
{
    public class StudentStoreDatabaseSettings : IStudentStoreDatabaseSettings
    {
        public required string StudentCoursesCollectionName { get; set; }
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
        public required string StudentAddressesCollectionName { get; set; }
    }
}
