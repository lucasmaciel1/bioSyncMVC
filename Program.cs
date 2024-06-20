namespace bioSyncMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Adicionado os servicos de interface e classe de httpconcextacessor e da sessao
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<Services.ISessao, Services.Sessao>();

            //Adicionar o Serviço de Gerenciamento de sessão
            builder.Services.AddSession(options => {
                /*
                 A propriedade IdleTimeout refere-se ao tempo de expiração da sessão por inatividade
                O tempo padrão para a inatividade da aplicação ASP.NET é de 20 minutos
                 */
                options.IdleTimeout = TimeSpan.FromMinutes(10); //10 minutos para expirar a sessao
                options.Cookie.HttpOnly = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); //Adicionar o uso de sessão após UseAuthorization() e antes de MapControllerRoute(...);

            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");
                //pattern: "{controller=Carros}/{action=Details}/{id=2}");
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}