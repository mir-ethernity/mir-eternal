using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository
{
    public interface IRepository<TObject> : IRepository where TObject : class
    {
        IEnumerable<TObject> DataSource { get; }
    }

    public interface IRepository
    {
        Task Initialize();
    }
}
