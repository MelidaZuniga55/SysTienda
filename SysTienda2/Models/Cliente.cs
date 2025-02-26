using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Column("Cliente_Nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClienteNombre { get; set; } = null!;

    [Column("Cliente_Dirección")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClienteDirección { get; set; } = null!;

    [InverseProperty("IdFacturaNavigation")]
    public virtual Factura? Factura { get; set; }
}
