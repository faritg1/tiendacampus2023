using Core.Entities;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class PaisController : BaseController
{
    private readonly UnitOfWork _unitOfWork;

    public PaisController(UnitOfWork unitOfWork)
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

    [HttpGet("id")]
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
}
