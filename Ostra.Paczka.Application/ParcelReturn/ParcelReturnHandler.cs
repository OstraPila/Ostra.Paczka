using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.ParcelReturn;

public record ParcelReturnCommand(Sender Sender, Recipient Recipient, ShipmentRequest ShipmentRequest, Reason? Reason);

public class ParcelReturnHandler(SupportQueue supportQueue)
{
    public void Handle(ParcelReturnCommand _)
    {
        supportQueue.SaveReturnRequest(new SupportTicket());
    }
}