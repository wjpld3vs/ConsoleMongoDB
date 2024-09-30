

using ConsoleMongoDB.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleMongoDB.Servicios
{
    public class OrdenService
    {
        private readonly IMongoCollection<OrdenModel> _ordenes;

        // Constructor
        public OrdenService(MongoDBContext context)
        {
            _ordenes = context.ColeccionOrden;
        }

        // CRUD
        // Agregar orden
        public void CrearOrden(OrdenModel orden)
        { 
            _ordenes.InsertOne(orden);
            Console.WriteLine("Orden creada correctamente");
        }

        // Obtener ordenes
        public List<OrdenModel> ObtenerOrdenes()
        { 
            return _ordenes.Find(orden => true).ToList();
        }

        // Obtener una orden por id
        public OrdenModel ObtenerOrdenPorId(string id)
        {
            return _ordenes.Find(orden => orden.Id == ObjectId.Parse(id)).FirstOrDefault();
        }

        // Actualizar orden
        public void ActualizarOrden(string id, OrdenModel ordenActualizada)
        {
            _ordenes.ReplaceOne(
                orden => orden.Id == ObjectId.Parse(id), ordenActualizada);
            Console.WriteLine("Orden actualizada correctamente");
        }

        // Eliminar orden
        public void EliminarOrden(string id)
        {
            _ordenes.DeleteOne(orden => orden.Id == ObjectId.Parse(id));
            Console.WriteLine("Orden eliminada correctamente");
        }

    }
}
