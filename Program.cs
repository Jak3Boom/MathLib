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
           -4, 2, 1,
            1, 2, 3,
            5, 1, 2
        );

        Vector3 v1 = new Vector3(1, 2, -5);

        Console.WriteLine((-v1).ToString());
    }
}