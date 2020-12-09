using ISUCorp.Reservation.Business.Implementations;
using ISUCorp.Reservation.Business.Interfaces;
using ISUCorp.Reservation.Data.Implementations.Framework;
using ISUCorp.Reservation.Data.Interfaces.Framework;
using ISUCorp.Reservation.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISUCorp.Reservation
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
           this IServiceCollection services)
        {

            services.AddTransient<IContactTypeService, ContactTypeService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IReservationService, ReservationService>();
           
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<ContactType>, GenericRepository<ContactType>>();
            services.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
            services.AddTransient<IGenericRepository<Data.Models.Reservation>, GenericRepository<Data.Models.Reservation>>();

            return services;
        }
    }
}
