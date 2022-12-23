using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityRoleMenu
{
    public int RoleMenuId { get; set; }

    public string? RolesCode { get; set; }

    public int? MenuId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual SecurityMenu? Menu { get; set; }
}
