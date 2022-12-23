using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityRole
{
    public string RolesCode { get; set; } = null!;

    public string? ApplicationCode { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual SecurityApplication? ApplicationCodeNavigation { get; set; }

    public virtual ICollection<SecurityAuthorization> SecurityAuthorizations { get; } = new List<SecurityAuthorization>();

    public virtual ICollection<SecurityUserRole> SecurityUserRoles { get; } = new List<SecurityUserRole>();
}
