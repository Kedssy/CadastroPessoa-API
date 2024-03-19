using CadastroPessoa_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa_API.DataManager
{
    public class ApplicationDataContext :DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) 
        {
           
        }
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Telefone> Telefone { get; set; }
    }
}
