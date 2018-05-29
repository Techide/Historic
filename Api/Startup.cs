using Historic.Api.Utils.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Historic.Api {
    public class Startup {
        private readonly string CORS_POLICY_NAME = "WordManagerCorsPolicy";
        private SimpleInjectorIntegration _injector = new SimpleInjectorIntegration();
        private readonly ClientAppSettings _clientAppSettings;
        private readonly ConnectionstringSettings _connectionstringSettings;

        public Startup(IConfiguration configuration) {
            Configuration = configuration;

            _clientAppSettings = configuration.GetSection("ClientApp").Get<ClientAppSettings>();
            _connectionstringSettings = configuration.GetSection("ConnectionStrings").Get<ConnectionstringSettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddOptions();

            services
                .AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

            services.AddEntityFrameworkSqlServer();

            services.AddCors(options => {
                options.AddPolicy(CORS_POLICY_NAME, builder => {
                    builder.WithOrigins(_clientAppSettings.Url)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            _injector.IntegrateSimpleInjectorServices(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            _injector.InitializeContainer(app, _clientAppSettings, _connectionstringSettings);

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCors(CORS_POLICY_NAME);

            app.UseMvc();

        }
    }
}
