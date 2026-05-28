namespace MathLib.LinearAlgebra;

public struct Quaternion
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public Quaternion(float x, float y, float z, float w)
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

    public static Quaternion Identity()
    {
        return new Quaternion (0f, 0f, 0f, 1f);
    }

    public Quaternion Normalized()
    {
        if (LengthSquared() == 0f)
            return Identity();

        float length = Length();
        return new Quaternion(
            X / length,
            Y / length,
            Z / length,
            W / length
        );
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(
           -X,
           -Y,
           -Z,
            W
        );
    }

    // public static Quaternion AngleAxis(float angleRadians, Vector3 axis)
    // {
        
    // }
}