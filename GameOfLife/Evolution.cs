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

        public static IList<Settlement> Evolve(IEnumerable<Settlement> settlements)
        {
            var oldWorld = new HashSet<Settlement>(settlements);
            var settlementAndNeighbourCounts = oldWorld.SelectMany(Evolution.GenerateNeighbours)
                                               .GroupBy(s => new {s.X, s.Y})
                                               .Select(gs => new { Settlement = new Settlement(gs.Key.X, gs.Key.Y), NeighbourCount = gs.Count() });


            var evolution = settlementAndNeighbourCounts.Where(sn =>
                                sn.NeighbourCount == 3 || 
                                (sn.NeighbourCount == 2 && oldWorld.Contains(sn.Settlement)))//oldWorld.Any(s => s.Equals(sn.Settlement))))
                            .Select(sn => new Settlement(sn.Settlement.X, sn.Settlement.Y))
                            .ToList();
            return evolution;
        }
    }
}
