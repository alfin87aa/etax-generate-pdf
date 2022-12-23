using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class VatInRecieveTemporary
{
    public long VatInTemporary { get; set; }

    public string? TaxNumber { get; set; }

    public string? OriNpwp { get; set; }

    public decimal? OriPpn { get; set; }

    public string? OriBusinessArea { get; set; }

    public DateTime? OriPostingDate { get; set; }

    public string? Url { get; set; }

    public string? TaxFp { get; set; }

    public string? TaxPeriodMonth { get; set; }

    public int? TaxPeriodYear { get; set; }

    public DateTime? TaxDate { get; set; }

    public string? VendorNpwp { get; set; }

    public string? VendorName { get; set; }

    public string? VendorAddress { get; set; }

    public decimal? TaxDpp { get; set; }

    public decimal? TaxPpn { get; set; }

    public decimal? TaxPpnbm { get; set; }

    public bool? IsCreditable { get; set; }

    public DateTime? PostingDate { get; set; }

    public string? Note { get; set; }

    public int? StatusId { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
