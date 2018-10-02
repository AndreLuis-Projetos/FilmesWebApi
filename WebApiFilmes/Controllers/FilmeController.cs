using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiFilmes.AcessoDados;
using WebApiFilmes.Models;

namespace WebApiFilmes.Controllers
{
    [Route("api/[Controller]")]
    public class FilmeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(FIlmeRepository.ListarFilmes());
            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }
        }

        // GET api/filme/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                return Ok(FIlmeRepository.ObterFilmePorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }

        }

        ///api/filme/GetNome/nome
        //[HttpGet("[action]/{nome}")]
        //api/filme/GetNome?nome=Matrix
        [HttpGet("GetNome")]
        public IActionResult GetNome(string nome)
        {
            try
            {

                return Ok(FIlmeRepository.ObterFilmePorNome(nome));
            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                    FIlmeRepository.Salvar(filme);
                return Created("api/filme", filme);

            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var filme = FIlmeRepository.ObterFilmePorId(id);

                if (filme == null)
                {
                    return NotFound();
                }

                FIlmeRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Filme filme)
        {
            try
            {
                var filmes = FIlmeRepository.ObterFilmePorId(id);

                if (filmes == null)
                {
                    return NotFound();
                }

                FIlmeRepository.Alterar(filme);

                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest("Error " + ex.Message);

            }

        }
    }
}