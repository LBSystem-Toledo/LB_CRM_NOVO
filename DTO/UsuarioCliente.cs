namespace Dominio
{
    public class UsuarioCliente
    {
        public int IdCliente { get; set; }
        public int IdLogin { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool NotificaEvolucao { get; set; }
        public bool Inativo { get; set; }
    }
}
