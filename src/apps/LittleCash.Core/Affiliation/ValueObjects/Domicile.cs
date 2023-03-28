using LittleCash.Core.Affiliation.Enums;

namespace LittleCash.Core.Affiliation.ValueObjects;

public class Domicile
{
    public long AccountNumber { get; set; }
    public int AccountDigit { get; set; }
    public int Ispb { get; set; }
    public long DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public AccountType AccountType { get; set; }
}