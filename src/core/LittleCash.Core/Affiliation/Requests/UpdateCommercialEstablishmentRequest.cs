using LittleCash.Core.Affiliation.Enums;
using LittleCash.Core.Affiliation.ValueObjects;

namespace LittleCash.Core.Affiliation.Requests;

public class UpdateCommercialEstablishmentRequest
{
    public long Id { get; set; }
    public string DocumentNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public IList<PaymentScheme> PaymentSchemes { get; set; }
    public Domicile Domicile { get; set; }
}