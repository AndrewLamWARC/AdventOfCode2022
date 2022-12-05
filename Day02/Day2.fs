module Day2

type Shape =
    Rock
    | Paper
    | Scissors

type Outcome =
    Win
    | Lose
    | Draw

// string -> Shape
let parseShape x =
    match x with
    | "A" -> Rock
    | "B" -> Paper
    | "C" -> Scissors

// string -> Shape
let parseResponse x =
    match x with
    | "X" -> Rock
    | "Y" -> Paper
    | "Z" -> Scissors

// ('a, Shape) -> int
let scoreShape (_, shape) =
    match shape with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

// Outcome -> int
let scoreOutcome outcome =
    match outcome with
    | Win -> 6
    | Draw -> 3
    | Lose -> 0

// (Shape, Shape) -> Outcome
let calculateOutcome round =
    match round with
    | (Scissors, Rock) -> Win
    | (Paper, Scissors) -> Win
    | (Rock, Paper) -> Win
    | (opponent, me) -> if me = opponent then Draw else Lose

// For part2 the 2nd column has different semantics
// string -> Outcome
let parseOutcome x =
    match x with
    | "X" -> Lose
    | "Y" -> Draw
    | "Z" -> Win

// (Shape, Outcome) -> (Shape, Shape)
let desiredShape round =
    match round with
    | (shape, Draw) -> (shape, shape)
    | (Rock, Win) -> (Rock, Paper)
    | (Rock, Lose) -> (Rock, Scissors)
    | (Paper, Win) -> (Paper, Scissors)
    | (Paper, Lose) -> (Paper, Rock)
    | (Scissors, Win) -> (Scissors, Rock)
    | (Scissors, Lose) -> (Scissors, Paper)

let scoreRound round =
   (calculateOutcome round |> scoreOutcome) + (scoreShape round)

let parse1 (lines: string[]) =
    lines
    |> Seq.map (fun s -> s.Split(" ")) 
    |> Seq.map (fun r -> (parseShape r[0], parseResponse r[1]))

let parse2 (lines: string[]) =
    lines
    |> Seq.map (fun s -> s.Split(" "))
    |> Seq.map (fun r -> (parseShape r[0], parseOutcome (r[1])))

let part1 (lines: string[]) =
    let score = 
        lines
        |> parse1
        |> Seq.map scoreRound
        |> Seq.sum
    
    score

let part2 (lines: string[]) = 
    let score =
        lines
        |> parse2
        |> Seq.map desiredShape
        |> Seq.map scoreRound
        |> Seq.sum
    
    score