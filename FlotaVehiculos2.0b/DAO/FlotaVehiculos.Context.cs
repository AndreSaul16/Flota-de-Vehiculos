namespace FlotaVehiculos2._0b.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlotaVehiculosEntities : DbContext
    {
        public FlotaVehiculosEntities()
            : base("name=FlotaVehiculosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DepCarga> DepCarga { get; set; }
        public virtual DbSet<DepTransporte> DepTransporte { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
