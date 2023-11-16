module cps

// 11.1
let rec len xs =
    match xs with
    | [] -> 0
    | x::xr -> 1 + len xr;;

let rec lenc xs f =
    match xs with
    | [] -> f 0
    | x::xr -> lenc xr (fun v -> f (1+v));;

let rec leni xs acc =
    match xs with
    | [] -> acc
    | x::xr -> leni xr (acc+1);;

// 11.2
let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x];;

let rec revc xs f =
    match xs with
    | [] -> f []
    | x::xr -> revc xr (fun v -> f (v @ [x]));;

let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xr -> revi xr (x :: acc);;

// 11.3
let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr;;

let rec prodc xs f =
    match xs with
    | [] -> f 1
    | x::xr -> prodc xr (fun v -> f (x*v));;

// 11.4
let rec prodz xs f =
    match xs with
    | [] -> f 1
    | x::xr ->
        match x with
        | 0 -> f 0
        | _ -> prodc xr (fun v -> f (x*v));;

let rec prodi xs acc =
    match xs with
    | [] -> acc
    | x::xr ->
        match x with
        | 0 -> 0
        | _ -> prodi xr (acc*x);;
