using MongoDB.Bson;

namespace Sheard.MongoModel
{
    public class BaseMongoEntity
    {
        public string Id => ObjectId.GenerateNewId().ToString();
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string RoleName { get; set; }
        public DateTime InsertDate => DateTime.UtcNow;
    }
}
