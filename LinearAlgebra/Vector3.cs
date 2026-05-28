namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public float LengthSquared()
    {
        return X*X + Y*Y + Z*Z;
    }

    public float Length()
    {
        return MathF.Sqrt(LengthSquared());
    }

    public Vector3 Normalized()
    {
        if (LengthSquared() == 0f)
            return new Vector3(0f, 0f, 0f);
            
        float length = Length();
        return new Vector3(
            X / length,
            Y / length,
            Z / length
        );
    }

    public static Vector3 operator -(Vector3 vec)
    {
        return new Vector3(
            -vec.X,
            -vec.Y,
            -vec.Z
        );
    }

    // Vector addition
    public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
    {
        return new Vector3(
            vec1.X + vec2.X,
            vec1.Y + vec2.Y,
            vec1.Z + vec2.Z
        );
    }

    // Vector subtraction
    public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
    {
        return new Vector3(
            vec1.X - vec2.X,
            vec1.Y - vec2.Y,
            vec1.Z - vec2.Z
        );
    }

    // Vector x Scalar
    public static Vector3 operator *(Vector3 vec, float scalar)
    {
        return new Vector3(
            vec.X * scalar,
            vec.Y * scalar,
            vec.Z * scalar
        );
    }

    // Scalar x Vector
    public static Vector3 operator *(float scalar, Vector3 vec)
    {
        return vec * scalar;
    }

    // Vector / scalar
    public static Vector3 operator /(Vector3 vec, float scalar)
    {
        if (MathF.Abs(scalar) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Vector cannot be divided: scalar is zero.");
            
        return new Vector3(
            vec.X / scalar,
            vec.Y / scalar,
            vec.Z / scalar
        );
    }

    // Dot product
    public static float Dot(Vector3 vec1, Vector3 vec2)
    {
        return (vec1.X * vec2.X) + (vec1.Y * vec2.Y) + (vec1.Z * vec2.Z);
    }

    // Cross product
    public static Vector3 Cross(Vector3 vec1, Vector3 vec2)
    {
        return new Vector3(
            vec1.Y * vec2.Z - vec1.Z * vec2.Y,
            vec1.Z * vec2.X - vec1.X * vec2.Z,
            vec1.X * vec2.Y - vec1.Y * vec2.X
        );
    }
}