using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController
    {
        [HttpPost(Name = "Setup")]
        public async void SetupOrders()
        {
            SetupSession();
        }

        [HttpGet(Name = "AddOrder")]
        public async void AddOrder(OrderDetails order)
        {
            var orders = GetOrders();
            orders.Add(order);
            Session["OrderDetails"] = orders;
        }

        [HttpGet(Name = "GetOrders")]
        public async IEnumerable<OrderDetails> GetOrderDetails()
        {
            return GetOrders();
        }

        void SetupSession()
        {
            if (!Session["OrderDetails"])
            {
                Session["OrderDetails"] = new List<OrderDetails>();
            }
        }

        IEnumerable<OrderDetails> GetOrders()
        {
            return Session["OrderDetails"] as List<OrderDetails>;
        }
    }
}
