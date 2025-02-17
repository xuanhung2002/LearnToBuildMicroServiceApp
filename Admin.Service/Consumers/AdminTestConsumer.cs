using Core.BaseService.MQ;
using Core.Domain.Contract.Admin;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Service.Consumers
{
    public class AdminTestConsumer : MQBaseConsumer<AdminTestContract>
    {
        //public AdminTestConsumer(string queue) : base(queue)
        //{
        //}
        public AdminTestConsumer(IOptions<ConsumerOptions> options)
            : base(options.Value.AdminQueue)
        {
        }

        protected override Task HandleMessage(AdminTestContract message)
        {
            Console.WriteLine($"Handle AdminTestConsumer: => text {message.Text}");
            return Task.CompletedTask;
        }
    }    
    public class ConsumerOptions
    {
        public string AdminQueue { get; set; } = "Admin";
    }
}
