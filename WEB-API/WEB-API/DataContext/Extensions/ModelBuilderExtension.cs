using Microsoft.EntityFrameworkCore;
using WEB_API.Models;

namespace WEB_API.DataContext.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfiguration(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "admin", Email = "admin@gmail.com" },
                new User { Id = 2, UserName = "Leonardo", Password = "123456", Email = "leonardothomazellif@gmail.com" },
                new User { Id = 3, UserName = "Geraldo", Password = "654321", Email = "geraneves@gmail.com" }
            );
            builder.Entity<Tasks>().HasData(
                new Tasks { Id = 1, Title = "Futebol", Summary = "Ir ao futebol.", Status = Enums.StatusEnum.ToDo, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 2 },
                new Tasks { Id = 2, Title = "Mercado", Summary = "Ir ao mercado.", Status = Enums.StatusEnum.Doing, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 3 },
                new Tasks { Id = 3, Title = "Teste de Programação", Summary = "Finalizar o teste.", Status = Enums.StatusEnum.Done, CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddYears(1), UserId = 1 }
            );

            return builder;
        }
    }
}
