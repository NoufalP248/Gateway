using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using EasyNetQ;

namespace Products.BackgroundServices
{
    public class EventHandler : BackgroundService
    {
        private readonly IBus _bus;

        public EventHandler(IBus bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.Rpc.RespondAsync<Request, Response>(ProcessRequest);
        }

        private Response ProcessRequest(Request request)
        {
            return new Response() { ProductName = "rice" };
        }
    }
    public class Request
    {
        public string Name { get; set; }

        public Request(string name)
        {
            Name = name;
        }

    }

    public class Response
    {
        public string ProductName { get; set; }

        public Response()
        {
            
        }
    }
}
