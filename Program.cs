namespace MathLib;

using MathLib.LinearAlgebra;

class Program
{
    static void Main()
    {
        Matrix3x3 m1 = new Matrix3x3(
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
        );

        Matrix3x3 m2 = new Matrix3x3(
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
        );

        Vector3 vec1 = new Vector3(1, 2, 3);
        
        Matrix3x3 res = m1 * m2;
        Console.WriteLine(res.ToString());
    }
}