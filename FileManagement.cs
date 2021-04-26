using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_dot_net_console
{
    class FileManagement
    {
        public string Readfile(string jsonname)
        {
            string jsoninput;
            StreamReader r = new StreamReader(jsonname); //reading all books from file
            jsoninput = r.ReadToEnd();
            r.Close();
            return (jsoninput);
        }
        public void Save(string filename, object obj)
        {
            
            string jsonoutput = (JsonConvert.SerializeObject(obj));
            File.WriteAllText(filename, jsonoutput);
        }
    }
}
