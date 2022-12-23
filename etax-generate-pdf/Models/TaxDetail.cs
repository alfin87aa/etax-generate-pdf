using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxDetail
{
    public long TaxDetailId { get; set; }

    public long? TaxHeaderId { get; set; }

    public string? MaterialCode { get; set; }

    public string? MaterialName { get; set; }

    public decimal? Price { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Dpp { get; set; }

    public decimal? Ppn { get; set; }

    public decimal? PpnbmCharge { get; set; }

    public decimal? Ppnbm { get; set; }

    public string? Pph22 { get; set; }

    public string? ItemReference { get; set; }

    public string? DocumentReference { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
