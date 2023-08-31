module ConsoleApp1.Intro2

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | If of expr * expr * expr
  | Prim of string * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4v1 = Prim("max", e1, e2)

let e4v2 = Prim("min", e1, e2)

let e4v3 = Prim("==", e1, e2)

let v5   = If(Var "a", CstI 11, CstI 22)

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x
    | If (e1, e2, e3)       -> if (eval e1 env) <> 0 then eval e2 env else eval e3 env
    //| Prim("+", e1, e2)     -> eval e1 env + eval e2 env
    | Prim("*", e1, e2)     -> eval e1 env * eval e2 env
    | Prim("-", e1, e2)     -> eval e1 env - eval e2 env
    | Prim("max", e1, e2)   -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2)   -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2)    -> if eval e1 env = eval e2 env then 1 else 0
    | Prim(ope, e1, e2)     ->
        let i1 = eval e1 env
        let i2 = eval e2 env
        match ope with
        | "+" -> i1 + i2

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;
let v5v1 = eval v5 env
