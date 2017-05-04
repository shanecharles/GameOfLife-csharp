# Conway's Game of Life in C# #

This is a C# solution to [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life).


### The rules:

1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.

2. Any live cell with two or three live neighbours lives on to the next generation.
    
3. Any live cell with more than three live neighbours dies, as if by overpopulation.

4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.


### Running the Tests:

Open the `GameOfLife.sln` in Visual Studio 2015, restore the nuget packages, and run the tests.