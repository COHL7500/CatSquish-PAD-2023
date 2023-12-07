(* Example showing the calculation of free variables 
   Try with -debug option *)

(* This example fails because the function freevarsValdec in file
   Absyn.fs is wrong.  You can only add x to bvs if x has not
   previously been marked as free. 

   Solved by exercise is to do alpha conversion first.
*)

begin
  let
    val y1 = 1
    fun f x = (* freevars=[y] *)
      let
        val z = y1 + 1
        val y2 = 1
      in
        z+y2+x
      end                  
  in
    f y1
  end         
end 
