namespace Hamburguesas.Models
{
    public class Jugador
    {
        public string Nombre { get; set; } = "";
        public int NivelActual { get; set; } = 0;
        public int MejorNivel { get; set; } = 0;
        public int PartidasJugadas { get; set; } = 0;
        public int MejorPuntaje { get; set; } = 0;
    }
}