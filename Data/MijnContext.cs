using Microsoft.EntityFrameworkCore;
using src.Models;

public class MijnContext : DbContext {
    public MijnContext(DbContextOptions options) : base(options) { }
    
    public DbSet<PS_Lijst> PS_Lijsts {get;set;}
    public DbSet<BR_Lijst> BR_Lijsts {get;set;}
    public DbSet<Verzamel_Lijst> Verzamel_Lijsts {get;set;}
    public DbSet<Overig_Lijst> Overig_Lijsts {get;set;}

}