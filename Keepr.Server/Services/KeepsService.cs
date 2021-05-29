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
      return _repo.GetAll();
    }

    internal Keep GetById(int id)
    {
      Keep keep = _repo.GetById(id);
      if(keep == null)
      {
        throw new Exception("Invalid ID");
      }
      return keep;
    }

    internal List<Keep> GetKeepsByProfileId(string id)
    {
      return _repo.GetKeepsByProfileId(id);

    }

    internal Keep Create(Keep k)
    {
      return _repo.Create(k);
    }

    internal Keep Edit(Keep k, string id)
    {
      Keep original = GetById(k.Id);
      if(original.CreatorId != id){
        throw new Exception("You cannot edit another users blog");
      }
      original.Name = k.Name.Length > 0 ? k.Name : original.Name;
      original.Description = k.Description.Length > 0 ? k.Description : original.Description;
      original.Img = k.Img.Length > 0 ? k.Img : original.Img;
      original.Views = k.Views != original.Views ? k.Views : original.Views;
      original.Shares = k.Shares != original.Shares ? k.Shares : original.Shares;
      original.Keeps = k.Keeps != original.Keeps ? k.Keeps : original.Keeps;
      if(_repo.Edit(original))
      {
        return original;
      }
      throw new Exception("Something went Wrong");
    }

    internal void Delete(int id, string creatorId)
    {
      Keep keep = GetById(id);
      if(keep.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete this!");
      }
      if(!_repo.Delete(id))
      {
        throw new Exception("Something's Gone Wrong!");
      }
    }


  }
}