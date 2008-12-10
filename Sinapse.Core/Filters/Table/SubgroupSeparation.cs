using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters.Table
{
    /// <summary>
    ///   This filter can add an additional column in a Table specifying subgroups
    ///  for the rows using integer values, i.e. '1' for the first subgroup, '2'
    ///  for the second subgroup and so on.
    /// </summary>
    class SubgroupSeparation : IFilter
    {
        string newColumnName;
    }
}
