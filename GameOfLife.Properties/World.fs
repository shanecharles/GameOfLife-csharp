module World

open FsCheck
open GameOfLife
open NUnit.Framework
open FsCheck.NUnit
open Swensen.Unquote

let settlementGen = Arb.generate<int32>
                    |> Gen.two
                    |> Gen.map (fun (x,y) -> new Settlement(x,y))

type SettlementGenerator = 
    static member Value () = 
        settlementGen
        |> Arb.fromGen

type SettlementPropertyAttribute () =
    inherit PropertyAttribute (
        Arbitrary = [| typeof<SettlementGenerator> |])

let filterY yPos (settlement : Settlement) = settlement.Y = yPos
let filterX xPos (settlement : Settlement) = settlement.X = xPos
let numberOfNeighboursOnX x = World.GenerateNeighbours >> Seq.filter (filterX x) >> Seq.length
let numberOfNeighboursOnY y = World.GenerateNeighbours >> Seq.filter (filterY y) >> Seq.length

[<SettlementProperty>]
let ``A settlement should have three possible neighbours with an X-1 position.`` (s : Settlement) =
    let expected = 3
    let result = s |> numberOfNeighboursOnX (s.X - 1)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have two possible neighbours with an X position.`` (s : Settlement) =
    let expected = 2
    let result = s |> numberOfNeighboursOnX (s.X)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have three possible neighbours with an X+1 position.`` (s : Settlement) =
    let expected = 3
    let result = s |> numberOfNeighboursOnX (s.X + 1)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have three possible neighbours with a Y-1 position.`` (s : Settlement) =
    let expected = 3
    let result = s |> numberOfNeighboursOnY (s.Y - 1)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have two possible neighbours with a Y position.`` (s : Settlement) =
    let expected = 2
    let result = s |> numberOfNeighboursOnY (s.Y)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have three possible neighbours with a Y+1 position.`` (s : Settlement) =
    let expected = 3
    let result = s |> numberOfNeighboursOnY (s.Y + 1)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should not have itself as a potential neighbour.`` (s : Settlement) =
    let expected = true
    let result = s |> World.GenerateNeighbours |> Seq.forall (fun n -> n <> s)
    test <@ expected = result @>

[<SettlementProperty>]
let ``A settlement should have exactly eight potential neighbours.`` (s : Settlement) =
    let expected = 8
    let result = s |> World.GenerateNeighbours |> Seq.length
    test <@ expected = result @>