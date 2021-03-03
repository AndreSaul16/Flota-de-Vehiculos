using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Modelos.Dep.Carga
{
    class Camion : DtoCarga
    {
        public Camion(int ID, string marca, string modelo, string matricula, string color, int kg) : base(ID, marca, modelo, matricula, color, kg)
        {

        }

        public override void apagar()
        {
            Console.WriteLine("apagado");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\CamionApagado.wav");
            player.Play();
        }

        public override void conducir()
        {
            Console.WriteLine("conduciendo");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\camionConduce.wav");
            player.Play();
        }

        public override void detener()
        {
            Console.WriteLine("detenido");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\camionFrena.wav");
            player.Play();
        }

        public override void encender()
        {
            Console.WriteLine("encendido");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\camionConduce.wav");
            player.Play();
        }

        public override void estacionar()
        {
            Console.WriteLine("estacionado");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\wav\CamionEstaciona.wav");
            player.Play();
        }
    }
}
