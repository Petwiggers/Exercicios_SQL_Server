using FilmesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmesApi.Controllers
{
    [Route("api/v{version:apiVersion/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Requisição de Lista mocada de filmes
        /// </summary>
        /// <returns>Retorna uma Lista mocada de filmes</returns>
        /// <response code = "200">Sucesso no retorno da lista mocada de filmes!</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MockFilmes.Filmes);
        }

        /// <summary>
        /// Requisição do item de uma lista mocada
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <returns>Retorno do objeto Filme</returns>
        /// <response code="404">Id inválido !</response>
        /// <response code="200">Sucesso no retorno do objeto filme!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Get(int id)
        {
            //pesquisar pelo id e retornar a informação caso seja verdadeiro
            Filme filme = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);
            //caso não encontre o filme , retornar Status Code 404 NotFound
            if(filme is null)
            {
                return NotFound();
            }
            //caso encontre, retornar Status Code 200 com os dados do filme
            return Ok(filme);
        }

        /// <summary>
        /// Postando um novo filme na lista
        /// </summary>
        /// <param name="filme">Objeto FIlme</param>
        /// <returns>Criação do Filme</returns>
        /// <response code= "201">Objeto Filme postado na lista! </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Filme filme)
        {
            //Adicionar no mockFilmes.Filmes essa entidade
            MockFilmes.Filmes.Add(filme);
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);

            //Filme Criado
        }

        /// <summary>
        /// Atualização de um filme da lista
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <param name="filme">Objeto com as novas caracteristicas do filme</param>
        /// <returns>Atualização do Filme</returns>
        /// <response code="404">Id não encontrado !</response>
        /// <response code="204">Atualização do filme realizada com sucesso !</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Filme filme)
        {
            //pesquisar na lista se o id informado no parametro pertence a lista
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if (filmeUpdate is null)
            {
                return NotFound();
            }

            //caso não pertença, retorna com Status Code NoContent
            var index = MockFilmes.Filmes.IndexOf(filmeUpdate);
            if(index != -1)
            {
                MockFilmes.Filmes[index] = filme;
            }
            return NoContent();

            //caso encomntre, realizo a alteração
        }

        /// <summary>
        /// Remoção de um filme
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <returns>Remoção do filme da lista !</returns>
        /// <reponse code="404">Filme não encontrado</reponse>
        /// <reponse code="204">Filme removido com sucesso</reponse>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            //Validar se o Id informado existe na base de dados
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if (filmeUpdate is null)
            {
                //Caso não exista, retornar NotFound
                return NotFound();
            }

            //remover dad base de dados
            MockFilmes.Filmes.Remove(filmeUpdate);
            return NoContent();
        }
    }
}
