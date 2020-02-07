using System.IO;
using System.Xml.Serialization;

namespace Application.Common.Parsers
{
    public class XmlParser
    {
        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");

            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize, xmlSerializerNamespaces);
                return textWriter.ToString();
            }
        }

        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringReader stringReader = new StringReader(input))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
