using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxHeader
{
    public long TaxHeaderId { get; set; }

    public string? PdfPath { get; set; }

    public string? CsvPath { get; set; }

    public bool? IsManual { get; set; }

    public string? Currency { get; set; }

    public string? TransactionTypeCode { get; set; }

    public string? TaxFp { get; set; }

    public string TaxNumber { get; set; } = null!;

    public string? TaxPeriodMonth { get; set; }

    public int? TaxPeriodYear { get; set; }

    public DateTime? TaxDate { get; set; }

    public string? TaxNpwp { get; set; }

    public string? TaxName { get; set; }

    public string? TaxAddress { get; set; }

    public decimal? TaxDpp { get; set; }

    public decimal? TaxPpn { get; set; }

    public decimal? TaxPpnbm { get; set; }

    public int? AdditionalInformationId { get; set; }

    /// <summary>
    /// 1:uang muka
    /// </summary>
    public byte? TaxDp { get; set; }

    public decimal? TaxDpDpp { get; set; }

    public decimal? TaxDpPpn { get; set; }

    public decimal? TaxDpPpnbm { get; set; }

    public string? TaxReference { get; set; }

    public string? Ref { get; set; }

    public string? InvoiceList { get; set; }

    public string? BillingType { get; set; }

    public string? BillingNo { get; set; }

    public long? CustomerId { get; set; }

    public long? CustomerOthersId { get; set; }

    public string? CompanyCode { get; set; }

    public string? Note { get; set; }

    public int? StatusId { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public decimal? LastDpp { get; set; }

    public decimal? LastPpnbm { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public string? DokumenPendukung { get; set; }

    public string? CustomerAddress { get; set; }

    public string? IsExpired { get; set; }

    public string? IsMailReminder { get; set; }

    public string? IsMailExpired { get; set; }

    public virtual TaxCustomerOther? CustomerOthers { get; set; }
}
