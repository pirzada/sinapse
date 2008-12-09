using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core
{
    
    public interface ISerializableObject<T>
    {
        string Name { get; set;}

        string Description { get; set;}

        string Location { get; set; }

        string Remarks { get; set;}

        bool HasChanges { get; set; }

        // DateTime Creation { get; }

        bool Save(string path);
        bool Save();

    }
}
