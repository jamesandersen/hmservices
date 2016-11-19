using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HMServices.Models {
        [BsonIgnoreExtraElements]
        public class Symbol {
        public ObjectId Id { get; set; }

        [BsonElement("Symbol")]
        [JsonProperty("Symbol")]
        public string Ticker { get; set; }
        public string Name { get; set; }

        public string Sector { get; set; }
        public string Industry {get; set; }

        public decimal MarketCap { get; set; }

        public string exchange { get; set; }
    }


}