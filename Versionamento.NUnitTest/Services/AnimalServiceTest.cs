using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Versionamento.Domain.Dto;
using Versionamento.Domain.Entities;
using Versionamento.Domain.Interfaces.Data;
using Versionamento.Domain.Interfaces.Services;
using Versionamento.NUnitTest.Common;
using Versionamento.Service.Services;

namespace Versionamento.NUnitTest.Services
{
    public class AnimalServiceTest
    {
        private Animal _animal;
        private IMapper _mapper;
        private IAnimalService _animalService;
        private Mock<IAnimalRepository> _mockAnimalRepository;

        public AnimalServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _animal = new Animal(Guid.NewGuid(), "Cachorro");
            _mockAnimalRepository = new Mock<IAnimalRepository>();
            _animalService = new AnimalService(_mapper, _mockAnimalRepository.Object);
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new AnimalDto());

        [Test]
        public void ObterTodosTest()
        {
            IList<Animal> animalsList = new List<Animal>();
            animalsList.Add(_animal);

            _mockAnimalRepository.Setup(r => r.ObterTodos()).Returns(animalsList.AsQueryable());
            Assert.IsNotNull(_animalService.ObterTodos());
        }
    }
}