module StringCalculaterModule

open System 
open System.Text.RegularExpressions

type NegativeException(negativeList)=
      inherit Exception(sprintf "Negative is negatives not allowed %A" negativeList)
(*let delimiterList="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$ ";
let stringdelimiters=[|',';'\n';'*','[',']'|]
**)
(*let isDelimiters (singleChar:char)=
    if (stringdelimiters.Contains(singleChar)) then
         true
    else   false
      
let containDelimiters (stringexpression:string)=
         [for n in stringexpression.ToCharArray() ->  
            if (stringdelimiters.Contains(n)) then
               stringexpression.Remove(stringexpression.IndexOf(n),1)
            else ""
            ]
         
         stringexpression  
*)
type StringCalculator()=
    (*let isNegative num = num < 0 *)
    let rec addStringExpresstion delimiters expression=

     match expression with 

     |"" -> 0
     | _ when expression.StartsWith "//[" ->
         let s = Regex.Replace(expression,@"[\d-]",",").Replace("-",",").ToCharArray()
         let numbers = expression.Split(s,StringSplitOptions.RemoveEmptyEntries)
         numbers|>Seq.map Int32.Parse |> Seq.sum
(*     | _ when expression.StartsWith "//[" ->
         expression.Substring((expression.IndexOf("\n"))+1) |> addStringExpresstion delimiters
     |_ when (expression.Contains('*') ) ->

             expression.ToCharArray() |> Array.toList |> List.filter (fun c-> not(c.Equals('*') ))
             |> string|>addStringExpresstion delimiters  
*)     |_ when expression.StartsWith "//"->

           expression.Substring ((expression.IndexOf "\n")+1)|> addStringExpresstion [|';'|]
     |_  ->let (negativeList,positiveList)=
        
              [for n in expression.Split delimiters-> Int32.Parse n ] |>

              List.filter (fun n->n<=1000) |> List.partition (fun n->n < 0 )
           if negativeList.Length>0 then raise (NegativeException(negativeList))
           positiveList|>List.sum
    member x.add expression=
       expression |> addStringExpresstion [|',';'\n'|]
