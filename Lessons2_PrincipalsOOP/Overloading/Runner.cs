using System;

namespace Overloading
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            Patient patient1 =
                new Patient(111, "Petrov", "Petr", "Bronchit", new DateTime(1990, 10, 4));
            Patient patient2 = patient1;
            patient2.ChangePatientInformation("Otit");
            Console.WriteLine(patient1.Equals(patient2));
            Patient patient3 = patient1;
            patient3.ChangePatientInformation(113, "Pneumonia", "Ivan", "Ivanov", new DateTime(1980, 12, 3));
            patient3.PrintPatientInfo();
        }
    }
}