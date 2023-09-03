module ConsoleApp1.Intro2_1_2

// -------------------------------------------------------
// EXERCISE 1.2
// -------------------------------------------------------

// EXPR TYPE AND EXAMPLE EXPRESSIONS //

type aexpr =                  // (i)
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

let e1 = Sub(Var "v", Add(Var "w", Var "z"))                // (ii)

let e2 = Mul(CstI 2, e1)                                    // (ii)

let e3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))  // (ii)

let e4 = Add(Var "x", CstI 0)                               // (iv)

let e5 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))     // (iv)

let e6 = Add(Mul(CstI 5, Var "x"), CstI 2)                  // (v)

// FMT ENVIRONMENT //

let rec fmt a : string =      // (iii)
  match a with
  | CstI a -> string a  
  | Var x -> x
  | Add(a1, a2) -> sprintf "(%s + %s)" (fmt a1) (fmt a2)
  | Mul(a1, a2) -> sprintf "(%s * %s)" (fmt a1) (fmt a2)
  | Sub(a1, a2) -> sprintf "(%s - %s)" (fmt a1) (fmt a2)

// SIMPLIFY ENVIRONMENT //

let rec simplify a : aexpr =  // (iv)
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

// SYMBOLIC DIFFERENTIATION ENVIRONMENT //

let rec diff a : aexpr =      // (v)
  match a with
  | CstI _ -> CstI 0
  | Var _ -> CstI 1
  | Add (a1, a2) -> simplify (Add(diff a1, diff a2))
  | Mul (a1, a2) -> simplify (Mul(a1, diff a2))
  | Sub (a1, a2) -> simplify (Sub(diff a1, diff a2))

// EVALUATION OF EXPRESSIONS //

fmt e1        // (ii) + (iii)

fmt e2        // (ii) + (iii)

fmt e3        // (ii) + (iii)

fmt e4        // (ii) + (iii)

simplify e5   // (iv)

diff e6       // (v)