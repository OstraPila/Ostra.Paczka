using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application;

public class SupportService(SupportQueue supportQueue)
{
    public void ReturnParcel(ParcelReturnRequest parcelReturnRequest)
    {
        // zwrot towaru - koszt po stronie kupującego
        supportQueue.SaveReturnRequest(new SupportTicket());
    }

    public void RejectParcel(ParcelRejectRequest parcelRejectRequest)
    {
        // nieprzyjecie towaru; paczka uszkodzone - koszt po stronie ??
        supportQueue.SaveRejectRequest(new SupportTicket());
    }
}

public record SupportTicket;