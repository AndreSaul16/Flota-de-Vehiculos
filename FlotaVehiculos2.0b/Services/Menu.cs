using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Services
{
    class Menu
    {
        CRUDService crud = new CRUDService();
        string depEnGestion = "";


        /*───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        ─████████████───██████████████─██████████████───────────██████████████─██████████████─████████████████───██████████████─██████████████─
        ─██░░░░░░░░████─██░░░░░░░░░░██─██░░░░░░░░░░██───────────██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░░░██─
        ─██░░████░░░░██─██░░██████████─██░░██████░░██───────────██░░██████████─██░░██████░░██─██░░████████░░██───██░░██████████─██░░██████░░██─
        ─██░░██──██░░██─██░░██─────────██░░██──██░░██───────────██░░██─────────██░░██──██░░██─██░░██────██░░██───██░░██─────────██░░██──██░░██─
        ─██░░██──██░░██─██░░██████████─██░░██████░░██───────────██░░██─────────██░░██████░░██─██░░████████░░██───██░░██─────────██░░██████░░██─
        ─██░░██──██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██───────────██░░██─────────██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░██──██████─██░░░░░░░░░░██─
        ─██░░██──██░░██─██░░██████████─██░░██████████───────────██░░██─────────██░░██████░░██─██░░██████░░████───██░░██──██░░██─██░░██████░░██─
        ─██░░██──██░░██─██░░██─────────██░░██───────────────────██░░██─────────██░░██──██░░██─██░░██──██░░██─────██░░██──██░░██─██░░██──██░░██─
        ─██░░████░░░░██─██░░██████████─██░░██───────██████──────██░░██████████─██░░██──██░░██─██░░██──██░░██████─██░░██████░░██─██░░██──██░░██─
        ─██░░░░░░░░████─██░░░░░░░░░░██─██░░██───────██░░██──────██░░░░░░░░░░██─██░░██──██░░██─██░░██──██░░░░░░██─██░░░░░░░░░░██─██░░██──██░░██─
        ─████████████───██████████████─██████───────██████──────██████████████─██████──██████─██████──██████████─██████████████─██████──██████─
        ───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────  */
        public void gestionDtoCarga(string option)
        {
            option = "";
            depEnGestion = "1";
            bool finalizar = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Añadir un nuevo vehiculo al departamento de carga");
                Console.WriteLine("2 - Eliminar un vehiculo del departamento de carga");
                Console.WriteLine("3 - Mostrar todos los vehiculos del departamento de carga");
                Console.WriteLine("4 - Ver las opciones de filtrado del departamento de carga");
                Console.WriteLine("5 - Modifica un vehiculo del departamento de carga");
                Console.WriteLine("6 - Regresar");
                Console.WriteLine();
                Console.Write("Pulsa el numero correspondiente para seleccionar una opcion: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("    AGREGAR UN VEHICULO PESADO  ");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        try
                        {
                            crud.agregarVehiculo(depEnGestion);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }
                        break;

                    case "2":
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("    ELIMINA UN VEHICULO PESADO ");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine();
                        try
                        {
                            crud.borrarVehiculo(depEnGestion);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }


                        break;

                    case "3":
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("     MOSTRAR TODOS LOS VEHICULOS PESADOS   ");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine();
                        try
                        {
                            crud.mostrarVehiculosDeCarga();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }


                        break;

                    case "4":
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("                OPCIONES DE FILTRADO            ");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("1 - Filtrar por ID");
                        Console.WriteLine("2 - Fitlrar por marca");
                        Console.WriteLine("3 - Filtrar por modelo");
                        Console.WriteLine("4 - Filtrar por color");
                        Console.WriteLine("5 - Filtrar por capacidad de carga");
                        Console.WriteLine("6 - Filtrar por tipo (camion o remolque)");
                        Console.WriteLine();
                        Console.Write("Pulsa el numero correspondiente para seleccionar una opcion: ");
                        string filter = Console.ReadLine();

                        crud.filtradosDepCarga(filter);

                        break;

                    case "5":
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("         MODIFICAR UN VEHICULO PESADO      ");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine();
                        try
                        {
                            crud.modificarVehiculo();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }


                        break;

                    case "6":
                        finalizar = true;

                        break;

                    default:
                        Console.Write("Wrong option");

                        break;
                }
            } while (!finalizar);
        }















        /*──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        ─████████████───██████████████─██████████████───────────██████████████─████████████████───██████████████─██████──────────██████─██████████████─██████████████─██████████████─████████████████───██████████████─██████████████─
        ─██░░░░░░░░████─██░░░░░░░░░░██─██░░░░░░░░░░██───────────██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░██████████──██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░░░██─
        ─██░░████░░░░██─██░░██████████─██░░██████░░██───────────██████░░██████─██░░████████░░██───██░░██████░░██─██░░░░░░░░░░██──██░░██─██░░██████████─██░░██████░░██─██░░██████░░██─██░░████████░░██───██████░░██████─██░░██████████─
        ─██░░██──██░░██─██░░██─────────██░░██──██░░██───────────────██░░██─────██░░██────██░░██───██░░██──██░░██─██░░██████░░██──██░░██─██░░██─────────██░░██──██░░██─██░░██──██░░██─██░░██────██░░██───────██░░██─────██░░██─────────
        ─██░░██──██░░██─██░░██████████─██░░██████░░██───────────────██░░██─────██░░████████░░██───██░░██████░░██─██░░██──██░░██──██░░██─██░░██████████─██░░██████░░██─██░░██──██░░██─██░░████████░░██───────██░░██─────██░░██████████─
        ─██░░██──██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██───────────────██░░██─────██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░██──██░░██──██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──██░░██─██░░░░░░░░░░░░██───────██░░██─────██░░░░░░░░░░██─
        ─██░░██──██░░██─██░░██████████─██░░██████████───────────────██░░██─────██░░██████░░████───██░░██████░░██─██░░██──██░░██──██░░██─██████████░░██─██░░██████████─██░░██──██░░██─██░░██████░░████───────██░░██─────██░░██████████─
        ─██░░██──██░░██─██░░██─────────██░░██───────────────────────██░░██─────██░░██──██░░██─────██░░██──██░░██─██░░██──██░░██████░░██─────────██░░██─██░░██─────────██░░██──██░░██─██░░██──██░░██─────────██░░██─────██░░██─────────
        ─██░░████░░░░██─██░░██████████─██░░██───────██████──────────██░░██─────██░░██──██░░██████─██░░██──██░░██─██░░██──██░░░░░░░░░░██─██████████░░██─██░░██─────────██░░██████░░██─██░░██──██░░██████─────██░░██─────██░░██████████─
        ─██░░░░░░░░████─██░░░░░░░░░░██─██░░██───────██░░██──────────██░░██─────██░░██──██░░░░░░██─██░░██──██░░██─██░░██──██████████░░██─██░░░░░░░░░░██─██░░██─────────██░░░░░░░░░░██─██░░██──██░░░░░░██─────██░░██─────██░░░░░░░░░░██─
        ─████████████───██████████████─██████───────██████──────────██████─────██████──██████████─██████──██████─██████──────────██████─██████████████─██████─────────██████████████─██████──██████████─────██████─────██████████████─
        ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── */


        public void gestorDtoTransporte(string option)
        {
            option = "";
            depEnGestion = "2";
            bool finalizar = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Añadir un nuevo vehiculo al departamento de transporte");
                Console.WriteLine("2 - Eliminar un vehiculo del departamento de transporte");
                Console.WriteLine("3 - Mostrar todos los vehiculos del departamento de transporte");
                Console.WriteLine("4 - Ver las opciones de filtrado del departamento de transporte");
                Console.WriteLine("5 - Modificar un vehiculo del departamento de transporte");
                Console.WriteLine("6 - Regresar");
                Console.WriteLine();
                Console.Write("Pulsa el numero correspondiente para seleccionar una opcion: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("    AGREGAR UN VEHICULO LIGERO  ");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();

                        try
                        {
                            crud.agregarVehiculo(depEnGestion);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }

                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("    ELIMINA UN VEHICULO LIGERO  ");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();

                        try
                        {
                            crud.borrarVehiculo(depEnGestion);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("     MOSTRAR TODOS LOS VEHICULOS LIGERO    ");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine();


                        try
                        {
                            crud.mostrarVehiculosDeTransporte();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("                OPCIONES DE LIGERO             ");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("1 - Fitlrar por marca");
                        Console.WriteLine("2 - Filtrar por modelo");
                        Console.WriteLine("3 - Filtrar por color");
                        Console.WriteLine("4 - Filtrar por capacidad de carga");
                        Console.WriteLine("5 - Filtrar por tipo (motocicleta o automovil)");
                        Console.WriteLine();
                        Console.Write("Pulsa el numero correspondiente para seleccionar una opcion: ");
                        string filter = Console.ReadLine();


                        try
                        {
                            crud.filrarVehiculosDeTrasnporte(filter);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }
                        break;

                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("         MODIFICAR UN VEHICULO LIGERO      ");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine();


                        try
                        {
                            crud.modificarVehiculo();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error inesperado: " + error);
                        }
                        break;

                    case "6":
                        finalizar = true;

                        break;

                    default:
                        Console.Write("Wrong option");

                        break;
                }
            } while (!finalizar);
        }












        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------> MENU
        public void menu()
        {
            crud.cargarDTOs();
            bool finalizar = false;
            do
            {
                string option = "";
                Console.WriteLine("¿Que departamento deseas gestionar?");
                Console.WriteLine("1 - Departamento de Carga");
                Console.WriteLine("2 - Departamento de Transporte");
                Console.WriteLine("3 - Mostrar todos los vehiculos");
                Console.WriteLine("4 - Salir");
                Console.WriteLine("Selecciona una opcion para continuar\n \n<<Para seleccionar una opcion debes presionar el numero correspondiente>>");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        gestionDtoCarga(option);

                        break;
                    case "2":
                        gestorDtoTransporte(option);

                        break;
                    case "3":
                        crud.mostrarTodos();

                        break;
                    case "4":
                        finalizar = true;
                        break;

                    default:
                        Console.Write("Wrong option");
                        break;
                }

            } while (!finalizar);
        }
    }
}
