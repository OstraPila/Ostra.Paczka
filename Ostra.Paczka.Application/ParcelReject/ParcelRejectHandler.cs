using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.ParcelReject;


public class ParcelRejectHandler(SupportQueue supportQueue)
{
    public void Handle(ParcelRejectCommand _)
    {
        supportQueue.SaveRejectRequest(new SupportTicket());
    }
}