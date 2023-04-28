using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.DTO
{
    public abstract class BaseRequestAuditableDTO : IAuditableDTO
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
