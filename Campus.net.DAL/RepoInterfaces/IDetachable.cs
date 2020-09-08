using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL.RepoInterfaces
{
    public interface IDetachable
    {
        public void Detach(Guid id);
    }
}
