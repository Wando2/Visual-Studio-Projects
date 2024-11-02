using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        
        AddNotifications(new Contract<Address>()
            .Requires()
            .IsNotNullOrEmpty(Street, "Address.Street", "Rua é obrigatória")
            .IsNotNullOrEmpty(Number, "Address.Number", "Número é obrigatório")
            .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "Bairro é obrigatório")
            .IsNotNullOrEmpty(City, "Address.City", "Cidade é obrigatória")
            .IsNotNullOrEmpty(State, "Address.State", "Estado é obrigatório")
            .IsNotNullOrEmpty(Country, "Address.Country", "País é obrigatório")
            .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "CEP é obrigatório")
            .IsLowerOrEqualsThan(Street, 40, "Address.Street", "Rua deve conter até 40 caracteres")
            .IsLowerOrEqualsThan(Neighborhood, 40, "Address.Neighborhood", "Bairro deve conter até 40 caracteres")
            .IsLowerOrEqualsThan(City, 40, "Address.City", "Cidade deve conter até 40 caracteres")
                
        
        );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}