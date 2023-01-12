using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.ClientId).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.NameCompany).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();

            builder.HasData(new List<Client>()
            {
                new Client() { ClientId = 1, FirstName = "Мыкола", LastName = "Парасюк", NameCompany = "Нафтогаз", Email = "comercial@nafta.ua", PhoneNumber = "04067493487" },
                new Client() { ClientId = 2, FirstName = "Степан", LastName = "Наливайко", NameCompany = "АТБ-Маркет", Email = "comercial@atb.ua", PhoneNumber = "0785493787" },
                new Client() { ClientId = 3, FirstName = "Юрий", LastName = "Шурло", NameCompany = "Мотор Сич", Email = "comercial@sich.ua", PhoneNumber = "78067496587" },
                new Client() { ClientId = 4, FirstName = "Виктория", LastName = "Акулибаба", NameCompany = "Кернел-трейд", Email = "comercial@kernel.ua", PhoneNumber = "0655649547" },
                new Client() { ClientId = 5, FirstName = "Виктор", LastName = "Хрюкин", NameCompany = "Тесла", Email = "comercial@tesla.ua", PhoneNumber = "056593487" },
            });
        }
    }
}
