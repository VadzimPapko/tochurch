using System.Collections.Generic;
using ToChurch.Models;

namespace ToChurch.Interfaces
{
    /// <summary>
    /// Interface realizes all CRUD operations related to church entity
    /// </summary>
    public interface IChurchRepository
    {
        IEnumerable<Church> GetAllChurches();
        Church GetChurch(string churchName);

        IEnumerable<Address> GetAddresses();
    }
}
