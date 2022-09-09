namespace Dominio
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Ds_modulo { get; set; } = string.Empty;
        public ICollection<Processo>? Processos { get; set; }
    }
}
