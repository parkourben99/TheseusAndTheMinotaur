using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelDesign.Model;

namespace StorageManagement
{
    public static class Filer
    {
        //save stuff to XML
        public static void saveToFile<t>(t toSave, string file)
        {
            System.Xml.Serialization.XmlSerializer serialiser = new System.Xml.Serialization.XmlSerializer(toSave.GetType());
            using ( System.IO.StreamWriter writer = new System.IO.StreamWriter(file + ".xml") )
            {
                
                serialiser.Serialize(writer, toSave);
            }
           
            

        }

        //creates stuff from XML
        public static object loadFromFile(Type type, string file)
        {
            System.Xml.Serialization.XmlSerializer serialiser = new System.Xml.Serialization.XmlSerializer(type);

            System.IO.StreamReader reader = new System.IO.StreamReader(file + ".xml");          

            return serialiser.Deserialize(reader);
        }
    }
}
