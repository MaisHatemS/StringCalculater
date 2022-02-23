module StringCalculater

open NUnit.Framework
open StringCalculaterModule
[<SetUp>]
let Setup () =
    ()


[<TestFixture>]
type stringCalculatr()=
    [<Test>]
    member x.AddEmptyString_ReturnsZero () = 
      let calc = StringCalculator() 
      Assert.That(calc.add "",Is.EqualTo 0)

    [<TestCase("1",ExpectedResult = 1)>]
    [<TestCase("2",ExpectedResult = 2)>]
    member x.Add_SingleNumber_ReturnsThatNumber expression=
      let calc= StringCalculator()
      calc.add expression

    [<TestCase("1,3",ExpectedResult = 4)>]
    member x.Add_TwoNumber_ReturnTheSumation expression=
        let calc=StringCalculator()
        calc.add expression
   
    [<TestCase("1,2,4,5,3",ExpectedResult = 15)>]
    member x.Add_UnknownAmountOfNumber_ReturnTheirSum expression=
         let calc= StringCalculator()
         calc.add expression

    
    
    [<TestCase("1\n2,4,5",ExpectedResult = 12)>]
    [<TestCase("1\n2",ExpectedResult = 3)>]
    member x.Add_NewLineBetweenTheNumbers_ReturnTheirSumOfthenumbers expression=
         let calc= StringCalculator()
         calc.add expression

    [<Test>]
    member x.Add_EmptyStringwithdifferantDelimiters_ReturnZero()=
         let calc= StringCalculator()
         Assert.That(calc.add "//;\n",Is.EqualTo 0);

    
    [<TestCase("//;\n1",ExpectedResult = 1)>]
    [<TestCase("//;\n2",ExpectedResult = 2)>]
       member x.Add_SingleNumberWithDifferantDelimiters_ReturnsThatNumber expression=
         let calc= StringCalculator()
         calc.add expression

    [<TestCase("//;\n1;3",ExpectedResult = 4)>]
       member x.Add_TwoNumberwithDifferantDelimiters_ReturnTheSumation expression=
          let calc=StringCalculator()
          calc.add expression

    [<TestCase("//;\n1;2;4;5;3",ExpectedResult = 15)>]
       member x.Add_UnknownAmountOfNumberWithDifferantDelimiters_ReturnTheirSum expression=
            let calc= StringCalculator()
            calc.add expression

    [<TestCase("1,-1,2,-3",ExpectedResult ="Negative is negatives not allowed [-1; -3]" )>]
       member x.NigativeNumber_ReturnException expression=
                 let calc= StringCalculator()
                 let exceptionMsg=  Assert.Throws(typeof<NegativeException>,fun()->calc.add expression |> ignore)
                 exceptionMsg.Message

    [<TestCase("2,1001")>]
       member x.IgnoreNumberAbove1000 expression=
            let calc = StringCalculator()
            Assert.That(calc.add expression,Is.EqualTo 2)

    [<TestCase("//[***]\n1***2***3",ExpectedResult =6 )>]
    member x.Add_NumberWith_ManyDelimiters_ReturnSumationOfTheNumber expression=
              let calc= StringCalculator()
              calc.add expression


     [<TestCase("//[*][%]\n1*2%3",ExpectedResult = 6)>]
     [<TestCase("//[*][%]\n1%***2%%%%%*****3",ExpectedResult = 6)>]
       member  r.AddMoreThanTwoNumbersWithCustomDelimiterAnylength_ReturnsSummation expression = 
           let calc = StringCalculator()
           calc.add expression