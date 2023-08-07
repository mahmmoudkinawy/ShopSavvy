namespace Order.Infrastructure;
public static class InfrastructureServiceRegistrations
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<OrdersDbContext>(_
            => _.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
