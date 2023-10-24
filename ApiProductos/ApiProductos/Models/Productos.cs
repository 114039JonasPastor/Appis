namespace ApiProductos.Models
{
    public class Productos
    {
        private static List<Productos> instancia;

        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public float Precio { get; set; }

        public static List<Productos> ObtenerInstancia()
        {
               if(instancia == null)
            {
                instancia = new List<Productos>();
            }
               return instancia;
        }
    }
}
