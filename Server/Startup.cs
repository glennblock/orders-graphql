using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using GraphQL.Server.Transports.WebSockets.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Schemas.Orders;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<OrdersSchema>();
            services.AddSingleton<OrdersQuery>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<OrderCreateInputType>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<OrderStatusesEnum>();
            services.AddSingleton<OrdersMutation>();
            services.AddSingleton<OrderSubscription>();
            services.AddSingleton<OrderEventType>();
            services.AddSingleton<IOrderEventService, OrderEventService>();
            services.AddSingleton<IEventAggregator, SimpleEventAggregator>();
            services.AddSingleton<IDependencyResolver>(c =>
               new FuncDependencyResolver(type => c.GetRequiredService(type))); services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<OrdersSchema>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseWebSockets();
            app.UseGraphQLWebSocket<OrdersSchema>(new GraphQLWebSocketsOptions());
            app.UseGraphQLHttp<OrdersSchema>(new GraphQLHttpOptions());
            app.UseMvc();
        }
    }
}
