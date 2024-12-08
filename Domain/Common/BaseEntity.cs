using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity : BaseEntity<Guid>

    {
        protected BaseEntity() => Id = new Guid();

    }

    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    { 
        public TId Id { get; protected set; } = default!;

    }
}
