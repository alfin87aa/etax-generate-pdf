using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class Retur
{
    public long ReturId { get; set; }

    /// <summary>
    /// 0:keluaran
    /// 1:masukan
    /// </summary>
    public bool? ReturType { get; set; }

    public string? ReturFp { get; set; }

    public string? TransactionTypeCode { get; set; }

    public string? TaxNumber { get; set; }

    public string? ReturNumber { get; set; }

    public DateTime? TaxDate { get; set; }

    public string? Name { get; set; }

    public string? Npwp { get; set; }

    public DateTime? ReturDate { get; set; }

    public string? ReturPeriodMonth { get; set; }

    public int? ReturPeriodYear { get; set; }

    public decimal? Dpp { get; set; }

    public decimal? Ppn { get; set; }

    public decimal? Ppnbm { get; set; }

    public bool? IsCreditable { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public int? StatusId { get; set; }

    public DateTime? UploadDate { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
