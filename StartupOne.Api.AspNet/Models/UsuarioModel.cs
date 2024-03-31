using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StartupOne.Api.AspNet.Models
{
    [Table("STRT_ON_USUARIO")]
    public class UsuarioModel
    {
        //Atributos

        [Key]
        [Column("CPF_USUARIO")]
        [StringLength(11)]
        public string CpfUsuario { get; set; }

        [Column("NOME_USUARIO")]
        [Required]
        [StringLength(70)]
        public string NomeUsuario { get; set; }

        [Column("EMAIL_USUARIO")]
        [Required]
        [StringLength(255)]
        public string EmailUsuario { get; set; }

        [Column("TEL_USUARIO")]
        [Required]
        [StringLength(11)]
        public string TelefoneUsuario { get; set; }

        [Column("CIDADE")]
        [Required]
        [StringLength(31)]
        public string CidadeUsuario { get; set; }

        [Column("UF")]
        [Required]
        [StringLength(2)]
        public string UfUsuario { get; set; }

        //Navegation Property

        [JsonIgnore]
        public IList<ServicoModel>? Servicos { get; set; }

        //Construtores

        public UsuarioModel()
        {
        }

        public UsuarioModel(string cpfUsuario)
        {
            CpfUsuario=cpfUsuario;
        }

        public UsuarioModel(string cpfUsuario, string nomeUsuario, string emailUsuario, string telefoneUsuario, string cidadeUsuario, string ufUsuario)
        {
            CpfUsuario=cpfUsuario;
            NomeUsuario=nomeUsuario;
            EmailUsuario=emailUsuario;
            TelefoneUsuario=telefoneUsuario;
            CidadeUsuario=cidadeUsuario;
            UfUsuario=ufUsuario;
        }
    }
}
