module BrainFark.Program

open System.Diagnostics
open Examples

let run f x =
    let watch = Stopwatch.StartNew()
    f x Memory.Zero |> ignore
    printfn ""
    printfn "%.1f msec" watch.Elapsed.TotalMilliseconds


printfn "Interpreter:"
run Interpreter.fromString HelloWorldComplex

printfn "Compiler:"
run Compiler.fromString HelloWorldComplex
