using AutoMapper;
using filmesApi.Data;
using filmesApi.DTO;
using filmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace filmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private DataContext _context;
    private IMapper _mapper;

    public FilmeController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] // não entendi o que essa linha faz
    public IActionResult AdiconarFilme([FromBody] CreateFilmeDto filmeDTo)
    {

        Filme filme = _mapper.Map<Filme>(filmeDTo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> BuscarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        //skip => pula uma quantidade de elementos na lista
        //take => quantidade que de elementos que vai pegar da lista
        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilmePorId([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

        return Ok(filmeDTO);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme([FromRoute]int id, [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem();
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

       _context.Filmes.Remove(filme);
       _context.SaveChanges();

        return NoContent();
    }


}
