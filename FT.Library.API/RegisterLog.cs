using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace FT.Library.API
{
    public class RegisterLog
    {
        // Globals
        private string path;

        public RegisterLog(string pathLog)
        {
            path = pathLog;
        }

        public void WriteLog(string source, string method, object data)
        {
            try
            {
                var log = new
                {
                    Date = DateTime.Now,
                    ApiSource = source,
                    Method = method,
                    Request = JsonConvert.SerializeObject(data)
                };

                string nameFile = $"{source}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.txt";
                string fullPath = $"{path}\\{nameFile}";

                if (!File.Exists(fullPath))
                {
                    using (StreamWriter file = File.CreateText(fullPath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, log);
                    }
                }
                else
                {
                    File.AppendAllText(fullPath, JsonConvert.SerializeObject(log));
                }
            }
            catch (RegisterLogException ex)
            {
                throw ex;
            }
        }
    }

    public class RegisterLogException : Exception
    {
        public RegisterLogException(string message) : base(message)
        {

        }
    }
}
