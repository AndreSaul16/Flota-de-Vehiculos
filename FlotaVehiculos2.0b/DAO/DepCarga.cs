namespace FlotaVehiculos2._0b.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepCarga
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public int cargaMax { get; set; }
        public int vehiculoID { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
