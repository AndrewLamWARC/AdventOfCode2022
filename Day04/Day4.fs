module Day4
open System

let toIntList (first, last) = [(int first)..(int last)]
let split (separator: string) (line: string) = line.Split(separator)
let first s = Seq.head s
let second s = Seq.head (Seq.skip 1 s)

let parseLine (line: string) =
    line
    |> split ","
    |> Seq.map (fun row -> split "-" row)
    |> Seq.map (fun x -> (first x, second x))
    |> Seq.map toIntList
    |> Seq.map Set.ofSeq
    |> (fun x -> (first x, second x))
        
// set intersection is good way to find items common to a number of sets
let parse (lines: string[]) =
    lines
    |> Seq.map parseLine

let part1 (lines: string[]) =   
    parse lines
    |> Seq.map (fun (s1, s2) -> Set.isSubset s1 s2 || Set.isSubset s2 s1)
    |> Seq.map (fun b -> if b then 1 else 0)
    |> Seq.sum


let part2 (lines: string[]) = 
    parse lines
    |> Seq.map (fun (s1, s2) -> Set.isEmpty (Set.intersect s1 s2))
    |> Seq.map (fun b -> if b then 0 else 1)
    |> Seq.sum