module BrainFark.Program

let HelloWorld = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."

HelloWorld
|> Seq.toList
|> Interpreter.run