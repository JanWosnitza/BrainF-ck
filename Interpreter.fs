﻿module BrainFark.Interpreter

open System
open System.Text

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

    let rec loop (left,current,right) stack code =
        match code with
        | c::cs ->
            match c with
            | '>' -> 
                match right with
                | [] -> loop (current::left, 0uy, []) stack cs
                | r::rs -> loop (current::left, r, rs) stack cs

            | '<' ->
                match left with
                | [] -> loop ([], 0uy, current::right) stack cs
                | l::ls -> loop (ls, l, current::right) stack cs

            | '+' ->
                loop (left, current + 1uy, right) stack cs

            | '-' ->
                loop (left, current - 1uy, right) stack cs

            | '.' ->
                Console.Write( Encoding.ASCII.GetString( [|current|] ) )
                loop (left, current, right) stack cs

            | ',' ->
                let i = Console.Read()
                if i < -1 then failwith "aborted"
                else loop (left, byte i, right) stack cs

            | '[' ->
                match current with
                | 0uy -> loop (left, current, right) stack (skip 1 cs)
                | _ -> loop (left, current, right) (cs::stack) cs

            | ']' ->
                match stack with
                | s::ss ->
                    match current with
                    | 0uy -> loop (left, current, right) ss cs
                    | _ -> loop (left, current, right) stack s
                | [] -> failwith "unmatched ["

            | _ -> loop (left, current, right) stack cs
        | [] ->
            match stack with
            | s::ss -> failwith "unmatched ["
            | _ -> ()
    
    loop ([], 0uy, []) [] code
