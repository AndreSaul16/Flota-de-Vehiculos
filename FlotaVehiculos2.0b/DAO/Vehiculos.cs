namespace FlotaVehiculos2._0b.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            this.DepCarga = new HashSet<DepCarga>();
            this.DepTransporte = new HashSet<DepTransporte>();
        }
    
        public string marca { get; set; }
        public string modelo { get; set; }
        public string matricula { get; set; }
        public string color { get; set; }
        public int ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepCarga> DepCarga { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepTransporte> DepTransporte { get; set; }
    }
}
