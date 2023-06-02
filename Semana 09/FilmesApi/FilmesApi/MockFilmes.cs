using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi
{
    public static class MockFilmes
    {
        public static IList<Filme> Filmes = new List<Filme>()
        {
                                  new Filme {
                                      Id = 1,
                                      Nome= "Blade Runner",
                                      Diretor = "Jane Campion",
                                      Duracao = 60,
                                      Genero =  "Suspense"},
                                   new Filme
                                   {
                                       Id = 2,
                                       Nome = "Trainspotting - Sem Limites",
                                       Diretor = "Quentin Tarantino",
                                       Duracao = 90,
                                       Genero = "Documentário"
                                   },
                                   new Filme
                                   {
                                       Id = 3,
                                       Nome = "Gênio Indomável",
                                       Diretor = "Sofia Coppola",
                                       Duracao = 90,
                                       Genero = "Romance"
                                   },
                                   new Filme
                                   {
                                       Id = 4,
                                       Nome = "Titanic",
                                       Diretor = "Petra Costa",
                                       Duracao = 120,
                                       Genero = "Romance"
                                   },
                                   new Filme
                                   {
                                       Id = 5,
                                       Nome = "Aliens, O Resgate",
                                       Diretor = "Sofia Coppola",
                                       Duracao = 120,
                                       Genero = "Desenho"
                                   },
                                   new Filme
                                   {
                                       Id = 6,
                                       Nome = "Um Sonho de Liberdade",
                                       Diretor = "Kathryn Bigelow",
                                       Duracao = 60,
                                       Genero = "Ficção"
                                   },
                                   new Filme
                                   {
                                       Id = 7,
                                       Nome = "Blade Runner",
                                       Diretor = "Jean-Luc Godard",
                                       Duracao = 120,
                                       Genero = "Policial"
                                   },
                                   new Filme
                                   {
                                       Id = 8,
                                       Nome = "Noivo Neurótico, Noiva Nervosa",
                                       Diretor = "Alfred Hitchcock",
                                       Duracao = 60,
                                       Genero = "Romance"
                                   },
                                   new Filme
                                   {
                                       Id = 9,
                                       Nome = "Uma Vida sem Limites",
                                       Diretor = "Steven Spielberg",
                                       Duracao = 90,
                                       Genero = "Aventura"
                                   },
                                   new Filme
                                   {
                                       Id = 10,
                                       Nome = "Donnie Darko",
                                       Diretor = "Stanley Kubrick",
                                       Duracao = 90,
                                       Genero = "Ficção"
                                   }

        };
    }
}
