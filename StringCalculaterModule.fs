module StringCalculaterModule

open System 


type StringCalculator()=
     let rec addStringExpresstion delimiters expression=
      match expression with 
      |"" -> 0
      |_ when expression.StartsWith "//"->
            expression.Substring ((expression.IndexOf "\n")+1)|> addStringExpresstion [|';'|]
      |_  ->
           [for n in expression.Split delimiters-> Int32.Parse n] |> List.sum

     member x.add expression=
        expression |> addStringExpresstion [|',';'\n'|]