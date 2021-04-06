namespace Lessons5_NUnit.Models
{
    public class Calcucator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        
        public int Division(int a, int b)
        {
            return a / b;
        }

        public double Division(double a, double b)
        {
            return a / b;
        }

        public int Multiplication(int a, int b)
        {
            return a * b;
        }

        public int RemainderOfDivision(int a, int b)
        {
            return a % b;
        }
    }
}