using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxOther
{
    public long TaxOthersId { get; set; }

    /// <summary>
    /// 1:retur
    /// 0:transaction
    /// </summary>
    public bool? IsRetur { get; set; }

    /// <summary>
    /// 0:keluaran
    /// 1:masukan
    /// </summary>
    public bool? Type { get; set; }

    public string? DocumentNumber { get; set; }

    public DateTime? DocumentDate { get; set; }

    public string? PeriodMonth { get; set; }

    public int? PeriodYear { get; set; }

    public int? TransactionId { get; set; }

    public string? TaxOthersFp { get; set; }

    public string? TransactionTypeCode { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? TaxOthersName { get; set; }

    public string? TaxOthersAddress { get; set; }

    public string? TaxOthersNpwp { get; set; }

    public decimal? TaxOthersDpp { get; set; }

    public decimal? TaxOthersPpn { get; set; }

    public decimal? TaxOthersPpnbm { get; set; }

    public string? Assigment { get; set; }

    public string? Aju { get; set; }

    public int? StatusId { get; set; }

    public string? Reference { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public decimal? LastDpp { get; set; }

    public decimal? LastPpnbm { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual MasterCompany? CompanyCodeNavigation { get; set; }

    public virtual MasterDocumentType? DocumentType { get; set; }

    public virtual MasterStatus? Status { get; set; }

    public virtual MasterTransaction? Transaction { get; set; }

    public virtual MasterTransactionType? TransactionTypeCodeNavigation { get; set; }
}
