﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Entities
{
    public class BaseAuditableEntity<TKey> : IAuditableEntity<TKey>
    {
        protected BaseAuditableEntity()
        {
            Id = Activator.CreateInstance<TKey>();
        }

        public TKey Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class BaseAuditableEntity : IAuditableEntity<string>
    {
        protected BaseAuditableEntity()
        {
            Id = string.Empty;
        }

        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}