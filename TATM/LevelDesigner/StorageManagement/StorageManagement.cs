using LevelDesign.Model;
using System.Collections.Generic;
using System.Xml.Serialization; 

    namespace StorageManagement
    {
        public static class StorageManagement
        {
            private static System.Xml.Serialization.XmlSerializer serialiser = new System.Xml.Serialization.XmlSerializer(typeof(SerialDict<string, string>));
            public static Level loadLevel(string levelName)
            {

                Level level = (Level)Filer.loadFromFile(typeof(Level), levelName);
                return level;

            }

            public static List<string> getLevelList()
            {
                List<string> levelList = new List<string>();
                foreach (var file in System.IO.Directory.EnumerateFiles("../../Levels/"))
                {
                    levelList.Add(file);
                }
                return levelList;
            }

            public static void getCustomSettings()
            {

            }

           /* public static List<string> getHighScores(Level level)
            {
                List<string> higscores = new List<string>();

            } */



            public static void saveLevel(Level level)
            {
               
                Filer.saveToFile(level, "../../Levels/" + level.LevelName);
            }

            public static void publishLevel(Level level)
            {
               // Connector.sendToServer(levels);
            }


            public static void saveTileset(SerialDict<string, string> tileSet, string file)
            {
                Filer.saveToFile(tileSet, file);
            }

            public static SerialDict<string, string> getTileset(string name)
            {
                SerialDict<string, string> tileset = new SerialDict<string, string>();
                tileset = (SerialDict<string, string>)Filer.loadFromFile(tileset.GetType(), "../../Resources/XML/Tilesets/" + name);
                return tileset;
            }
        }

    }


