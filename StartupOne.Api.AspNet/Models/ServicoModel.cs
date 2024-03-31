using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StartupOne.Api.AspNet.Models
{
    [Table("STRT_ON_SERVICO")]
    public class ServicoModel
    {
        //Atributos

        [Key]
        [Column("ID_SERVICO")]
        public int Id { get; set; }

        [Required]
        [Column("DESCRICAO")]
        [StringLength(1000)]
        public string Descricao { get; set; }

        [Column("OBS")]
        [StringLength(255)]
        public string Observacao { get; set; }

        [Column("NOTA")]
        public int Nota { get; set; }

        //Chaves Estrangeiras - Foreign Key (FK)

        [ForeignKey("Prestador")]
        [Column("CPF_PRESTADOR")]
        [StringLength(11)]
        public string CpfPrestadorId { get; set; }

        [ForeignKey("Usuario")]
        [Column("CPF_USUARIO")]
        [StringLength(11)]
        public string CpfUsuario { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public PrestadorModel? Prestador { get; set; }

        [JsonIgnore]
        public UsuarioModel? Usuario { get; set; }
    }
}
