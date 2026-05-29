namespace MathLib;

using MathLib.LinearAlgebra;

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);
        Console.WriteLine((q2*q1).ToString());
    }
}