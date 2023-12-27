using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.ParcelReturn;

public record ParcelReturnCommand(Sender Sender, Recipient Recipient, ShipmentRequest ShipmentRequest, Reason? Reason);

public class ParcelReturnHandler(ISupportQueue supportQueue)
{
    public void Handle(ParcelReturnCommand _)
    {
        supportQueue.SaveReturnRequest(new SupportTicket());
    }
}