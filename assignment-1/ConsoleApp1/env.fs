module ConsoleApp1.env

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

//let emptyenv = [];

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

//let cvalue = lookup env "c";;