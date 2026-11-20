using System.Collections.Generic;
using Domain.Core.Models;

namespace Domain.Core.Comparers
{
    public class OrderCostComparer : IComparer<RepairOrder>
    {
        public int Compare(RepairOrder? x, RepairOrder? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.CalculateTotalCost().CompareTo(y.CalculateTotalCost());
        }
    }
}