module ConsoleApp1.Intro2_1_2

open ConsoleApp1.env

(* Object language expressions with variables *)
  
type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

let e1 = Sub(Var "v", Add(Var "w", Var "z"))

let e2 = Mul(CstI 2, e1)

let e3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))

let rec fmt a : string =
  match a with
  | CstI a -> string a  
  | Var x -> x
  | Add(a1, a2) -> sprintf "(%s + %s)" (fmt a1) (fmt a2)
  | Mul(a1, a2) -> sprintf "(%s * %s)" (fmt a1) (fmt a2)
  | Sub(a1, a2) -> sprintf "(%s - %s)" (fmt a1) (fmt a2)
  
(* Evaluation within an environment *)



(*eval e1 env;;
eval e2 env;;
eval e2 [("a", 314)];;
eval e3 env;;
eval e4v1 env;;
eval e4v2 env;;
eval e4v3 env;;
eval v5 env;;*)