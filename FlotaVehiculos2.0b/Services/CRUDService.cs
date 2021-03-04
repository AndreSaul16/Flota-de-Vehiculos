using FlotaVehiculos2._0b.DAO;
using FlotaVehiculos2._0b.Modelos;
using FlotaVehiculos2._0b.Modelos.Dep.Carga;
using FlotaVehiculos2._0b.Modelos.Dep.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaVehiculos2._0b.Services
{
    class CRUDService
    {
        FlotaVehiculosEntities db;
        List<Vehiculo> listaDeVehiculos;

        public CRUDService()
        {
            this.db = new FlotaVehiculosEntities();
            this.listaDeVehiculos = new List<Vehiculo>();
        }

        public void cargarDTOs()
        {
            //CARGAR DEPARTAMENTO DE CARGA
            var carga = this.db.DepCarga;
            foreach (var i in carga)
            {
                if (i.tipo == 1)
                {
                    Vehiculo dto = new Camion(i.Vehiculos.ID, i.Vehiculos.marca, i.Vehiculos.modelo, i.Vehiculos.matricula, i.Vehiculos.color, i.cargaMax);
                    listaDeVehiculos.Add(dto);
                }
                if (i.tipo == 2)
                {
                    Vehiculo dto = new Remolque(i.Vehiculos.ID, i.Vehiculos.marca, i.Vehiculos.modelo, i.Vehiculos.matricula, i.Vehiculos.color, i.cargaMax);
                    listaDeVehiculos.Add(dto);
                }
            }
            //CARGAR DEPARTAMENTO DE TRANSPORTE
            var transporte = this.db.DepTransporte;
            foreach (var i in transporte)
            {
                if (i.tipo == 1)
                {
                    Vehiculo dto = new Automovil(i.Vehiculos.ID, i.Vehiculos.marca, i.Vehiculos.modelo, i.Vehiculos.matricula, i.Vehiculos.color, i.maxPersonas);
                    listaDeVehiculos.Add(dto);
                }
                if (i.tipo == 2)
                {
                    Vehiculo dto = new Motocicleta(i.Vehiculos.ID, i.Vehiculos.marca, i.Vehiculos.modelo, i.Vehiculos.matricula, i.Vehiculos.color, i.maxPersonas);
                    listaDeVehiculos.Add(dto);
                }
            }
        }
        public void mostrarTodos()
        {
            Console.WriteLine();
            listaDeVehiculos.ForEach(delegate (Vehiculo i)
            {
                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID}");
                Console.WriteLine();
            });
        }

        //FILTRADOS DEL DEP DE CARGA
        public void mostrarVehiculosDeCarga()
        {
            listaDeVehiculos.ForEach(delegate (Vehiculo i)
            {
                if (i is DtoCarga)
                {
                    Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG}");
                    Console.WriteLine();
                }
            });
        }

        public void mostrarVehiculosDeTransporte()
        {
            listaDeVehiculos.ForEach(delegate (Vehiculo i)
            {
                if (i is DtoTransporte)
                {
                    Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas}");
                    Console.WriteLine();
                }
            });
        }


        /* ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        ─██████████████─██████████████─████████████████───██████████████─██████████████─██████████████─████████████████───
        ─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───
        ─██░░██████░░██─██░░██████████─██░░████████░░██───██░░██████████─██░░██████████─██░░██████░░██─██░░████████░░██───
        ─██░░██──██░░██─██░░██─────────██░░██────██░░██───██░░██─────────██░░██─────────██░░██──██░░██─██░░██────██░░██───
        ─██░░██████░░██─██░░██─────────██░░████████░░██───██░░██████████─██░░██─────────██░░██████░░██─██░░████████░░██───
        ─██░░░░░░░░░░██─██░░██──██████─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░██──██████─██░░░░░░░░░░██─██░░░░░░░░░░░░██───
        ─██░░██████░░██─██░░██──██░░██─██░░██████░░████───██░░██████████─██░░██──██░░██─██░░██████░░██─██░░██████░░████───
        ─██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─────██░░██─────────██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─────
        ─██░░██──██░░██─██░░██████░░██─██░░██──██░░██████─██░░██████████─██░░██████░░██─██░░██──██░░██─██░░██──██░░██████─
        ─██░░██──██░░██─██░░░░░░░░░░██─██░░██──██░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──██░░██─██░░██──██░░░░░░██─
        ─██████──██████─██████████████─██████──██████████─██████████████─██████████████─██████──██████─██████──██████████─
        ────────────────────────────────────────────────────────────────────────────────────────────────────────────────── */





        public void agregarVehiculo(string depEnGestion)
        {
            switch (depEnGestion)
            {
                case "1":
                    Console.WriteLine("¿Que tipo de vehiculo de carga deseas añadir al sistema?");
                    Console.WriteLine();
                    Console.WriteLine("1 - Camion \n2 - Remolque");
                    Console.WriteLine();
                    Console.WriteLine("Elige una opcion presionando '1' para añadir un camion o '2' para añadir un remolque");
                    Console.WriteLine();
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡Bien! Vamos a añadir un nuevo camion, empecemos: ");
                        ToolService.nuevoVehciulo();
                        Console.WriteLine("Porvafor, indicame la carga maxima del camion en toneladas (numeros enteros, por ejemplo: 1 o 50): ");
                        int.TryParse(Console.ReadLine(), out int cargaMax);

                        Vehiculo nuevoCamion = new Camion(0, ToolService.marca, ToolService.modelo, ToolService.matricula, ToolService.color, cargaMax);
                        listaDeVehiculos.Add(nuevoCamion);


                        DepCarga nuevo = new DepCarga();
                        nuevo.Vehiculos = new Vehiculos();
                        nuevo.Vehiculos.color = nuevoCamion.color;
                        nuevo.Vehiculos.marca = nuevoCamion.marca;
                        nuevo.Vehiculos.modelo = nuevoCamion.modelo;
                        nuevo.Vehiculos.matricula = nuevoCamion.matricula;
                        nuevo.cargaMax = cargaMax;
                        nuevo.tipo = 1;

                        db.DepCarga.Add(nuevo);
                        db.SaveChanges();

                        nuevoCamion.ID = nuevo.vehiculoID;


                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Has creado un nuevo Camion con las siguientes caracteristicas: \nMarca: {nuevoCamion.marca} \nModelo: {nuevoCamion.modelo} \nMatricula: {nuevoCamion.matricula} \nColor: {nuevoCamion.color} \nCarga Maxima:{cargaMax} toneladas \nID: {nuevoCamion.ID}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    if (option == "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡Bien! Vamos a añadir un nuevo remolque, empecemos: ");
                        ToolService.nuevoVehciulo();
                        Console.WriteLine("Porvafor, indicame la carga maxima del remolque en toneladas (numeros enteros, por ejemplo: 1 o 50): ");
                        int.TryParse(Console.ReadLine(), out int cargaMax);

                        Vehiculo nuevoRemolque = new Remolque(0, ToolService.marca, ToolService.modelo, ToolService.matricula, ToolService.color, cargaMax);
                        listaDeVehiculos.Add(nuevoRemolque);

                        DepCarga nuevo = new DepCarga();
                        nuevo.Vehiculos = new Vehiculos();
                        nuevo.Vehiculos.color = nuevoRemolque.color;
                        nuevo.Vehiculos.marca = nuevoRemolque.marca;
                        nuevo.Vehiculos.modelo = nuevoRemolque.modelo;
                        nuevo.Vehiculos.matricula = nuevoRemolque.matricula;
                        nuevo.cargaMax = cargaMax;
                        nuevo.tipo = 2;

                        db.DepCarga.Add(nuevo);
                        db.SaveChanges();

                        nuevoRemolque.ID = nuevo.vehiculoID;

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Has creado un nuevo remolque con las siguientes caracteristicas: \nMarca: {nuevoRemolque.marca} \nModelo: {nuevoRemolque.modelo} \nMatricula: {nuevoRemolque.matricula} \nColor: {nuevoRemolque.color} \nCarga Maxima:{cargaMax} toneladas \nID: {nuevoRemolque.ID}");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("¿Que tipo de vehiculo de carga deseas añadir al sistema?");
                    Console.WriteLine("1 - Automovil \n2 - Motocicleta");
                    Console.WriteLine();
                    Console.WriteLine("Elige una opcion presionando '1' para añadir un automovil o '2' para añadir una motocicleta");
                    Console.WriteLine();
                    string option2 = Console.ReadLine();
                    if (option2 == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡Bien! Vamos a añadir un nuevo automovil, empecemos: ");
                        ToolService.nuevoVehciulo();
                        Console.WriteLine("Porvafor, indicame la capacidad maxima de pasajeros del vehiculo (numeros enteros, por ejemplo: 1 o 50): ");
                        int.TryParse(Console.ReadLine(), out int numPasajeros);

                        Vehiculo nuevoVehiculo = new Automovil(0, ToolService.marca, ToolService.modelo, ToolService.matricula, ToolService.color, numPasajeros);
                        listaDeVehiculos.Add(nuevoVehiculo);

                        DepTransporte nuevo = new DepTransporte();
                        nuevo.Vehiculos = new Vehiculos();
                        nuevo.Vehiculos.color = nuevoVehiculo.color;
                        nuevo.Vehiculos.marca = nuevoVehiculo.marca;
                        nuevo.Vehiculos.modelo = nuevoVehiculo.modelo;
                        nuevo.Vehiculos.matricula = nuevoVehiculo.matricula;
                        nuevo.maxPersonas = numPasajeros;
                        nuevo.tipo = 1;

                        db.DepTransporte.Add(nuevo);
                        db.SaveChanges();

                        nuevoVehiculo.ID = nuevo.vehiculoID;

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Has creado un nuevo automovil con las siguientes caracteristicas: \nMarca: {nuevoVehiculo.marca} \nModelo: {nuevoVehiculo.modelo} \nMatricula: {nuevoVehiculo.matricula} \nColor: {nuevoVehiculo.color} \nMaximo de pasajeros: {numPasajeros} pasajeros \nID: {nuevoVehiculo.ID}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    if (option2 == "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡Bien! Vamos a añadir una nueva motocicleta, empecemos: ");
                        ToolService.nuevoVehciulo();
                        Console.WriteLine("Porvafor, a capacidad maxima de pasajeros del vehiculo (numeros enteros, por ejemplo: 1 o 50): ");
                        int.TryParse(Console.ReadLine(), out int numPasajeros);

                        Vehiculo nuevoVehiculo = new Motocicleta(0, ToolService.marca, ToolService.modelo, ToolService.matricula, ToolService.color, numPasajeros);
                        listaDeVehiculos.Add(nuevoVehiculo);

                        DepTransporte nuevo = new DepTransporte();
                        nuevo.Vehiculos = new Vehiculos();
                        nuevo.Vehiculos.color = nuevoVehiculo.color;
                        nuevo.Vehiculos.marca = nuevoVehiculo.marca;
                        nuevo.Vehiculos.modelo = nuevoVehiculo.modelo;
                        nuevo.Vehiculos.matricula = nuevoVehiculo.matricula;
                        nuevo.maxPersonas = numPasajeros;
                        nuevo.tipo = 2;

                        db.DepTransporte.Add(nuevo);
                        db.SaveChanges();

                        nuevoVehiculo.ID = nuevo.vehiculoID;

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Has creado un nuevo automovil con las siguientes caracteristicas: \nMarca: {nuevoVehiculo.marca} \nModelo: {nuevoVehiculo.modelo} \nMatricula: {nuevoVehiculo.matricula} \nColor: {nuevoVehiculo.color} \nMaximo de pasajeros: {numPasajeros} pasajetos \nID: {nuevoVehiculo.ID}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    break;
            }
        }





        /* ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        ─██████████████───██████████████─████████████████───████████████████───██████████████─████████████───██████████████─
        ─██░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░░░░░██─
        ─██░░██████░░██───██░░██████░░██─██░░████████░░██───██░░████████░░██───██░░██████░░██─██░░████░░░░██─██░░██████░░██─
        ─██░░██──██░░██───██░░██──██░░██─██░░██────██░░██───██░░██────██░░██───██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
        ─██░░██████░░████─██░░██──██░░██─██░░████████░░██───██░░████████░░██───██░░██████░░██─██░░██──██░░██─██░░██──██░░██─                            
        ─██░░░░░░░░░░░░██─██░░██──██░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░██──██░░██─██░░██──██░░██─
        ─██░░████████░░██─██░░██──██░░██─██░░██████░░████───██░░██████░░████───██░░██████░░██─██░░██──██░░██─██░░██──██░░██─
        ─██░░██────██░░██─██░░██──██░░██─██░░██──██░░██─────██░░██──██░░██─────██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
        ─██░░████████░░██─██░░██████░░██─██░░██──██░░██████─██░░██──██░░██████─██░░██──██░░██─██░░████░░░░██─██░░██████░░██─
        ─██░░░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──██░░░░░░██─██░░██──██░░░░░░██─██░░██──██░░██─██░░░░░░░░████─██░░░░░░░░░░██─
        ─████████████████─██████████████─██████──██████████─██████──██████████─██████──██████─████████████───██████████████─
        ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────── */
        public void borrarVehiculo(string depEnGestion)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("-------------¡CUIDADO!--------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Esta opcion es irreversible, asi que ten cuidado con lo que eliminas");
            Console.WriteLine();
            Console.WriteLine("Porfavor introduce el ID del vehiculo que deseas eliminar");
            Console.WriteLine();
            int borrador = int.Parse(Console.ReadLine());

            Vehiculo listavehiculo = null;
            Vehiculos vehiculos = null;

            switch (depEnGestion)
            {
                case "1":
                    DepCarga depcarga = null;
                    bool complete = false;
                    foreach (var i in listaDeVehiculos)
                    {
                        if (i.ID == borrador)
                        {
                            listavehiculo = i;
                            int id = i.ID;
                            foreach (var x in db.DepCarga)
                            {
                                if (x.vehiculoID == id)
                                {
                                    int vehiculoID = x.vehiculoID;
                                    depcarga = x;

                                    foreach (var y in db.Vehiculos)
                                    {
                                        if (vehiculoID == y.ID)
                                        {
                                            vehiculos = y;
                                            complete = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (depcarga == null)
                    {
                        Console.WriteLine("Haz introducido un ID incorrecto");
                    }
                    listaDeVehiculos.Remove(listavehiculo);
                    db.DepCarga.Remove(depcarga);
                    db.Vehiculos.Remove(vehiculos);
                    db.SaveChanges();

                    Console.WriteLine();
                    if (complete) Console.WriteLine("Vehiculo eliminado de manera exitosa");
                    else Console.WriteLine("Lo siento, no hemos podido eliminar el vehiculo, asegurate de que el ID introducido sea correcto");
                    Console.WriteLine();
                    break;

                case "2":
                    bool complete2 = false;
                    DepTransporte deptransporte = null;
                    foreach (var i in listaDeVehiculos)
                    {
                        if (i.ID == borrador)
                        {
                            listavehiculo = i;
                            int id = i.ID;
                            foreach (var x in this.db.DepTransporte)
                            {
                                if (x.vehiculoID == id)
                                {
                                    int vehiculoID = x.vehiculoID;
                                    deptransporte = x;
                                    foreach (var y in db.Vehiculos)
                                    {
                                        if (vehiculoID == y.ID)
                                        {
                                            vehiculos = y;
                                            complete2 = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    listaDeVehiculos.Remove(listavehiculo);
                    db.DepTransporte.Remove(deptransporte);
                    db.Vehiculos.Remove(vehiculos);
                    db.SaveChanges();
                    if (complete2) Console.WriteLine("Vehiculo eliminado de manera exitosa");
                    else Console.WriteLine("Lo siento, no hemos podido eliminar el vehiculo, asegurate de que el ID introducido sea correcto");
                    break;
            }
        }






        /* ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        ─██████──────────██████─██████████████─████████████───██████████─██████████████─██████████─██████████████─██████████████─████████████████───
        ─██░░██████████████░░██─██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░██─██░░░░░░░░░░██─██░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░░░██───
        ─██░░░░░░░░░░░░░░░░░░██─██░░██████░░██─██░░████░░░░██─████░░████─██░░██████████─████░░████─██░░██████████─██░░██████░░██─██░░████████░░██───
        ─██░░██████░░██████░░██─██░░██──██░░██─██░░██──██░░██───██░░██───██░░██───────────██░░██───██░░██─────────██░░██──██░░██─██░░██────██░░██───
        ─██░░██──██░░██──██░░██─██░░██──██░░██─██░░██──██░░██───██░░██───██░░██████████───██░░██───██░░██─────────██░░██████░░██─██░░████████░░██───
        ─██░░██──██░░██──██░░██─██░░██──██░░██─██░░██──██░░██───██░░██───██░░░░░░░░░░██───██░░██───██░░██─────────██░░░░░░░░░░██─██░░░░░░░░░░░░██───
        ─██░░██──██████──██░░██─██░░██──██░░██─██░░██──██░░██───██░░██───██░░██████████───██░░██───██░░██─────────██░░██████░░██─██░░██████░░████───
        ─██░░██──────────██░░██─██░░██──██░░██─██░░██──██░░██───██░░██───██░░██───────────██░░██───██░░██─────────██░░██──██░░██─██░░██──██░░██─────
        ─██░░██──────────██░░██─██░░██████░░██─██░░████░░░░██─████░░████─██░░██─────────████░░████─██░░██████████─██░░██──██░░██─██░░██──██░░██████─
        ─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░██─██░░██─────────██░░░░░░██─██░░░░░░░░░░██─██░░██──██░░██─██░░██──██░░░░░░██─
        ─██████──────────██████─██████████████─████████████───██████████─██████─────────██████████─██████████████─██████──██████─██████──██████████─
        ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── */




        public void modificarVehiculo()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("-------------¡CUIDADO!--------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Esta opcion es peligrosa, asi que ten cuidado con lo que modificas");
            Console.WriteLine();
            Console.WriteLine("Porfavor introduce el ID del vehiculo que deseas modificar");
            Console.WriteLine();

            int.TryParse(Console.ReadLine(), out int result);
            Vehiculo item = null;

            listaDeVehiculos.ForEach(delegate (Vehiculo i)
            {
                if (i.ID == result)
                {
                    item = i;
                    Console.WriteLine("¡ATENCION!");
                    Console.WriteLine($"Vas a modificar el siguiente vehiculo: \nMarca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID}");

                    if (i is DtoCarga)
                    {
                        ((DtoCarga)item).capacidadKG = ((DtoCarga)i).capacidadKG;
                        Console.WriteLine($"Capacidad de carga: {((DtoCarga)i).capacidadKG}");
                    }
                    else
                    {
                        ((DtoTransporte)item).capacidadDePersonas = ((DtoTransporte)i).capacidadDePersonas;
                        Console.WriteLine($"Capacidad de carga: {((DtoTransporte)i).capacidadDePersonas}");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            });
            if (item == null)
            {
                Console.WriteLine("No hemos encontrado ningun vehiculo con ese ID, intentalo de nuevo");
            }
            else
            {
                Vehiculos vehiculo = null;
                foreach (var x in db.Vehiculos)
                {
                    if (x.ID == result)
                    {
                        vehiculo = x;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("¿Que le deseas modificar a este vehiculo?");
                Console.WriteLine();
                Console.WriteLine("1 - Marca");
                Console.WriteLine("2 - Modelo");
                Console.WriteLine("3 - Color");
                Console.WriteLine("4 - Capacidad de Carga/Transporte");
                Console.WriteLine("5 - Matricula");
                Console.WriteLine();
                Console.WriteLine("SELECCIONA UNA OPCION PARA CONTINUAR");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Bien, vamos a modificar la marca del vehiculo. \nIntroduce la nueva marca: ");
                        Console.WriteLine();
                        item.marca = Console.ReadLine();
                        vehiculo.marca = item.marca;
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Bien, vamos a modificar el modelo del vehiculo. \nIntroduce el nuevo modelo: ");
                        Console.WriteLine();
                        item.modelo = Console.ReadLine();
                        vehiculo.modelo = item.modelo;
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Bien, vamos a modificar el color del vehiculo. \nIntroduce el nuevo color: ");
                        Console.WriteLine();
                        item.color = Console.ReadLine();
                        vehiculo.color = item.color;
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Bien, vamos a modificar la capacidad de carga/transporte del vehiculo. \nIntroduce la nueva capacidad: ");
                        Console.WriteLine();
                        if (item is DtoCarga)
                        {
                            ((DtoCarga)item).capacidadKG = int.Parse(Console.ReadLine());
                            DepCarga modify = null;
                            foreach (var x in db.DepCarga)
                            {
                                if (x.vehiculoID == result)
                                {
                                    x.cargaMax = ((DtoCarga)item).capacidadKG;
                                    modify = x;
                                }
                            }
                            db.Entry(modify).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                        }
                        else
                        {
                            ((DtoTransporte)item).capacidadDePersonas = int.Parse(Console.ReadLine());
                            DepTransporte modify = null;
                            foreach (var x in db.DepTransporte)
                            {
                                if (x.vehiculoID == result)
                                {
                                    x.maxPersonas = ((DtoTransporte)item).capacidadDePersonas;
                                    modify = x;
                                }
                            }

                            db.Entry(modify).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Bien, vamos a modificar la matricula del vehiculo. \nIntroduce la nueva matricula: ");
                        Console.WriteLine();
                        item.matricula = Console.ReadLine();
                        break;
                }
            }
        }


        /* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
         ─██████████████─██████████─██████─────────██████████████─████████████████───██████████████─████████████───██████████████─
         ─██░░░░░░░░░░██─██░░░░░░██─██░░██─────────██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░░░░░░░████─██░░░░░░░░░░██─
         ─██░░██████████─████░░████─██░░██─────────██████░░██████─██░░████████░░██───██░░██████░░██─██░░████░░░░██─██░░██████░░██─
         ─██░░██───────────██░░██───██░░██─────────────██░░██─────██░░██────██░░██───██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
         ─██░░██████████───██░░██───██░░██─────────────██░░██─────██░░████████░░██───██░░██████░░██─██░░██──██░░██─██░░██──██░░██─
         ─██░░░░░░░░░░██───██░░██───██░░██─────────────██░░██─────██░░░░░░░░░░░░██───██░░░░░░░░░░██─██░░██──██░░██─██░░██──██░░██─
         ─██░░██████████───██░░██───██░░██─────────────██░░██─────██░░██████░░████───██░░██████░░██─██░░██──██░░██─██░░██──██░░██─
         ─██░░██───────────██░░██───██░░██─────────────██░░██─────██░░██──██░░██─────██░░██──██░░██─██░░██──██░░██─██░░██──██░░██─
         ─██░░██─────────████░░████─██░░██████████─────██░░██─────██░░██──██░░██████─██░░██──██░░██─██░░████░░░░██─██░░██████░░██─
         ─██░░██─────────██░░░░░░██─██░░░░░░░░░░██─────██░░██─────██░░██──██░░░░░░██─██░░██──██░░██─██░░░░░░░░████─██░░░░░░░░░░██─
         ─██████─────────██████████─██████████████─────██████─────██████──██████████─██████──██████─████████████───██████████████─
         ───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── */



        //---------------------------------------
        //-------FILTRADOS DEL DEP CARGA---------
        //---------------------------------------
        public void filtradosDepCarga(string option)
        {

            int contador;
            switch (option)
            {
                //FILTRAR POR ID
                case "1":
                    contador = 0;
                    Console.WriteLine("¿Que ID deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    int ID = int.Parse(Console.ReadLine());


                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.ID == ID && i is DtoCarga)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG}");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
                //FILTRAR POR MARCA
                case "2":
                    contador = 0;
                    Console.WriteLine("¿Que marca deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string marca = Console.ReadLine();


                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.marca.Equals(marca) && i is DtoCarga)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG}");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR MODELO
                case "3":
                    contador = 0;
                    Console.WriteLine("¿Que modelo deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string modelo = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.modelo.Equals(modelo) && i is DtoCarga)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG} toneladas");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR COLOR
                case "4":
                    contador = 0;
                    Console.WriteLine("¿Que color deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string color = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.color.Equals(color) && i is DtoCarga)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG} toneladas");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR CAPACIDAD DE CARGA
                case "5":
                    contador = 0;
                    Console.WriteLine("¿Que capacidad deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    int maxCarga = int.Parse(Console.ReadLine());

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i is DtoCarga)
                        {
                            if (((DtoCarga)i).capacidadKG == maxCarga)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG} toneladas");
                                Console.WriteLine();
                            }
                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
                //FILTRAR POR TIPO DE VEHICULO
                case "6":
                    contador = 0;
                    Console.WriteLine("¿Que tipo de vehiculo deseas buscar?");
                    Console.WriteLine("Escribe 'camion' o escribe 'remolque'>>");
                    Console.WriteLine();
                    Console.Write("---> ");
                    var tipo = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (tipo.Equals("remolque"))
                        {
                            if (i is Remolque)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG} toneladas");
                                Console.WriteLine();
                            }
                        }
                        if (tipo.Equals("camion"))
                        {
                            if (i is Camion)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoCarga)i).capacidadKG} toneladas");
                                Console.WriteLine();
                            }
                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
            }
        }
        //--------------------------------------------
        //-------FILTRADOS DEL DEP TRANSPORTE---------
        //--------------------------------------------
        public void filrarVehiculosDeTrasnporte(string opcion)
        {
            int contador;
            switch (opcion)
            {
                //FILTRAR POR ID
                case "1":
                    contador = 0;
                    Console.WriteLine("¿Que ID deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    int ID = int.Parse(Console.ReadLine());


                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.ID == ID && i is DtoTransporte)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas}");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
                //FILTRAR POR MARCA
                case "2":
                    contador = 0;
                    Console.WriteLine("¿Que marca deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string marca = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.marca.Equals(marca) && i is DtoTransporte)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas} pasajeros");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR MODELO
                case "3":
                    contador = 0;
                    Console.WriteLine("¿Que modelo deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string modelo = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.modelo.Equals(modelo) && i is DtoTransporte)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas} pasajeros");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR COLOR
                case "4":
                    contador = 0;
                    Console.WriteLine("¿Que color deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    string color = Console.ReadLine();

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i.color.Equals(color) && i is DtoTransporte)
                        {

                            contador++;
                            Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas} pasajeros");
                            Console.WriteLine();

                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;

                //FILTRAR POR CAPACIDAD DE TRANSPORTE
                case "5":
                    contador = 0;
                    Console.WriteLine("¿Que capacidad deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    int maxCarga = int.Parse(Console.ReadLine());

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (i is DtoTransporte)
                        {
                            if (((DtoTransporte)i).capacidadDePersonas == maxCarga)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas} pasajeros");
                                Console.WriteLine();
                            }
                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
                //FILTRAR POR TIPO DE VEHICULO
                case "6":
                    contador = 0;
                    Console.WriteLine("¿Que tipo de vehiculo deseas buscar?");
                    Console.WriteLine();
                    Console.Write("---> ");
                    var tipo = Console.ReadLine().ToLower(); ;

                    listaDeVehiculos.ForEach(delegate (Vehiculo i)
                    {
                        if (tipo.Equals("automovil"))
                        {
                            if (i is Automovil)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas} pasajeros");
                                Console.WriteLine();
                            }
                        }
                        if (tipo.Equals("motocicleta"))
                        {
                            if (i is Motocicleta)
                            {
                                contador++;
                                Console.WriteLine($"Marca: {i.marca} \nModelo: {i.modelo} \nMatricula: {i.matricula} \nColor: {i.color} \nID: {i.ID} \nMax Carga: {((DtoTransporte)i).capacidadDePersonas}");
                                Console.WriteLine();
                            }
                        }
                    });
                    Console.WriteLine($"Se encontraron {contador} resultados que coinciden con tu busqueda.");
                    break;
            }
        }
    }
}
