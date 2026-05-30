namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Matrix3x3
{
    /*
    =========================================
    1. Base Components
    =========================================
    */

    public float M11, M12, M13;
    public float M21, M22, M23;
    public float M31, M32, M33;

    public static Matrix3x3 Identity => new Matrix3x3(
        1f, 0f, 0f,
        0f, 1f, 0f,
        0f, 0f, 1f
    );

    public Matrix3x3(
        float m11, float m12, float m13,
        float m21, float m22, float m23,
        float m31, float m32, float m33
    )
    {
        M11 = m11; M12 = m12; M13 = m13;
        M21 = m21; M22 = m22; M23 = m23;
        M31 = m31; M32 = m32; M33 = m33;
    }

    /*
    =========================================
    2. Math (Properties & Methods)
    =========================================
    */

    public float Determinant => (
        M11 * (M22 * M33 - M32 * M23) -
        M12 * (M21 * M33 - M31 * M23) +
        M13 * (M21 * M32 - M31 * M22)
    );

    public Matrix3x3 Transpose => new Matrix3x3(
        M11, M21, M31,
        M12, M22, M32,
        M13, M23, M33
    );
    
    public Matrix3x3 Inverse()
    {
        float det = Determinant;

        if (MathF.Abs(det) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Matrix cannot be inverted: determinant is zero.");

        float invDet = 1f / det;

        return invDet * new Matrix3x3(
            M22 * M33 - M32 * M23,      M32 * M13 - M12 * M33,      M12 * M23 - M22 * M13,
            M23 * M31 - M33 * M21,      M33 * M11 - M13 * M31,      M13 * M21 - M23 * M11,
            M21 * M32 - M31 * M22,      M31 * M12 - M11 * M32,      M11 * M22 - M21 * M12
        );
    }

    public static Matrix3x3 RotationX(float angleRadians)
    {
        float cos = MathF.Cos(angleRadians);
        float sin = MathF.Sin(angleRadians);

        return new Matrix3x3(
            1f,  0f,   0f,
            0f, cos, -sin,
            0f, sin,  cos
        );
    }

    public static Matrix3x3 RotationY(float angleRadians)
    {
        float cos = MathF.Cos(angleRadians);
        float sin = MathF.Sin(angleRadians);

        return new Matrix3x3(
            cos, 0f, sin,
             0f, 1f,  0f,
           -sin, 0f, cos
        );
    }

    public static Matrix3x3 RotationZ(float angleRadians)
    {
        float cos = MathF.Cos(angleRadians);
        float sin = MathF.Sin(angleRadians);

        return new Matrix3x3(
            cos, -sin, 0f,
            sin,  cos, 0f,
             0f,   0f, 1f
        );
    }

    public static Matrix3x3 Scale(float sx, float sy, float sz)
    {
        return new Matrix3x3(
            sx, 0f, 0f,
            0f, sy, 0f,
            0f, 0f, sz
        );
    }

    /*
    =========================================
    3. Operators
    =========================================
    */

    public static Matrix3x3 operator *(Matrix3x3 matrix, float scalar)
    {
        return new Matrix3x3(
            matrix.M11 * scalar, matrix.M12 * scalar, matrix.M13 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar, matrix.M23 * scalar,
            matrix.M31 * scalar, matrix.M32 * scalar, matrix.M33 * scalar
        );
    }

    public static Matrix3x3 operator *(float scalar, Matrix3x3 matrix)
    {
        return matrix * scalar;
    }

    public static Vector3 operator *(Matrix3x3 matrix, Vector3 vec)
    {
        return new Vector3(
            vec.X * matrix.M11 + vec.Y * matrix.M12 + vec.Z * matrix.M13,
            vec.X * matrix.M21 + vec.Y * matrix.M22 + vec.Z * matrix.M23,
            vec.X * matrix.M31 + vec.Y * matrix.M32 + vec.Z * matrix.M33
        );
    }

    public static Matrix3x3 operator +(Matrix3x3 left, Matrix3x3 right)
    {
        return new Matrix3x3(
            left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13,
            left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23,
            left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33
        );
    }

    public static Matrix3x3 operator -(Matrix3x3 left, Matrix3x3 right)
    {
        return new Matrix3x3(
            left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13,
            left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23,
            left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33
        );
    }

    public static Matrix3x3 operator *(Matrix3x3 left, Matrix3x3 right)
    {
        return new Matrix3x3(
            right.M11 * left.M11 + right.M21 * left.M12 + right.M31 * left.M13, // M11
            right.M12 * left.M11 + right.M22 * left.M12 + right.M32 * left.M13, // M12
            right.M13 * left.M11 + right.M23 * left.M12 + right.M33 * left.M13, // M13

            right.M11 * left.M21 + right.M21 * left.M22 + right.M31 * left.M23, // M21
            right.M12 * left.M21 + right.M22 * left.M22 + right.M32 * left.M23, // M22
            right.M13 * left.M21 + right.M23 * left.M22 + right.M33 * left.M23, // M23

            right.M11 * left.M31 + right.M21 * left.M32 + right.M31 * left.M33, // M31
            right.M12 * left.M31 + right.M22 * left.M32 + right.M32 * left.M33, // M32
            right.M13 * left.M31 + right.M23 * left.M32 + right.M33 * left.M33  // M33
        );
    }

    public static bool operator ==(Matrix3x3 left, Matrix3x3 right)
    {
        return (left.M11 == right.M11) && (left.M12 == right.M12) && (left.M13 == right.M13) &&
               (left.M21 == right.M21) && (left.M22 == right.M22) && (left.M23 == right.M23) &&
               (left.M31 == right.M31) && (left.M32 == right.M32) && (left.M33 == right.M33);
    }

    public static bool operator !=(Matrix3x3 left, Matrix3x3 right)
    {
        return !(left == right);
    }

    /*
    =========================================
    4. System Overrides
    =========================================
    */

    public override string ToString()
    {
        return "Matrix3x3:\n" +
                $"{M11,8:F3}{M12,8:F3}{M13,8:F3}\n" + 
                $"{M21,8:F3}{M22,8:F3}{M23,8:F3}\n" +
                $"{M31,8:F3}{M32,8:F3}{M33,8:F3}\n";
    }

    public override bool Equals(object? obj)
    {
        return obj is Matrix3x3 other && this == other;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(M11); hash.Add(M12); hash.Add(M13);
        hash.Add(M21); hash.Add(M22); hash.Add(M23);
        hash.Add(M31); hash.Add(M32); hash.Add(M33);
        return hash.ToHashCode();
    }
}