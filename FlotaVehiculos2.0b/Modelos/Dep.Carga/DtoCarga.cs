using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Modelos.Dep.Carga
{
    abstract class DtoCarga : Vehiculo
    {
        public int capacidadKG { get; set; }

        protected DtoCarga(int ID, string marca, string modelo, string matricula, string color, int kg) : base(ID, marca, modelo, matricula, color)
        {
            this.capacidadKG = kg;

        }

        public override abstract void encender();
        public override abstract void conducir();
        public override abstract void estacionar();
        public override abstract void detener();
        public override abstract void apagar();
    }
}
