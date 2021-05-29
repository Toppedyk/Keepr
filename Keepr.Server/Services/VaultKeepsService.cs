using System;
using Keepr.Server.Models;
using Keepr.Server.Repositories;

namespace Keepr.Server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
    private readonly KeepsRepository _repoKeep;

    public VaultKeepsService(VaultKeepsRepository vks, KeepsRepository ks)
    {
    _repo = vks;
    _repoKeep = ks;
    }

    internal VaultKeep Create(VaultKeep vk)
    {
      //Add to total keeps
    return _repo.Create(vk);
    }

    internal void Delete(int id, string creatorId)
    {
      Keep keep = _repoKeep.GetById(id);
      if(keep.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete this");
      }
      //subtract from total keeps
      if(!_repo.Delete(id)){
        throw new Exception("Something's Gone Wrong!");
      }
    }
  }
}