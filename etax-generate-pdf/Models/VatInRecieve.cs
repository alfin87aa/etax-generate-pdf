using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class VatInRecieve
{
    public string TaxNumber { get; set; } = null!;

    public string? Url { get; set; }

    /// <summary>
    /// 1:scan
    /// 2:upload csv
    /// 3:manual
    /// 4:upload txt (IPPI)
    /// </summary>
    public byte? Source { get; set; }

    public string? TransactionTypeCode { get; set; }

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

    public DateTime? UploadDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public int? StatusId { get; set; }

    public string? CompanyCode { get; set; }

    public decimal? LastDpp { get; set; }

    public decimal? LastPpnbm { get; set; }

    public string? Ref { get; set; }

    /// <summary>
    /// 0: normal
    /// 1:proses merge Scan1 &amp; 3 IAMI
    /// </summary>
    public byte? TypeInput { get; set; }

    public string? Scan1By { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual MasterStatus? Status { get; set; }

    public virtual MasterTransactionType? TransactionTypeCodeNavigation { get; set; }
}
