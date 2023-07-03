using LittleCash.Core.Affiliation.ValueObjects;
using LittleCash.Core.Shared.SeedWork;

namespace LittleCash.Core.Entities;

public class CommercialEstablishment : AggregateRoot
{
    public string Name { get; private set; }
    public string Document { get; private set; }
    public PaymentScheme PaymentScheme { get; private set; }
    public Domicile Domicile { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAd { get; private set; }

    public CommercialEstablishment(string name, string document, PaymentScheme paymentScheme, Domicile domicile)
    {
        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        PaymentScheme = paymentScheme;
        Domicile = domicile;
        IsActive = true;
        CreatedAd = DateTime.Now;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}