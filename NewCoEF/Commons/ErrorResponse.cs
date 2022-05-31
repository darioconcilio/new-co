using Newtonsoft.Json;

namespace NewCoEF.Commons
{
    [JsonObject]
    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }

        public ErrorResponse(int pStatusCode, string pMessage)
        {
            StatusCode = pStatusCode;
            Message = pMessage;
        }

        [JsonProperty]
        public int StatusCode { get; set; } = 0;

        [JsonProperty]
        public string Message { get; set; } = string.Empty;
    }
}
