namespace Dominio
{
    public class Pacote
    {
        public int IdPacote { get; set; }
        public string DsPacote { get; set; } = string.Empty;
        public IEnumerable<Processo>? Processos { get; set; }
    }
}
