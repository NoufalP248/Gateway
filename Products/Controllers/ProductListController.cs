using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Products.BackgroundServices;
using System.Net.Http;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly IBus _bus;
        public ProductListController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        [Route("api/Products/{name}")]
        public async Task<string> ProductListWithName(string name)
        {
            Request request = new Request(name);
            var response = await _bus.Rpc.RequestAsync<Request, Response>(request);
            return response.ProductName;
            //Provided global exception habdler using middleware
        }

        [HttpGet]
        [Route("api/Products")]
        public async Task<string> GetAllProductDetails()
        {
            //Subscribe message from rabbitmq
            var subscribeMessage = await _bus.PubSub.SubscribeAsync<ProductInfo>(
                                       "my_subscription_id", msg => Console.WriteLine(msg));
            //Subscribe message from rabbitmq

            return subscribeMessage.ToString();
            //Provided global exception habdler using middleware
        }
    }
}
