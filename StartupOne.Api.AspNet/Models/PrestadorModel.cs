using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StartupOne.Api.AspNet.Models
{
    [Table("STRT_ON_PRESTADOR")]
    public class PrestadorModel
    {
        //Atributos

        [Key]
        [Column("CPF_PRESTADOR")]
        [StringLength(11)]
        public string CpfPrestadorId { get; set; }

        [Column("NOME_PRESTADOR")]
        [Required]
        [StringLength(70)]
        public string NomePrestador { get; set; }

        [Column("EMAIL_PRESTADOR")]
        [Required]
        [StringLength(255)]
        public string EmailPrestador { get; set; }

        [Column("TEL_PRESTADOR")]
        [Required]
        [StringLength(11)]
        public string TelefonePrestador { get; set; }

        [Column("CIDADE")]
        [Required]
        [StringLength(31)]
        public string CidadePrestador { get; set; }

        [Column("UF")]
        [Required]
        [StringLength(2)]
        public string UfPrestador { get; set; }

        [Column("REG_PROFISSIONAL")]
        [Required]
        [StringLength(9)]
        public string RegistroProfissional { get; set; }

        [Column("VALOR_HORA")]
        [Required]
        public float ValorHora { get; set; }

        [Column("ESPECIALIDADE")]
        [Required]
        [StringLength(255)]
        public string Especialidade { get; set; }

        //Navegation Property

        [JsonIgnore]
        public IList<ServicoModel>? Servicos { get; set; }

        //Construtores

        public PrestadorModel()
        {
        }

        public PrestadorModel(string cpfPrestadorId)
        {
            CpfPrestadorId=cpfPrestadorId;
        }

        public PrestadorModel(string cpfPrestadorId, string nomePrestador, string emailPrestador, string telefonePrestador, string cidadePrestador, string ufPrestador, string registroProfissional, float valorHora, string especialidade)
        {
            CpfPrestadorId=cpfPrestadorId;
            NomePrestador=nomePrestador;
            EmailPrestador=emailPrestador;
            TelefonePrestador=telefonePrestador;
            CidadePrestador=cidadePrestador;
            UfPrestador=ufPrestador;
            RegistroProfissional=registroProfissional;
            ValorHora=valorHora;
            Especialidade=especialidade;
        }
    }
}
