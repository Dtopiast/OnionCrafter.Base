using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Common
{
    public interface ICopyable<T>
    {
        public void ToCopy(T ToCopy);
    }
}