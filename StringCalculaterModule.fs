module StringCalculaterModule

open System 


type StringCalculator()=
     member x.add expression =
      match expression with 
      |"" -> 0
      |_ when expression.Contains ',' ->
           let numbers=expression.Split[|','|]
           (Int32.Parse numbers.[0])+(Int32.Parse numbers.[1])
      |_-> Int32.Parse expression

