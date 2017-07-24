using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.PetClinics
{
    public class Clinic<Pet> : IEnumerable<Pet>
    {
        public IEnumerator<Pet> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

