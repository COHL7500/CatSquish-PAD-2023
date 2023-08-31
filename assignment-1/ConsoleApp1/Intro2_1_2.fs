module ConsoleApp1.Intro2_1_2

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

let e4 = Add(Var "x", CstI 0)

let e5 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))

let e6 = Add(Mul(CstI 5, Var "x"), CstI 2)

let rec fmt a : string =
  match a with
  | CstI a -> string a  
  | Var x -> x
  | Add(a1, a2) -> sprintf "(%s + %s)" (fmt a1) (fmt a2)
  | Mul(a1, a2) -> sprintf "(%s * %s)" (fmt a1) (fmt a2)
  | Sub(a1, a2) -> sprintf "(%s - %s)" (fmt a1) (fmt a2)
  
(* Evaluation within an environment *)

let rec simplify a : aexpr =
  match a with
  | Add (a1, a2) ->
    match simplify a1, simplify a2 with
    | CstI 0, a2 -> a2
    | a1, CstI 0 -> a1
    | _ -> Add(a1, a2)
  | Sub (a1, a2) ->
    match simplify a1, simplify a2 with
    | a1, CstI 0 -> a1
    | a1, a2 when a1 = a2 -> CstI 0
    | _ -> Sub(a1, a2)
  | Mul (a1, a2) ->
    match simplify a1, simplify a2 with
    | CstI 1, a2 -> a2
    | a1, CstI 1 -> a1
    | CstI 0, a2 -> a2
    | a1, CstI 0 -> a1
    | _ -> Mul(a1, a2)
  | _ -> a
  
let rec diff a : aexpr =
  match a with
  | CstI _ -> CstI 0
  | Var _ -> CstI 1
  | Add (a1, a2) -> simplify (Add(diff a1, diff a2))
  | Mul (a1, a2) -> simplify (Mul(a1, diff a2))
  | Sub (a1, a2) -> simplify (Sub(diff a1, diff a2))
  
simplify e5
diff e6

(*eval e1 env;;
eval e2 env;;
eval e2 [("a", 314)];;
eval e3 env;;
eval e4v1 env;;
eval e4v2 env;;
eval e4v3 env;;
eval v5 env;;*)