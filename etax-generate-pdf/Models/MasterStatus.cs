using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterStatus
{
    public int StatusId { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public string? Root { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual ICollection<TaxHeaderBackup> TaxHeaderBackups { get; } = new List<TaxHeaderBackup>();

    public virtual ICollection<TaxOther> TaxOthers { get; } = new List<TaxOther>();

    public virtual ICollection<VatInRecieve> VatInRecieves { get; } = new List<VatInRecieve>();
}
