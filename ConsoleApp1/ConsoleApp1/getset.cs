using System;

namespace ConsoleApp1
{
    class Program2
    {
        static void Main(string[] args)
        {
           using(var pessoa = new GetSet("123", "João", "Rua 1"))
            {
                pessoa.Cadastrar("Rua 2");
                Console.WriteLine(pessoa.endereco);
       
            }

        
        }
    }

    class GetSet : IDisposable
    {
        public string cpf { get; set; }
        public string nome { get; set; }

        private string _endereco;

        public string endereco
        {
            get
            {
                return _endereco;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("Endereço não pode ser nulo");
                }
                _endereco = value;
            }
        }

        public GetSet(string cpf, string nome, string endereco)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.endereco = endereco;
        }

        public void Cadastrar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new Exception("Texto não pode ser nulo ou vazio");
            }

            this.endereco = texto;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }

    class Filho : GetSet
    {
        public Filho(string cpf, string nome, string endereco) : base(cpf, nome, endereco)
        {
        }
    }
}
