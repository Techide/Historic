using Historic.Api.Common.CQS;
using Historic.Api.Data.Models;
using Historic.Api.Utils.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;

namespace Historic.Api {
    public class SimpleInjectorIntegration {

        private Container _container = new Container();

        internal void IntegrateSimpleInjectorServices(IServiceCollection services) {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        internal void InitializeContainer(IApplicationBuilder app, ClientAppSettings clientAppSettings, ConnectionstringSettings connectionstringSettings) {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var allAssemblies = new[] { executingAssembly };

            // Add application presentation components:
            _container.RegisterMvcControllers(app);

            // Register settings as singleton
            _container.RegisterInstance(clientAppSettings);
            _container.RegisterInstance(connectionstringSettings);

            // Add application services. For instance:
            _container.Register(typeof(IQueryHandler<,>), allAssemblies);
            _container.Register(typeof(ICommandHandler<>), allAssemblies);
            _container.Register<HistoricContext>(Lifestyle.Scoped);

            // Add crosswiring services.

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _container.AutoCrossWireAspNetComponents(app);

            using (AsyncScopedLifestyle.BeginScope(_container)) {
                var context = _container.GetInstance<HistoricContext>();
                context.Database.Migrate();
            }

            _container.Verify();

        }

    }
}
