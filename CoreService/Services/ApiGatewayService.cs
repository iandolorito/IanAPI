using CoreService.Models;

namespace CoreService.Services
{
    public class ApiGatewayService : IApiGatewayService
    {
        private readonly HttpClient _httpClient;

        public ApiGatewayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiGatewayResponse> ForwardRequestAsync(string serviceUrl)
        {
            var response = await _httpClient.GetAsync(serviceUrl);

            if (!response.IsSuccessStatusCode)
            {
                return new ApiGatewayResponse
                {
                    Success = false,
                    Message = "Error fetching data",
                    Data = null
                };
            }

            var data = await response.Content.ReadAsStringAsync();
            return new ApiGatewayResponse
            {
                Success = true,
                Message = "Request successful",
                Data = data
            };
        }
    }

}
