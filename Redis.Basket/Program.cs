using Redis.Basket.Services;
using StackExchange.Redis;

namespace Redis.Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var config = ConfigurationOptions.Parse("localhost:1111",true);
                return ConnectionMultiplexer.Connect(config);
            });

            builder.Services.AddScoped<IRedisService,RedisService>();
            builder.Services.AddScoped<IBasketService,BasketService>();
            


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
