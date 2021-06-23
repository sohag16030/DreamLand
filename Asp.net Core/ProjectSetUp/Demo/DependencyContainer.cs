using Microsoft.Extensions.DependencyInjection;
using TestWeb.Core;

namespace TestWeb
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            //services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            //    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            //});
            
            //data
            services.AddTransient(typeof(ICrudRepository<>),typeof(CrudRepository<>));
            //services.AddTransient<IPurchaseOrganizationRepository, PurchaseOrganizationRepository>();
            //services.AddTransient<IPurchaseOrganizationService, PurchaseOrganizationService>();

            //services.AddTransient<IPurchaseRequestTypeService, PurchaseRequestTypeService>();
            //services.AddTransient<IPurchaseRequestTypeRepository, PurchaseRequestTypeRepository>();

            //services.AddTransient<IPurchaseRequestRepository, PurchaseRequestRepository>();
            //services.AddTransient<IPurchaseRequestService, PurchaseRequestService>();
            //services.AddTransient<IRequestForQuotationService, RequestForQuotationService>();
            //services.AddTransient<IRequestForQuotationRepository, RequestForQuotationRepository>();

            //services.AddTransient<IMaintainRFQRepository, MaintainRFQRepository>();
            //services.AddTransient<IMaintainRFQService, MaintainRFQService>();


            //services.AddTransient<IComperativeStatementRepository, ComperativeStatementRepository>();
            //services.AddTransient<IComperativeStatementService, ComperativeStatementService>();
        }
    }
}
