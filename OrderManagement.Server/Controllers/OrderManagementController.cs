using System;
using System.Collections;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;

        OrderManagementController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Setup")]
        public async Task<IActionResult> SetupOrders()
        {
            SetupSession();
            return Ok(new { Message = "Session setup complete" });
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrderToSession(OrderDetails order)
        {
            var orders = GetOrdersFromSession() as List<OrderDetails>;

            if(orders != null)
            {
                orders.Add(order);
                SaveOrdersToSession(orders);
            }

            return Ok(new { Message = "Order added successfully" });
        }

        [HttpGet("GetOrders")]
        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return GetOrdersFromSession();
        }

        void SetupSession()
        {
            if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("OrderDetails")))
            {
                SaveOrdersToSession(new List<OrderDetails>());
            }
        }

        IEnumerable<OrderDetails> GetOrdersFromSession()
        {
            var sessionData = _httpContextAccessor.HttpContext.Session.GetString("OrderDetails");
            return sessionData != null ? JsonSerializer.Deserialize<List<OrderDetails>>(sessionData) : new List<OrderDetails>();
        }

        private void SaveOrdersToSession(List<OrderDetails> orders)
        {
            var json = JsonSerializer.Serialize(orders);
            _httpContextAccessor.HttpContext.Session.SetString("OrderDetails", json);
        }
    }      
}

