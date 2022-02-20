module StringCalculaterModule

open System 


type StringCalculator()=
     member x.add expression =
      match expression with 
      |"" -> 0
      |_ when expression.Contains ',' ->
         [for n in expression.Split[|','|]-> Int32.Parse n] |> List.sum  //Allow the Add method to handle an unknown amount of numbers
      |_-> Int32.Parse expression

