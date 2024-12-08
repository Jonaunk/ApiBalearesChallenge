using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interfaces
{
    public interface IBaseEntity
    {
    }

    public interface IBaseEntity<TId> : IBaseEntity
    {
        TId Id { get; }
    }
}
