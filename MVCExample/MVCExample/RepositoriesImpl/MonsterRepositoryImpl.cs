using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCExample.RepositoriesImpl
{
    public class MonsterRepositoryImpl : IMonsterRepository
    {
        IWeaponRepository weaponReponsitory;

        public MonsterRepositoryImpl()
        {
            weaponReponsitory = new WeaponRepositoryImpl();
        }
        public bool AddMonster(MonsterDTO monsterDTO)
        {
            if (monsterDTO != null)
            {
                var newMonster = DTOModelTransfer.mapper.Map<MonsterDTO, Monster>(monsterDTO);
                using (MappleFakeContext db = new MappleFakeContext())
                {
                    db.Monsters.Add(newMonster);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteMonster(int monsterId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                Monster monsterToRemove = db.Monsters.Find(monsterId);
                db.Monsters.Remove(monsterToRemove);
                db.SaveChanges();
                return true;
            }
        }

        public bool EditMonster(MonsterDTO monsterDTO)
        {
            Monster monster = DTOModelTransfer.mapper.Map<MonsterDTO, Monster>(monsterDTO);
            using (MappleFakeContext db = new MappleFakeContext())
            {
                db.Entry(monster).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public ICollection<MonsterDTO> GetAllMonsters()
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                MonsterDTO monsterDTO;
                List<MonsterDTO> allMonstersDTO = new List<MonsterDTO>();
                var allMonsters = db.Monsters.Include(c => c.Weapon).ToList();
                foreach (var monster in allMonsters)
                {
                    monsterDTO = DTOModelTransfer.mapper.Map<Monster, MonsterDTO>(monster);
                    allMonstersDTO.Add(monsterDTO);
                }
                return allMonstersDTO.ToList();
            }
        }

        public MonsterDTO GetMonsterById(int? monsterId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                var monster = db.Monsters.Where(m => m.MonsterId == monsterId).Include(c => c.Weapon).FirstOrDefault();
                var monsterDTO = DTOModelTransfer.mapper.Map<Monster, MonsterDTO>(monster);
                return monsterDTO;
            }
        }
    }
}
