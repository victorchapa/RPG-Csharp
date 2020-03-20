using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.RepositoriesImpl;
using System.Collections.Generic;
using System.Linq;

namespace MVCExample.Services
{
    class WeaponService
    {
        IWeaponRepository weaponRepository;

        public WeaponService()
        {
            weaponRepository = new WeaponRepositoryImpl();
        }
        public bool ForgeWeapon(WeaponDTO weaponDTO)
        {
            return weaponRepository.AddWeapon(weaponDTO);
        }

        public bool RemoveWeapon(int weaponId)
        {
            return weaponRepository.RemoveWeapon(weaponId);
        }

        public bool EditWeapon(WeaponDTO weaponDTO)
        {
            return weaponRepository.EditWeapon(weaponDTO);
        }

        public WeaponDTO GetWeaponByID(int? weaponId)
        {
            return weaponRepository.GetWeaponById(weaponId);
        }

        public ICollection<WeaponDTO> GetAllWeapons()
        {
            return weaponRepository.GetAllWeapons();
        }
        public List<WeaponDTO> GetAllWeaponsByKind(string weaponKind)
        {
            if (weaponKind != null)
            {
                return weaponRepository.GetAllWeaponsByKind(weaponKind).ToList<WeaponDTO>();
            }
            return null;
        }
    }
}
