using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }

        public short? KTID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        //[Column(TypeName = "varchar(100)")]
        //public string? CP12Name { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string? CP12Address1 { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string? CP12Address2 { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string? CP12Address3 { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string? CP12Address4 { get; set; }

        //[Column(TypeName = "varchar(10)")]
        //public string? CP12PostCode { get; set; }

        //[Column(TypeName = "varchar(15)")]
        //public string? CP12Telephone { get; set; }

        //[Column(TypeName = "varbinary(MAX)")]
        //public byte[]? CP12Logo { get; set; }

        //[Column(TypeName = "varchar(50)")]
        //public string? Region { get; set; }

        //[Required]
        //public int PBL { get; set; }

        //[Required]
        //public int T1 { get; set; }

        //[Required]
        //public int T2 { get; set; }

        //[Required]
        //public int W1 { get; set; }

        //[Required]
        //public int W2 { get; set; }

        //public short ManagerID { get; set; }

        //[Required]
        //public short SupervisorID { get; set; }

        //[Required]
        //public short AdministratorID { get; set; }

        //[Column(TypeName = "datetime")]
        //public DateTime LastUpdated { get; set; }

        //[Required]
        //[Column(TypeName = "bit")]
        //public bool Chargeable { get; set; }

        //[Required]
        //[Column(TypeName = "bit")]
        //public bool Maintenance { get; set; }

        //[Required]
        //[Column(TypeName = "bit")]
        //public bool Repair { get; set; }

        //[Required]
        //[Column(TypeName = "bit")]
        //public bool Service { get; set; }

        //[Column(TypeName = "bit")]
        //public bool Deleted { get; set; }

        //[Required]
        //public short Additional1ID { get; set; }

        //[Required]
        //public short Additional2ID { get; set; }

        //public short HeadID { get; set; }

        //[Required]
        //public short CompanyID { get; set; }

        //[Column(TypeName = "varchar(15)")]
        //public string? Telephone { get; set; }

        //[Column(TypeName = "varchar(10)")]
        //public string? NavCode { get; set; }

        //[Column(TypeName = "datetime")]
        //public DateTime StartDate { get; set; }

        //[Column(TypeName = "datetime")]
        //public DateTime EndDate { get; set; }

        //public short MOTService { get; set; }

        //[Column(TypeName = "varchar(4)")]
        //public string? Code { get; set; }
    }
}
