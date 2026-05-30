namespace MathLib.LinearAlgebra;

using MathLib.Constants;

public struct Matrix2x2
{
    /*
    =========================================
    1. Base Components
    =========================================
    */

    public float M11, M12;
    public float M21, M22;

    public static Matrix2x2 Identity => new Matrix2x2(
        1f, 0f,
        0f, 1f
    );

    public Matrix2x2(
        float m11, float m12,
        float m21, float m22
    )
    {
        M11 = m11; M12 = m12;
        M21 = m21; M22 = m22;
    }

    /*
    =========================================
    2. Math (Properties & Methods)
    =========================================
    */

    public float Determinant => M11 * M22 - M21 * M12;

    public Matrix2x2 Transpose => new Matrix2x2(
        M11, M21,
        M12, M22
    );
    
    public Matrix2x2 Inverse()
    {
        float det = Determinant;

        if (MathF.Abs(det) < MathConstants.NearlyZero)
            throw new InvalidOperationException("Matrix cannot be inverted: determinant is zero.");

        float invDet = 1f / det;
        return invDet * new Matrix2x2(
            M22, -M12,
           -M21,  M11
        );
    }

    public static Matrix2x2 Rotation(float angleRadians)
    {
        float cos = MathF.Cos(angleRadians);
        float sin = MathF.Sin(angleRadians);

        return new Matrix2x2(
            cos, -sin,
            sin,  cos
        );
    }

    public static Matrix2x2 Scale(float sx, float sy)
    {
        return new Matrix2x2(
            sx, 0f,
            0f, sy
        );
    }
    
    /*
    =========================================
    3. Operators
    =========================================
    */

    public static Matrix2x2 operator *(Matrix2x2 matrix, float scalar)
    {
        return new Matrix2x2(
            matrix.M11 * scalar, matrix.M12 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar
        );
    }

    public static Matrix2x2 operator *(float scalar, Matrix2x2 matrix)
    {
        return matrix * scalar;
    }

    public static Vector2 operator *(Matrix2x2 matrix, Vector2 vec)
    {
        return new Vector2(
            vec.X * matrix.M11 + vec.Y * matrix.M12,
            vec.X * matrix.M21 + vec.Y * matrix.M22
        );
    }
    
    public static Matrix2x2 operator +(Matrix2x2 left, Matrix2x2 right)
    {
        return new Matrix2x2(
            left.M11 + right.M11, left.M12 + right.M12,
            left.M21 + right.M21, left.M22 + right.M22
        );
    }

    public static Matrix2x2 operator -(Matrix2x2 left, Matrix2x2 right)
    {
        return new Matrix2x2(
            left.M11 - right.M11, left.M12 - right.M12,
            left.M21 - right.M21, left.M22 - right.M22
        );
    }

    public static Matrix2x2 operator *(Matrix2x2 left, Matrix2x2 right)
    {
        return new Matrix2x2(
            right.M11 * left.M11 + right.M21 * left.M12, // M11
            right.M12 * left.M11 + right.M22 * left.M12, // M12

            right.M11 * left.M21 + right.M21 * left.M22, // M21
            right.M12 * left.M21 + right.M22 * left.M22  // M22
        );
    }

    public static bool operator ==(Matrix2x2 left, Matrix2x2 right)
    {
        return (left.M11 == right.M11) && (left.M12 == right.M12) &&
               (left.M21 == right.M21) && (left.M22 == right.M22);
    }

    public static bool operator !=(Matrix2x2 left, Matrix2x2 right)
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
        return "\n" +
                $"{M11,8:F3}{M12,8:F3}\n" + 
                $"{M21,8:F3}{M22,8:F3}\n";
    }

    public override bool Equals(object? obj)
    {
        return obj is Matrix2x2 other && this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            M11, M12,
            M21, M22
        );
    }
}