using System.Runtime.CompilerServices;

class Program
{
    //static void main()
    //{
    //    var pagamentoboleto = new pagamentoboleto();
    //    pagamentoboleto.pagar();
    //}
}

public interface IPayment
{
    DateTime vencimento { get; set; }
    public void Pagar();
    
       
}

public abstract class Pagamento : IPayment
{
    public DateTime vencimento { get; set; }
    public  virtual void Pagar()
    {
        Console.WriteLine("Pagamento realizado com sucesso");
    }
}

public class PagamentoBoleto : Pagamento
{
    public override void Pagar()
    {
        Console.WriteLine("Pagamento realizado com sucesso com boleto");
    }
}

