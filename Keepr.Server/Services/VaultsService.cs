using System;
using System.Collections.Generic;
using Keepr.Server.Models;
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

    internal List<Vault> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Vault GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal List<VaultKeep> GetVaultKeeps(int id)
    {
      throw new NotImplementedException();
    }

    internal Vault Create(Vault v)
    {
      throw new NotImplementedException();
    }

    internal Vault Edit(Vault v, string id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}