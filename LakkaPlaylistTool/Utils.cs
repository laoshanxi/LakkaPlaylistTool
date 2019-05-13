using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LakkaPlaylistTool
{
    class Utils
    {
        /// <summary>
        /// Get ROM Chinese name from FBA_Shuffle data base
        /// </summary>
        /// <returns>Key: rom name [wofa], Value : tranlated rom Name [三国志 II (亚洲版 921005)] </returns>
        public static Dictionary<string, string> getFBA_res()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fba_res.Lakka.gamelist_cn);
            XmlNodeList gameList = doc.SelectNodes("//game");
            foreach (XmlNode game in gameList)
            {
                XmlElement xe = (XmlElement)game;
                string romName = xe.SelectSingleNode("name").InnerText.Trim();
                string romCnName = xe.SelectSingleNode("translation").InnerText.Trim();
                if (romName.Length > 0 && !dic.ContainsKey(romName))
                {
                    dic[romName] = romCnName;
                }
            }
            return dic;
        }

        /// <summary>
        /// Get ROM Chinese name from
        /// http://www.emu618.net/home/fc/allset/web/
        /// </summary>
        /// <returns>Key: rom name [Super Gryzor (J)], Value : 魂斗罗2(日) </returns>
        public static Dictionary<string, string> getFC_res()
        {
            return getTxt_res(fc_res.Fc.fc_rom);
        }
        public static Dictionary<string, string> getMD_res()
        {
            return getTxt_res(md_res.md_cn.md_rom);
        }

        public static Dictionary<string, string> getSFC_res()
        {
            return getTxt_res(sfc_res.sfc_cn.sfc_rom);
        }
        public static Dictionary<string, string> getPCE_res()
        {
            return getTxt_res(pce_res.pce_cn.pce_rom);
        }

        private static Dictionary<string, string> getTxt_res(string text)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string str = string.Empty;
            StringReader sr = new StringReader(text);
            while (sr.Peek() != -1)
            {
                str = sr.ReadLine();
                string[] arr = str.Split('\t');
                string romName = arr.Length > 1 ? arr[0].Trim() : "";
                string romCnName = arr.Length > 1 ? arr[1].Trim() : "";
                if (romName.Length > 0 && !dic.ContainsKey(romName))
                {
                    dic[romName] = romCnName;
                }
            }
            return dic;
        }

        /// <summary>
        /// write line to file
        /// </summary>
        /// <param name="fStream"></param>
        /// <param name="str"></param>
        public static void WriteStrToFile(FileStream fStream, string str)
        {
            byte[] data1 = System.Text.Encoding.UTF8.GetBytes(str);
            fStream.Write(data1, 0, data1.Length);

            byte[] data2 = System.Text.Encoding.UTF8.GetBytes("\r\n");
            fStream.Write(data2, 0, data2.Length);
        }

        /// <summary>
        /// Get File Name
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileNameWithOutExtention(string file)
        {
            FileInfo fi = new FileInfo(file);
            return fi.Name.Remove(fi.Name.LastIndexOf(fi.Extension));
        }

        /// <summary>
        /// Get File Name
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileNameWithOutExtention(FileInfo file)
        {
            return file.Name.Remove(file.Name.LastIndexOf(file.Extension));
        }

        public static string AddPYCharToStr(string str)
        {
            return GetPYChar(str) + " " + str;
        }

        public static string GetPYChar(string str)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(str);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return str.Substring(0, 1);
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return str.Substring(0, 1);
        }
    }
}
