//using System.Text.Json;

using Newtonsoft.Json;

namespace _20_lesson_exam_1_2
{
    public class Service
    {
        private string FilePath = @"C:\Users\Admin\source\repos\Bootcamp-Result\1_month_C#\20_lesson_exam_1_2\Datas";

        public void CreateFile<T>()
        {
            string myfileName = typeof(T).Name + ".json";
            string Path = System.IO.Path.Combine(FilePath, myfileName);
            FullPath = Path;
            try
            {
                if (!File.Exists(Path))
                {
                    using StreamWriter writer = new StreamWriter(Path);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Mistake in creating file: {e.Message}");
            }
        }
        private string FullPath = string.Empty;

        public void AddData<T>(T obj)
        {
            CreateFile<T>();
            List<T> objects = GetAllDatas<T>();

            for (int i = 0; i < objects.Count; i++)
            {
                if (GetId(objects[i]) == GetId(obj))
                {
                    Console.WriteLine("Already exist.");
                    return;
                }
            }

            objects.Add(obj);
            Console.WriteLine("Added succesfully.");

            WriteDatas<T>(Serialize(objects));
        }

        public void DeleteData<T>(int id)
        {
            List<T> objects = GetAllDatas<T>();
            for (int i = 0; i < objects.Count; i++)
            {
                if (GetId(objects[i]) == id)
                {
                    objects.RemoveAt(i);
                    Console.WriteLine("Deleted succesfully.");
                    WriteDatas<T>(Serialize(objects));
                    return;
                }
            }
            Console.WriteLine("Not found");
        }
        public void UpdateData<T>(int id, T obj)
        {
            List<T> objects = GetAllDatas<T>();

            for (int i = 0; i < objects.Count; i++)
            {
                if (GetId(objects[i]) == id)
                {
                    objects[i] = obj;
                    WriteDatas<T>(Serialize(objects));
                }
            }
        }
        public List<T> GetAllDatas<T>()
        {
            try
            {
                using (StreamReader ReadFiles = new StreamReader(FullPath))
                {
                    Console.WriteLine(FullPath);
                    return SDeserialize<T>(ReadFiles.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new List<T>();
            }
        }


        public List<T> SDeserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public string Serialize<T>(List<T> vals)
        {
            return JsonConvert.SerializeObject(vals, Formatting.Indented);
        }

        public void WriteDatas<T>(string json)
        {
            try
            {
                File.WriteAllText(FullPath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Mistake in writing to file: {e.Message}");
            }
        }

        private int GetId<T>(T item)
        {
            string fileName = typeof(T).Name;
            var propId = typeof(T).GetProperty("Id")!;
            var propValue = propId.GetValue(item)!;
            return (int)propValue;
        }
    }
}

