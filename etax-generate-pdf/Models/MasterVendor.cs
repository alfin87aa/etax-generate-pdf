using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterVendor
{
    public long VendorId { get; set; }

    public string? Npwp { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
