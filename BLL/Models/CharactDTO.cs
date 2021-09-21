using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CharactDTO : IEquatable<CharactDTO>
    {
        public string Value { get; set; }

        public bool Equals(CharactDTO other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Value.Equals(other.Value);
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {
            //Get hash code for the Code field.
            int hashValue = Value.GetHashCode();

            //Calculate the hash code for the product.
            return hashValue;
        }

    }
}
