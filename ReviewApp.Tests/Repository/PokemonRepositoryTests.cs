﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Model;
using ReviewApp_InWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Tests.Repository
{
    public class PokemonRepositoryTests
    {
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Pokemon.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Pokemon.Add(
                    new Pokemon()
                    {
                        Name = "Pikachu",
                        BirthDate = new DateTime(1903, 1, 1),
                        PokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Category = new Category() { Name = "Electric"}}
                            },
                        Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Gio", LastName = "Ab" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "luka", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "niko", LastName = "McGregor" } },
                            }
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async void PokemonRepository_GetPokemon_returnPokemon()
        {
            //Arrange
            var name = "Pikachu";
            var dbContext=await GetDatabaseContext();
            var pokemonRepository=new PokemonRepository(dbContext);

            //Act
            var result=pokemonRepository.GetPokemon(name);


            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Pokemon>();

        }
        [Fact]
        public async void PokemonRepository_GetPokemonRating_ReturnDecimalBetweenOneAndTen()
        {
            //Arrange
            var pokeId = 1;
            var dbContext=await GetDatabaseContext();
            var pokemonRepository=new PokemonRepository(dbContext);


            //Act
            var result=pokemonRepository.GetPokemonRating(pokeId);



            //Assert
            result.Should().NotBe(0);
            result.Should().BeInRange(1, 10);

        }


    }
}
