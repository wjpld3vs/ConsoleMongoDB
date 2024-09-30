using ConsoleMongoDB.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleMongoDB.Servicios
{
    public class ClienteService
    {
        private readonly IMongoCollection<ClienteModel> _clientes;

        // constructor
        public ClienteService(MongoDBContext context)
        {
            _clientes = context.ColeccionCliente;
        }

        // CRUD
        // Agregar cliente
        public void CrearCliente(ClienteModel cliente)
        { 
            _clientes.InsertOne(cliente);
            Console.WriteLine("Se ha creado un cliente...");
        }

        // Obtener clientes
        public List<ClienteModel> ObtenerClientes()
        {
            return _clientes.Find(cliente => true).ToList();
        }

        // Obtener cliente por id
        public ClienteModel ObtenerClientePorId(string id)
        {
            return _clientes.Find
                (cliente => cliente.Id == ObjectId.Parse(id)).FirstOrDefault();
        }

        // Actualizar cliente
        public void ActualizarCliente(string id, ClienteModel clienteActualizado)
        {
            _clientes.ReplaceOne(cliente => cliente.Id == ObjectId.Parse(id), clienteActualizado);
            Console.WriteLine("Cliente actualizado correctamente");
        }

        // Eliminar cliente
        public void EliminarCliente(string id)
        {
            _clientes.DeleteOne(cliente => cliente.Id == ObjectId.Parse(id));
            Console.WriteLine("Cliente eliminado correctamente");
        }

    }
}
