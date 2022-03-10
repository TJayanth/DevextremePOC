using Newtonsoft.Json;
using System;

namespace POC.DTO
{
    public class EmployeeDTO
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("fathersName")]
        public string FathersName { get; set; }
        [JsonProperty("mothersName")]
        public string MothersName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
