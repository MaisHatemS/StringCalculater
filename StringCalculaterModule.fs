module StringCalculaterModule

open System 


type NegativeException(negativeList)=
      inherit Exception(sprintf "Negative is negatives not allowed %A" negativeList)

let stringdelimiters="^.*[-!$%^&*()_+|~=`{}[\\]:;\'<>?,.\/]+.*$"


let concatinateFunction (stringexpression:seq<string>) =
            
            String.Join(';',stringexpression)
           

type StringCalculator()=
    (*let isNegative num = num < 0 *)
    let rec addStringExpresstion delimiters expression=

     match expression with 

     |"" -> 0
     | _ when expression.StartsWith "//[" ->
               expression.Substring ((expression.IndexOf "\n")+1)|> 
               String.filter(fun c -> not (stringdelimiters.Contains c ))|>Seq.map (fun c->c.ToString())
               |>concatinateFunction|>addStringExpresstion [|';'|]

     |_ when expression.StartsWith "//"->
           expression.Substring ((expression.IndexOf "\n")+1)|> addStringExpresstion [|';'|]
     |_  ->let (negativeList,positiveList)=
        
              [for n in expression.Split delimiters-> Int32.Parse n ] |>

              List.filter (fun n->n<=1000) |> List.partition (fun n->n < 0 )
           if negativeList.Length>0 then raise (NegativeException(negativeList))
           positiveList|>List.sum
    member x.add expression=
       expression |> addStringExpresstion [|',';'\n'|]
