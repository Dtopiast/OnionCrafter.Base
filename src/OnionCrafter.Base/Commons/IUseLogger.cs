using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for classes that use a logger.
    /// </summary>
    public interface IUseLogger
    {
        /// <summary>
        ///  /// Gets or sets a value indicating whether to use a logger.
        /// </summary>
        public bool UseLogger { get; set; }
    }
}