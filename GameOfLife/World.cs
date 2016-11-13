using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        public IList<Settlement> Settlements { get; private set; }
        public World(IList<Settlement> settlements)
        {
            Settlements = settlements;
        }

        public static IList<Settlement> GenerateNeighbours(Settlement settlement)
        {
            var offset = new []{-1, 0, 1};
            return (from x in offset 
                    from y in offset 
                    where x != 0 || y != 0 
                    select new Settlement(settlement.X + x, settlement.Y + y)).ToList();
        }
    }
}
