using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.BL
{
    public interface IDBData
    {
      //  DBModel ToDBModel<BLModel, DBModel>();
        StringModel ToStringModel<BLModel, StringModel>();
    }
}
