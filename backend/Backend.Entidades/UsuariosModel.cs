using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entidades
{
    [Table("usuarios", Schema = "dbo")]
    public class UsuariosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usuario", Order = 1, TypeName = "INT")]
        public int? Id { get; set; }

        [Column("nombre", Order = 2, TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Column("apellido", Order = 3, TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Column("correo_electronico", Order = 4, TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no válido")]
        public string CorreoElectronico {set;get;}

        [Column("fecha_nacimiento", Order = 5, TypeName = "DATETIME")]
        [Required(ErrorMessage = "La fecha de Nacimiento es requerida")]
        public DateTime FechaNacimiento { set; get; }

        [Column("telefono", Order = 6, TypeName = "VARCHAR(8)")] 
        public string Telefono { set; get; }

        [Column("pais_residencia", Order = 7, TypeName = "VARCHAR(5)")]
        [Required(ErrorMessage = "El país es requerido")] 
        public string PaisResidencia { set; get; }

        [Column("contacto", Order = 8, TypeName = "BIT")]
        [Required]
        public bool Contacto { set; get; }

    }
}
