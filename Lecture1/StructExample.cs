using System;

namespace Lecture1
{
    public struct StructExample : IEquatable<StructExample>
    {
        public int A { get; set; }


        public bool Equals(StructExample other)
        {
            return A == other.A;
        }

        public override bool Equals(object obj)
        {
            return obj is StructExample other && Equals(other);
        }

        public override int GetHashCode()
        {
            return A;
        }

        public static bool operator ==(StructExample left, StructExample right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StructExample left, StructExample right)
        {
            return !left.Equals(right);
        }
    }
}
