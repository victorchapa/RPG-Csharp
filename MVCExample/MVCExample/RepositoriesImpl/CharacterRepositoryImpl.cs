using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.Services;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MVCExample.RepositoriesImpl
{
    class CharacterRepositoryImpl : ICharacterRepository
    {
        IWeaponRepository weaponRepository;
        public CharacterRepositoryImpl()
        {
            weaponRepository = new WeaponRepositoryImpl();
        }

        public bool AddCharacter(CharacterDTO characterDTO)
        {
            var newCharacter = DTOModelTransfer.mapper.Map<CharacterDTO, Character>(characterDTO);
            using (MappleFakeContext db = new MappleFakeContext())
            {
                db.Characters.Add(newCharacter);
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveCharacter(int characterId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                Character characterToRemove = db.Characters.Find(characterId);
                db.Characters.Remove(characterToRemove);
                db.SaveChanges();
                return true;
            }
        }

        public bool EditCharacter(CharacterDTO characterDTO)
        {
            Character character = DTOModelTransfer.mapper.Map<CharacterDTO, Character>(characterDTO);
            using (MappleFakeContext db = new MappleFakeContext())
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public ICollection<CharacterDTO> GetAllCharacters()
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                CharacterDTO characterDTO;
                List<CharacterDTO> allCharactersDTO = new List<CharacterDTO>();
                var allCharacters = db.Characters.Include(c => c.Weapon).ToList();
                foreach (var character in allCharacters)
                {
                    characterDTO = DTOModelTransfer.mapper.Map<Character, CharacterDTO>(character);
                    allCharactersDTO.Add(characterDTO);
                }
                return allCharactersDTO.ToList();
            }
        }

        CharacterDTO ICharacterRepository.getCharacterById(int? characterId)
        {
            using (MappleFakeContext db = new MappleFakeContext())
            {
                var character = db.Characters.Where(c => c.CharacterId == characterId).Include(c => c.Weapon).FirstOrDefault();
                var characterDTO = DTOModelTransfer.mapper.Map<Character, CharacterDTO>(character);
                return characterDTO;
            }
        }

    }
}
