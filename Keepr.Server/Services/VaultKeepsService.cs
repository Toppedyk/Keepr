using System;
using Keepr.Server.Models;
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

    internal VaultKeep Create(VaultKeep vk)
    {
    throw new NotImplementedException();
    }

    internal void Delete(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}