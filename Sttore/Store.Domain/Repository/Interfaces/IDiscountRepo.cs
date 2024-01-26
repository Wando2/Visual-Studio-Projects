using Store.Domain.Entities;

namespace Store.Domain.Repository.Interfaces;

public interface IDiscountRepo
{
    public Discount Get(string code);
}