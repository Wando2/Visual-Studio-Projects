using System;

namespace Abstract
{
    internal class Generics
    {
   /*   static void Main()
        {
            var person = new Person();
            var paymentG = new PaymentG();
            var context = new DataContext<PaymentG, Person, Boleto>();
            context.Save(paymentG);
            context.Save(person);

        }
    */
        
    }
 
    public class PaymentG { 
        public int Id { get; set; }
        public DateTime DueDate { get; set; }

        public PaymentG(int id){
            Id = id;
            DueDate = DateTime.Now;
        }
    }
    public class Person { }

    public class Boleto { }

    public class DataContext <T,P,B>
        where T : PaymentG
        where P : Person
        where B : Boleto
    {
        public void Save(T entity) { 
            System.Console.WriteLine("Salvando T");
        }

        public void Save(P entity)
        {
            System.Console.WriteLine("Salvando P");
        }

        public void Save(B entity)
        {
            System.Console.WriteLine("Salvando B");
        }
    }
}
