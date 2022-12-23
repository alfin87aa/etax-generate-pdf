using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterCompany
{
    public string CompanyCode { get; set; } = null!;

    public string? Description { get; set; }

    public string? Npwp { get; set; }

    public string? Address { get; set; }

    public string? PostalCode { get; set; }

    public string? Telp { get; set; }

    public string? Fax { get; set; }

    public string? Hp { get; set; }

    public string? Ttd { get; set; }

    public string? Position { get; set; }

    public string? Domain { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual ICollection<TaxHeaderBackup> TaxHeaderBackups { get; } = new List<TaxHeaderBackup>();

    public virtual ICollection<TaxOther> TaxOthers { get; } = new List<TaxOther>();
}
