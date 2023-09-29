using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class PaisController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public PaisController(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }

    public UnitOfWork UnitOfWork { get;}

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Pais>>> Get(){
        var Paises = await _unitOfWork.Paises.GetAllAsync();
        return Ok(Paises);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Pais>> Get(int id){
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        return Ok(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais pais){
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if(pais == null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new{id=pais.Id},pais);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pais>> Put(int id, [FromBody]Pais pais){

        if(pais.Id == 0){
            pais.Id = id;
        }

        if(pais.Id != id){
            return BadRequest();
        }

        if(pais == null){
            return NotFound();
        }
        
        _unitOfWork.Paises.Update(pais);
        await _unitOfWork.SaveAsync();
        return pais;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
    var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        _unitOfWork.Paises.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}




