using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Servicio
{
    [Key]
    public int IdServicio { get; set; }

    [Column("Servicio_Descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string ServicioDescripcion { get; set; } = null!;

    [InverseProperty("Servicio")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();
}
