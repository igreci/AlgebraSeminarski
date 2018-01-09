namespace SeminarDva
{
    using SeminarDva.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelOne : DbContext
    {
        // Your context has been configured to use a 'ModelOne' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SeminarDva.ModelOne' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelOne' 
        // connection string in the application configuration file.
        public ModelOne()
            : base("name=ModelOne")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Predbiljezba> Predbiljezbe { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenici { get; set; }
        public virtual DbSet<Seminar> Seminari { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}