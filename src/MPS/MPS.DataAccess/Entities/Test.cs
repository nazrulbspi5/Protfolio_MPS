﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.DataAccess.Entities
{
    public class Test:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
