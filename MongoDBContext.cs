using ConsoleMongoDB.Modelos;
using MongoDB.Driver;

namespace ConsoleMongoDB
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        // Constructor
        public MongoDBContext()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            var client = new MongoClient(settings);
            _database = client.GetDatabase("TiendaDB");
        }

        // Traer coleccion de clientes
        public IMongoCollection<ClienteModel> ColeccionCliente =>
            _database.GetCollection<ClienteModel>("Cliente");

        // Traer coleccion de ordenes

        public IMongoCollection<OrdenModel> ColeccionOrden =>
            _database.GetCollection<OrdenModel>("Orden");

    }
}
