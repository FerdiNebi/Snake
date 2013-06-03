namespace MySnake
{
    public struct Vector
    {
        public int X;
        public int Y;
        
        public Vector GetOpposite()
        {
            Vector result;
            result.X = -this.X;
            result.Y = -this.Y;

            return result;
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            Vector result;
            result.X = firstVector.X + secondVector.X;
            result.Y = firstVector.Y + secondVector.Y;

            return result;
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            Vector result;
            result.X = firstVector.X - secondVector.X;
            result.Y = firstVector.Y - secondVector.Y;

            return result;
        }

        public static Vector operator *(int coefficient, Vector aVector)
        {
            Vector result;
            result.X = coefficient * aVector.X;
            result.Y = coefficient * aVector.Y;

            return result;
        }

        public static bool operator ==(Vector firstVector, Vector secondVector)
        {
            return firstVector.X == secondVector.X &&
                   firstVector.Y == secondVector.Y;
        }

        public static bool operator !=(Vector firstVector, Vector secondVector)
        {
            return firstVector.X != secondVector.X ||
                   firstVector.Y != secondVector.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.X.GetHashCode();
                result = result * 23 + this.Y.GetHashCode();
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector))
            {
                return false;
            }
            return this.Equals((Vector)obj);
        }

        public bool Equals(Vector value)
        {
            return this.X == value.X &&
                   this.Y == value.Y;
        }

    }
}