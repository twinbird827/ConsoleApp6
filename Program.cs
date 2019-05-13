using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    [DataContract]
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{default(double) == 0d}");
            //for (int i = 1; true; i++)
            //{
            //    var hasException = false;
            //    var target = double.MaxValue / i;

            //    try
            //    {
            //        Console.WriteLine(double.Parse(target.ToString()));
            //    }
            //    catch
            //    {
            //        hasException = true;
            //    }

            //    if (!hasException)
            //    {
            //        Console.WriteLine($"{i}:{target}");
            //        break;
            //    }
            //}
            //var array = new List<string>();

            //Console.WriteLine(array.Sum(a => a.Length));
            //var fi = new FileInfo(@"C:\TEst\Test.txt");

            //Console.WriteLine(fi.Exists);
            //Console.WriteLine(fi.Length);
            //try
            //{
            //    fi.Delete();
            //}
            //catch
            //{
            //    Console.WriteLine("ﾌｧｲﾙが存在しないのに削除しようとするとｴﾗｰになるらしい");
            //}
            //Console.ReadLine();

            //var s = string.Empty;
            //while ((s = Console.ReadLine()) != string.Empty)
            //{
            //    var i1 = double.Parse(s);
            //    var i = Math.Round(i1, 2);
            //    Console.WriteLine(i * 100);
            //    Console.WriteLine(Math.Ceiling(i * 100));
            //    //Console.WriteLine(Math.Floor(i / 8d));
            //    //Console.WriteLine(Math.Floor(i % 3d));
            //    Console.WriteLine("--");
            //}
            //try
            //{
            //    Console.WriteLine(sbyte.Parse(sbyte.MaxValue.ToString()));
            //    Console.WriteLine(sbyte.Parse(sbyte.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: sbyte");
            //}
            //try
            //{
            //    Console.WriteLine(byte.Parse(byte.MaxValue.ToString()));
            //    Console.WriteLine(byte.Parse(byte.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: byte");
            //}
            //try
            //{
            //    Console.WriteLine(short.Parse(short.MaxValue.ToString()));
            //    Console.WriteLine(short.Parse(short.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: short");
            //}
            //try
            //{
            //    Console.WriteLine(ushort.Parse(ushort.MaxValue.ToString()));
            //    Console.WriteLine(ushort.Parse(ushort.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: ushort");
            //}
            //try
            //{
            //    Console.WriteLine(int.Parse(int.MaxValue.ToString()));
            //    Console.WriteLine(int.Parse(int.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: int");
            //}
            //try
            //{
            //    Console.WriteLine(uint.Parse(uint.MaxValue.ToString()));
            //    Console.WriteLine(uint.Parse(uint.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: uint");
            //}
            //try
            //{
            //    Console.WriteLine(long.Parse(long.MaxValue.ToString()));
            //    Console.WriteLine(long.Parse(long.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: long");
            //}
            //try
            //{
            //    Console.WriteLine(ulong.Parse(ulong.MaxValue.ToString()));
            //    Console.WriteLine(ulong.Parse(ulong.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: ulong");
            //}
            //try
            //{
            //    Console.WriteLine(float.Parse(float.MaxValue.ToString()));
            //    Console.WriteLine(float.Parse(float.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: float");
            //}
            //try
            //{
            //    double d;
            //    Console.WriteLine(double.TryParse(double.MaxValue.ToString(), out d));
            //    Console.WriteLine(double.TryParse(double.MinValue.ToString(), out d));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: double");
            //}
            //try
            //{
            //    //Console.WriteLine(decimal.Parse(double.MaxValue.ToString()));
            //    Console.WriteLine(decimal.Parse(double.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: decimal");
            //}
            //try
            //{
            //    Console.WriteLine(char.Parse(char.MaxValue.ToString()));
            //    Console.WriteLine(char.Parse(char.MinValue.ToString()));
            //}
            //catch
            //{
            //    Console.WriteLine("Exception: char");
            //}

            //double dd;
            //for (dd = double.MaxValue; true; dd *= 0.99999999999999999d)
            //{
            //    try
            //    {
            //        Console.WriteLine(double.Parse(dd.ToString()));
            //        break;
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Exception: double");

            //    }
            //}
            //Console.WriteLine(double.MaxValue);
            //Console.WriteLine(dd);

            //double target = (3600000d / 2000d / 1000);
            //Console.WriteLine(target);
            //Console.WriteLine(Math.Ceiling(target));
            //Console.WriteLine(Math.Floor(target));

            //var timer = new AsyncTimer();
            //var enddate = DateTime.Now.AddSeconds(10);
            //timer.Interval = TimeSpan.FromMilliseconds(1000);
            //timer.Tick += async (sender, e) =>
            //{
            //    Console.WriteLine("begin");

            //    await Task.Delay(500);
            //    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            //    Console.WriteLine("end");
            //    timer.Completed();
            //};
            //timer.Start();
            //const int Count = 20000000;

            //var sp = new Stopwatch();
            //var r = new Random();

            //sp.Restart();
            //for (int i = 0; i < Count; i++)
            //{
            //    int[] arr = GetArr(r);
            //    int[] result = cal1(arr);
            //}
            //Console.WriteLine($"cal1: {sp.Elapsed}");

            //sp.Restart();
            //for (int i = 0; i < Count; i++)
            //{
            //    int[] arr = GetArr(r);
            //    int[] result = cal2(arr);
            //}
            //Console.WriteLine($"cal2: {sp.Elapsed}");

            //sp.Restart();
            //for (int i = 0; i < Count; i++)
            //{
            //    int[] arr = GetArr(r);
            //    int[] result = cal3(arr);
            //}
            //Console.WriteLine($"cal3: {sp.Elapsed}");

            ////sp.Restart();
            ////for (int i = 0; i < Count; i++)
            ////{
            ////    int[] arr = GetArr(r);
            ////    int[] result = cal4(arr);
            ////}
            ////Console.WriteLine($"cal4: {sp.Elapsed}");

            //int[] arr1 = GetArr(r);
            //Console.WriteLine($"{arr1[0]} {arr1[1]} {arr1[2]} {arr1[3]} {arr1[4]} {arr1[5]}");
            Console.ReadLine();
            ////var program = Deserialize<Program>(@"program.json") ?? new Program();

            ////program.Main();
        }
        static int[] GetArr(Random r)
        {
            return Enumerable.Repeat(0, 6).Select(i => r.Next(100)).ToArray();
        }
        static int[] cal1(int[] arr)

        {
            var list = arr.AsEnumerable();   
            //var list =

            //    from a in arr

            //    select a;

            var sum = list.Sum();

            var count = list.Count();

            var max = list.Max();

            var min = list.Min();

            return new int[] { sum, count, max, min };

        }

        static int[] cal2(int[] arr)

        {

            int sum = 0;

            int count = 0;

            int max = int.MinValue;

            int min = int.MaxValue;

            foreach (int a in arr)

            {

                sum += a;

                count++;

                if (max < a) max = a;

                if (min > a) min = a;

            }

            return new int[] { sum, count, max, min };

        }

        static int[] cal3(int[] arr)

        {

            return new int[] {

        arr.Sum(),

        arr.Count(),

        arr.Max(),

        arr.Min()

    };

        }

        static int[] cal4(int[]arr)
        {
            var c =
                from d in arr
                group d by 0 into x
                select new
                {
                    Count = x.Count(),
                    Max = x.Max(),
                    Min = x.Min(),
                    Sum = x.Sum()
                };
            var b = c.First();
            //var b = arr.GroupBy(c => 0).Select(x => new
            //{
            //    Count = x.Count(),
            //    Max = x.Max(),
            //    Min = x.Min(),
            //    Sum = x.Sum()
            //}).First();
            return new int[] { b.Sum, b.Count, b.Max, b.Min };
        }

        private Program()
        {
            Console.WriteLine("ｺﾝｽﾄﾗｸﾀ");
        }

        public void Main()
        {
            Serialize(@"program.json", this);

            Console.WriteLine("ﾒｲﾝ");
            Console.WriteLine(Date);
            Console.ReadLine();
        }

        [DataMember]
        public DateTime Date { get; set; } = DateTime.Now;

        // Json保存
        private static void Serialize<T>(string filePath, T data)
        {
            var encoding = Encoding.UTF8;

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(filePath, false, encoding))
            {
                var settings = new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = true,
                };
                var serializer = new DataContractJsonSerializer(typeof(T), settings);
                serializer.WriteObject(stream, data);
                writer.Write(encoding.GetString(stream.ToArray()));
            }
        }

        // Json復元
        private static T Deserialize<T>(string filePath)
        {
            var encoding = Encoding.UTF8;

            if (!File.Exists(filePath))
            {
                return default(T);
            }

            var message = File.ReadAllText(filePath);
            using (var stream = new MemoryStream(encoding.GetBytes(message)))
            {
                var settings = new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = true,
                };
                var serializer = new DataContractJsonSerializer(typeof(T), settings);
                return (T)serializer.ReadObject(stream);
            }
        }

    }
}
