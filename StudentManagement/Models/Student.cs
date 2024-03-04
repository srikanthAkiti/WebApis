using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


[BsonIgnoreExtraElements]

public class Student
{
    
   // [BsonElement("studentid")]
    public required string StudentId { get; set; }
    //[BsonElement("name")]
    public string Name { get; set; } = String.Empty;
   // [BsonElement("teacherid")]
    public int TeacherId { get; set; }
}

