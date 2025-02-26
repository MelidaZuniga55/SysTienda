using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Factura
{
    [Key]
    public int IdFactura { get; set; }

    [Column("Cliente_Id")]
    public int ClienteId { get; set; }

    [Column("Fecha_Factura")]
    public DateOnly FechaFactura { get; set; }

    [Column("Fecha_Vencimiento")]
    public DateOnly FechaVencimiento { get; set; }

    [Column("SubTotal_sin_iva", TypeName = "decimal(18, 0)")]
    public decimal SubTotalSinIva { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Descuento { get; set; }

    [Column("IVA", TypeName = "decimal(18, 0)")]
    public decimal Iva { get; set; }

    [Column("Total_Con_IVA", TypeName = "decimal(18, 0)")]
    public decimal TotalConIva { get; set; }

    [Column("Importe_Pagado", TypeName = "decimal(18, 0)")]
    public decimal ImportePagado { get; set; }

    [Column("Importe_Pagar", TypeName = "decimal(18, 0)")]
    public decimal ImportePagar { get; set; }

    [InverseProperty("IdDetalleFacturaNavigation")]
    public virtual DetalleFactura? DetalleFactura { get; set; }

    [ForeignKey("IdFactura")]
    [InverseProperty("Factura")]
    public virtual Cliente IdFacturaNavigation { get; set; } = null!;
}
