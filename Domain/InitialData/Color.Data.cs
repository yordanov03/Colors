using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models.Common
{
    internal class ColorData : IInitialData
    {
        public Type EntityType => typeof(Color);

        public IEnumerable<object> GetData()
            => new List<Color>
            {
                new Color("blau"),
                new Color("grün"),
                new Color("violett"),
                new Color("rot"),
                new Color("gelb"),
                new Color("türkis"),
                new Color("weiß")
            };
    }
}
