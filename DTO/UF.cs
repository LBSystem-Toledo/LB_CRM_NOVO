namespace Dominio
{
    public class UF
    {
        public int Cd_uf { get; set; }
        public string Ds_uf { get; set; } = string.Empty;
        public string Sg_uf { get; set; } = string.Empty;
        public ICollection<Cidade>? Cidades { get; set; }
    }
}
