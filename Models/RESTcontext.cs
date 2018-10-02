using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RESTcontext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTcontext(DbContextOptions<RESTcontext> options) : base(options) { }
        public DbSet<restaurant> Restaurant{get;set;}
        
    }
}