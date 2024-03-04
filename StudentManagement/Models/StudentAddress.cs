using MongoDB.Bson.Serialization.Attributes;

public class StudentAddress
{
    //[BsonId]
    //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    //public required string Id { get; set; }

    //public required Object _id { get; set; }
    public required string StudentId { get; set; }
    public required string Address { get; set; }
}
