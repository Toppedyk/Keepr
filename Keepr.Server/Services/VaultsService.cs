using System;
using System.Collections.Generic;
using Keepr.Server.Models;
using Keepr.Server.Repositories;

namespace Keepr.Server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
    private readonly VaultKeepsRepository _repoVK;

    public VaultsService(VaultsRepository vs, VaultKeepsRepository vkr)
        {
            _repo = vs;
            _repoVK = vkr;
        }

    // internal List<Vault> GetAll()
    // {
    //   return _repo.GetAll();
    // }

    internal Vault GetById(int id)
    {
      Vault vault = _repo.GetById(id);
      if(vault == null)
      {
        throw new Exception("Invalid ID");
      }
      return vault;
    }

    internal List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      return _repoVK.GetVaultKeeps(id);
    }

    internal List<Vault> GetVaultsByAccountId(string id)
    {
      return _repo.GetVaultsByAccountId(id);
    }

    internal List<Vault> GetVaultsByProfileId(string id)
    {
      return _repo.GetVaultsByProfileId(id);
    }

    internal Vault Create(Vault v)
    {
      return _repo.Create(v);
    }

    internal Vault Edit(Vault v, string id)
    {
      Vault original = _repo.GetById(v.Id);
      if(original.CreatorId != id){
        throw new Exception("You cannot edit this");
      }
      original.Name = v.Name.Length > 0 ? v.Name : original.Name;
      original.Description= v.Description.Length > 0 ? v.Description : original.Description;
      original.ImgUrl= v.ImgUrl.Length > 0 ? v.ImgUrl : original.ImgUrl;
      original.IsPrivate= v.IsPrivate != v.IsPrivate ? v.IsPrivate : original.IsPrivate;
      // original.Creator = null;
      return _repo.Edit(original);
    }
    

    internal void Delete(int id, string creatorId)
    {
      Vault vault = GetById(id);
      if(vault.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete another user's blog");
      }
      _repo.Delete(id);
    }


  }
}