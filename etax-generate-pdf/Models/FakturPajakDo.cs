using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class FakturPajakDo
{
    public Guid Id { get; set; }

    public string? KodeDealer { get; set; }

    public string? KodeOutlet { get; set; }

    public string? ClaimId { get; set; }

    public string? KwitansiId { get; set; }

    public string? NomorFakturPajak { get; set; }

    public string? LinkFakturPajak { get; set; }

    public DateTime? DateScan { get; set; }

    public string? ClaimType { get; set; }

    public string? UnitType { get; set; }

    public string? PathFile { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsProcess1 { get; set; }

    public bool? IsProcess3 { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }
}
