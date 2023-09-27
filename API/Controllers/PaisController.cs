using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class PaisController : BaseController
{
    private readonly TiendaCampusContext _context;

    public PaisController(TiendaCampusContext context)
    {
        _context = context;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Pais>>> Get(){
        var Paises = await _context.Paises.ToListAsync();
        return Ok(Paises);
    }
}
