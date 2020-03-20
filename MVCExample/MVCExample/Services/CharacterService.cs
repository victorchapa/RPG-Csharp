using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Repositories;
using MVCExample.RepositoriesImpl;
using System.Collections.Generic;

namespace MVCExample.Services
{
    class CharacterService
    {
        ICharacterRepository characterRepository;

        public CharacterService()
        {
            characterRepository = new CharacterRepositoryImpl();
        }

        public CharacterDTO GetCharacterById(int? characterId)
        {
            return characterRepository.getCharacterById(characterId);
        }

        public bool createCharacter(CharacterDTO characterDTO) {
            return characterRepository.AddCharacter(characterDTO);
        }

        public bool RemoveCharacter(int characterId) {
            return characterRepository.RemoveCharacter(characterId);
        }

        public bool EditCharacter(CharacterDTO characterDTO) {
            return characterRepository.EditCharacter(characterDTO);
        }

        public ICollection<CharacterDTO> GetAllCharacters() {
            return characterRepository.GetAllCharacters();
        }
    }
}
