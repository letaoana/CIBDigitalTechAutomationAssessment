using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dog.API.Models
{
    public class Breed
    {
        [JsonProperty("message")]
        public IDictionary<string, List<string>> Message { get; set; }
    }
}
