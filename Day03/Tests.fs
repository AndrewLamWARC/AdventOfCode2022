module Tests

open Swensen.Unquote
open Input
open Day3

let runTests () =
    let part1Result = part1 sample
    test <@ part1Result = 157 @>
    test <@ part2 sample = 70 @>
    printfn "Tests passed"
