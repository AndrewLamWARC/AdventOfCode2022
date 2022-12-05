module Tests

open Swensen.Unquote
open Input
open Day0

let runTests () =
    test <@ part1 sample = 888 @>
    test <@ part2 sample = 888 @>
    printfn "Tests passed"
