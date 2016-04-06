module BrainFark.Program

let HelloWorld = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."

HelloWorld
|> Seq.toList
|> Interpreter.run

(HelloWorld
|> Functional.fromString) Functional.Memory.Zero