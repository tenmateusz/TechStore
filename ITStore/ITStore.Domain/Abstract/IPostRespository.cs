using ITStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITStore.Domain.Abstract
{
    public interface IPostRespository
    {
        IEnumerable<Post> Posts { get; set; }
    }
}
