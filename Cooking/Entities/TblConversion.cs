using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblConversion
{
    public long ConversionId { get; set; }

    public decimal FromUnit { get; set; }

    public decimal ToUnit { get; set; }

    public decimal ConversionFactor { get; set; }
}
