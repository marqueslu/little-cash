using LittleCash.Core.Affiliation.Enums;

namespace LittleCash.Core.Affiliation.ValueObjects;

public class PaymentScheme
{
    public CardBrand Scheme { get; set; }
    public SchemeType SchemeType { get; set; }
}