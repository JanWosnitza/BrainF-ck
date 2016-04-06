module BrainFark.Compiler

let fromString (code:string) =        
    let rec loopIfNotZero body memory =
        match Memory.get memory with
        | 0uy -> memory
        | _ -> memory |> body |> loopIfNotZero body

    let rec loop fs f =
        function
        | '>'::xs -> loop fs (f >> Memory.moveRight) xs
        | '<'::xs -> loop fs (f >> Memory.moveLeft) xs

        | '+'::xs -> loop fs (f >> Memory.increment) xs
        | '-'::xs -> loop fs (f >> Memory.decrement) xs

        | '.'::xs -> loop fs (f >> Memory.write) xs
        | ','::xs -> loop fs (f >> Memory.read) xs

        | '['::xs -> loop (f::fs) id xs
        | ']'::xs ->
            match fs with
            | f'::fs' -> loop fs' (f' >> loopIfNotZero f) xs
            | [] -> failwith "unmatched ]"

        | _::xs -> loop fs f xs
        | [] ->
            match fs with
            | [] -> f
            | _ -> failwith "unmatched ["

    code
    |> Seq.toList
    |> loop [] id
