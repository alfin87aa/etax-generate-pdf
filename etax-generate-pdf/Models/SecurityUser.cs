using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? DisplayName { get; set; }

    public string? Password { get; set; }

    public string? Domain { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public bool? IsExternal { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public virtual ICollection<SecurityUserRole> SecurityUserRoles { get; } = new List<SecurityUserRole>();
}
