using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JSON
{
    class Json
    {
        public string path;
        public string inputJsonFile;
        public string outputJsonFile;
        public Payload json;
        public Json(string pathToFolder, string inputJsonFilename, string outputJsonFilename)
        {
            path = pathToFolder;
            inputJsonFile = inputJsonFilename;
            outputJsonFile = outputJsonFilename;
            Read();
            Write();
        }
        public void Read()
        {
            using StreamReader sr = File.OpenText(path + inputJsonFile);
            var data = sr.ReadToEnd();
            json = JsonConvert.DeserializeObject<Payload>(data);
            foreach (var item in json.Numbers)
                Console.WriteLine(item);
        }
        public void Write()
        {
            using StreamWriter sw = File.CreateText(path + outputJsonFile);
            Payload newPayload = new Payload()
            {
                Numbers = new List<Numbers>()
                {
                    new Numbers()
                    {
                        a = json.Numbers[0].a * 2,
                        b = json.Numbers[0].b * 2,
                        c = json.Numbers[0].c * 2
                    },
                    new Numbers()
                    {
                        a = json.Numbers[1].a * 2,
                        b = json.Numbers[1].b * 2,
                        c = json.Numbers[1].c * 2
                    },
                    new Numbers()
                    {
                        a = json.Numbers[2].a * 2,
                        b = json.Numbers[2].b * 2,
                        c = json.Numbers[2].c * 2
                    }
                },

            };
            var obj = JsonConvert.SerializeObject((object)newPayload);
            sw.WriteLine(obj);
        }
    }
}
