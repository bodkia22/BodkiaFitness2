using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BodkiaFitness.BL.Controller
{
    public abstract class BaseController
    {
        protected void Save(string FileName,object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        protected T Load<T>(string FileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T foods)
                {
                    return foods;
                }
                else
                {
                    return default(T); //new clas();
                }
            }
        }
    }
}
