using System;
using System.Collections.Generic;
using System.IO;
using DAL.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IOFile
{

  //  class CoherentDataList<T>  where T : Data, ICoherentDataList 
    public class CoherentDataList<T> : ICoherentDataList where T : FileData, new() 
    {
        
        public List<T> List = new List<T>();

        public CoherentDataList()
        {
           
        }


        public CoherentDataList(string file)
        {
            LoadFromFile(file);
        }
        
        public void LoadFromFile(string file)
        {
            using (StreamReader readtext = new StreamReader(file))
            {
                while (!readtext.EndOfStream)
                {
                    string line = readtext.ReadLine();
                    //            T tmp = (T)Activator.CreateInstance(typeof(T), null);
                    //            tmp.ReadFromLine(line);
                    var toAdd = new T();
                    toAdd.ReadFromLine(line);
                    List.Add(toAdd);
                }
            }
        }

        public void ReciveData()
        {   
            
            throw new NotImplementedException();
        }

        public void SaveToFile(string file)
        {
            using (StreamWriter writetext = new StreamWriter(file))
            {
                foreach (var el in List)
                {
                    var line = el.ParseToLine();
                    writetext.WriteLine(line);
                }
            }       
        }


        public void Add(T el)
        {
            List.Add(el);
        }
    }
}
