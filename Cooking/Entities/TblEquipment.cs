using System;
using System.Collections.Generic;

namespace Cooking.Entities;

public partial class TblEquipment
{
    public long EquipmentId { get; set; }

    public string Equipment { get; set; } = null!;

    public string Usage { get; set; } = null!;
}
