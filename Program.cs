using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace FinalBootCamp
{

    class Program
    {
        #region static variables
        static Random iNumber = new Random();
        static Random conditionNum = new Random();
        static int c, i, j = 0, n = 0;
        static ulong answerGiven;
        static char responseGiven, charGivenYN, characterGivenTF;
        static bool TrueisTrue, AisTrue, BisTrue, CisTrue, DisTrue;
        static string answerGivenString;
        #endregion
        static void Main(string[] args)
        {
            /*WhileLoopQuestionsTypeOne();
            WhileLoopQuestionsTypeTwo();
            WhileLoopsType3();
            WhileLoopsTypeFour();*/
            ForLoopMethod1();
            ForLoopMethod2();
            ForLoopMethod3();
            ForLoopMethod4();
            ForLoopMethod5();
            NestedForLoop1();
            NestedForLoop2();
            NestedForLoop3();
            /*AdditionOfNumbers();
            ConvertDecimaltoBinary();
            ConvertDecimalToOctal();
            ConvertDecimalToHexadecimal();
            ConvertBinaryToDecimal();
            ConvertHexadecimalToDecimal();
            ConvertOctalToDecimal();
            VariablesMemoryAndDomain();
            RulesOfAssocicativity();
            MixedExpressionRules();
            CastingVariables();
            ArrayQuestions();
            MethodQuestions();*/
        }
        #region Code to validate and check user input;
        static void ReadAndValidateInputUlong(ref ulong answerGiven)
        //As the name suggests, this method will read in the answers to the loops and addition problems and validate that it isn't invalid or null.
        {
            var answerAsString = Console.ReadLine();
            while (string.IsNullOrEmpty(answerAsString))
            {
                Console.WriteLine("Please enter in a valid answer.");
                answerAsString = Console.ReadLine();

            }
            bool parseSuccess = ulong.TryParse(answerAsString, out answerGiven);
            bool numberGiven = true;

            while (numberGiven)
            {
                if (parseSuccess)
                {
                    Console.WriteLine("Your answer was {0}. You can view the correct answer below:", answerGiven);
                    numberGiven = false;
                }
                else
                {
                    Console.WriteLine("Error: invalid entry. Please enter in a number as your answer.");
                    answerAsString = Console.ReadLine();
                    parseSuccess = ulong.TryParse(answerAsString, out answerGiven);
                    continue;
                }
            }
        }
        static void ReadAndValidateInputString(ref string answerGivenString)
        {
            var answerAsString = Console.ReadLine();
            while (string.IsNullOrEmpty(answerAsString))
            {
                Console.WriteLine("Please enter a valid answer in the form of two numbers separated by commas.");
                answerAsString = Console.ReadLine();
            }
            answerGivenString = answerAsString;
        }
        static void ReadAndValidateInputCharYesorNo(ref char charGivenYN)
        {
            var charTester = Console.ReadLine();
            while (string.IsNullOrEmpty(charTester))
            {
                Console.WriteLine("Error: invalid entry. Please enter in the letter that corresponds to your answer.");
                charTester = Console.ReadLine();
            }
            bool charParse = char.TryParse(charTester, out charGivenYN);
            while (!charParse)
            {
                Console.WriteLine("Error: invalid entry. Please enter either an y or a n");
                var charTester2 = Console.ReadLine();
                charParse = char.TryParse(charTester2, out charGivenYN);
            }
            bool charValid = true;

            while (charValid)
            {
                switch (charGivenYN)
                {
                    case 'Y':
                    case 'y':
                        j++;
                        Console.WriteLine("Congrats. You have {0} points and {1} questions answered.", j, n);
                        charValid = false;
                        break;
                    case 'n':
                    case 'N':
                        Console.WriteLine("Better luck next time. You have {0} points and {1} questions answered.", j, n);
                        charValid = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid entry. Please enter a y or a n");
                        var charTester2 = Console.ReadLine();
                        charParse = char.TryParse(charTester2, out charGivenYN);
                        if (charParse)
                        {
                            continue;
                        }
                        else
                        {
                            while (!charParse)
                            {
                                Console.WriteLine("Error: invalid entry. Please enter either an y or a n");
                                charTester2 = Console.ReadLine();
                                charParse = char.TryParse(charTester2, out charGivenYN);
                            }
                        }
                        break;
                }
            }


        }

        static void CheckTrueFalseQuestions(ref char characterGivenTF)
        {
            //Read in answer to true or false question while validating it isn't null, then checking to make sure it is either T, 
            var testerVariable = Console.ReadLine();
            while (string.IsNullOrEmpty(testerVariable))
            {
                Console.WriteLine("Please enter T, t, F, or F");
                testerVariable = Console.ReadLine();
            }
            bool parseSuccess2 = char.TryParse(testerVariable, out characterGivenTF);
            while (!parseSuccess2)
            {
                Console.WriteLine("Error: invalid entry. Please enter either an t or an f");
                var testerVariable2 = Console.ReadLine();
                parseSuccess2 = char.TryParse(testerVariable2, out characterGivenTF);
            }

            bool charIsValid = true;
           
            while (charIsValid)
            {
                switch (characterGivenTF)
                {
                    case 'T':
                    case 't':
                    case 'F':
                    case 'f':
                        charIsValid = false;
                        break;;
                    default:
                        Console.WriteLine("Error: invalid entry. Please enter an T or a F");
                        var testerVariable2 = Console.ReadLine();
                        parseSuccess2 = char.TryParse(testerVariable2, out characterGivenTF);
                        if (parseSuccess2)
                        {
                            continue;
                        }
                        else
                        {
                            while (!parseSuccess2)
                            {
                                Console.WriteLine("Error: invalid entry. Please enter either an T or a F");
                                testerVariable2 = Console.ReadLine();
                                parseSuccess2 = char.TryParse(testerVariable2, out characterGivenTF);
                            }
                        }
                        break;
                }
            }
            if (TrueisTrue == true)
            {
                switch(characterGivenTF)
                {
                    case 'T':
                    case 't':
                        j++;
                        Console.WriteLine("Congrats, you got the right answer. You have {0} points and have answered {1} questions", j, n);
                        break;
                    case 'f':
                    case 'F':
                        Console.WriteLine("Better luck next time. You have {0} points and {1} questions answered.", j, n);
                        break;
                }
            }
            if(TrueisTrue == false)
            {
                switch (characterGivenTF)
                {
                    case 'f':
                    case 'F':
                        j++;
                        Console.WriteLine("Congrats, you got the right answer. You have {0} points and have answered {1} questions", j, n);
                        break;
                    case 'T':
                    case 't':
                        Console.WriteLine("Oops. Better luck next time. You have {0} points and have answered {1} questions",j, n);
                        break;
                }
            }
            Console.WriteLine();
        }
        static void CheckMultipleChoiceQuestions()
        {

            var testerVariableMC = Console.ReadLine();

            while (string.IsNullOrEmpty(testerVariableMC))
            {
                Console.WriteLine("Please enter either a capital or lowercase A, B, C or D");
                testerVariableMC = Console.ReadLine();
            }
            testerVariableMC = testerVariableMC.ToUpper();

            bool parseSuccess2 = char.TryParse(testerVariableMC, out responseGiven);

            while (!parseSuccess2)
            {
                Console.WriteLine("Please enter one of the answers provided.");
                testerVariableMC = Console.ReadLine();
                parseSuccess2 = char.TryParse(testerVariableMC, out responseGiven);
            }
            //start of section that takes care of when the user enters a char other than A, B, C, or D;
            bool charIsValid = true;
            while (charIsValid)
            {
                switch (responseGiven)
                {
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                        charIsValid = false;
                        break;
                    default:
                        Console.WriteLine("Error: invalid entry. Please enter one of the letters that were provided as options for an answer.");
                        testerVariableMC = Console.ReadLine();
                        parseSuccess2 = char.TryParse(testerVariableMC, out responseGiven);
                        if (parseSuccess2)
                        {
                            continue;
                        }
                        else
                        {
                            while (!parseSuccess2)
                            {
                                Console.WriteLine("Error: invalid entry. Please enter one of the letters that were provided as options for an answer.");
                                testerVariableMC = Console.ReadLine();
                                parseSuccess2 = char.TryParse(testerVariableMC, out responseGiven);
                            }
                            continue;
                        }
                }
            }

            //End of section. 
            if (parseSuccess2)
            {
                if (AisTrue == true)
                {
                    BisTrue = false; CisTrue = false; DisTrue = false;
                    switch (responseGiven)
                    {
                        case 'a':
                        case 'A':
                            j++;
                            Console.WriteLine("Correct! You get a point. So far, you have answered {0} questions and earned {1} points.", n, j);
                            break;
                        default:
                            Console.WriteLine("Incorrect. The correct answer was A. You have gained {0} points and answered {1} questions.", j, n);
                            break;
                    }

                }
                else if (BisTrue == true)
                {
                    CisTrue = false; DisTrue = false;
                    switch (responseGiven)
                    {
                        case 'b':
                        case 'B':
                            j++;
                            Console.WriteLine("Correct! You get a point. So far, you have answered {0} questions and earned {1} points.", n, j);
                            break;
                        default:
                            Console.WriteLine("Incorrect. The right answer was B. So far, you have answered {0} questions and earned {1} points.", n, j);
                            break;
                    }
                }
                else if (CisTrue == true)
                {//Yes, I know that declaring AisTrue and BisTrue as false should be unneccessary. The console disagrees.
                    DisTrue = false;
                    switch (responseGiven)
                    {
                        case 'C':
                        case 'c':
                            j++;
                            Console.WriteLine("Correct! You get a point. You have earned {0} points and have answered {1} questions so far.", j, n); break;
                        default:
                            Console.WriteLine("Incorrect. You have earned {0} points and have answered {1} questions so far.", j, n); break;
                    }
                }
                else
                {
                    DisTrue = true; AisTrue = false; BisTrue = false; CisTrue = false;
                    switch (responseGiven)
                    {
                        case 'd':
                        case 'D':
                            j++;
                            Console.WriteLine("Correct! You earn a point. So far, you have earned {0} points and have answered {1} questions.", j, n);
                            break;
                        default:
                            Console.WriteLine("Incorrect. The correct answer was D. So far, you have answered {0} questions and earned {1} points.", n, j);
                            break;

                    }

                }
            }
            Console.WriteLine();
        }

        #endregion
        #region Code to handle binary addition 
        static string[] BinaryAddition()
        {
            //Also code to generate binary number
            c = conditionNum.Next(100, 400);

            i = iNumber.Next(401, 701);

            string addend1 = Convert.ToString(c, 2);
            string addend2 = Convert.ToString(i, 2);
            string binaryProblem = addend1 + "+" + addend2;
            int decimalAnswer = c + i;
            string binaryAnswer = Convert.ToString(decimalAnswer, 2);
            string[] BinaryArray = { binaryProblem, binaryAnswer };
            return BinaryArray;
        }

        #endregion

        #region while loop in which Console.Write is before i, and both are in while loop.
        static void WhileLoopQuestionsTypeOne()
        {
            #region I is < condition number;

            i = iNumber.Next(0, 5);
            c = conditionNum.Next(6, 10);

            Console.WriteLine();
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i < {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("\ti++;");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i < c)
            {
                Console.Write(i);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Type y or Y for yes but n or N for no:");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is <= c;

            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 10);
            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i <= {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("\ti++;");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i <= c)
            {
                Console.Write(i);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("You gave an answer of {0}. Did you get the right answer? Type y for yes but n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is > than c

            i = iNumber.Next(5, 10);
            c = conditionNum.Next(0, 4);
            Console.WriteLine();
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i > {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("\ti--;");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i > c)
            {
                Console.Write(i);
                i--;
            }
            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is >= c;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(1, 5);
            Console.WriteLine();
            Console.WriteLine("int i = {0} ", i);
            Console.WriteLine("while(i >= {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("\ti--;");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("You can find the correct answer below: ");
            n++;
            while (i >= c)
            {
                Console.Write(i);
                i--;
            }
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }

        #endregion
        #region while loops in which i is in the while loop, but console.Write is after the loop
        static void WhileLoopQuestionsTypeTwo()
        #region I is < c;
        {

            i = iNumber.Next(0, 5);
            c = conditionNum.Next(6, 10);

            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i < {0} )", c);
            Console.WriteLine("{");

            Console.WriteLine("\ti++;");
            Console.WriteLine("}");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);

            n++;
            while (i < c)
            {
                i++;
            }
            Console.Write(i);
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region I is <= condition number;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 10);
            Console.WriteLine();
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i <= {0} )", c);
            Console.WriteLine("{");

            Console.WriteLine("\ti++;");
            Console.WriteLine("}");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            Console.WriteLine("You can find the correct answer below");
            while (i <= c)
            {

                i++;
            }
            Console.Write(i);
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region I is > condition number;

            i = iNumber.Next(5, 10);
            c = conditionNum.Next(0, 4);
            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i > {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti--;");
            Console.WriteLine("}");
            Console.WriteLine("Console.Write(i);");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("You can find the correct answer below: ");
            n++;
            while (i > c)
            {

                i--;
            }
            Console.Write(i);
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region I is  condition number;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(0, 5);
            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i >= {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti--;");
            Console.WriteLine("}");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("You can find the correct answer below: ");
            n++;

            while (i >= c)
            {

                i--;
            }
            Console.Write(i);
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }
        #endregion
        #region While loop in which both i and Console.Write is in the while loop, but i is first. 
        static void WhileLoopsType3()
        {

            #region I is < c;

            i = iNumber.Next(0, 5);
            c = conditionNum.Next(6, 10);

            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i < {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti++;");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i < c)
            {
                i++;
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is <= c;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 10);
            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i <= {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti++;");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);

            n++;
            while (i <= c)
            {
                i++;
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is > c;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(0, 4);
            Console.WriteLine();
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i > {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti--;");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);

            n++;
            while (i > c)
            {
                i--;
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i is >= c;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(0, 5);
            Console.WriteLine();
            Console.WriteLine("int i = {0}; ", i);
            Console.WriteLine("while(i >= {0} )", c);
            Console.WriteLine("{");
            Console.WriteLine("\ti--;");
            Console.WriteLine("\tConsole.Write(i);");
            Console.WriteLine("}");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);

            n++;
            while (i >= c)
            {
                i--;
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("You gave the answer of {0}. Did you get the correct answer? Enter in y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }
        #endregion
        #region While loops with Console.Write and i inside loop, but i is added to
        static void WhileLoopsTypeFour()
        {
            // i is less than c 

            i = iNumber.Next(1, 5);
            c = conditionNum.Next(8, 12);
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i < {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\t Console.Write(i);");
            Console.WriteLine("\ti+=2;");
            Console.WriteLine("}");
            Console.WriteLine("Please type in the correct answer below, then press enter:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i < c)
            {
                Console.Write(i);
                i += 2;
            }

            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Type in Y or y for yes, but N or N for no, then hit enter: ", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 12);
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i <= {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\t Console.Write(i);");
            Console.WriteLine("\ti += 2;");
            Console.WriteLine("}");

            Console.WriteLine("Please type in the correct answer below, then press enter:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i <= c)
            {
                Console.Write(i);
                i += 2;
            }

            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Type in Y or y for yes, but N or N for no, then hit enter: ", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);


            //i is greater than c 
            i = iNumber.Next(8, 12);
            c = conditionNum.Next(1, 6);
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i > {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\t Console.Write(i);");
            Console.WriteLine("\t i =- 2;");
            Console.WriteLine("}");

            Console.WriteLine("Please type in the correct answer below, then press enter:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i > c)
            {
                Console.Write(i);
                i -= 2;
            }

            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Type in Y or y for yes, but N or N for no, then hit enter: ", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);


            i = iNumber.Next(6, 10);
            c = conditionNum.Next(0, 6);
            Console.WriteLine("int i = {0};", i);
            Console.WriteLine("while(i >= {0})", c);
            Console.WriteLine("{");
            Console.WriteLine("\t Console.Write(i);");
            Console.WriteLine("\ti -= 2;");
            Console.WriteLine("}");

            Console.WriteLine("Please type in the correct answer below, then press enter:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            while (i >= c)
            {
                Console.Write(i);
                i -= 2;
            }

            Console.WriteLine();
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Type in Y or y for yes, but N or N for no, then hit enter: ", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        #endregion

        #region For loop in which sum is incremented inside loop, then console.write(sum) is outside of it
        static void ForLoopMethod1()
        {
            #region for loop; i < || <= c
            int sum = 0;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);

            List<int> iList = new List<int>
            {
                i
            };
            Console.WriteLine("This is question one of the first for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{\n\tsum++\n}");
            Console.WriteLine("Console.Write(sum);");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;

            for (i = iList[0]; i < c; i++)
            {
                sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the correct answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            sum = 0;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            Console.WriteLine("This is question 2 of the first for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{\n\tsum++\n}");
            Console.WriteLine("Console.Write(sum)");
            Console.WriteLine("Please enter in the correct answer:");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i <= c; i++)
            {
                sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\n Did you get the correct answer? Enter in y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region i > || >= c

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 5);
            sum = 0;
            Console.WriteLine("This is question 3 of the first for loop method");
            Console.WriteLine("int sum= 0;\n for(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{\n\t sum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            Console.WriteLine("Please enter in the correct answer below:");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i > c; i--)
            {
                sum++;
            }
            Console.Write(sum);
            Console.WriteLine("Did you get the right answer? Your answer was {0}. Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 6);
            Console.WriteLine("This is question 4 of the first for loop method");
            Console.WriteLine("int sum= 0;\n for(int i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{\n\t sum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            Console.WriteLine("Please enter in the correct answer below:");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            sum = 0;
            for (i = iList[0]; i >= c; i--)
            {
                sum++;
            }
            Console.Write(sum);
            Console.WriteLine("Did you get the right answer? Your answer was {0}. Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }

        #endregion
        #region For loop in which sum is incremented inside loop, then console.Write(sum, i) is outside of it
        static void ForLoopMethod2()
        {
            #region i < || <= c

            List<int> iList = new List<int>
            {
                i
            };
            i = iNumber.Next(0, 5);
            c = conditionNum.Next(6, 10);
            int sum = 0;
            Console.Write("This is question one of the second for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(int i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{\n\tsum++;");
            Console.WriteLine("}\n Console.Write(sum, i);");

            ReadAndValidateInputString(ref answerGivenString); n++;
            for (i = iList[0]; i < c; i++)
            {
                sum++;
            }
            Console.Write("{0}, {1}", sum, i);
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Enter y for yes but n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(0, 5);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(5, 10);
            sum = 0;
            Console.Write("This is question 2 of the second for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(int i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{\n\tsum++;");
            Console.WriteLine("}\n Console.Write(sum, i);");

            ReadAndValidateInputString(ref answerGivenString); n++;
            for (i = iList[0]; i <= c; i++)
            {
                sum++;
            }
            Console.Write("{0}, {1}", sum, i);
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Enter y for yes but n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            #endregion
            #region i > || >= c;
            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 5);
            sum = 0;
            Console.Write("This is question 3 of the second for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{\n\tsum++;");
            Console.WriteLine("}\n Console.Write(sum, i);");

            ReadAndValidateInputString(ref answerGivenString); n++;
            sum = 0;
            for (i = iList[0]; i > c; i--)
            {
                sum++;
            }
            Console.Write("{0}, {1}", sum, i);
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Enter y for yes but n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            iList.Remove(0);
            iList.Add(i);
            i = iNumber.Next(6, 10);
            c = conditionNum.Next(1, 6);
            sum = 0;
            Console.Write("This is question 4 of the second for loop method");
            Console.WriteLine("int sum = 0;");
            Console.WriteLine("for(i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{\n\tsum++;");
            Console.WriteLine("}\n Console.Write(sum, i);");

            ReadAndValidateInputString(ref answerGivenString); n++;
            for (i = iList[0]; i >= c; i--)
            {
                sum++;
            }
            Console.Write("{0}, {1}", sum, i);
            Console.WriteLine("Did you get the correct answer? Your answer was {0}. Enter y for yes but n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

        }
        #endregion

        #endregion
        #region For loop in which Console.Write(i) is in for loop

        static void ForLoopMethod3()

        {
            #region subregion in which i < || <= c

            List<int> iList = new List<int>
            {
                i
            };
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            Console.Write("This is question 1 of the 3rd for loop method");
            Console.WriteLine("for(int i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i < c; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine("\nDid you get the correct answer? Your answer was {0}. Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            iList.Remove(0);
            i = iNumber.Next(1, 5);
            iList.Add(i);
            c = conditionNum.Next(6, 10);
            Console.Write("This is question 2 of the 3rd for loop method");
            Console.WriteLine("for(int i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i <= c; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine("\nDid you get the correct answer? Your answer was {0}. Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion

            #region subregion in which i is > || >= c

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 5);

            Console.Write("This is question 3 of the 3rd for loop method");
            Console.WriteLine("for(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;

            for (i = iList[0]; i > c; i--)
            {
                Console.Write(i);
            }

            Console.WriteLine("Did you get the right answer? Your answer was {0}. Enter y for yes and n for no", answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 6);
            Console.Write("This is question 4 of the 3rd for loop method");
            Console.WriteLine("for(int i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{\n\t Console.Write(i);");
            Console.WriteLine("}");
            ReadAndValidateInputUlong(ref answerGiven);
            n++;
            for (i = iList[0]; i >= c; i--)
            {
                Console.Write(i);
            }
            Console.WriteLine("Did you get the correct answer? Enter in y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }
        #endregion
        #region Forloop in which Console.Write is inside and outside forloop
        static void ForLoopMethod4()
        {

            #region subregion in which i < || <= c

            List<int> iList = new List<int>
            {
                i
            };

            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            Console.Write("This is question 1 of the 4th for loop method");
            Console.WriteLine("for(int i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);\n}");
            Console.WriteLine("Console.Write(i);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i < c; i++)
            {
                Console.Write(i);
            }
            Console.Write(i);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(1, 6);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(6, 10);
            Console.Write("This is question 2 of the 4th for loop method");
            Console.WriteLine("for(int i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tConsole.Write(i);\n}");
            Console.WriteLine("Console.Write(i);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i <= c; i++)
            {
                Console.Write(i);
            }
            Console.Write(i);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region subregion in which i > || >= c

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 5);
            Console.Write("This is question 3 of the 4th for loop method");
            Console.WriteLine("for(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);");
            Console.WriteLine("}\n Console.Write(i);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i > c; i--)
            {
                Console.Write(i);
            }
            Console.Write(i);
            Console.WriteLine("\n Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 6);
            Console.Write("This is question 4 of the 4th for loop method");
            Console.WriteLine("for(int i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);");
            Console.WriteLine("}\n Console.Write(i);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i >= c; i--)
            {
                Console.Write(i);
            }
            Console.Write(i);
            Console.WriteLine("\n Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
        }

        #endregion
        #region forloop in which Console.Write(i) and then sum is incremented, then outside forloop is Console.Write(sum);
        static void ForLoopMethod5()
        {
            #region subregion in which i < || <= c

            List<int> iList = new List<int>
            {
                i
            };
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            int sum = 0;
            Console.Write("This is question 1 of the 5th for loop method");
            Console.WriteLine("int sum = 0;\n for(int i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i);");
            Console.WriteLine("\tsum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i < c; i++)
            {
                Console.Write(i);
                sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(1, 6);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(6, 10);
            sum = 0;
            Console.Write("This is question 2 of the 5th for loop method");
            Console.WriteLine("int sum = 0;\n for(int i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{\n\t Console.Write(i); sum++; ");
            Console.WriteLine("}\n Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i <= c; i++)
            {
                Console.Write(i); sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes or n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion
            #region subregion in which i > || >= c

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 5);
            sum = 0;
            Console.Write("This is question 3 of the 5th for loop method");
            Console.WriteLine("int sum = 0;\nfor(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i); sum++;");
            Console.WriteLine("}\n Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i > c; i--)
            {
                Console.Write(i); sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(6, 10);
            iList.Remove(0);
            iList.Add(i);
            c = conditionNum.Next(1, 6);
            sum = 0;
            Console.Write("This is question 4 of the 5th for loop method");
            Console.WriteLine("int sum = 0;\nfor(int i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{\n\tConsole.Write(i); sum++;");
            Console.WriteLine("}\n Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i >= c; i--)
            {
                Console.Write(i); sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            #endregion 
        }
        #endregion
        #region Nested for loop in which inside for loop has Console.Write(j) inside of it
        static void NestedForLoop1()
        {

            List<int> iArray = new List<int>();
            i = iNumber.Next(1, 2);
            c = conditionNum.Next(3, 4);
            int m = c - 2;
            iArray.Add(i);
            Console.Write("This is question 1 of the 1st nested for loop method");
            Console.WriteLine("for(int i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m = {0}; m < {1}; m++)", m, c);
            Console.WriteLine("\t\tConsole.Write(m);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iArray[0]; i < c; i++)
            {
                for (m = c - 2; m < c; m++)
                {
                    Console.Write(m);
                }
            }
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(1, 2);
            c = conditionNum.Next(3, 4);

            iArray.Remove(0);
            m = c - 1;
            iArray.Add(i);
            Console.Write("This is question 2 of the 1st nested for loop method");
            Console.WriteLine("for(int i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m  = {0}; m <= {1}; m++)", m, c);
            Console.WriteLine("\t\tConsole.Write(m);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iArray[0]; i <= c; i++)
            {
                for (m = c - 1; m <= c; m++)
                {
                    Console.Write(m);
                }
            }
            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
            iArray.Remove(0);
            i = iNumber.Next(3, 4);
            c = conditionNum.Next(1, 2);
            m = 3;

            iArray.Add(i);
            ;
            Console.Write("This is question 3 of the 1st nested for loop method");
            Console.WriteLine("for(int i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m  = {0}; m > {1}; m--)", m, c);
            Console.WriteLine("\t\tConsole.Write(m);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;

            for (i = iArray[0]; i > c; i--)

                for (m = 3; m > c; m--)
                {
                    Console.Write(m);
                }


            Console.WriteLine("\nDid you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(2, 4);
            c = conditionNum.Next(1, 2);

            iArray.Remove(0);
            iArray.Add(i);
            Console.Write("This is question 4 of the 1st nested for loop method");
            Console.WriteLine("for(int i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m  = {0}; m >= {1}; m--)", m, c);
            Console.WriteLine("\t\tConsole.Write(m);\n}");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iArray[0]; i >= c; i--)
            {
                for (m = 3; m >= c; m--)
                {
                    Console.Write(m);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        #endregion
        #region Outerfor loop, then the inner increments sum, then outside of both loops, print sum
        static void NestedForLoop2()
        {
            int sum = 0;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            List<int> iList = new List<int>
            {
                i
            };
            Console.Write("This is question 1 of the 2nd nested for loop method");
            Console.WriteLine("int sum = 0; \nfor(int i = {0}; i < {1}; i++)", iList[0], c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m = 5; m < {0}; m++)", c);
            Console.WriteLine("\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (int i = iList[0]; i < c; i++)
            {
                for (int m = 5; m < c; m++)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("");
            Console.WriteLine("Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            sum = 0;
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 10);
            iList.Remove(0);
            iList.Add(i);
            Console.Write("This is question 2 of the 2nd nested for loop method");
            Console.WriteLine("int sum = 0; \nfor(int i = {0}; i <= {1}; i++)", iList[0], c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m = 5; m <= {0}; m++)", c);
            Console.WriteLine("\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (int i = iList[0]; i <= c; i++)
            {
                for (int m = 5; m <= c; m++)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("");
            Console.WriteLine("Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            sum = 0;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(1, 4);
            iList.Remove(0);
            iList.Add(i);
            Console.Write("This is question 3 of the 2nd nested for loop method");
            Console.WriteLine("int sum = 0; \nfor(int i = {0}; i > {1}; i--)", iList[0], c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m = 5; m > {0}; m--)", c);
            Console.WriteLine("\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (int i = iList[0]; i > c; i--)
            {
                for (int m = 5; m > c; m--)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("");
            Console.WriteLine("Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);


            sum = 0;
            i = iNumber.Next(5, 10);
            c = conditionNum.Next(1, 5);
            iList.Remove(0);
            iList.Add(i);
            Console.Write("This is question 4 of the 2nd nested for loop method");
            Console.WriteLine("int sum = 0; \nfor(int i = {0}; i > {1}; i--)", iList[0], c);
            Console.WriteLine("{");
            Console.WriteLine("\tfor(int m = 5; m > {0}; m--)", c);
            Console.WriteLine("\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum);");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (int i = iList[0]; i >= c; i--)
            {
                for (int m = 5; m >= c; m--)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("");
            Console.WriteLine("Did you get the right answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        #endregion
        #region Outer for loop sets sum = 0, then inner loop increments sum, then outside both, print sum
        static void NestedForLoop3()
        {
            i = iNumber.Next(1, 5);
            c = conditionNum.Next(6, 10);
            int sum = 0;
            List<int> iList = new List<int>
            {
                i
            };
            Console.Write("This is question 1 of the 3rd nested for loop method");
            Console.WriteLine("for(i = {0}; i < {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tint sum = 0;");
            Console.WriteLine("\t\tfor(int m = 5; m < {0}; m++)", c);
            Console.WriteLine("\t\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum)");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i < c; i++)
            {
                sum = 0;
                for (int m = 5; m < c; m++)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("\nDid you get the right answer? enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(1, 5);
            c = conditionNum.Next(5, 10);
            iList.Remove(0);
            iList.Add(i);
            sum = 0;
            Console.Write("This is question 2 of the 3rd nested for loop method");
            Console.WriteLine("for(i = {0}; i <= {1}; i++)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tint sum = 0;");
            Console.WriteLine("\t\tfor(int m = 5; m <= {0}; m++)", c);
            Console.WriteLine("\t\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum)");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i <= c; i++)
            {
                sum = 0;
                for (int m = 5; m <= c; m++)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("Did you get the correct answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

            i = iNumber.Next(6, 10);
            c = conditionNum.Next(1, 5);
            iList.Remove(0);
            iList.Add(i);
            sum = 0;
            Console.Write("This is question 3 of the 3rd nested for loop method");
            Console.WriteLine("for(i = {0}; i > {1}; i--)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tint sum = 0;");
            Console.WriteLine("\t\tfor(int m = 6; m > {0}; m--)", c);
            Console.WriteLine("\t\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum)");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i > c; i--)
            {
                sum = 0;
                for (int m = 6; m > c; m--)
                    sum++;
            }
            Console.Write(sum);
            Console.WriteLine("Did you get the correct answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);


            i = iNumber.Next(5, 10);
            c = conditionNum.Next(1, 5);
            iList.Remove(0);
            iList.Add(i);
            Console.Write("This is question 4 of the 3rd nested for loop method");
            Console.WriteLine("for(i = {0}; i >= {1}; i--)", i, c);
            Console.WriteLine("{");
            Console.WriteLine("\tint sum = 0;");
            Console.WriteLine("\t\tfor(int m = 5; m >= {0}; m--)", c);
            Console.WriteLine("\t\t\tsum++;\n}");
            Console.WriteLine("Console.Write(sum)");
            ReadAndValidateInputUlong(ref answerGiven); n++;
            for (i = iList[0]; i >= c; i--)
            {
                sum = 0;
                for (int m = 5; m >= c; m--)
                {
                    sum++;
                }
            }
            Console.Write(sum);
            Console.WriteLine("Did you get the correct answer? Enter y for yes but n for no");
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        #endregion

        static void AdditionOfNumbers()
        {
            TrueisTrue = false;
            Console.WriteLine("True or false: When adding binary numbers, 0+0 != 0");
            n++;
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: When adding binary numbers, 0 + 1 equals 1");
            n++; TrueisTrue = true;
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: When adding binary numbers,  1 + 0 equals 1");
            n++;
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: when adding binary numbers, 1 + 1 would have a sum of 0 and a carry of 1. Enter a t for true or a f for false");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);
            Console.WriteLine("What are the numbers included in the octal number system? Type all the numbers with no spaces or commas.\nA:01234567\tB:12345678");
            n++;
            AisTrue = true;
            CheckMultipleChoiceQuestions();

            Console.WriteLine("What are the allowed numbers in hexadecimal? \nA: 0123456789\tB: 123456789");
            n++; AisTrue = true;
            CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter A?\nA:15\tB:10\nC:11\tD:12");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter B?\nA:23\tB:1\nC:11\tD:12");
            n++;
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter C?\nA:12\tB:3\nC:22\tD:32");
            n++;
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter D?\nA:34\tB:4\nC:13\tD:32");
            n++;
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter E?\nA:14\tB:54\nC:26\tD:5");
            n++;
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("In hexadecimal, what is the equivalent number for the letter F?\nA:6\tB:10\nC:34\nD:15");
            n++;
            string[] BinaryArray = new string[2];
            DisTrue = true; CheckMultipleChoiceQuestions(); DisTrue = false;
            BinaryArray = BinaryAddition();

            Console.WriteLine("Please solve the following addition problem: {0} and enter your answer in below.", BinaryArray[0]); n++;
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("{0}", BinaryArray[1]);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        #region ConversionsFromDecimal
        static void ConvertDecimaltoBinary()
        {

            c = conditionNum.Next(1, 10000);
            Console.WriteLine("How do you Convert decimal to binary?\nA:Divide the decimal number by two, and note the remainder. Then divide the quotient by two again" +
                ", and note the remainder. Then repeat until you can't divide anymore. Then, list the remainders in a row, starting from the last remainder and ending at the first\nB:" +
                "Divide the decimal number by 8, and note the remainder. Then divide the quotient by 8 again, and note the remainder. Then repeat until you can't divide anymore. Then, list " +
                "the remainders in a row, starting from the last remainder and ending at the first");
            n++;
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("What is the binary equivalent of the decimal number {0}", c);
            n++;
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("The correct answer was {0}. Did you get it right? Your answer was {1}. Type y or Y for yes, but n or N for no", Convert.ToString(c, 2), answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

        }
        static void ConvertDecimalToOctal()
        {
            c = conditionNum.Next(10, 1000);

            Console.WriteLine("How do you convert Decimal to Octal?\nA:Same way you convert decimal to binary, except instead of dividing by two, you are dividing by 10\nB:Same way you convert decimal to binary, except instead of dividing by two, you divide by 8");
            n++;
            BisTrue = true;
            CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please convert the decimal number of {0} to octal and type your answer in below, then press enter:", c);
            n++;
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("You can view the correct answer below:\n {0}. Your answer was {1}.Did you get it right?", Convert.ToString(c, 8), answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        static void ConvertDecimalToHexadecimal()
        {

            c = conditionNum.Next(16, 300);
            Console.WriteLine("How do you convert decimal to Hexadecimal? Please type in your answer below then hit enter:\nA: Same way you convert decimal to octal, except instead of dividing by 8, you divide by 6\nB:Same way you convert decimal to octal, except instead of dividing by 8, you divide by 16;");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please convert the decimal number {0} to hexadecimal, then type in your answer ans hit enter:", c);
            n++;
            ReadAndValidateInputUlong(ref answerGiven);
            Console.WriteLine("The correct answer is below:\n {0:X}. Your answer was {1}. Did you get it right? Type y or Y for yes or n or N for no.", c, answerGiven);
            ReadAndValidateInputCharYesorNo(ref charGivenYN);

        }
        #endregion
        #region Convert to Decimal

        static void ConvertBinaryToDecimal()
        {
            c = conditionNum.Next(16, 10000);
            Console.WriteLine("True or false: you can convert binary to decimal by multiplying 2 by itself however many times indicated by the power for each number represented by a 1, then add them all up.");
            n++; TrueisTrue = true; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("Please convert {0} to decimal", Convert.ToString(c, 2)); n++;
            ReadAndValidateInputUlong(ref answerGiven); Console.WriteLine("{0}. Did you get the right answer? enter Y for yes or n for no", c); ReadAndValidateInputCharYesorNo(ref charGivenYN);


        }
        static void ConvertHexadecimalToDecimal()
        {
            Console.WriteLine("True or false: You can convert hexadecimal to decimal by using four bits to convert each of the digits in the hexadecimal number to binary . Then converting to decimal");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("Please convert {0} to decimal", Convert.ToString(c, 16)); n++;
            ReadAndValidateInputUlong(ref answerGiven); Console.WriteLine("{0}. Did you get the right answer? type in y for yes or n for no then hit enter", c); ReadAndValidateInputCharYesorNo(ref charGivenYN);
        }
        static void ConvertOctalToDecimal()
        {
            Console.WriteLine("How do you convert octal to decimal?\nA:use two bits to represent each of the digits in the octal number to convert to binary. Then, convert the binary number to decimal.\n" +
                "B:Use three bits to represent each of the digits in the octal number to convert to binary. Then, convert the binary to decimal.");
            n++;
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

        }
        #endregion
        static void VariablesMemoryAndDomain()
        {
            Console.WriteLine("This section will be for matching each variable with the corresponding memory size and domain");
            Console.WriteLine("1. Int \t\t  A:2 bytes, {-2^15,...,(2^15)-1} - {-32,768...32,767} "); //B
            Console.WriteLine("2. Byte\t\t  B:4 bytes, {-2^31,...,(2^31)-1} = {-2,147,483,648...2,147,483,647} ");//C
            Console.WriteLine("3. Short\t   C:1 byte, { 0 - 255}={ 0,....,2 ^ 8 - 1} ");//A

            Console.WriteLine("Please pair number 1 with the correct letter by typing the letter in and then hitting enter");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please pair number 2 with the correct letter by typing the letter in and then hitting enter");
            n++; CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("Please pair number 3 with the correct letter by typing the letter in and then hitting enter");
            n++; AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("1. uint \t  A:8 bytes, { 0,...,(2 ^ 64) - 1} = { 0...18,446,744,073,709,551,615} ");//B
            Console.WriteLine("2. ulong \t  B:4 bytes, { 0,...,2^32 - 1} = { 0...4,294,967,295} ");//a
            Console.WriteLine("3. long \tC:8 bytes, {-(2^63),...,(2^63)-1} = {-9,223,372,036,854,775,808...9,223,372,036,854,775,807}");//C
            Console.WriteLine("Please pair number 1 with the correct letter by typing the letter in and then hitting enter");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please pair number 2 with the correct letter by typing the letter in and then hitting enter");
            n++; AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("Please pair number 3 with the correct letter by typing the letter in and then hitting enter");
            n++; CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("1. sbyte\t  A:2 bytes, unicode character set");//C
            Console.WriteLine("2. char \t  B:2 bytes,{0,...,(2^16)-1} = {0...65,535}");//A
            Console.WriteLine("3. ushort \t  C:1 byte {-128....127}={-2^7,....,2^7-1} ");//B

            Console.WriteLine("Please pair number 1 with the correct letter by typing the letter in and then hitting enter");
            n++; CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("Please pair number 2 with the correct letter by typing the letter in and then hitting enter");
            n++; AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("Please pair number 3 with the correct letter by typing the letter in and then hitting enter");
            n++;  BisTrue = true; CheckMultipleChoiceQuestions(); ReadAndValidateInputCharYesorNo(ref charGivenYN); BisTrue = false;

        }
        static void RulesOfAssocicativity()
        {
            Console.WriteLine("True or false: two binary operators must never be put side by side. Put t for true, F for false");
            n++;
            TrueisTrue = true;
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: Everything enclosed in a parenthesis is evaluated first and parenthesis can't be used to indicate multiplication");
            CheckTrueFalseQuestions(ref characterGivenTF);
            Console.WriteLine("What does += do?\n A: Adds the variable on the left to the variable on the right and then stores the sum in the variable on the left\t B: Adds the variable on the left to the variable on the right and then stores the sum in the variable on the right.");
            n++;
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("What does -= do?\n A: Subtracts the variable on the right from the variable on the left and then stores the difference in the variable on the left\t B: Subtracts the variable on the right from the variable on the left and then stores the difference in the variable on the right.");
            n++; AisTrue = true;
            CheckMultipleChoiceQuestions();

            Console.WriteLine("What does /= do?\n A: Divides the variable on the left by the variable on the right and then stores the quotient in the variable on the left\t B: Divides the variable on the left by the  variable on the right and then stores the quotient in the variable on the right.");
            n++; CheckMultipleChoiceQuestions();

            Console.WriteLine("What does *= do?\n A: Multiplies the variable on the left by the variable on the right and then stores the product in the variable on the left\t B: Multiplies the variable on the left by the variable on the right and then stores the product in the variable on the right.");
            n++; CheckMultipleChoiceQuestions();

            Console.WriteLine("What does %= do?\n A: Divides the variable on the left by the variable on the right and then stores the remainder in the variable on the left\t B: Divides the variable on the left by the variable on the right and then stores the remainder in the variable on the right.");
            n++; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("True or false: the ++ symbol increments its operand by one. Enter t for true and f for false");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: the -- symbol does not decrement its operand by 1. Enter t for true and f for false.");
            n++; TrueisTrue = false; CheckTrueFalseQuestions(ref characterGivenTF);


            Console.WriteLine("Below you will find a list of ordinal numbers and categories of symbols. You will be asked to match the category with the ordinal number, using the rules of associativity as a guide.");
            Console.WriteLine("1 Relational\t\t  A: First"); //B
            Console.WriteLine("2. Postfix increment and decrement\t\t B:Sixth");//A
            Console.WriteLine("3. Prefix increment and decrement \t  C: Third");//C

            Console.WriteLine("Please match number one with the ordinal number it corresponds to");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please match number two with the ordinal number it corresponds to");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("Please match number three with the ordinal number it corresponds to");
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;


            Console.WriteLine("1. Multiplicative \t  A: Fourth");//B
            Console.WriteLine("2. shift \t  B: third");//C
            Console.WriteLine("3. additive \t  C: fifth");//A

            Console.WriteLine("Please match number one with the ordinal number it corresponds to");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please match number two with the ordinal number it corresponds to");
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("Please match number three with the ordinal number it corresponds to");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("1. Equality\t  A: Seventh");//A
            Console.WriteLine("2.  Logical and\t  B:ninth ");//C
            Console.WriteLine("3. Bitwise XOR \t C: eleventh");//B

            Console.WriteLine("Please match number one with the ordinal number it corresponds to");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("Please match number two with the ordinal number it corresponds to");
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("Please match number three with the ordinal number it corresponds to");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("1. Bitwise AND\t A:Thirteenth");//B
            Console.WriteLine("2. Bitwise OR\t B:eighth ");//C
            Console.WriteLine("3. Ternary\t C:Tenth");//A

            Console.WriteLine("Please match number one with the ordinal number it corresponds to");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please match number two with the ordinal number it corresponds to");
            CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("Please match number three with the ordinal number it corresponds to");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("1. Assignment \t A:Twelve");//B
            Console.WriteLine("2. Logical OR\t B:Fourteenth");//A

            Console.WriteLine("Please match number one with the ordinal number it corresponds to");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("Please match number two with the ordinal number it corresponds to");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;
            Console.WriteLine();

            Console.WriteLine("True or false: Both the postfix and prefix increment and decrement categories includes the symbols ++ and --. Enter T or t for true, or f or F for false");
            TrueisTrue = true; n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("What is the difference between the postfix and the prefix operators?/\n A: the prefix operator returns the value of the operand after it has been incremented, whereas the postfix operator returns the value of the operand before it has been incremented;\nB: The postfix operator returns the value of the operand after it has been inremented, whereas the prefix operator returns the value of the operand before it has been incremented;");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("True or false: The * / and % are not part of the multiplicative category. Enter t for true and F for false.");
            n++;
            TrueisTrue = false;
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: the symbols + - are in the additive category. Enter t for true or f for false.");
            n++; TrueisTrue = true; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: the symbols << and >> are part of the shift category. Enter t for true or f for false");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: the relational category includes the symbols < <= > and >= . Enter T for true or F for false");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: the equality category includes the symbols == and !=. Enter t for true or F for false:");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("The bitwise AND category is the  & symbol. Enter T for true or f for false");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);
        }

        static void MixedExpressionRules()
        {
            Console.WriteLine("Now we need to go over the rules for mixed expressions.");
            Console.WriteLine("If either operand is a decimal, then the other operand is converted to what variable type?");
            Console.WriteLine("A: a double \t B: a decimal\n C: an integer \t D: a string");
            n++; BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;
            Console.WriteLine("If either operand is a double, then the other operand is converted to what variable type?\n A: an integer\t B: a short\n C: a double\t D: a uint");
            n++; CisTrue = true; CheckMultipleChoiceQuestions(); CisTrue = false;
            Console.WriteLine("If either operand is a float, then the other operand is then converted to what variable type?\n A: a double\t B: a short\n C: a uint\t D: a float");
            n++; DisTrue = true; CheckMultipleChoiceQuestions(); DisTrue = false;

            Console.WriteLine("If either operand is a ulong, then the other operand is converted to what variable type?\n A: a ulong\t B: a long\n C: a short\t D: a string");
            n++; AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("If either operand is a long, then the other operand is converted to what variable type?\n A: a double\t B: a short\n C: a string\t D: a long");
            n++; DisTrue = true; CheckMultipleChoiceQuestions(); DisTrue = false;

            Console.WriteLine("If one operand is a uint, then the other operand is converted to what variable type?\n A: an uint\t B: A double\n C: a triple\t D: a short");
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("If neither operand is a uint, long, ulong, float,double or decimal, then both must be converted into what variable type?\n A: a string\t B: an int");
            BisTrue = true; CheckMultipleChoiceQuestions(); BisTrue = false;

        }
        static void CastingVariables()
        {
            Console.WriteLine("Time to go over casting!");
            Console.WriteLine("A variable of type sbyte can be converted into which types of variables?\n A: short, int, long, float, Double, and Decimal\t B: byte");
            n++; AisTrue = true; CheckMultipleChoiceQuestions();

            Console.WriteLine("True or false: a variable of type byte can be converted into all numeric data type except char and sbyte. Enter T for true or F for false.");
            CheckTrueFalseQuestions(ref characterGivenTF);//true

            Console.WriteLine("A variable of type short can be converted into what variable type?\nA:int, Long, Float, Double, and Decimal\tB:uint and string");
            n++; CheckMultipleChoiceQuestions();

            Console.WriteLine("A variable of type ushort can be converted into any numeric data type except which of the following data types?\n A: byte, char, sbyte and short;\t B: float, decimal, and int;\nC: ulong and Long;\t D:int and uint");
            CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("A variable of type int can be converted into what four data types?\nA:short, ushort, double, and float;\t B:long, float, double, and decimal;\nC:char, short, ushort, nad string;\tD:float, double, decimal and ulong");
            BisTrue = true; CheckMultipleChoiceQuestions(); n++; BisTrue = false;

            Console.WriteLine("A variable of type uint can be converted into what five data types?\nA: Long, ulong, float, double or decimal\t B: long, int, ushort and short");
            n++; AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("A variable of type long can be converted into which three data types?\n A:float, int and char;\tB:float, double, and decimal");
            BisTrue = true; CheckMultipleChoiceQuestions();
            n++;

            Console.WriteLine("A variable of type char can be converted into all data types except which?\nA: ushort, string\t B:string, bool, byte, sbyte, and short");
            n++; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("A variable of type float can be converted into what data type?\n A: double\t B: decimal");
            AisTrue = true; n++; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("A variable of type ulong can be converted into which 3 data types?\nA:decimal, float, and int\t B: Decimal, float, and double");
            BisTrue = true; CheckMultipleChoiceQuestions(); n++; BisTrue = false;

        }

        static void ArrayQuestions()
        {
            Console.WriteLine("The correct way to declare an one-dimentional array that isn't a constant is which of the following: \n A: *insert variable data type here*[] *insert name of array here* = new *insert same data type here*[*insert number to represent array size here*]\nB: *insert name of array here*[] *insert data type of array here* = new *insert data type* [*insert array size*]");
            n++;
            AisTrue = true; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("The correct way to declare an one dimentional array that is a constant is which of the following:\nA: const *insert data type here* *INSERT CONST NAME HERE* = *insert array size here*\nB:*insert data type here*[] *insert name of array here* = new *insert data type here*[*INSERT CONST NAME HERE*];\n C:Either A or B");
            CisTrue = true; n++; CheckMultipleChoiceQuestions(); CisTrue = false;

            Console.WriteLine("True or false: the correct way to initialize an array at declaration is by replacing everything to the right of the equal size with two curly braces and then entering the variables in between the curly braces");
            CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("True or false: Setting an array equal to another array will copy the array on the left into the array on the right");
            CheckTrueFalseQuestions(ref characterGivenTF);



        }
        static void MethodQuestions()
        {
            Console.WriteLine("True or false: When you call a method that recieves arguments, you do not need to include data types in the method stub");
            TrueisTrue = false; CheckTrueFalseQuestions(ref characterGivenTF); n++;

            Console.WriteLine("True or false: when you call a method that has arguments, you do not need to include data types."); TrueisTrue = true; CheckTrueFalseQuestions(ref characterGivenTF); n++;

            Console.WriteLine("When you pass by value,A: the arguement that did not include data types are copied and stored in the arguments that did include data types B: the arguement that did include data types is copied and stored in the arguments that did not include data types");
            AisTrue = true; n++; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("True or false: When you pass by reference, the called method receives a copy of the argument’s address. This means that the method has the ability to change the actual arguement.");
            TrueisTrue = true; n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("T/F: Passing by out means that an argument needs to be passed but has not been initialized yet.");
            n++; CheckTrueFalseQuestions(ref characterGivenTF);

            Console.WriteLine("The term 'scope' refers to A: the accessibility of a variable; B: the interval of time that the variable exists and can be used by statements within its scope.");
            AisTrue = true; n++; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("Please take a look at the code below:");
            Console.WriteLine("namespace: PracticeTester \n{\n static string colorOption;\n \t class Program");
            Console.WriteLine("\t\t{ \n\t\t\t static void ColorChoosenMethod()\n\t\t\t\t{");
            Console.WriteLine("\t\t\t\t string colorChosen;\n\t\t\t\t}");
            Console.WriteLine("\t\t}\n}");

            Console.WriteLine("What is the difference between colorOption and colorChosen?\n A: colorOption is a class-wide variable whereas colorChosen is a local scope variable\nB: colorOption is a local scope variable whereas colorChosen is a class wide variable");
            Console.WriteLine("What is the difference between colorOption and colorChosen?\n A: colorOption is a class-wide variable whereas colorChosen is a local scope variable\nB: colorOption is a local scope variable whereas colorChosen is a class wide variable");
            BisTrue = true; n++; CheckMultipleChoiceQuestions(); BisTrue = false;

            Console.WriteLine("The term 'storage class' refers to \nA: the period of time in which a variable exists and can be used by statements within its scope\nB: the period of time in which a variable exists and can be used by statements OUTSIDE its scope");
            AisTrue = true; n++; CheckMultipleChoiceQuestions(); AisTrue = false;

            Console.WriteLine("If a variable's storage class is not specified, it defaults to what type of storage class?\n A: automatic\t B: static; \n Trick question-the storage class of a variable must always be specified, the code won't compile otherwise");
            AisTrue = true; n++; CheckMultipleChoiceQuestions();

            Console.WriteLine("T/F: if a variable has an automatic storage class, that means that the variable can be access even after the block in which it is declared is done executing");
            TrueisTrue = false; CheckMultipleChoiceQuestions(); n++; Console.WriteLine("A quote by Dr. James Collins:\"An automatic variable is allocated memory (created) only when the statement block in which it is declared begins to execute. When that statement block’s execution terminates, the automatic variable’s memory is reclaimed (the variable is destroyed).");

            Console.WriteLine("T/F: A static variable retains its memory and value from the time at which the class in which it is declared is first loaded until the program terminates.");
            TrueisTrue = true; CheckMultipleChoiceQuestions(); n++;

        }

    }
}
