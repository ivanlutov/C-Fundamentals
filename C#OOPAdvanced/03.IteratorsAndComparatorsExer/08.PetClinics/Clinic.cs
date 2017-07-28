using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.PetClinics
{
    public class Clinic : IEnumerable<Pet>
    {
        private List<Pet> pets;
        private readonly int center;
        private int roomsCount;
        private int occupiedRooms;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.RoomsCount = roomsCount;
            this.occupiedRooms = 0;
            this.center = this.RoomsCount / 2;
            this.pets = new List<Pet>(new Pet[this.RoomsCount]);
        }

        public string Name { get; set; }

        public int RoomsCount
        {
            get { return this.roomsCount; }
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.roomsCount = value;
            }
        }

        public bool Add(Pet pet)
        {
            int currentRoom = this.center;

            int step = 0;
            int stepsTaken = 0;
            bool goLeft = true;

            while (this.pets[currentRoom] != null && step <= this.pets.Count() / 2)
            {
                if (goLeft)
                {
                    currentRoom = this.center - step;
                }
                else
                {
                    currentRoom = this.center + step;
                }

                goLeft = !goLeft;

                stepsTaken++;
                if (stepsTaken == 2)
                {
                    step++;
                    stepsTaken = 0;
                }
            }

            if (this.pets[currentRoom] == null)
            {
                this.pets[currentRoom] = pet;
                this.occupiedRooms++;
                return true;
            }

            return false;
        }

        public bool Release()
        {
            for (int i = this.center; i < this.pets.Count; i++)
            {
                if (pets[i] != null)
                {
                    var indexOfPet = this.pets.IndexOf(pets[i]);
                    this.pets[indexOfPet] = null;
                    this.occupiedRooms--;
                    return true;
                }
            }

            for (int i = 0; i < this.center; i++)
            {
                if (pets[i] != null)
                {
                    var indexOfPet = this.pets.IndexOf(pets[i]);
                    this.pets[indexOfPet] = null;
                    this.occupiedRooms--;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            if (this.occupiedRooms < this.RoomsCount)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            var sb = new StringBuilder();
            foreach (var pet in this.pets)
            {
                if (pet != null)
                {
                    sb.AppendLine(pet.ToString());
                }
                else
                {
                    sb.AppendLine("Room empty");
                }
            }

            return sb.ToString().Trim();
        }

        public string Print(int index)
        {
            var sb = new StringBuilder();
            var pet = this.pets[index - 1];
            if (pet != null)
            {
                sb.AppendLine(pet.ToString());
            }
            else
            {
                sb.AppendLine("Room empty");
            }

            return sb.ToString().Trim();
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            for (int i = 0; i < this.pets.Count; i++)
            {
                yield return this.pets[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}