module Tests

//#r "nuget: Unquote"
open Swensen.Unquote
open Input
open Day1

test <@ part1 sample = 24000 @>
test <@ part2 sample = 45000 @>
