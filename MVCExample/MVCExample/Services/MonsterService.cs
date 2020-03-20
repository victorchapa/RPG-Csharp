using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.RepositoriesImpl;
using System.Collections.Generic;

namespace MVCExample.Services
{
    public class MonsterService
    {
        IMonsterRepository monsterRepository;

        public MonsterService()
        {
            monsterRepository = new MonsterRepositoryImpl();
        }

        public bool AddNewMonsta(MonsterDTO newMonster)
        {
            if (newMonster != null)
            {
                return monsterRepository.AddMonster(newMonster);
            }
            return false;
        }

        public bool DeleteMonster(int monsterId)
        {
            return monsterRepository.DeleteMonster(monsterId);
        }

        public bool EditMonster(MonsterDTO monsterDTO)
        {
            return monsterRepository.EditMonster(monsterDTO);
        }

        public MonsterDTO GetCharacterById(int? monsterId)
        {
            return monsterRepository.GetMonsterById(monsterId);
        }

        public ICollection<MonsterDTO> GetAllMonsters()
        {
            return monsterRepository.GetAllMonsters();
        }
    }
}
