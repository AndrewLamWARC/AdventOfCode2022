module Tests

open Swensen.Unquote
open Day2
open Input

let runTests () =
    test <@ part1 sample = 15 @>
    test <@ part2 sample = 12 @>
    printfn "Tests passed"