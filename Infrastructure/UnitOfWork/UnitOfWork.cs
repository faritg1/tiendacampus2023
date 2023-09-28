using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TiendaCampusContext _context;
    private ICiudad _ciudades;
    private IPais _paises;
    private IDepartamento _departamentos;

    public UnitOfWork(TiendaCampusContext context){
        _context = context;
    }
    public ICiudad Ciudades{
        get{
            if(_ciudades == null){
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }
    public IPais Paises{
        get{
            if(_paises == null){
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }

    }
    public IDepartamento Departamentos{
        get{
            if (_departamentos == null){
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}


