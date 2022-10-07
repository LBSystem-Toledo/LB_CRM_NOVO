namespace Dominio
{
    public class Operador
    {
        public int IdParceiro { get; set; }
        public int IdOperador { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NomeOperador { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }
}
