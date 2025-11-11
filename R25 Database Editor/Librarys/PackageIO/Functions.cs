using System.Text;
using System.Text.RegularExpressions;

namespace PackageIO
{
    public class Functions
    {
        public static bool CompareBytes(byte[] Arg0, byte[] Arg1)
        {
            return (Conversions.ObjectToHex(Arg0) == Conversions.ObjectToHex(Arg1));
        }

        public static int FileLen(string FilePath)
        {
            return FilePath.Length;
        }

        public static int FileSize(string file)
        {
            FileInfo fi = new(file);
            int FileSize = Convert.ToInt32(fi.Length);
            return FileSize;
        }

        public static string[] DirectoryInfo(string folder, string Char, SearchOption options)
        {
            string[] files = Directory.GetFiles(folder, Char, SearchOption.AllDirectories);
            return files;
        }

        public static int TxtLinesCount(string file)
        {
            int length = File.ReadLines(file).Count();
            return length;
        }

        public static string GetRatio(long Arg0, long Arg1)
        {
            return (Convert.ToDouble(Arg0 / Arg1)).ToString() + "%";
        }

        public static bool IsNumeric(long Numeric)
        {
            return new Regex(@"^[0-9]+\d").IsMatch(Numeric.ToString());
        }

        public static bool IsValidHex(string Hex)
        {
            return new Regex("^[A-Fa-f0-9]*$", RegexOptions.IgnoreCase).IsMatch(Hex);
        }

        public static bool IsValidUnicode(string Unicode)
        {
            return (Unicode.Length == LenB(Unicode));
        }

        public static int LenB(string ObjStr)
        {
            if (ObjStr.Length == 0)
            {
                return 0;
            }
            return Encoding.Unicode.GetByteCount(ObjStr);
        }

        public static byte[] RemoveAt(byte[] Bytes, int Index)
        {
            return Conversions.HexToByteArray(Conversions.ObjectToHex(Bytes).Remove(Index, 2));
        }

        public static byte[] RemoveByte(byte[] Bytes, byte ByteToRemove)
        {
            return Conversions.HexToByteArray(Conversions.ObjectToHex(Bytes).Replace(ByteToRemove.ToString(), string.Empty));
        }

        public static Array ReverseArray(Array Buffer)
        {
            Array.Reverse(Buffer);
            return Buffer;
        }

        public static string RoundBytes(long ByteCount)
        {
            if (ByteCount < 0x400)
            {
                return (ByteCount.ToString() + " b");
            }
            if ((ByteCount >= 0x400) && (ByteCount < 0x100000))
            {
                return (Convert.ToDouble(ByteCount / 1024.0).ToString() + " kb");
            }
            if ((ByteCount >= 0x100000) && (ByteCount < 0x40000000))
            {
                return (Convert.ToDouble(ByteCount / 1024.0 / 1024.0).ToString() + " mb");
            }
            if ((ByteCount < 0x40000000) || (ByteCount >= 0x10000000000))
            {
                throw new Exception("WTF!");
            }
            return (Convert.ToDouble(ByteCount / 1024.0 / 1024.0 / 1024.0).ToString() + " gb");
        }

        public static byte[] SwapSex(byte[] Buffer)
        {
            return (byte[])ReverseArray(Buffer);
        }
    }
}

