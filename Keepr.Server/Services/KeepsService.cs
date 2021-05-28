using System;
using System.Collections.Generic;
using Keepr.Server.Models;
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

    internal List<Keep> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Keep GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Keep Create(Keep k)
    {
      throw new NotImplementedException();
    }

    internal Keep Edit(Keep k, string id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id1, string id2)
    {
      throw new NotImplementedException();
    }

    internal List<Keep> GetKeepsByProfileId(string id)
    {
      throw new NotImplementedException();
    }
  }
}