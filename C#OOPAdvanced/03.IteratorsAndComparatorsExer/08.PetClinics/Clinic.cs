using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.PetClinics
{
    public class Clinic : IEnumerable<Pet>
    {
        private List<Pet> pets;
        public string Name { get; set; }
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
            foreach (var pet in this.pets)
            {
                if (pet != null)
                {
                    this.pets.Remove(pet);
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
        public void Print()
        {
            foreach (var pet in this.pets)
            {
                if (pet != null)
                {
                    Console.WriteLine(pet);
                }
                else
                {
                    Console.WriteLine("Room empty");
                }
            }
        }

        public void Print(int index)
        {
            var pet = this.pets[index];
            if (pet != null)
            {
                Console.WriteLine(pet);
            }
            else
            {
                Console.WriteLine("Room empty");
            }
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            for (int i = this.center; i < this.pets.Count; i++)
            {
                yield return this.pets[i];
            }

            for (int i = 0; i < this.center; i++)
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

