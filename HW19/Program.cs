using Newtonsoft.Json;

namespace HW19
{
    internal class Program
    {
        static string path = @"C:\Users\ASUS\Desktop\KonulHW\names.json";

        static void Main(string[] args)
        {
            Add("Konul");
            Add("Aynur");

            Console.WriteLine(Search("Konul")); // True
            Console.WriteLine(Search("Nigar")); // False

            Delete("Aynur");

            Console.WriteLine("Proqram bitdi!");
        }

        static void Add(string name)
        {
            List<string> names = ReadNames();
            names.Add(name);
            WriteNames(names);
        }

        static bool Search(string name)
        {
            List<string> names = ReadNames();
            foreach (string n in names)
            {
                if (n.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }

        static void Delete(string name)
        {
            List<string> names = ReadNames();
            names.RemoveAll(n => n.ToLower() == name.ToLower());
            WriteNames(names);
        }

        static List<string> ReadNames()
        {
            if (!File.Exists(path))
                return new List<string>();

            string json = File.ReadAllText(path);

            List<string> names = JsonConvert.DeserializeObject<List<string>>(json);

            if (names == null)  // əgər fayl boşdursa, Deserialize null qaytara bilər
                return new List<string>();

            return names;
        }

        static void WriteNames(List<string> names)
        {
            string json = JsonConvert.SerializeObject(names, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
