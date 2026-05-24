namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Matrix3x3
{
    public float M11, M12, M13;
    public float M21, M22, M23;
    public float M31, M32, M33;

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

    public override string ToString()
    {
        return "\n" +
                $"{M11,8:F2}{M12,8:F2}{M13,8:F2}\n" + 
                $"{M21,8:F2}{M22,8:F2}{M23,8:F2}\n" +
                $"{M31,8:F2}{M32,8:F2}{M33,8:F2}\n";
    }

    // Matrix x Scalar
    public static Matrix3x3 operator *(Matrix3x3 matrix, float scalar)
    {
        return new Matrix3x3(
            matrix.M11 * scalar, matrix.M12 * scalar, matrix.M13 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar, matrix.M23 * scalar,
            matrix.M31 * scalar, matrix.M32 * scalar, matrix.M33 * scalar
        );
    }

    // Scalar x Matrix
    public static Matrix3x3 operator *(float scalar, Matrix3x3 matrix)
    {
        return matrix * scalar;
    }

    // Matrix x Vector
    public static Vector3 operator *(Matrix3x3 matrix, Vector3 vec)
    {
        return new Vector3(
            vec.X * matrix.M11 + vec.Y * matrix.M12 + vec.Z * matrix.M13,
            vec.X * matrix.M21 + vec.Y * matrix.M22 + vec.Z * matrix.M23,
            vec.X * matrix.M31 + vec.Y * matrix.M32 + vec.Z * matrix.M33
        );
    }

    // Matrix x Matrix
    public static Matrix3x3 operator *(Matrix3x3 matrix2, Matrix3x3 matrix1)
    {
        return new Matrix3x3(
            matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12 + matrix1.M31 * matrix2.M13, // M11
            matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12 + matrix1.M32 * matrix2.M13, // M12
            matrix1.M13 * matrix2.M11 + matrix1.M23 * matrix2.M12 + matrix1.M33 * matrix2.M13, // M13

            matrix1.M11 * matrix2.M21 + matrix1.M21 * matrix2.M22 + matrix1.M31 * matrix2.M23, // M21
            matrix1.M12 * matrix2.M21 + matrix1.M22 * matrix2.M22 + matrix1.M32 * matrix2.M23, // M22
            matrix1.M13 * matrix2.M21 + matrix1.M23 * matrix2.M22 + matrix1.M33 * matrix2.M23, // M23

            matrix1.M11 * matrix2.M31 + matrix1.M21 * matrix2.M32 + matrix1.M31 * matrix2.M33, // M31
            matrix1.M12 * matrix2.M31 + matrix1.M22 * matrix2.M32 + matrix1.M32 * matrix2.M33, // M32
            matrix1.M13 * matrix2.M31 + matrix1.M23 * matrix2.M32 + matrix1.M33 * matrix2.M33  // M33
        );
    }
}