using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IMediator<Tar>
    {
        public void Add(Tar t);
        public void Delete(Tar t);
        public List<Tar> GetAll();


    }
}
