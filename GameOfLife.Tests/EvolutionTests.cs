using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class EvolutionTests
    {
        [Theory]
        public void Settlement_should_have_eight_potential_neighbours(Settlement settlement)
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(settlement);
            Assert.AreEqual(8, potentialNeighbours.Count());
        }

        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_0_0()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(0,0), potentialNeighbours.ToList());
        }

        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_1_0()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(1,0), potentialNeighbours.ToList());
        }
        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_2_0()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(2,0), potentialNeighbours.ToList());
        }
        
        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_0_1()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(0,1), potentialNeighbours.ToList());
        }

        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_2_1()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(2,1), potentialNeighbours.ToList());
        }
        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_0_2()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(0,2), potentialNeighbours.ToList());
        }

        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_1_2()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(1,2), potentialNeighbours.ToList());
        }

        [Test]
        public void Settlement_of_1_1_should_have_a_neighbour_of_2_2()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.Contains(new Settlement(2,2), potentialNeighbours.ToList());
        }

        [Test]
        public void Settlement_of_1_1_should_not_have_a_neighbour_of_itself()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.True(potentialNeighbours.All(s => !s.Equals(Origin1)));
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_99_99()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(99,99), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_100_99()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(100,99), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_101_99()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(101,99), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_99_100()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(99,100), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_101_100()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(101,100), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_99_101()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(99,101), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_100_101()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(100,101), neighbours.ToList());
        }

        [Test]
        public void Settlement_of_100_100_should_have_a_neighbour_of_101_101()
        {
            var neighbours = Evolution.GenerateNeighbours(Origin100);
            Assert.Contains(new Settlement(101,101), neighbours.ToList());
        }


        [Test]
        public void Generated_neighbours_should_have_no_duplicate_settlements()
        {
            var potentialNeighbours = Evolution.GenerateNeighbours(Origin1);
            Assert.AreEqual(8, potentialNeighbours.Distinct().Count());
        }

        [Datapoint]
        public Settlement Origin1 =  new Settlement(1,1);

        [Datapoint]
        public Settlement Origin = new Settlement(0, 0);

        [Datapoint]
        public Settlement Origin2_1 = new Settlement(2, 1);

        [Datapoint] public Settlement Origin100 = new Settlement(100,100);
    };
}
