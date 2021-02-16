using System;

namespace Overloading
{
    /*
    * The constructors and methods overloading
    */
    public class Patient
    {
        private int Id { get; set; }
        private string Surname { get; set; }
        private string Name { get; set; }
        private string Diagnosis { get; set; }
        private DateTime Birthday { get; set; }

        public Patient(DateTime birthday, string surname)
        {
            Birthday = birthday;
            Surname = surname;
        }

        // Constructor overloading. Сalling constructor from other constructor.
        public Patient(int id, string surname, string name, string diagnosis, DateTime birthday) : this(birthday,
            surname)
        {
            Id = id;
            Name = name;
            Diagnosis = diagnosis;
        }

        public Patient(Patient patient)
        {
            Id = Id;
            Surname = Surname;
            Name = Name;
            Diagnosis = Diagnosis;
            Birthday = Birthday;
        }

        // Method Overloading.
        public void ChangePatientInformation(string diagnosis)
        {
            Diagnosis = diagnosis;
        }
/// <summary>
/// Extended patient information changer
/// </summary>
/// <param Name="id"></param>
/// <param Name="Diagnosis"></param>
/// <param Name="personalInfo">1rst - name, 2nd - surname, 3rd - birthday (type of DateTime object)</param>
        public void ChangePatientInformation(int id, string diagnosis, params object[] personalInfo)
        {
            Id = id;
            Diagnosis = diagnosis;
            Name = personalInfo[0].ToString();
            Surname = personalInfo[1].ToString();
            Birthday = Convert.ToDateTime(personalInfo[2]);
        }

        public void PrintPatientInfo()
        {
            Console.WriteLine(
                $"Patient: id = {Id}, surname = {Surname}, name = {Name}, diagnosis = {Diagnosis}, birthday = {Birthday}");
        }
    }
}