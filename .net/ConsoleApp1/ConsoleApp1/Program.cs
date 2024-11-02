using System;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        private static void Cadastrar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new Exception("Texto não pode ser nulo ou vazio");
            }
        }

//        public static void Main(string[] args)
//        {
//            double idade = 23.231134;
//            string nome = "João";
//            var array = new int[] { 1, 2, 3, 4, 5 };

//            try
//            {

//                Console.WriteLine($"hello, my name is {nome} and i have {idade}");
//                 Console.Write(array[8] );
//                Cadastrar("");
//            }

//            catch (IndexOutOfRangeException e)
//            {
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.InnerException);
//            }

//            catch (ArgumentNullException e) { 
//                Console.WriteLine(e.Message);
//            }

            


//            catch(Exception e)
//            {
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.InnerException);

//            }


//;
//        }
    }
}
