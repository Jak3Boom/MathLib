namespace MathLib.LinearAlgebra;

public struct Quaternion
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

    public static Quaternion Identity => new Quaternion (0f, 0f, 0f, 1f);

    public Quaternion(float x, float y, float z, float w)
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

    public Quaternion Normalized()
    {
        if (LengthSquared == 0f)
            return Identity;

        float length = Length;
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

    public static Quaternion AngleAxis(float angleRadians, Vector3 axis)
    {
        if (axis == Vector3.Zero)
            throw new ArgumentException("Axis vector cannot be zero.", nameof(axis));
        
        Vector3 normAxis = axis.Normalized();
        float halfAngle = angleRadians / 2f;
        float sin = MathF.Sin(halfAngle);

        return new Quaternion(
            sin * normAxis.X,
            sin * normAxis.Y,
            sin * normAxis.Z,
            MathF.Cos(halfAngle)
        );
    }

    /*
    =========================================
    3. Operators
    =========================================
    */

    public static Quaternion operator *(Quaternion left, Quaternion right)
    {
        float newX = (left.X * right.W) + (left.Y * right.Z) - (left.Z * right.Y) + (left.W * right.X);
        float newY = (left.Y * right.W) + (left.Z * right.X) + (left.W * right.Y) - (left.X * right.Z);
        float newZ = (left.Z * right.W) + (left.W * right.Z) + (left.X * right.Y) - (left.Y * right.X);
        float newW = (left.W * right.W) - (left.X * right.X) - (left.Y * right.Y) - (left.Z * right.Z);

        return new Quaternion(newX, newY, newZ, newW);
    }

    /*
    =========================================
    4. System Overrides
    =========================================
    */

    public override string ToString()
    {
        return $"({X:F2}, {Y:F2}, {Z:F2}, {W:F2})";
    }
}