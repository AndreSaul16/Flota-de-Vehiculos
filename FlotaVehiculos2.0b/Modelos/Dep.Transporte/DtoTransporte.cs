using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Modelos.Dep.Transporte
{
    abstract class DtoTransporte : Vehiculo
    {
        public int capacidadDePersonas { get; set; }
        protected DtoTransporte(int ID, string marca, string modelo, string matricula, string color, int capacidadDePersonas) : base(ID, marca, modelo, matricula, color)
        {
            this.capacidadDePersonas = capacidadDePersonas;
        }
        public override abstract void encender();
        public override abstract void conducir();
        public override abstract void estacionar();
        public override abstract void detener();
        public override abstract void apagar();
    }
}
