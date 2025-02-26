using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class DetalleFactura
{
    [Key]
    public int IdDetalleFactura { get; set; }

    public int IdFactura { get; set; }

    [Column("Servicio_Id")]
    public int ServicioId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    [ForeignKey("IdDetalleFactura")]
    [InverseProperty("DetalleFactura")]
    public virtual Factura IdDetalleFacturaNavigation { get; set; } = null!;

    [ForeignKey("ServicioId")]
    [InverseProperty("DetalleFactura")]
    public virtual Servicio Servicio { get; set; } = null!;
}
