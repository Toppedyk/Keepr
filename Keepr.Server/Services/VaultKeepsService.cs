using Keepr.Server.Repositories;

namespace Keepr.Server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository vks)
        {
            _repo = vks;
        }
    }
}