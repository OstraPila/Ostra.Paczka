using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.ParcelReject;

public record ParcelRejectCommand(Reason Reason);

public class ParcelRejectHandler(ISupportQueue supportQueue)
{
    public void Handle(ParcelRejectCommand _)
    {
        supportQueue.SaveRejectRequest(new SupportTicket());
    }
}