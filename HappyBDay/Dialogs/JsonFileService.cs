using HappyBDay.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HappyBDay.Dialogs
{
    public class JsonFileService : IFileService
    {
        public List<Model.Person> Open(string filename)
        {
            List<Model.Person> people = new List<Model.Person>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Model.Person>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                people = jsonFormatter.ReadObject(fs) as List<Model.Person>;
            }

            return people;
        }

        public void Save(string filename, List<Model.Person> people)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Model.Person>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, people);
            }
        }
    }
}
