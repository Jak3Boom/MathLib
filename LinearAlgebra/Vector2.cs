namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Vector2
{
    /*
    =========================================
    1. Base Components
    =========================================
    */

    public float X;
    public float Y;

    public static Vector2 Zero => new Vector2(0f, 0f);

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    /*
    =========================================
    2. Math (Properties & Methods)
    =========================================
    */

    public float LengthSquared => X*X + Y*Y;

    public float Length => MathF.Sqrt(LengthSquared);

    public Vector2 Normalized()
    {
        if (LengthSquared == 0f)
            return new Vector2(0f, 0f);

        float length = Length;
        return new Vector2(
            X / length,
            Y / length
        );
    }

    public static float Dot(Vector2 vec1, Vector2 vec2)
    {
        return (vec1.X * vec2.X) + (vec1.Y * vec2.Y);
    }

    public static float Cross(Vector2 vec1, Vector2 vec2)
    {
        return vec1.X * vec2.Y - vec1.Y * vec2.X;
    }    

    /*
    =========================================
    3. Operators
    =========================================
    */

    public static Vector2 operator -(Vector2 vec)
    {
        return new Vector2(
            -vec.X,
            -vec.Y
        );
    }
    
    public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
    {
        return new Vector2(
            vec1.X + vec2.X,
            vec1.Y + vec2.Y
        );
    }
    
    public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
    {
        return new Vector2(
            vec1.X - vec2.X,
            vec1.Y - vec2.Y
        );
    }

    public static Vector2 operator *(Vector2 vec, float scalar)
    {
        return new Vector2(
            vec.X * scalar,
            vec.Y * scalar
        );
    }

    public static Vector2 operator *(float scalar, Vector2 vec)
    {
        return vec * scalar;
    }

    public static Vector2 operator /(Vector2 vec, float scalar)
    {
        if (MathF.Abs(scalar) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Vector cannot be divided: scalar is zero.");

        return new Vector2(
            vec.X / scalar,
            vec.Y / scalar
        );
    }

    public static bool operator ==(Vector2 vec1, Vector2 vec2)
    {
        return (vec1.X == vec2.X) && (vec1.Y == vec2.Y);
    }

    public static bool operator !=(Vector2 vec1, Vector2 vec2)
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
        return $"({X:F3}, {Y:F3})";
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2 other && this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}