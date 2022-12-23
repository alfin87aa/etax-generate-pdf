using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogActivity
{
    public Guid ActivitiesUid { get; set; }

    public Guid LoginUid { get; set; }

    public DateTime AccessDate { get; set; }

    public string DomainUser { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual LogLogin LoginU { get; set; } = null!;
}
