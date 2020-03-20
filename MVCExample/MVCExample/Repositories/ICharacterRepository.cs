using MVCExample.ModelsDTO;
using System.Collections.Generic;

namespace MVCExample.Repositories
{
    interface ICharacterRepository
    {
        bool AddCharacter(CharacterDTO characterDTO);
        bool RemoveCharacter(int characterId);
        bool EditCharacter(CharacterDTO characterDTO);
        CharacterDTO getCharacterById(int? characterId);
        ICollection<CharacterDTO> GetAllCharacters();
    }
}
