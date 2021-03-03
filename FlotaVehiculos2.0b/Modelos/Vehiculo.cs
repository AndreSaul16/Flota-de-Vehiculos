using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Modelos
{
    abstract class Vehiculo
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string matricula { get; set; }
        public string color { get; set; }
        public int ID { get; set; }


        public Vehiculo(int ID, string marca, string modelo, string matricula, string color)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.matricula = matricula;
            this.color = color;
            this.ID = ID;
        }
        public abstract void encender();
        public abstract void conducir();
        public abstract void estacionar();
        public abstract void detener();
        public abstract void apagar();
    }
}
