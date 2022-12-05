module Input

let readFile file = System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}\{file}"""

let sample = readFile "sample.txt"
let input = readFile "input.txt"