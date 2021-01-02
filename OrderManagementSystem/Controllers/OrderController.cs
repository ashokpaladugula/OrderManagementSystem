using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using OrderManagementSystem.Models;
using System.Collections.Generic;

namespace OrderManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IDbConnection connection;
        private readonly DbProviderFactory _dataProvideFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        public OrderController(IOptions<DatabaseOptions> databaseOptions)
        {
            connection = _dataProvideFactory.CreateConnection();
            connection.ConnectionString = databaseOptions.Value.OrderManagementConnection;

            if (connection.State.Equals(ConnectionState.Closed))
            {
                if (string.IsNullOrEmpty(connection.ConnectionString))
                {
                    connection.ConnectionString = databaseOptions.Value.OrderManagementConnection;
                }
                connection.Open();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orderList = (await connection.QueryAsync<Order>("GetOrders", commandType: CommandType.StoredProcedure)).ToList();
            return Ok(orderList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = (await connection.QueryAsync<Order>("GetOrder", id, commandType: CommandType.StoredProcedure)).ToList();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            List<string> tvpOrderItemsParameters = new List<string>() {
                "Id",
                "Quantity",
                "OrderId",
                "ProductId"
            };

            var orderStatus = await connection.ExecuteAsync("SaveOrder", new
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = "",
                OrderItems = Helpers.BuildObjectDataTable<OrderItem>(order.OrderItems, tvpOrderItemsParameters)

            }, commandType: CommandType.StoredProcedure);

            if (orderStatus == 1) {
                Helpers.SendMail("ashok@gamil.com", "buyer@gmail.com", "Order Update", "Success");
            }

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            List<string> tvpOrderItemsParameters = new List<string>() {
                "Id",
                "Quantity",
                "OrderId",
                "ProductId"
            };

            var orderStatus = await connection.ExecuteAsync("UpdateOrder", new
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = "",
                OrderItems = Helpers.BuildObjectDataTable<OrderItem>(order.OrderItems, tvpOrderItemsParameters)

            }, commandType: CommandType.StoredProcedure);

            if (orderStatus == 1)
            {
                Helpers.SendMail("ashok@gamil.com", "buyer@gmail.com", "Order Update", "Success");
            }

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int orderId)
        {
            await connection.ExecuteAsync("DeleteOrder", new { id = orderId }, commandType: CommandType.StoredProcedure);
            return Ok();
        }
    }


}
