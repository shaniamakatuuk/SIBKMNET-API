using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Repositories.Interface
{
    public interface IGeneralRepository<Entity>
        where Entity : class
    {
        List<Entity> Get();

        Entity Get(int id);

        int Post(Entity province);

        int Put(Entity province);

        int Delete(int id);
    }
}
