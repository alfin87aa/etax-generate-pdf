using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityOperation
{
    public string OperationsCode { get; set; } = null!;

    public string ApplicationCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual SecurityApplication ApplicationCodeNavigation { get; set; } = null!;
}
