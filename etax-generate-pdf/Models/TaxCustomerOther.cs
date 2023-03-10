using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxCustomerOther
{
    public long CustomerOthersId { get; set; }

    public string? Npwp { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? No { get; set; }

    public string? Blok { get; set; }

    public string? Rt { get; set; }

    public string? Rw { get; set; }

    public string? Kecamatan { get; set; }

    public string? Kelurahan { get; set; }

    public string? Kabupaten { get; set; }

    public string? Propinsi { get; set; }

    public string? PostalCode { get; set; }

    public string? Telpon { get; set; }

    public string? Email { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual ICollection<TaxHeaderBackup> TaxHeaderBackups { get; } = new List<TaxHeaderBackup>();

    public virtual ICollection<TaxHeader> TaxHeaders { get; } = new List<TaxHeader>();
}
