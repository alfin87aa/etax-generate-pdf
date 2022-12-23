using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class PaymentStatusSap
{
    public Guid PaymentId { get; set; }

    public string? TransNumber { get; set; }

    public string? CompanyCode { get; set; }

    public string? VendorNpwp { get; set; }

    public string? TaxNumber { get; set; }

    public string? TaxPeriodMonth { get; set; }

    public int? TaxPeriodYear { get; set; }

    public DateTime? PostingDate { get; set; }

    public decimal? TaxPpn { get; set; }

    public string? PaymentStatus { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? PostingDateSap { get; set; }
}
