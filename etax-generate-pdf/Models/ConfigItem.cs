using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class ConfigItem
{
    public int ItemsId { get; set; }

    public string Key { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }

    public virtual ConfigCategory CategoryCodeNavigation { get; set; } = null!;
}
