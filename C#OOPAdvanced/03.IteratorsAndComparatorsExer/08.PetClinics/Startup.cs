using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.PetClinics
{
    public class Startup
    {
        public static List<Pet> pets;
        public static Dictionary<string, Clinic> holdingClinics;

        public static void Main()
        {
            holdingClinics = new Dictionary<string, Clinic>();
            pets = new List<Pet>();

            var countOfCmd = int.Parse(Console.ReadLine());
            var clinicName = string.Empty;
            for (int i = 0; i < countOfCmd; i++)
            {
                var commandLine = Console.ReadLine().Split();
                var cmd = commandLine[0];

                switch (cmd)
                {
                    case "Create":
                        var createType = commandLine[1];
                        if (createType == "Pet")
                        {
                            CreatePet(commandLine);
                        }
                        else
                        {
                            try
                            {
                                clinicName = commandLine[2];
                                CreateClinic(clinicName, commandLine);
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                        }
                        break;

                    case "Add":
                        var petName = commandLine[1];
                        var clinicNameForAdd = commandLine[2];
                        var currentClinic = holdingClinics[clinicNameForAdd];
                        var petForAdd = pets.FirstOrDefault(p => p.Name == petName);
                        Console.WriteLine(currentClinic.Add(petForAdd));
                        break;

                    case "Release":
                        clinicName = commandLine[1];
                        Console.WriteLine(holdingClinics[clinicName].Release());
                        break;

                    case "HasEmptyRooms":
                        clinicName = commandLine[1];
                        Console.WriteLine(holdingClinics[clinicName].HasEmptyRooms());
                        break;

                    case "Print":
                        clinicName = commandLine[1];
                        string resultToPrint = GetPrintData(clinicName, commandLine);
                        Console.WriteLine(resultToPrint);
                        break;
                }
            }
        }

        private static string GetPrintData(string clinicName, string[] commandLine)
        {
            var clinicForPrint = holdingClinics[clinicName];
            var resultToPrint = string.Empty;
            if (commandLine.Length > 2)
            {
                var roomIndex = int.Parse(commandLine[2]);
                resultToPrint = clinicForPrint.Print(roomIndex);
            }
            else
            {
                resultToPrint = clinicForPrint.Print();
            }

            return resultToPrint;
        }

        private static void CreateClinic(string clinicName, string[] commandLine)
        {
            var roomsCount = int.Parse(commandLine[3]);
            Clinic clinic = new Clinic(clinicName, roomsCount);
            holdingClinics[clinicName] = clinic;
        }

        private static void CreatePet(string[] commandLine)
        {
            Pet pet = new Pet(commandLine[2], int.Parse(commandLine[3]), commandLine[4]);
            pets.Add(pet);
        }
    }
}