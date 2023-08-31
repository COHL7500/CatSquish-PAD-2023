module ConsoleApp1.Intro2_1_2

open ConsoleApp1.env

(* Object language expressions with variables *)
  
type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr


(* Evaluation within an environment *)



(*eval e1 env;;
eval e2 env;;
eval e2 [("a", 314)];;
eval e3 env;;
eval e4v1 env;;
eval e4v2 env;;
eval e4v3 env;;
eval v5 env;;*)