module Tests

open Swensen.Unquote
open Input
open Day4

let runTests () =
    test <@ part1 sample = 2 @>
    //test <@ part2 sample = 70 @>
    printfn "Tests passed"
