using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;


namespace BIT.Customer.Server.Repository
{
    public static class XpoHelper
    {
        private static readonly Type type = typeof(Models.Customer);
        static readonly Type[] entityTypes = new Type[] {
            type
        };
        public static void InitXpo(string connectionString)
        {
            var dictionary = PrepareDictionary();

            if (XpoDefault.DataLayer == null)
            {
                using (var updateDataLayer = XpoDefault.GetDataLayer(connectionString, dictionary, AutoCreateOption.DatabaseAndSchema))
                {
                    XPClassInfo[] types = dictionary.CollectClassInfos(entityTypes);
                    //var XpoDemoId = types[0].GetMember("CustomerId");
                    //XpoDemoId.AddAttribute(new KeyAttribute(true));
                    updateDataLayer.UpdateSchema(false, types);

                    new Session(updateDataLayer).CreateObjectTypeRecords();
                }
            }

            var dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
            XpoDefault.Session = null;


        }
        public static UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
        static XPDictionary PrepareDictionary()
        {
            var dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(entityTypes);
            return dict;
        }


    }
}
