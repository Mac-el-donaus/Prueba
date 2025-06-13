namespace Prueba___API.Datos
{
    public class Dbcontext
    {
        private DbcontextOptions<ApplicationDbcontext> options;

        public Dbcontext(DbcontextOptions<ApplicationDbcontext> options)
        {
            this.options = options;
        }
    }
}