using Newtonsoft.Json;

namespace NSomeWorks.Dtos;
public class ErrorTextDto
{
    [JsonProperty("error")]
    public string ErrorBody { get; set; } = null;
}
