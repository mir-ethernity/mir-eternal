using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository
{
    public interface IRepository<TObject> where TObject : class
    {
        IEnumerable<TObject> DataSource { get; }
    }
}
