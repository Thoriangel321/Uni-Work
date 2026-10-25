using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab_3.Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector[] vectors = {
                new Vector("Red", 3, 4),
                new Vector("Blue", 6, 8),
                new Vector("Green", 5, 12)
            };

            List<Vector> vectorList = new List<Vector>(vectors);

            // JSON
            string jsonString = JsonSerializer.Serialize(vectors);
            File.WriteAllText("vectors.json", jsonString);
            var jsonDeser = JsonSerializer.Deserialize<Vector[]>(File.ReadAllText("vectors.json"));

            // XML
            XmlSerializer xmlSer = new XmlSerializer(typeof(Vector[]));
            using (FileStream fs = new FileStream("vectors.xml", FileMode.Create)) xmlSer.Serialize(fs, vectors);
            using (FileStream fs = new FileStream("vectors.xml", FileMode.Open))
            {
                var xmlDeser = (Vector[])xmlSer.Deserialize(fs);
            }

#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete
            // Binary & Custom (Iserializable realised in class file)
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("vectors.bin", FileMode.Create)) binFormatter.Serialize(fs, vectors);
            using (FileStream fs = new FileStream("vectors.bin", FileMode.Open))
            {
                var binDeser = (Vector[])binFormatter.Deserialize(fs);
                Console.WriteLine("deserialized in binary (Custom ISerializable):");
                foreach (var v in binDeser) Console.WriteLine(v.ToString());
            }
#pragma warning restore SYSLIB0011
        }
    }
}
