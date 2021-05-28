using Keepr.Server.Repositories;

namespace Keepr.Server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository ks)
        {
            _repo = ks;
        }
    }
}