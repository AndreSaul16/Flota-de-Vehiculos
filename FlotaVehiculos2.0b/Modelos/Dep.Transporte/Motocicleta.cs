using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Modelos.Dep.Transporte
{
    class Motocicleta : DtoTransporte
    {
        public Motocicleta(int ID, string marca, string modelo, string matricula, string color, int capacidadDePersonas) : base(ID, marca, modelo, matricula, color, capacidadDePersonas)
        {
        }
        public override void apagar()
        {
            Console.WriteLine("apagado");

        }
        public override void conducir()
        {
            Console.WriteLine("conduciendo");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\motoConduce.wav");
            player.Play();
        }
        public override void detener()
        {
            Console.WriteLine("detenido");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\motoFrena.wav");
            player.Play();
        }
        public override void encender()
        {
            Console.WriteLine("encendido");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\motoEnciende.wav");
            player.Play();
        }
        public override void estacionar()
        {
            Console.WriteLine("estacionado");
        }
    }
}
