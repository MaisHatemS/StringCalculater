module StringCalculaterModule

open System 


type StringCalculator()=
     member x.add expression =
      match expression with 
      |"" -> 0
      |_  ->
           [for n in expression.Split[|','; '\n'|]-> Int32.Parse n] |> List.sum
(*      |_-> Int32.Parse expression
*)
