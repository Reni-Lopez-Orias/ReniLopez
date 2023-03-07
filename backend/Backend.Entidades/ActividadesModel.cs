using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entidades
{
    [Table("actividades", Schema = "dbo")]
    public class ActividadesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_actividades", Order = 1, TypeName = "INT")]
        public int? Id { set; get; }

        [Column("create_date", Order = 2, TypeName = "DATETIME")]
        [Required]
        public DateTime CreateDate { set; get; }

        [Column("id_usuario", Order = 3, TypeName = "INT")]
        [ForeignKey("Usuario")]
        [Required] 
        public int IdUsuario { set; get; }
        public UsuariosModel Usuario { set; get; }

        [Column("actividad", Order = 4, TypeName = "VARCHAR(25)")]
        [Required]
        public string Actividad { set; get; }
    }
}
