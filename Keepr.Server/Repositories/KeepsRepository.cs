using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Server.Models;

namespace Keepr.Server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

    internal List<Keep> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Keep GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal List<Keep> GetKeepsByProfileId(string id)
    {
      throw new NotImplementedException();
    }

    internal Keep Create(Keep k)
    {
      throw new NotImplementedException();
    }

    internal bool Edit(Keep original)
    {
      throw new NotImplementedException();
    }

    internal bool Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}