namespace Simple_Math_Expression_Evaluator_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.Write("Enter Math Expression : ");
                string input = Console.ReadLine();
                input = input.Trim();
                ExpressionEvaluator expression = new ExpressionEvaluator();
                MathExpression ex = expression.Parser(input);
                double result = ExpressionEvaluator.Result(ex);
                Console.WriteLine($"{input} = {result.ToString("F2")}");
            }
            
        }
    }
}
