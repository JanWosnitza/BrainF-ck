module BrainFark.Compiler

let fromString (code:string) =        
    let rec loop body memory =
        match Memory.get memory with
        | 0uy -> memory
        | _ -> memory |> body |> loop body

    let f, fs =
        code
        |> Seq.fold
            (fun (f,fs) x ->
            match x with
            | '>' -> (f >> Memory.moveRight, fs)
            | '<' -> (f >> Memory.moveLeft, fs)

            | '+' -> (f >> Memory.increment, fs)
            | '-' -> (f >> Memory.decrement, fs)

            | '.' -> (f >> Memory.write, fs)
            | ',' -> (f >> Memory.read, fs)

            | '[' -> (id, f::fs)
            | ']' ->
                match fs with
                | f'::fs' -> (f' >> loop f, fs')
                | [] -> failwith "unmatched ]"

            | _ -> (f,fs)
            )
            (id,[])

    match fs with
    | [] -> f
    | _ -> failwith "unmatched ["
