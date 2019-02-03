using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dboEF6.EF;

namespace dboEF6
{
    class GetData<T> where T : class
    {
        private DbSet<T> _table;
        private AutoEntities _db;

        public GetData()
        {
            _db = new AutoEntities();
            _table = _db.Set<T>();
        }

        public List<T> getTable()
        {
            using (var _db = new AutoEntities())
            {
                return _table.ToList();
            }
        }
    }
}
