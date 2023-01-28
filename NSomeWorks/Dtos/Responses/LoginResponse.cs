using Newtonsoft.Json;

namespace NSomeWorks.Dtos.Responses;
public class LoginResponse : ErrorTextDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; } = null;
}
