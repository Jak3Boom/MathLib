namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Vector4
{
    /*
    =========================================
    1. Base Components
    =========================================
    */

    public float X;
    public float Y;
    public float Z;
    public float W;

    public static Vector4 Zero => new Vector4(0f, 0f, 0f, 0f);

    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    /*
    =========================================
    2. Math (Properties & Methods)
    =========================================
    */

    public float LengthSquared => X*X + Y*Y + Z*Z + W*W;

    public float Length => MathF.Sqrt(LengthSquared);

    public Vector4 Normalized()
    {
        if (LengthSquared == 0f)
            return new Vector4(0f, 0f, 0f, 0f);
            
        float length = Length;
        return new Vector4(
            X / length,
            Y / length,
            Z / length,
            W / length
        );
    }

    public static float Dot(Vector4 vec1, Vector4 vec2)
    {
        return (vec1.X * vec2.X) + (vec1.Y * vec2.Y) + (vec1.Z * vec2.Z) + (vec1.W * vec2.W);
    }

    /*
    =========================================
    3. Operators
    =========================================
    */

    public static Vector4 operator -(Vector4 vec)
    {
        return new Vector4(
            -vec.X,
            -vec.Y,
            -vec.Z,
            -vec.W
        );
    }

    public static Vector4 operator +(Vector4 vec1, Vector4 vec2)
    {
        return new Vector4(
            vec1.X + vec2.X,
            vec1.Y + vec2.Y,
            vec1.Z + vec2.Z,
            vec1.W + vec2.W
        );
    }

    public static Vector4 operator -(Vector4 vec1, Vector4 vec2)
    {
        return new Vector4(
            vec1.X - vec2.X,
            vec1.Y - vec2.Y,
            vec1.Z - vec2.Z,
            vec1.W - vec2.W
        );
    }

    public static Vector4 operator *(Vector4 vec, float scalar)
    {
        return new Vector4(
            vec.X * scalar,
            vec.Y * scalar,
            vec.Z * scalar,
            vec.W * scalar
        );
    }

    public static Vector4 operator *(float scalar, Vector4 vec)
    {
        return vec * scalar;
    }

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

    public static bool operator ==(Vector4 vec1, Vector4 vec2)
    {
        return (vec1.X == vec2.X) && (vec1.Y == vec2.Y) && (vec1.Z == vec2.Z) && (vec1.W == vec2.W);
    }

    public static bool operator !=(Vector4 vec1, Vector4 vec2)
    {
        return !(vec1 == vec2);
    }

    /*
    =========================================
    4. System Overrides
    =========================================
    */

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector4 other && this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }
}