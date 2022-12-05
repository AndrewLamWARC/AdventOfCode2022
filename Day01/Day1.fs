module Day1

let parse (lines: string) =
    lines.Split("\r\n\r\n") // split on 2 consecutive newline
    |> Seq.map (fun s -> s.Split("\r\n") |> Seq.map int)

let elvesTotalCalories (lines: string) =
    let elves = lines |> parse         // elves' seq of calories  
    let calories = elves |> Seq.map Seq.sum // elves total calories
    
    calories
    
let part1 (lines: string) =   
    let calories = elvesTotalCalories lines
    let maxCalories = calories |> Seq.max

    maxCalories

let part2 lines = 
    let calories = 
        elvesTotalCalories lines
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.sum

    calories

