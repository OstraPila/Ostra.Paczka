using System.Linq.Expressions;

namespace Ostra.Paczka.SharedKernel;

public interface IParcelsStore<T>
{
    void Add(T delivery);
    IList<T> Get();
    Result<T> GetBy(Func<T, bool> getBy);
}