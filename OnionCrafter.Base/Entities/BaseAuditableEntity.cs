﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Entities
{
    public class BaseAuditableEntity<TKey> : IAuditableEntity<TKey>
    {
        public TKey Id { get; set; }
    }
    public class BaseAuditableEntity : IAuditableEntity<string>
    {
        public string Id { get; set; }

    }
}
