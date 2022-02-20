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