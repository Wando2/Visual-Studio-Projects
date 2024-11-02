namespace Store.Domain.Repository.Interfaces;

public interface IDeliveryRepository
{
    public decimal Get(string zipCode);
    
}