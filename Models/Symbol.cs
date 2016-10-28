using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HMServices.Models {
        [BsonIgnoreExtraElements]
        public class Symbol {
        public ObjectId Id { get; set; }

        [BsonElement("Symbol")]
        public string Ticker { get; set; }
        public string Name { get; set; }
    }


}