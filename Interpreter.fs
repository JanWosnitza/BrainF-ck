module BrainFark.Interpreter

let run code =
    let rec skip count =
        function
        | c::cs ->
            match c with
            | '[' -> skip (count + 1) cs
            | ']' ->
                match count with
                | 1 -> cs
                | _ -> skip (count - 1) cs
            | _ -> skip count cs
        | [] -> failwith "unmatched ["

    let rec loop mem stack =
        function
        | '>'::cs -> loop (Memory.moveRight mem) stack cs
        | '<'::cs -> loop (Memory.moveLeft mem) stack cs

        | '+'::cs -> loop (Memory.increment mem) stack cs
        | '-'::cs -> loop (Memory.decrement mem) stack cs

        | '.'::cs -> loop (Memory.write mem) stack cs
        | ','::cs -> loop (Memory.read mem) stack cs

        | '['::cs ->
            match Memory.get mem with
            | 0uy -> loop mem stack (skip 1 cs)
            | _ -> loop mem (cs::stack) cs

        | ']'::cs ->
            match stack with
            | s::ss ->
                match Memory.get mem with
                | 0uy -> loop mem ss cs
                | _ -> loop mem stack s
            | [] -> failwith "unmatched ["

        | _::cs -> loop mem stack cs
        | [] ->
            match stack with
            | s::ss -> failwith "unmatched ["
            | _ -> ()
    
    loop Memory.Zero [] code
