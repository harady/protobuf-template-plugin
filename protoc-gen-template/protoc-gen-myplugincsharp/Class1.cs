#define sample03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StreamReaderForBOM_sample
{
	class Program
	{
		/// <summary>
		/// This is the reading sample of BOM by StreamReader. 
		/// </summary>
		/// <param name="args">[1]:FileName</param>
		static void Main(string[] args)
		{
			if (args.Length == 0) {
				Console.WriteLine("Please input file name !");
			}

			string fileName = args[0];
			string fileContent = null;

#if sample01
            // Simplest StreamReader sample code.
            using (var reader =
                new StreamReader(fileName, 
                    Encoding.GetEncoding("utf-8"), true)
                )
            {
                Console.WriteLine("Before reading content : {0},{1}\n", 
                    reader.CurrentEncoding.ToString(), 
                    reader.CurrentEncoding.CodePage.ToString());

                fileContent = reader.ReadToEnd();

                Console.WriteLine("After reading content : {0},{1}\n", 
                    reader.CurrentEncoding.ToString(), 
                    reader.CurrentEncoding.CodePage.ToString());
            }

            Console.WriteLine(fileContent);
#endif

#if sample02
            // This is a sample code that can identify the BOM.
            // However, I cannot identify that there is no BOM.
            using (var reader =
                new StreamReader(fileName,
                    Encoding.GetEncoding("utf-8"), true)
                )
            {
                Console.WriteLine("Peek().");

                reader.Peek();

                byte[] buffer;
                buffer = reader.CurrentEncoding.GetPreamble().ToArray<byte>();

                Console.WriteLine("GetPreamble().Length : {0}",
                    reader.CurrentEncoding.GetPreamble().Length);

                Console.Write("GetPreamble().ToArray ");

                foreach(var buf in buffer)
                {
                    Console.Write(":{0}", buf.ToString("x2"));
                }
                Console.WriteLine(";");

                Console.WriteLine("Before reading content : {0},{1}\n",
                    reader.CurrentEncoding.ToString(),
                    reader.CurrentEncoding.CodePage.ToString());

                fileContent = reader.ReadToEnd();

                Console.WriteLine("After reading content : {0},{1}\n",
                    reader.CurrentEncoding.ToString(),
                    reader.CurrentEncoding.CodePage.ToString());
            }

            Console.WriteLine(fileContent);
#endif

#if sample03

			// This is sample code where utf and shift-jis can coexist.
			using (FileStream fs =
				new FileStream(fileName, FileMode.Open)
				) {
				// I am read BOM of readfile.
				byte[] bom = new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
				int codepage;
				fs.Read(bom, 0, 4);
				fs.Position = 0;

				if (IsBOM(bom, out codepage)) {
					Console.Write("BOM Value ");

					foreach (var b in bom) {
						Console.Write(":{0}", b.ToString("x2"));
					}
					Console.WriteLine(";");
				} else {
					Console.WriteLine("non BOM ! ;");

				}

				// Determine the encoding of StreamReader using FileStream.
				using (var reader =
					new StreamReader(fs, Encoding.GetEncoding(codepage))
					) {
					Console.WriteLine("Before reading content : {0},{1}\n",
						reader.CurrentEncoding.EncodingName,
						reader.CurrentEncoding.CodePage.ToString());

					fileContent = reader.ReadToEnd();

					Console.WriteLine("After reading content : {0},{1}\n",
						reader.CurrentEncoding.EncodingName,
						reader.CurrentEncoding.CodePage.ToString());
				}

				Console.WriteLine(fileContent);
			}

#endif
		} //End of Main

#if sample03

		/// <summary>
		/// Determine if it is BOM
		/// </summary>
		/// <param name="bom">Array to be inspected (4 bytes)</param>
		/// <param name="codepage">output of Encoding.Codepage</param>
		/// <returns>true=BOM.</returns>
		static bool IsBOM(byte[] bomByte, out int codepage)
		{
			bool result;
			byte[] bomUTF8 = { 0xEF, 0xBB, 0xBF };
			byte[] bomUTF16Little = { 0xFF, 0xFE };
			byte[] bomUTF16Big = { 0xFE, 0xFF };
			byte[] bomUTF32Little = { 0xFF, 0xFE, 0x00, 0x00 };
			byte[] bomUTF32Big = { 0x00, 0x00, 0xFE, 0xFF };

			if (IsMatched(bomByte, bomUTF8)) {
				result = true;
				codepage = 65001; //utf-8,Unicode (UTF-8)
			} else if (IsMatched(bomByte, bomUTF32Little)) {
				result = true;
				codepage = 12000; //utf-32,Unicode (UTF-32)
			} else if (IsMatched(bomByte, bomUTF32Big)) {
				result = true;
				codepage = 12001; //utf-32BE,Unicode (UTF-32 Big-Endian) 
			} else if (IsMatched(bomByte, bomUTF16Little)) {
				result = true;
				codepage = 1200; //utf-16,Unicode
			} else if (IsMatched(bomByte, bomUTF16Big)) {
				result = true;
				codepage = 1201; //utf-16BE,Unicode (Big-Endian) 
			} else {
				result = false;
				//codepage = 0; //non BOM !
				codepage = 932; //shift_jis,Japanese (Shift-JIS)
			}

			return result;
		}

		/// <summary>
		/// BOM sequence comparison
		/// </summary>
		/// <param name="data">Sequence to be inspected</param>
		/// <param name="bom">BOM array</param>
		/// <returns>true=match</returns>
		static bool IsMatched(byte[] data, byte[] bom)
		{
			bool result = true;

			for (int i = 0; i < bom.Length; i++) {
				if (bom[i] != data[i])
					result = false;
			}

			return result;
		}

#endif

	}
}