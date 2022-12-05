module Day3
open System

let halfLength (line: string) =
    line.Length / 2

let firstHalf (line: string) =
    let half = halfLength line

    line
    |> Seq.take half  

let lastHalf (line: string) =
    let half = halfLength line

    line
    |> Seq.skip half
    |> Seq.take half

let asSets (first, last) = (Set.ofSeq first, Set.ofSeq last)
let intersect (first, last) = Set.intersect first last

let lowerCharToScore char = int char - int 'a' + 1
let upperCharToScore char = int char - int 'A' + 27

let score (char: char) =
    match char with
    | char when Char.IsLower(char) -> lowerCharToScore char
    | char -> upperCharToScore char

// set intersection is good way to find items common to a number of sets
let parse (lines: string[]) =
    lines
    |> Seq.map (fun r -> (firstHalf r, lastHalf r))
    |> Seq.map asSets
    |> Seq.map intersect
    |> Seq.map Set.toSeq
    |> Seq.concat

// turn each chunk into a set with intersections
let parseChunk x =
    x 
    |> Seq.map Set.ofSeq
    |> Set.intersectMany

let parseChunks (lines: string[]) =
    lines
    |> Seq.splitInto (lines.Length / 3) // split lines into chunks of 3
    |> Seq.map parseChunk               
    |> Seq.map Set.toSeq
    |> Seq.concat // flatten seq of seq of char into a seq of char 

let part1 (lines: string[]) =   
    parse lines
    |> Seq.map score
    |> Seq.sum

let part2 (lines: string[]) = 
    parseChunks lines
    |> Seq.map score
    |> Seq.sum