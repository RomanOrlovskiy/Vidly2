using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Adding additional profile data. This requires creating migration 
        //and apdating DB as it modifies the domain model class.
        //For users that already exists driving license will be empty string
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    /* Begging to work with Entity Framework
     For a new project, at first, you have to use command 
     "enable-migrations" in package console.
     When creating our first migration by command "add-migration
     InitialModels", 
     EF looked at ApplicationDbContext and discovered a bunch 
     of IdentityDbContext DbSet tables from ASP.NET Identity
     (used for controlling authorization and authentication),
     that are initialized with references of type AspNetRoles, 
     AspNetUsers and others. And used them to create necessary 
     tables in InitialModels.cs migration file.

     ******
     To create a table for Customer or Movies class we have to 
     set a refernce to needed Model by creating new 
     DbSet<Customer> "table" propperty in DbContext class
     like is shown below. After that you need to add new migration 
     with a command "add-migration InitialModel -force". -force 
     switch is used because InitialModel migration already 
     exists and we need to override it.
     After that you need to update date-base with command update-database.
     ******
     
     It is importand with Code-First approach to create a migration
     after each small step, like adding DbSet<Customer> or adding
     new properties to Customer Model and naming that migration
     depending on the changes we have made. So that you want 
     have a need to deal with error's produced by Packet Manager Console.
         */
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //Customers table in Db
        public DbSet<Customer> Customers { get; set; }

        /*  Chapter 3. Exercise 3.
         Chapter 3. Exercise 3.
         Doing almost the same stuff as to Customers table
         1)Creating a DbSet<Movie> property here.
           
         2)Add additional properties to Movie class:
            -Genre,
            -ReleaseDate,
            -Date Added,
            -Number in Stock.
            Migration, update-database.
         3)Create another migration to populate Genres table
           with Sql INSERT statement because it's a reference 
           data (like MembershipType).
         3.5) Manually add rows to Movie table
         4)Modify MoviesController.
         5)Modify Views.
             */
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}