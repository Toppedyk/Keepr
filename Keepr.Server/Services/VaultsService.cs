using Keepr.Server.Repositories;

namespace Keepr.Server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository vs)
        {
            _repo = vs;
        }
    }
}