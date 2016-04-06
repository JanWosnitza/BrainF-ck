namespace BrainFark

type Memory = {l:byte list; v:byte; r:byte list}

[<CompilationRepresentation( CompilationRepresentationFlags.ModuleSuffix )>]
module Memory =
    open System
    open System.Text

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
        [|get mem|] |> Encoding.ASCII.GetString |> Console.Write
        mem

    let read mem =
        match Console.Read() with
        | -1 -> failwith "aborted"
        | i -> set mem (byte i)