namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Matrix2x2
{
    public float M11, M12;
    public float M21, M22;

    public Matrix2x2(float m11, float m12, float m21, float m22)
    {
        M11 = m11; M12 = m12;
        M21 = m21; M22 = m22;
    }

    public override string ToString()
    {
        return "\n" +
                $"{M11,8:F2}{M12,8:F2}\n" + 
                $"{M21,8:F2}{M22,8:F2}\n";
    }

    // Matrix x Scalar
    public static Matrix2x2 operator *(Matrix2x2 matrix, float scalar)
    {
        return new Matrix2x2(
            matrix.M11 * scalar, matrix.M12 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar
        );
    }

    // Scalar x Matrix
    public static Matrix2x2 operator *(float scalar, Matrix2x2 matrix)
    {
        return matrix * scalar;
    }

    // Matrix x Vector
    public static Vector2 operator *(Matrix2x2 matrix, Vector2 vec)
    {
        return new Vector2(
            vec.X * matrix.M11 + vec.Y * matrix.M12,
            vec.X * matrix.M21 + vec.Y * matrix.M22
        );
    }

    // Matrix x Matrix
    public static Matrix2x2 operator *(Matrix2x2 matrix2, Matrix2x2 matrix1)
    {
        return new Matrix2x2(
            matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12, // M11
            matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12, // M12
            matrix1.M11 * matrix2.M21 + matrix1.M21 * matrix2.M22, // M21
            matrix1.M12 * matrix2.M21 + matrix1.M22 * matrix2.M22  // M22
        );
    }

    // Determinant
    public float Determinant()
    {
        return M11 * M22 - M21 * M12;
    }

    // Inverse matrix
    public Matrix2x2 Inverse()
    {
        float det = Determinant();

        if (MathF.Abs(det) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Matrix cannot be inverted: determinant is zero.");

        float invDet = 1f / det;
        return new Matrix2x2(
            M22 * invDet, -M12 * invDet,
           -M21 * invDet,  M11 * invDet
        );
    }
}