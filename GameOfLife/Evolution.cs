using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Evolution
    {

        public static IList<Settlement> GenerateNeighbours(Settlement settlement)
        {
            var offset = new []{-1, 0, 1};
            return (from x in offset 
                    from y in offset 
                    where x != 0 || y != 0 
                    select new Settlement(settlement.X + x, settlement.Y + y)).ToList();
        }

        public IList<Settlement> Evolve(IEnumerable<Settlement> settlements)
        {
            var oldWorld = new HashSet<Settlement>(settlements);
            var settlementAndNeighbourCounts = oldWorld.SelectMany(Evolution.GenerateNeighbours)
                                               .GroupBy(s => s)
                                               .Select(gs => new {Settlement = gs.Key, NeighbourCount = gs.Count()});
            var evolution = settlementAndNeighbourCounts.Where(sn =>
                                sn.NeighbourCount == 3 
                                || (sn.NeighbourCount == 2 && oldWorld.Contains(sn.Settlement)))
                            .Select(sn => sn.Settlement)
                            .ToList();
            return evolution;
        }
    }
}
