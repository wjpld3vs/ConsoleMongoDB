using ConsoleMongoDB.Servicios;
using System.Net.Http.Headers;

namespace ConsoleMongoDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new MongoDBContext();
            var clienteService = new ClienteService(context);
            var ordenService = new OrdenService(context);

            while (true)
            {
                //...
            }
        }
    }
}
