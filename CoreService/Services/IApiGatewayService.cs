using CoreService.Models;

namespace CoreService.Services
{
    public interface IApiGatewayService
    {
        Task<ApiGatewayResponse> ForwardRequestAsync(string serviceUrl);
    }
}
