using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCoreHospitales.Models
{
    [Table("Hospital")]
    public class Hospital
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("DIRECCION")]
        public string Direccion { get; set; }
        [Column("TELEFONO")]
        public string Telefono { get; set; }
        [Column("NUM_CAMA")]
        public int Camas { get; set; }
    }
}
