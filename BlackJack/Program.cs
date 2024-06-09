using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop GL = new GameLoop();
            GL.Play();

            Console.ReadKey();
        }
    }
}
