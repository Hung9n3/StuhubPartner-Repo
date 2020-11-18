using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Entities.Models.IdentityContext;
using Repository.IdentityManager;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entities.Models.SmartZoneContext;
using AutoMapper.EquivalencyExpression;

namespace StuhubPartner
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContextPool<SmartZoneContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SmartZoneContext")));
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddUserManager<UserManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "jwt";
                options.DefaultChallengeScheme = "jwt";
            })
              .AddCookie(cfg => cfg.SlidingExpiration = true)
              .AddJwtBearer("jwt", cfg =>
              {
                  cfg.RequireHttpsMetadata = false;
                  cfg.SaveToken = true;

                  cfg.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = Configuration["JwtTokens:Issuer"],
                      ValidAudience = Configuration["JwtTokens:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtTokens:Key"]))
                  };

              });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy(Constants.Policies.CompanyOnly, policy => policy.RequireClaim("CompanyType", "Company"));
            });
            // Auto Mapper Configurations
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddCollectionMappers();
                mc.AddProfile(new MappingProfile());
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
