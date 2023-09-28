using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get;}
        public IDepartamento Departamentos { get;}
        public IPais Paises { get;}
        Task<int> SaveAsync();
    }
}