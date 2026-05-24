namespace MathLib.LinearAlgebra;

public struct Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public float LengthSquared()
    {
        return X*X + Y*Y;
    }

    public float Length()
    {
        return MathF.Sqrt(LengthSquared());
    }

    public Vector2 Normalized()
    {
        if (LengthSquared() == 0)
            return new Vector2(0, 0);

        float length = Length();
        return new Vector2(
            X / length,
            Y / length
        );
    }

    // Vector addition
    public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
    {
        return new Vector2(
            vec1.X + vec2.X,
            vec1.Y + vec2.Y
        );
    }

    // Vector subtraction
    public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
    {
        return new Vector2(
            vec1.X - vec2.X,
            vec1.Y - vec2.Y
        );
    }

    // Vector x Scalar
    public static Vector2 operator *(Vector2 vec, float scalar)
    {
        return new Vector2(
            vec.X * scalar,
            vec.Y * scalar
        );
    }

    // Scalar x Vector
    public static Vector2 operator *(float scalar, Vector2 vec)
    {
        return vec * scalar;
    }

    // Dot product
    public static float Dot(Vector2 vec1, Vector2 vec2)
    {
        return (vec1.X * vec2.X) + (vec1.Y * vec2.Y);
    }

    // Cross product
    public static float Cross(Vector2 vec1, Vector2 vec2)
    {
        return vec1.X * vec2.Y - vec1.Y * vec2.X;
    }
}