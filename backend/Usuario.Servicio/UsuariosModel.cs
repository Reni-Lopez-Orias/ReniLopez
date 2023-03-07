using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Entity
{
    [Table("usuarios", Schema = "dbo")]
    public class UsuariosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usuario", Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column("nombre", Order = 2, TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }

        [Column("apellido", Order = 3, TypeName = "VARCHAR(50)")]
        public string Apellido { get; set; }

        [Column("correo_electronico", Order = 4, TypeName = "VARCHAR(50)")]
        public string CorreoElectronico {set;get;}

        [Column("fecha_nacimiento", Order = 5, TypeName = "DATETIME")]
        public DateTime FechaNacimiento { set; get; }

        [Column("telefono", Order = 6, TypeName = "VARCHAR(8)")]
        public string Telefono { set; get; }

        [Column("pais_residencia", Order = 7, TypeName = "VARCHAR(5)")]
        public string PaisResidencia { set; get; }

        [Column("contacto", Order = 8, TypeName = "BIT")]
        public bool Contacto { set; get; }

    }
}
