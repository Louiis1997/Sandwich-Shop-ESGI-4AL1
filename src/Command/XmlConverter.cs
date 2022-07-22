using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace sandwichshop.Command;

public class XmlConverter<T> where T : new()
{
    private readonly XmlSerializer _serializer;

    public XmlConverter()
    {
        _serializer = new XmlSerializer(typeof(T));
    }
    
    public T Deserialize(string xmlPath)
    {
        
        Stream fs = new FileStream(xmlPath, FileMode.Open);
        T items = (T)_serializer.Deserialize(new XmlTextReader(fs));
        fs.Close();
        return items;

    }

    public string Serialize(T items, string nameFile)
    {
        StringWriter stringWriter = new StringWriter();
        _serializer.Serialize(stringWriter, items );
        File.WriteAllText(nameFile, stringWriter.ToString(), Encoding.ASCII);
        return stringWriter.ToString();
    }
}