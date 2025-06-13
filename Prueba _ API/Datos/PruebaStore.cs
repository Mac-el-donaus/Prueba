using Prueba___API.Modelos.Dto;

namespace Prueba___API.Datos
{
    public class PruebaStore
    {
        public static List<PruebaDto> PruebaList = new List<PruebaDto>
        {
            new PruebaDto{Id=1, Nombre="vista a la Piscina", Ocupantes=3, MetrosCuadrados=50},
            new PruebaDto{Id=2, Nombre="vista a la playa", Ocupantes=4, MetrosCuadrados=80}
        };
    }
}
