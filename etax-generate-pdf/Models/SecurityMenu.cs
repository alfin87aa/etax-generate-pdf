using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityMenu
{
    public int MenuId { get; set; }

    public string? ApplicationCode { get; set; }

    public string? GroupMenu { get; set; }

    public string? MenuName { get; set; }

    public string? Url { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual ICollection<SecurityRoleMenu> SecurityRoleMenus { get; } = new List<SecurityRoleMenu>();
}
