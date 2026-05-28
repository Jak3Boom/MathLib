namespace MathLib;

using MathLib.LinearAlgebra;

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Console.WriteLine(q1.Normalized().ToString());
    }
}