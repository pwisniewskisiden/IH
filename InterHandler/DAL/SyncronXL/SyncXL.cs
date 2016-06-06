using AutoMapper;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SyncronXL
{
    public class SyncXL
    {
        public List<T> GetFromXL<T>() where T : new()
        {
            List<T> ret = new List<T>();

            var contextCDNXL = new CDNXL();




            if (typeof(T).Name == "DealerPartsMaster")
             {

                var tmp = contextCDNXL.Siden_Dealer_Parts_Master().ToList();

                Mapper.CreateMap<Siden_Dealer_Parts_Master_Result, T>();


                foreach (var el in tmp)
                {
                        var retModel = Mapper.Map<Siden_Dealer_Parts_Master_Result, T>(el);
                        ret.Add(retModel);
                }
                return ret;

            }

            if (typeof(T).Name == "TransactionalDemand")
            {

                var tmp = contextCDNXL.Siden_Transactional_Demand().ToList();

               Mapper.CreateMap<Siden_Transactional_Demand_Result, T>();


                foreach (var el in tmp)
               {
                  var retModel = Mapper.Map<Siden_Transactional_Demand_Result, T>(el);
                  ret.Add(retModel);
               }
               return ret;

            }


            if (typeof(T).Name == "OpenPurchaseOrders")
            {

                var tmp = contextCDNXL.Siden_Open_Purchase_Orders().ToList();

                Mapper.CreateMap<Siden_Open_Purchase_Orders_Result, T>();


                foreach (var el in tmp)
                {
                    var retModel = Mapper.Map<Siden_Open_Purchase_Orders_Result, T>(el);
                    ret.Add(retModel);
                }
                return ret;

            }

            //zostaw do celow testowych

            string[] lines = { "line 1", "line 2", "line 3", "line 4" };
            foreach (var line in lines)
            {


                var type = typeof(T);
                var properties = type.GetProperties();

                int i = 0;

                var toAdd = new T();


                foreach (PropertyInfo property in properties)
                {

                    if (property.PropertyType.Name == "String") { property.SetValue(toAdd, line + " " + property.Name, null); continue; }
                    if (property.PropertyType.Name == "Int32") { property.SetValue(toAdd, i, null); i++; continue; }
                    if (property.PropertyType.Name == "DateTime" || property.PropertyType.Name == "DateTime?") { property.SetValue(toAdd, DateTime.Now, null); continue; }
                    if (property.PropertyType.Name == "Decimal" || property.PropertyType.Name == "Decimal?") { property.SetValue(toAdd, 1.111111111111111111M, null); continue; }
                    if (property.PropertyType.FullName.Contains("System.Int32"))
                    {
                        property.SetValue(toAdd, i, null); i++; continue;
                    }

                    if (property.PropertyType.FullName.Contains("System.Decimal"))
                    {
                        property.SetValue(toAdd, 222222222222.2222222222M, null);
                        continue;
                    }

                    if (property.PropertyType.FullName.Contains("System.DateTime"))
                    {
                        property.SetValue(toAdd, DateTime.Now, null);
                        continue;
                    }


                    var deb1 = property.PropertyType.Name;
                    var deb2 = property.GetType();
                    var deb3 = property.GetType().Name;

                }
                ret.Add(toAdd);

            }
            return ret;
        }




        public bool SendToXL(string filename, List<OrderExport> lista)
        {
            return true;
        }
    }
}
