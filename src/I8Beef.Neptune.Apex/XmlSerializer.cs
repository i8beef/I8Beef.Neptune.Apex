using System.IO;
using System.Text;
using System.Xml;

namespace I8Beef.Neptune.Apex
{
    /// <summary>
    /// XML serializer.
    /// </summary>
    /// <typeparam name="TType">The type of object to serialize or deserialize.</typeparam>
    public static class XmlSerializer<TType>
        where TType : class
    {
        /// <summary>
        /// Serializes an object to XML
        /// </summary>
        /// <param name="instance">Object to serialize.</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize(TType instance)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TType));
            var settings = new XmlWriterSettings()
            {
                Encoding = new UnicodeEncoding(false, false),
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, instance);
                }

                return textWriter.ToString();
            }
        }

        /// <summary>
        /// DeSerializes an object from XML
        /// </summary>
        /// <param name="xml">XML to deserialize.</param>
        /// <returns>Deserialized object.</returns>
        public static TType Deserialize(string xml)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TType));

                return serializer.Deserialize(stream) as TType;
            }
        }
    }
}
