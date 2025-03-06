namespace CoreService.Models
{
    public class ApiGatewayResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
