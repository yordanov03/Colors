using System;
using System.Collections.Generic;

namespace Colors.Domain.Common
{
    public interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> GetData();
    }
}
