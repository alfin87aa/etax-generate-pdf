using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogLogin
{
    public Guid LoginUid { get; set; }

    public DateTime AccessDate { get; set; }

    public string DomainUser { get; set; } = null!;

    public string ClientIp { get; set; } = null!;

    public string ClientHostname { get; set; } = null!;

    public bool? IsLogged { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual ICollection<LogActivity> LogActivities { get; } = new List<LogActivity>();
}
