using Store.Domain.Entities;

namespace Store.Domain.Repository.Interfaces;

public interface IDiscountRepository
{
    public Discount Get(string code);
}