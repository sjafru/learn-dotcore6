﻿using System;
using System.Collections.Generic;

namespace Lib.Employees.Entities
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public short RegionId { get; set; }
        public char RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
