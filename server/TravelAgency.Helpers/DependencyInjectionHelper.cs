﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Implementations;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Services.Documents;
using TravelAgency.Services.Emails;
using TravelAgency.Services.Implementations;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TravelAppContext>(options => options.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IPlanRepository,  PlanRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IContractEventsRepository, ContractEventsRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
