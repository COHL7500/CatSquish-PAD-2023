 module Exercise_2._4_2._5.Program
 
 open Exercise_2._4_2._5.IntComp1
 
 let sinstrToInt (sinstr : sinstr) : int list =
     match sinstr with
     | SCstI i  -> [0; i]
     | SVar i   -> [1; i]
     | SAdd     -> [2]
     | SSub     -> [3]
     | SMul     -> [4]
     | SPop     -> [5]
     | SSwap    -> [6]
 
 let assemble (inss: sinstr list) : int list =
     List.fold (fun acc n -> acc @ sinstrToInt n) [] inss