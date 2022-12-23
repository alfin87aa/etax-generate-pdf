using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityApplication
{
    public string ApplicationCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual ICollection<SecurityOperation> SecurityOperations { get; } = new List<SecurityOperation>();

    public virtual ICollection<SecurityRole> SecurityRoles { get; } = new List<SecurityRole>();
}
