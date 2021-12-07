using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class ContainerComparer : IEqualityComparer<List<Container>>
    {
        public bool Equals(List<Container>? item1, List<Container>? item2)
        {
            if (item1 == null && item2 == null)
                return true;

            if ((item1 != null && item2 == null) || (item1 == null && item2 != null))
                return false;

            return (item1 ?? new()).SequenceEqual(item2 ?? new());
        }

        public int GetHashCode(List<Container> item)
        {
            if (item == null)
            {
                return int.MinValue;
            }
            int hc = item.Count;
            for (int i = 0; i < item.Count; ++i)
            {
                hc = unchecked(hc * 314159 + item[i].Value);
            }
            return hc;
        }
    }
}
