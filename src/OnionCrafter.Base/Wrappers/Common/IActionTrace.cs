using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Wrappers.Common
{
    public interface IActionTrace<TKey>
    {
        public TKey ActionId { get; set; }
    }
}