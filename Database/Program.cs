using System;
using Database.Context.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlite("Data Source=arcoiris.db"); // Substitua pela sua string de conexão
                })
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                // Aqui você pode adicionar a lógica para configurar o banco de dados
                // Por exemplo: context.Database.Migrate();
            }

            Console.WriteLine("Configuração do banco de dados concluída!");
        }
    }
}
