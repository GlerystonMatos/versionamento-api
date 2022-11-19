using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Versionamento.Domain.Dto;
using Versionamento.Domain.Interfaces.Data;
using Versionamento.Domain.Interfaces.Services;

namespace Versionamento.Service.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        public IQueryable<AnimalDto> ObterTodos()
            => _animalRepository.ObterTodos().ProjectTo<AnimalDto>(_mapper.ConfigurationProvider);
    }
}