module BrainFark.Program

let HelloWorld = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."

HelloWorld
|> Seq.toList
|> Interpreter.run

Compiler.Memory.Zero
|> Compiler.fromString HelloWorld
|> ignore