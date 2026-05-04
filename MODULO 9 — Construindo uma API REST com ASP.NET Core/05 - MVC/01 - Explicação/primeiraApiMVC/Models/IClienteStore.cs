namespace primeiraApi.Models;

public interface IClienteStore
{
    IReadOnlyList<Cliente> GetAll();
    Cliente? GetById(int id);
    Cliente Add(ClienteRequest request);
    bool Update(int id, ClienteRequest request);
    bool Patch(int id, ClientePatchRequest request);
    bool Remove(int id);
}
