using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace _08.PetClinics
{
    public class Startup
    {
        public static void Main()
        {
            var holdingClinics = new Dictionary<string, Clinic>();
            var pets = new List<Pet>();

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
                            Pet pet = new Pet(commandLine[2], int.Parse(commandLine[3]), commandLine[4]);
                            pets.Add(pet);
                        }
                        else
                        {
                            try
                            {
                                clinicName = commandLine[2];
                                var roomsCount = int.Parse(commandLine[3]);
                                Clinic clinic = new Clinic(clinicName, roomsCount);
                                holdingClinics[clinicName] = clinic;
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
                        Console.WriteLine(holdingClinics[clinicName].HasEmptyRooms());
                        break;
                    case "HasEmptyRooms":
                        clinicName = commandLine[1];
                        Console.WriteLine(holdingClinics[clinicName].HasEmptyRooms());
                        break;
                    case "Print":
                        clinicName = commandLine[1];
                        var clinicForPrint = holdingClinics[clinicName];
                        if (commandLine.Length > 2)
                        {
                            var roomIndex = int.Parse(commandLine[2]);
                            clinicForPrint.Print(roomIndex);
                        }
                        else
                        {
                            clinicForPrint.Print();
                        }

                        break;
                }
            }
        }
    }
}
