using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class Material
{
    public string MaterialCode { get; set; } = null!;

    public int? FuncAreaId { get; set; }

    public bool IsDeleted { get; set; }

    public string? MaterialType { get; set; }

    public string MaterialDesc { get; set; } = null!;

    public bool? IsMapped { get; set; }

    public bool? IsSendDos { get; set; }

    public bool? IsSendSap { get; set; }

    public bool? IsSendPss { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public string? InventoryUnitSymbol { get; set; }

    public string? ItemMajorGroupId { get; set; }

    public string? ItemMinorGroupId { get; set; }

    public string? ClassNumber { get; set; }

    public string? FileName { get; set; }

    public bool? IsNotification { get; set; }

    public bool Stop { get; set; }
}
