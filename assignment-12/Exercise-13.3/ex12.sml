(* The purpose of alpha conversion is to make all variables unique which simplifies
   subsequence compilation phases, e.g. calculation of free variables.

   The below expression is converted into
   let val x1 = 2 in let val x2 = 5 in x2 + x2 end
*)

begin
  let val x1 = 2
  in
    let val x2 = 5
    in
      x1 + x2
    end
  end
end

