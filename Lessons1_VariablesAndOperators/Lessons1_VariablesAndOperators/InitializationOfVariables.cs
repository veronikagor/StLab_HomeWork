using System;

/*
 * Initialize variables of all types.
 */
namespace Lessons1_VariablesAndOperators
{
    class InitializationOfVariables
    {
        public static void InitializeVariables()
        {
            Random random = new Random();
            bool booleanType = true;
            byte byteType = 255;
            sbyte sbyteType = -128;
            char charType = '#';
            decimal decimalType = -7501249835625724518m;
            double doubleType = 0.3d;
            float floatType = 1.3f;
            int integerType = random.Next(short.MinValue, short.MaxValue);
            uint uintegerType = 436029458;
            long longType = -9223372036854775808;
            ulong ulongType = 18446744073709551615;
            short shortType = -32768;
            string stringType = "C#";
            object objectType1 = byteType;
            object objectType2 = floatType;
            object objectType3 = "Hello ";
            dynamic dynamicType = objectType3 + stringType;

            Console.WriteLine("\n\t\t\t\t\t\tNumeric types:\n");

            Console.WriteLine($"The variable of the {typeof(byte).Name} type is assigned a value {byteType}");
            Console.WriteLine($"The variable of the {typeof(sbyte).Name} type is assigned a value {sbyteType}");
            Console.WriteLine($"The variable of the {typeof(decimal).Name} type is assigned a value {decimalType}");
            Console.WriteLine($"The variable of the {typeof(double).Name} type is assigned a value {doubleType}");
            Console.WriteLine($"The variable of the float({typeof(float).Name}) type is assigned a value {floatType}");
            Console.WriteLine($"The variable of the int({typeof(int).Name}) type is assigned a value {integerType}");
            Console.WriteLine($"The variable of the uint({typeof(uint).Name}) type is assigned a value {uintegerType}");
            Console.WriteLine($"The variable of the long({typeof(long).Name}) type is assigned a value {longType}");
            Console.WriteLine($"The variable of the short({typeof(short).Name}) type is assigned a value {shortType}");

            Console.WriteLine("\n\t\t\t\t\t\tCharacter type:\n");

            Console.WriteLine($"The variable of the {typeof(char).Name} type is assigned a value {charType}");

            Console.WriteLine("\n\t\t\t\t\t\tLogical type:\n");
            Console.WriteLine($"The variable of the {typeof(bool).Name} type is assigned a value {booleanType}");

            Console.WriteLine("\n\t\t\t\t\t\tReference types:\n");
            Console.WriteLine($"The variable of the {typeof(string).Name} type is assigned a value '{stringType}'");
            Console.WriteLine(
                $"The variable of the {typeof(object).Name} can be assigned a value {objectType1} or {objectType2} or '{objectType3}'");
            Console.WriteLine(
                $"The dynamic variable is assigned the type {dynamicType.GetType()} and value '{dynamicType}'");
        }
    }
}