using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityUserRole
{
    public int UserRolesId { get; set; }

    public int UserId { get; set; }

    public string RolesCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual SecurityRole RolesCodeNavigation { get; set; } = null!;

    public virtual SecurityUser User { get; set; } = null!;
}
