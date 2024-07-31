using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ReviewApp_InWebApi.Controllers;
using ReviewApp_InWebApi.Dto;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Tests.Controller
{
    public class PokemonControllerTests
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public PokemonControllerTests()
        {
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _reviewRepository=A.Fake<IReviewRepository>();
            _mapper=A.Fake<IMapper>();
        }
        [Fact]
        public void PokemonController_GetPokemons_ReturnsSuccess()
        {
            //Arrange
            var pokemons=A.Fake<ICollection<PokemonDto>>();
            var pokemonList=A.Fake<List<PokemonDto>>();
            A.CallTo(()=>_mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonList);
            var controller = new PokemonController(_pokemonRepository,_reviewRepository,_mapper);
            //Act
            var result = controller.GetPokemons();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void PokemonController_CreatePokemon_ReturnOk()
        {
            //arrange
            int ownerId = 1;
            int catId = 1;
            var pokemon = A.Fake<Pokemon>();
            var pokemonCreate = A.Fake<PokemonDto>();
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList= A.Fake<IList<PokemonDto>>();
            A.CallTo(() => _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate)). Returns(pokemon);
            A.CallTo(() => _mapper.Map<Pokemon>(pokemonCreate)).Returns(pokemon);
            A.CallTo(()=>_pokemonRepository.CreatePokemon(ownerId, catId,pokemon)).Returns(true);
            var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);

            //act
            var result=controller.CreatePokemon(ownerId,catId,pokemonCreate);


            //assert
            result.Should().NotBeNull();
        }

    }
}
