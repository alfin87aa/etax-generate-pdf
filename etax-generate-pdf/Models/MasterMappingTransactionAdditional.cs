using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterMappingTransactionAdditional
{
    public int MappingTransactionAdditionalId { get; set; }

    public string TransactionTypeCode { get; set; } = null!;

    public int? AdditionalInformationId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int? RowStatus { get; set; }
}
