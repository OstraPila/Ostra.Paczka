using Ostra.Paczka.Application;
using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Infrastructure;

public class SupportQueue : ISupportQueue
{
    public void SaveReturnRequest(SupportTicket supportTicket)
    {
        throw new NotImplementedException();
    }

    public void SaveRejectRequest(SupportTicket supportTicket)
    {
        throw new NotImplementedException();
    }
}