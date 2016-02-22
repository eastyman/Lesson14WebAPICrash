using Lesson14ASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Http;

namespace Lesson14ASP.Controllers
{
    public class ValuesController : ApiController
    {
        public Dictionary<int, Person> PersonList = new Dictionary<int, Person>();

        public Dictionary<int, Person> Get()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"C:\persons.dat", FileMode.Open))
            {
                PersonList = (Dictionary<int, Person>)formatter.Deserialize(fs);
            }
            return PersonList;
        }

        // GET api/values/5
        [Route("api/values/person")]
        public Person GetPerson(int id)
        {
            return PersonList[id];
        }

        // POST api/values
        public string Post(int Id, string Name, int Age)
        {
            //string path = @"C:\persons.dat";
            //FileInfo file = new FileInfo(path);
            //BinaryFormatter formatter = new BinaryFormatter();
            //if (file.Exists)
            //{                
            //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //    {
            //        PersonList = (Dictionary<int, Person>)formatter.Deserialize(fs); 
            //    }                
            //}
           
            //PersonList.Add(value.Id, value);           
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, PersonList);
            //}
            return "1"; //value.Name;


        }

        // PUT api/values/5
        public void Put([FromBody]Person value)
        {
            if (PersonList.ContainsKey(value.Id))
            {
                PersonList[value.Id].Age = value.Age;
                PersonList[value.Id].Name = value.Name;
            }
            else
            {
                Person NewPerson = new Person { Id = value.Id, Name = value.Name, Age = value.Age };
                PersonList.Add(NewPerson.Id, NewPerson);
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            PersonList.Remove(id);
        }
    }
}
