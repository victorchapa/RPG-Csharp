using AutoMapper;
using MVCExample.Models;
using MVCExample.ModelsDTO;

namespace MVCExample.Services
{
    public static class DTOModelTransfer
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Character, CharacterDTO>();
            cfg.CreateMap<Weapon, WeaponDTO>();
            cfg.CreateMap<Monster, MonsterDTO>();
            cfg.CreateMap<CharacterDTO, Character>();
            cfg.CreateMap<WeaponDTO, Weapon>();
            cfg.CreateMap<MonsterDTO, Monster>();
        });

        public static IMapper mapper = config.CreateMapper();
    }
}