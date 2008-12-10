using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters
{
    interface IReversibleFilter : IFilter
    {
        object Output { get; set;}
        void Reverse();
    }
}
