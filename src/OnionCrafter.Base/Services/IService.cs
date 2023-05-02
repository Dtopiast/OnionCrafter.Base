using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Services
{
    public interface IService<TServiceOptions> : IBaseService
        where TServiceOptions : IServiceOptions
    {
        public TServiceOptions _config { get; }
    }

    public interface IService : IBaseService
    {
    }
}