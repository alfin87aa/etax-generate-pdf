using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class ConfigEmail
{
    public int ConfigEmailId { get; set; }

    public string? EmailFrom { get; set; }

    public string? EmailPic1 { get; set; }

    public string? EmailPic2 { get; set; }

    public string? EmailSmtp { get; set; }

    public string? CompanyCode { get; set; }

    public string? EmailType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int? RowStatus { get; set; }
}
