using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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
      //id=vaultId
      string sql = @"
      SELECT 
      k.*,
      v.name,
      vk.id AS id,
      vk.keepId AS keepId,
      vk.VaultId AS vaultId,
      vk.creatorId as creatorId
      FROM 
      vault_keeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN vaults v ON vk.vaultId = id
      WHERE vk.vaultId = @id;";
      return _db.Query<VaultKeep>(sql, new{id}).ToList();
    }

    internal VaultKeep Create(VaultKeep vk)
    {
      string sql = @"
      INSERT INTO
      vault_keeps(vaultId, keepId, creatorId)
      VALUES(@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      vk.Id = _db.ExecuteScalar<int>(sql,vk);
      return vk;
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM vault_keeps WHERE id=@Id LIMIT 1;";
      _db.Execute(sql, new{id});
    }
  }
}