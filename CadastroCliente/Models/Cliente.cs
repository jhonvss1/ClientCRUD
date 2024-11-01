using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Cliente 
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserCPF { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }

    }
}
