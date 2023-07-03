using Dapper;
using ECommerceAPI.Contexts;
using ECommerceAPI.Entities;
using System.Data;

namespace ECommerceAPI.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly IDbConnection _connection;
        public AuthMiddleware(RequestDelegate request, DapperContext context)
        {
            _request = request;
            _connection = context.CreateConnection();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers.ContainsKey("x-user-id");
            if (!header)
            {
                context.Response.StatusCode = 401;
                return;
            }
            string UserId = context.Request.Headers["x-user-id"]!;
            Guid parseUser = Guid.Parse(UserId);
            if (!ValidateUser(parseUser))
            {
                context.Response.StatusCode = 401;
                return;
            }
            await _request(context);
        }

        private bool ValidateUser(Guid UserId)
        {
            var query = "SELECT * FROM Users where UserId = @UserId";
            var parameters = new { UserId };
            _connection.Open();
            var user = _connection.Query<User>(query, parameters).FirstOrDefault();
            _connection.Close();
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
