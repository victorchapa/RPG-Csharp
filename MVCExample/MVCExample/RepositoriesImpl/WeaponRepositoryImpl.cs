using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCExample.RepositoriesImpl
{
    class WeaponRepositoryImpl : IWeaponRepository
    {
        public bool AddWeapon(WeaponDTO weaponDTO)
        {
            var newWeapon = DTOModelTransfer.mapper.Map<WeaponDTO, Weapon>(weaponDTO);
            using (MappleFakeContext db = new MappleFakeContext())
            {
                db.Weapons.Add(newWeapon);
                db.SaveChanges();
                return true;
            }
        }

        public bool EditWeapon(WeaponDTO weaponDTO)
        {
            Weapon weapon = DTOModelTransfer.mapper.Map<WeaponDTO, Weapon>(weaponDTO);
            using (MappleFakeContext db = new MappleFakeContext())
            {
                db.Entry(weapon).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveWeapon(int weaponId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                Weapon weaponToRemove = db.Weapons.Find(weaponId);
                db.Weapons.Remove(weaponToRemove);
                db.SaveChanges();
                return true;
            }
        }

        public WeaponDTO GetWeaponById(int? weaponId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                var weapon = db.Weapons.Where(w => w.WeaponId == weaponId).FirstOrDefault();
                var WeaponDTO = DTOModelTransfer.mapper.Map<Weapon, WeaponDTO>(weapon);
                return WeaponDTO;
            }
        }

        public ICollection<WeaponDTO> GetAllWeapons()
        {
            using (MappleFakeContext db = new MappleFakeContext()) {
                WeaponDTO weaponDTO;
                List<WeaponDTO> allWeaponDTO = new List<WeaponDTO>();
                var allWeapons = db.Weapons.ToList<Weapon>();
                foreach (var weapon in allWeapons)
                {
                    weaponDTO = DTOModelTransfer.mapper.Map<Weapon, WeaponDTO>(weapon);
                    allWeaponDTO.Add(weaponDTO);
                }
                return allWeaponDTO.ToList();
            }
        }

        public ICollection<WeaponDTO> GetAllWeaponsByKind(string WeaponKind)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                WeaponDTO weaponDTO;
                List<WeaponDTO> allWeaponDTO = new List<WeaponDTO>();
                var weaponsByKind = db.Weapons.Where(w => w.Kind == WeaponKind).ToList<Weapon>();
                foreach (var weapon in weaponsByKind)
                {
                    weaponDTO = DTOModelTransfer.mapper.Map<Weapon, WeaponDTO>(weapon);
                    allWeaponDTO.Add(weaponDTO);
                }
                return allWeaponDTO.ToList();
            }
        }
    }
}
