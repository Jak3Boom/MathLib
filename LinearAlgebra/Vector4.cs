namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Vector4
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }

    public float LengthSquared()
    {
        return X*X + Y*Y + Z*Z + W*W;
    }

    public float Length()
    {
        return MathF.Sqrt(LengthSquared());
    }

    public Vector4 Normalized()
    {
        if (LengthSquared() == 0)
            return new Vector4(0, 0, 0, 0);
            
        return this / Length();
    }

    public static Vector4 operator -(Vector4 vec)
    {
        return new Vector4(
            -vec.X,
            -vec.Y,
            -vec.Z,
            -vec.W
        );
    }

    // Vector addition
    public static Vector4 operator +(Vector4 vec1, Vector4 vec2)
    {
        return new Vector4(
            vec1.X + vec2.X,
            vec1.Y + vec2.Y,
            vec1.Z + vec2.Z,
            vec1.W + vec2.W
        );
    }

    // Vector subtraction
    public static Vector4 operator -(Vector4 vec1, Vector4 vec2)
    {
        return new Vector4(
            vec1.X - vec2.X,
            vec1.Y - vec2.Y,
            vec1.Z - vec2.Z,
            vec1.W - vec2.W
        );
    }

    // Vector x Scalar
    public static Vector4 operator *(Vector4 vec, float scalar)
    {
        return new Vector4(
            vec.X * scalar,
            vec.Y * scalar,
            vec.Z * scalar,
            vec.W * scalar
        );
    }

    // Scalar x Vector
    public static Vector4 operator *(float scalar, Vector4 vec)
    {
        return vec * scalar;
    }

    // Vector / scalar
    public static Vector4 operator /(Vector4 vec, float scalar)
    {
        if (MathF.Abs(scalar) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Vector cannot be divided: scalar is zero.");
            
        return new Vector4(
            vec.X / scalar,
            vec.Y / scalar,
            vec.Z / scalar,
            vec.W / scalar
        );
    }

    // Dot product
    public static float Dot(Vector4 vec1, Vector4 vec2)
    {
        return (vec1.X * vec2.X) + (vec1.Y * vec2.Y) + (vec1.Z * vec2.Z) + (vec1.W * vec2.W);
    }
}