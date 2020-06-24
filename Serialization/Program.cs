using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Ahmet Faruk",
                Surname = "Ulu",
                BirthDate = 1998,
                Country = "Türkiye"
            };
            //BinarySample(person);
            //XmlSample(person);
            JsonSample(person);//Install-Package Newtonsoft.Json -Version 12.0.3
            Console.ReadKey();
        }
        #region Binary
        static byte[] BinarySerialize(object graph)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
                return stream.ToArray();
            }
        }
        static object BinaryDeserialize(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }
        static void BinarySample(Person person)
        {
            File.WriteAllBytes("BinaryData.dat", BinarySerialize(person));//serialization
            if (File.Exists("BinaryData.dat"))
            {
                var data = File.ReadAllBytes("BinaryData.dat");
                Person _person = (Person)BinaryDeserialize(data);//deserialization
            }
        }
        #endregion

        #region Xml
        static string XmlSerialize<T>(T value)
        {
            if (value == null) return string.Empty;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return stringWriter.ToString();
                }
            }
        }
        static T XmlDeserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        static void XmlSample(Person person)
        {
            File.WriteAllText("XmlData.xml", XmlSerialize(person));
            if (File.Exists("XmlData.xml"))
            {
                string dataXml = File.ReadAllText("XmlData.xml");
                Person _person = XmlDeserialize<Person>(dataXml);//deserialization
            }
        }
        #endregion

        #region Json
        static void JsonSample(Person person)
        {
            File.WriteAllText("JsonData.json", JsonConvert.SerializeObject(person));
            if (File.Exists("JsonData.json"))
            {
                string dataJson = File.ReadAllText("JsonData.json");
                Person _person = JsonConvert.DeserializeObject<Person>(dataJson);//deserialization
            }
        }
        #endregion
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDate { get; set; }
        [NonSerialized]
        public string Country;
    }
}
