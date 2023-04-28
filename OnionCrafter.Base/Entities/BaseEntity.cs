using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

     
    }
    public abstract class BaseEntity : IEntity<string>
    {
        public virtual string Id { get; set; }
    }
}
