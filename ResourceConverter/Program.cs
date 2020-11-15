using ResourceConverter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace RCConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // 引数チェック
            if (args.Length != 1)
            {
                // ファイルの指定が必要
                return;
            }

            // ファイルの実在チェック & rcファイルであること
            if (!File.Exists(args[0]) &&
            !args[0].ToLower().EndsWith(".rc"))
            {
                // 実在するファイルを指定する必要あり
                return;
            }

            List<string> lines = new List<string>();
            // ファイルを1行ずつ読み込む→既定の内容の場合、それに対応した処理を行う
            using (FileStream fs = new FileStream(args[0], FileMode.Open))
            {
                using StreamReader reader = new StreamReader(fs);
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                };
            }

            List<string>.Enumerator line = lines.GetEnumerator();


            var partsInfoBuilder = new PartsInfoBuilder();
            var converter = partsInfoBuilder.GetPartsInfo();
            var convertList = new List<List<string>>();
            while (line.MoveNext())
            {
                Debug.WriteLine(line.Current);
                var result = converter.Convert(line.Current);
                if (result.Item1.Count > 0)
                {
                    convertList.Add(result.Item1);
                }

                converter = partsInfoBuilder.GetPartsInfo(result.Item2);
            }

            Debug.WriteLine("END.");

        }
    }
}