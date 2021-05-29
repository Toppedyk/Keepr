using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Server.Models;

namespace Keepr.Server.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

    internal List<VaultKeep> GetVaultKeeps(int id)
    {
      throw new NotImplementedException();
    }

    internal VaultKeep Create(VaultKeep vk)
    {
      throw new NotImplementedException();
    }

    internal bool Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}