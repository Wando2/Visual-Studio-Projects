using System;
using System.Collections.Generic;

namespace Abstract
{
    class Lista {
        static void Main()
        {
            var PaymentList = new List<PaymentG>();
            // IEnumerable<Person> PersonList = new List<Person>(); lista apenas de leitura
            PaymentG payment1 = new PaymentG(1);
            PaymentG payment2 = new PaymentG(2);
            PaymentG payment3 = new PaymentG(3);

            PaymentList.Add(payment1);
            PaymentList.Add(payment2);
            PaymentList.Add(payment3);

            PaymentList.Add(new PaymentG(4)); // adicionando direto na lista, sintaxe mais simples
            
            foreach (var item in PaymentList)
            {
                Console.WriteLine(item.Id);
            }

             var paymenFind = PaymentList.Find(x => x.Id == 1); // retorna o primeiro elemento que satisfaz a condição

             if (paymenFind != null)
             {
                 Console.WriteLine(paymenFind.Id);
             }              

        }
    }
}