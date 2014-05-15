using LevelDesign.Model;
using System.Collections.Generic;
using System.Xml.Serialization; 

    namespace StorageManagement
    {
        public static class StorageManagement
        {
            private static System.Xml.Serialization.XmlSerializer serialiser = new System.Xml.Serialization.XmlSerializer(typeof(SerialDict<string, string>));
            private static SerialDict<string, Level> levels;

            public static SerialDict<string, string> loadBaseData()
            {
                SerialDict<string, string> tileSet = new SerialDict<string, string>();
                tileSet.Add("Theseus","../../Img/theseus.png");
                tileSet.Add("blank", "../../Img/blank.png");
                tileSet.Add("left", "../../Img/left.png");
                tileSet.Add("up", "../../Img/up.png");
                tileSet.Add("leftup", "../../Img/leftup.png");
                return tileSet;
            }

            public static void initLevels()
            {
                levels = (SerialDict<string, Level>)Filer.loadFromFile(typeof(SerialDict<string, Level>), "levels");
            }

            public static Level loadLevel(string levelName)
            {
                return levels[levelName];
            }

            public static List<string> getLevelList()
            {
                List<string> levelList = new List<string>();
                foreach (string key in levels.Keys)
                {
                    levelList.Add(key);
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


            public static void savePlayProgress(Level level, string save)
            {
                Filer.saveToFile(level, save);
            }

            public static void loadPlayProgress(string save)
            {
                Filer.loadFromFile(typeof(Level), save);
            }

            public static void saveLevel(Level level)
            {
                if (!levels.ContainsValue(level))
                {
                    levels.Add(level.LevelName, level);
                }
                else
                {
                    levels[level.LevelName] = level;
                }
                Filer.saveToFile(levels, "levels");
            }

            public static void publishLevel(Level level)
            {
               // Connector.sendToServer(levels);
            }

            public static void doesDirExist(string path)
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }

            public static void saveTileset(SerialDict<string, string> tileSet, string file)
            {
                Filer.saveToFile(tileSet, file);
            }

            public static SerialDict<string, string> getTileset(string name)
            {
                SerialDict<string, string> tileset = new SerialDict<string, string>();
                tileset = (SerialDict<string, string>)Filer.loadFromFile(tileset.GetType(), name);
                return tileset;

            }
        }

    }


