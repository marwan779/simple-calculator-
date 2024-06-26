using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Math_Expression_Evaluator_V2
{
    public  class ExpressionEvaluator
    {
        public  MathExpression Parser(string input)
        {
            var expr = new MathExpression();
            char CurrentChar;
            string Token = "";
            bool LiftInitalized = false;
            int count = 0;
            String Symbol = "+*%^/";
            for (int i = 0;i<input.Length;i++)
            {
                CurrentChar = input[i];
                if(Char.IsDigit(CurrentChar))
                {
                    if (LiftInitalized == false)
                    {
                        Token += CurrentChar;
                    }
                    else if (LiftInitalized == true && expr.Operation != MathOperation.None)
                    {
                        Token += CurrentChar;
                        expr.RightHandSide = double.Parse(Token);
                    }
                }
                else if(Symbol.Contains(CurrentChar))
                {
                    if(LiftInitalized == false)
                    {
                        expr.LiftHandSide = double.Parse(Token);
                        LiftInitalized = true; 
                        Token = "";
                        Token += CurrentChar;
                        expr.Operation = DetermineOperation(Token);
                        Token = "";
                    }
                }
                else if(CurrentChar == '-')
                {
                    if(LiftInitalized == false && i == 0)
                    {
                        Token += CurrentChar;
                    }
                    else if(LiftInitalized == false && expr.Operation == MathOperation.None)
                    {
                        expr.LiftHandSide = double.Parse(Token);
                        LiftInitalized = true;
                        Token = "";
                        expr.Operation = MathOperation.Subtract;
                    }
                    else if(LiftInitalized == true && expr.Operation != MathOperation.None)
                    {
                        Token += CurrentChar;
                    }
                }
                else if(CurrentChar == ' ')
                {
                    Token += CurrentChar;
                }
                else if(Char.IsLetter(CurrentChar))  
                {
                    LiftInitalized = true;
                    Token += CurrentChar;
                    count++;
                    if(count == 3)
                    {
                        expr.Operation = DetermineOperation(Token.ToLower());
                        Token = "";
                    }
                    
                }
                else
                {

                }
            }
            return expr;
        }

        public MathOperation DetermineOperation(string Token)
        {
            var op = new MathOperation();
            switch (Token)
            {
                case "+"  : op = MathOperation.Add;
                     return op;
                case "*"  : op = MathOperation.Multiply;
                     return op;
                case "/"  : op = MathOperation.Divide;
                     return op;
                case "^"  : op = MathOperation.Power;
                     return op;
                case "%":   op= MathOperation.Modulus;
                     return op;
                case "sin": op = MathOperation.Sin;
                    return  op;
                case "cos": op = MathOperation.Cos;
                    return  op;
                case "tan": op = MathOperation.Tan;
                    return  op;
                default: throw new NotImplementedException("Operation Not Found :)");
            }   
        }
        public static double Result(MathExpression expr)
        {
            double result = 0;
            if (expr.Operation == MathOperation.Add)
            {
                result = expr.LiftHandSide + expr.RightHandSide;
            }
            else if (expr.Operation == MathOperation.Subtract)
            {
                result = expr.LiftHandSide - expr.RightHandSide;
            }
            else if (expr.Operation == MathOperation.Multiply)
            {
                result = expr.LiftHandSide * expr.RightHandSide;
            }
            else if (expr.Operation == MathOperation.Divide)
            {
                result = expr.LiftHandSide / expr.RightHandSide;
            }
            else if (expr.Operation == MathOperation.Modulus)
            {
                result = expr.LiftHandSide % expr.RightHandSide;
            }
            else if (expr.Operation == MathOperation.Power)
            {
                result = Math.Pow(expr.LiftHandSide, expr.RightHandSide);
            }
            else if ((expr.Operation == MathOperation.Sin))
            {
                result = Math.Sin((expr.RightHandSide*Math.PI)/180);
            }
            else if ((expr.Operation == MathOperation.Cos))
            {
                result = Math.Cos((expr.RightHandSide * Math.PI) / 180);
            }
            else if (((expr.Operation == MathOperation.Tan)))
            {
                result = Math.Tan((expr.RightHandSide * Math.PI) / 180);
            }
            else
            {
                throw new Exception("Error : No operation found");
            }

            return result;
        }
    }
}
