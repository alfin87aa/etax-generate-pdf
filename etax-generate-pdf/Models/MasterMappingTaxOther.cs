using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterMappingTaxOther
{
    public int MasterMappingTaxOthersId { get; set; }

    public bool? DocumentType { get; set; }

    public int? TransactionId { get; set; }

    public string? IsRetur { get; set; }

    public string? TransactionTypeCode { get; set; }

    public int? DocumentTypeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }

    public short? MappingTransactionId { get; set; }

    public short? MappingIsRetur { get; set; }

    public short? MappingTransactionTypeCode { get; set; }

    public short? MappingDocumentTypeId { get; set; }
}
