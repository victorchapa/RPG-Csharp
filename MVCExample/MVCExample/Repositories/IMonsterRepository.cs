using MVCExample.ModelsDTO;
using System.Collections.Generic;

namespace MVCExample.Repositories
{
    interface IMonsterRepository
    {
        bool AddMonster(MonsterDTO monsterDTO);
        bool DeleteMonster(int monsterId);
        bool EditMonster(MonsterDTO characterDTO);
        MonsterDTO GetMonsterById(int? monsterId);
        ICollection<MonsterDTO> GetAllMonsters();
    }
}
