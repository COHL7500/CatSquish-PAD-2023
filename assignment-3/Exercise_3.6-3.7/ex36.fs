module Exercise_3._6_3._7.ex36

open Expr
open Parse

let compString (s: string) : sinstr list =
    scomp (fromString s) [];;