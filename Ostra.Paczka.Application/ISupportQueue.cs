using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application;

public interface ISupportQueue
{
    void SaveReturnRequest(SupportTicket supportTicket);
    void SaveRejectRequest(SupportTicket supportTicket);
}