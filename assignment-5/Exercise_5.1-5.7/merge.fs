let rec merge (xs: int list) (ys: int list) : int list =
    match xs, ys with
    | [], _ -> ys
    | _, [] -> xs
    | x :: tailx, y :: taily ->
        match x <= y with
            | true -> x :: (merge tailx ys)
            | false -> y :: (merge xs taily)   
           