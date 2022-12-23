using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class VatIn
{
    public string TaxNumber { get; set; } = null!;

    public string? Url { get; set; }

    public string? TransactionTypeCode { get; set; }

    public string? TaxFp { get; set; }

    public DateTime? TaxDate { get; set; }

    public decimal? TaxPpn { get; set; }

    public string? VendorNpwp { get; set; }

    public string? VendorName { get; set; }

    public string? CompanyCode { get; set; }

    public string? StatusApproval { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public string? VendorAddress { get; set; }

    public decimal? TaxDpp { get; set; }

    public decimal? TaxPpnbm { get; set; }

    public bool? IsCreditable { get; set; }
}
