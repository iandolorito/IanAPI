using CoreService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreService.Controllers
{
    [Route("api/gateway")]
    [ApiController]
    public class ApiGatewayController : ControllerBase
    {
        private readonly IApiGatewayService _apiGatewayService;

        public ApiGatewayController(IApiGatewayService apiGatewayService)
        {
            _apiGatewayService = apiGatewayService;
        }

        [HttpGet("identity/users/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var response = await _apiGatewayService.ForwardRequestAsync($"http://identityservice:5001/api/users/{id}");
            return Ok(response);
        }

        [HttpGet("catalog/products")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _apiGatewayService.ForwardRequestAsync("http://catalogservice:5002/api/products");
            return Ok(response);
        }
        [HttpGet("productinfo/details/{id}")]
        public async Task<IActionResult> GetProductInfo(Guid id)
        {
            var response = await _apiGatewayService.ForwardRequestAsync($"http://localhost:5003/api/productinfo/details/{id}");
            return Ok(response);
        }
        [HttpGet("basket/{userId}")]
        public async Task<IActionResult> GetBasket(Guid userId)
        {
            var response = await _apiGatewayService.ForwardRequestAsync($"http://basketservice:5004/api/basket/{userId}");
            return Ok(response);
        }


        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _apiGatewayService.ForwardRequestAsync("http://orderingservice:5005/api/orders");
            return Ok(response);
        }

        

        [HttpGet("payment/{orderId}")]
        public async Task<IActionResult> GetPayment(Guid orderId)
        {
            var response = await _apiGatewayService.ForwardRequestAsync($"http://paymentservice:5006/api/payment/{orderId}");
            return Ok(response);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var response = await _apiGatewayService.ForwardRequestAsync($"http://customerservice:5007/api/customers/{id}");
            return Ok(response);
        }

        [HttpGet("admin/users")]
        public async Task<IActionResult> GetAdminUsers()
        {
            var response = await _apiGatewayService.ForwardRequestAsync("http://adminservice:5008/api/admin/users");
            return Ok(response);
        }
    }
}
