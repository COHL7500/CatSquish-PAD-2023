module ConsoleApp1.Intro2_1_1

// NOT OUR CODE //
let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

// -------------------------------------------------------
// EXERCISE 1.1
// -------------------------------------------------------

// EXPR TYPE AND EXAMPLE EXPRESSIONS //

type expr = 
  | CstI of int
  | Var of string
  | If of expr * expr * expr // (iv)
  | Prim of string * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4v1 = Prim("max", e1, e2)              // (ii)

let e4v2 = Prim("min", e1, e2)              // (ii)

let e4v3 = Prim("==", e1, e2)               // (ii)

let v5   = If(Var "a", CstI 11, CstI 22)    // (v)

// EVAL ENVIRONMENT //

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x
    | If (e1, e2, e3)       -> if (eval e1 env) <> 0 then eval e2 env else eval e3 env  // (v)
    | Prim("*", e1, e2)     -> eval e1 env * eval e2 env
    | Prim("-", e1, e2)     -> eval e1 env - eval e2 env
    | Prim("max", e1, e2)   -> max (eval e1 env) (eval e2 env)                          // (i)
    | Prim("min", e1, e2)   -> min (eval e1 env) (eval e2 env)                          // (i)
    | Prim("==", e1, e2)    -> if eval e1 env = eval e2 env then 1 else 0               // (i)
    | Prim(ope, e1, e2)     ->                                                          // (iii)
        let i1 = eval e1 env
        let i2 = eval e2 env
        match ope with
        | "+" -> i1 + i2

// EVALUATION OF EXPRESSIONS //

eval e1 env;;

eval e2 env;;

eval e2 [("a", 314)];;

eval e3 env;;

eval e4v1 env;; // (ii)

eval e4v2 env;; // (ii)

eval e4v3 env;; // (ii)

eval v5 env;;   // (v)