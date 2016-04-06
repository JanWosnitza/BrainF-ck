module BrainFark.Functional

open System
open System.Text

type Memory = {l:byte list; v:byte; r:byte list}

[<CompilationRepresentation( CompilationRepresentationFlags.ModuleSuffix )>]
module Memory =
    let create l v r = {l=l; v=v; r=r}

    let Zero = create [] 0uy []

    let get {v=v} = v
    let set mem v = {mem with v=v}

    let private pop =
        function
        | x::xs -> x, xs
        | [] -> 0uy, []

    let moveLeft  {l=l; v=v; r=r} =
        let x, xs = pop l
        create xs x (v::r)

    let moveRight {l=l; v=v; r=r} =
        let x, xs = pop r
        create (v::l) x xs
    
    let increment mem = {mem with v=mem.v + 1uy}
    let decrement mem = {mem with v=mem.v - 1uy}

let write mem =
    [|Memory.get mem|] |> Encoding.ASCII.GetString |> Console.Write
    mem

let read mem =
    match Console.Read() with
    | -1 -> failwith "aborted"
    | i -> Memory.set mem (byte i)

let rec loopIfNotZero body memory =
    match Memory.get memory with
    | 0uy -> memory
    | _ -> memory |> body |> loopIfNotZero body

let fromString (code:string) =        
    let rec loop fs f =
        function
        | '>'::xs -> loop fs (f >> Memory.moveRight) xs
        | '<'::xs -> loop fs (f >> Memory.moveLeft) xs
        | '+'::xs -> loop fs (f >> Memory.increment) xs
        | '-'::xs -> loop fs (f >> Memory.decrement) xs
        | '.'::xs -> loop fs (f >> write) xs
        | ','::xs -> loop fs (f >> read) xs
        | '['::xs -> loop (f::fs) id xs
        | ']'::xs ->
            match fs with
            | f'::fs' -> loop fs' (f' >> loopIfNotZero f) xs
            | [] -> failwith "unmatched ["
        | _::xs -> loop fs f xs
        | [] ->
            match fs with
            | [] -> f
            | _ -> failwith "unmatched ["

    code
    |> Seq.toList
    |> loop [] id
