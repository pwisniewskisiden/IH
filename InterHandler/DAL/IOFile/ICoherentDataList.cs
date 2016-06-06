using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IOFile
{
    interface ICoherentDataList
    {
      void SaveToFile(string file);
      void LoadFromFile(string file);

      void ReciveData();

    }
}
