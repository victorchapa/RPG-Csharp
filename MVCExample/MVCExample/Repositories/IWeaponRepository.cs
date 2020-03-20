using MVCExample.ModelsDTO;
using System.Collections.Generic;

namespace MVCExample.Repositories
{
    interface IWeaponRepository
    {
        bool AddWeapon(WeaponDTO weaponDTO);
        bool RemoveWeapon(int weaponId);
        bool EditWeapon(WeaponDTO weaponDTO);
        WeaponDTO GetWeaponById(int? weaponId);
        ICollection<WeaponDTO> GetAllWeaponsByKind(string weaponKind);
        ICollection<WeaponDTO> GetAllWeapons();
    }
}
