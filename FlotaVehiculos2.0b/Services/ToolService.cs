using FlotaVehiculos2._0b.Modelos.Dep.Carga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Services
{
    class ToolService
    {
        public static string marca;
        public static string modelo;
        public static string color;
        public static string matricula;
        public static void nuevoVehciulo()
        {
            Console.WriteLine("Porfavor dime la marca: ");
            marca = Console.ReadLine();
            Console.WriteLine("Porfavor dime el modelo: ");
            modelo = Console.ReadLine();
            Console.WriteLine("Porfavor dime el color: ");
            color = Console.ReadLine();
            Console.WriteLine("Porfavor dime la matricula: ");
            matricula = Console.ReadLine();
        }
       
        //Crear otro metodo que nos permita saber cual es el ultimo numero ID asigando en la base de datos, 
        //de esa manera vamos a saber cual sera el id del proximo vehiculo que se añada y podemos agregarle el id a los vehiculos de manera automatica en nuestro programa y no habra fallos en la base de datos al añadir
    }
}
