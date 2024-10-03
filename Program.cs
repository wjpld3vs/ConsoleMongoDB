using ConsoleMongoDB.Servicios;
using ConsoleMongoDB.Modelos;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace ConsoleMongoDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new MongoDBContext();
            var clienteService = new ClienteService(context);
            var ordenService = new OrdenService(context);

            // Menu
            while (true)
            {
                Console.WriteLine("***** TIENDA ******");
                Console.WriteLine("1. Crear un cliente");
                Console.WriteLine("2. Mostrar clientes");
                Console.WriteLine("3. Actualizar cliente");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("5. Crear una orden");
                Console.WriteLine("6. Mostrar ordenes");
                Console.WriteLine("7. Salir");
                Console.WriteLine("\n Selecciona opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese nombre del cliente: ");
                        var nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el email del cliente: ");
                        var email = Console.ReadLine();
                        var cliente = new ClienteModel { Nombre = nombre, Email = email };
                        clienteService.CrearCliente(cliente);
                        break;

                    case 2:
                        var clientes = clienteService.ObtenerClientes();
                        foreach (var c in clientes)
                        {
                            Console.WriteLine(
                                $"ID: {c.Id} - Nombre: {c.Nombre} - Email: {c.Email}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el ID del cliente: ");
                        var idCliente = Console.ReadLine();
                        var clienteExistente = clienteService.ObtenerClientePorId(idCliente);

                        if (clienteExistente != null)
                        {
                            Console.WriteLine("Ingrese el nuevo nombre del cliente: ");
                            clienteExistente.Nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el nuevo email del cliente: ");
                            clienteExistente.Email = Console.ReadLine();

                            clienteService.ActualizarCliente(idCliente, clienteExistente);
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado");
                        }

                        break;

                    case 4:
                        Console.WriteLine("Ingrese el ID del cliente: ");
                        var idEliminarCliente = Console.ReadLine();

                        clienteService.EliminarCliente(idEliminarCliente);

                        break;

                    case 5:

                        var orden = new OrdenModel
                        {
                            FechaOrden = DateTime.Now,
                            Items = new List<string> { "Producto 1", "Producto 2" },
                            Total = new Random().Next(10, 100)
                        };
                        
                        ordenService.CrearOrden(orden);

                        break;

                    case 6:

                        var ordenes = ordenService.ObtenerOrdenes();
                        foreach (var c in ordenes)
                        {
                            Console.WriteLine(
                            $"ID: {c.Id} - Fecha: {c.FechaOrden} - Productos: {c.Items[0]} - {c.Items[1]} " +
                            $"- Total: {c.Total}");
                        }

                        break;

                    case 7:

                        return;
                }

            }
        }
    }
}
