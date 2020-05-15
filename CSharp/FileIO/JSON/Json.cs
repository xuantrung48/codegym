using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JSON
{
    class Json
    {
        public string path;
        public string inputJsonFile;
        public string output1JsonFile;
        public string output2JsonFile;
        public NumbersList json;
        public Json(string pathToFolder, string inputJsonFilename, string output1JsonFilename, string output2JsonFilename)
        {
            path = pathToFolder;
            inputJsonFile = inputJsonFilename;
            output1JsonFile = output1JsonFilename;
            output2JsonFile = output2JsonFilename;
            ReadJsonFile();
            WriteToOutput1();
            WriteToOutput2();
        }
        public void ReadJsonFile()
        {
            using StreamReader sr = File.OpenText(path + inputJsonFile);
            var data = sr.ReadToEnd();
            json = JsonConvert.DeserializeObject<NumbersList>(data);
        }
        public void WriteToOutput1()
        {
            using StreamWriter sw = File.CreateText(path + output1JsonFile);
            TotalNumbers payload2 = new TotalNumbers(json);
            var obj = JsonConvert.SerializeObject((object)payload2);
            sw.WriteLine(obj);
        }
        public void WriteToOutput2()
        {
            using StreamWriter sw = File.CreateText(path + output2JsonFile);
            NumbersList payload1 = new NumbersList()
            {
                Numbers = new List<Numbers>()
                {
                    json.Numbers[0].MultiWith(2),
                    json.Numbers[1].MultiWith(2),
                    json.Numbers[2].MultiWith(2)
                },

            };
            var obj = JsonConvert.SerializeObject((object)payload1);
            sw.WriteLine(obj);
        }
    }
}
