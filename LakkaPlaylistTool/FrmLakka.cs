using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace LakkaPlaylistTool
{

    public partial class FrmLakka : Form
    {
        /// <summary>
        /// Key : ROM name, wolf
        /// </summary>
        private Dictionary<string, GameItem> m_games = new Dictionary<string, GameItem>();
        /// <summary>
        /// Key : ROM name, wolf
        /// </summary>
        private Dictionary<string, FileInfo> m_roms = new Dictionary<string, FileInfo>();

        /// <summary>
        /// Key : ROM name, wolf
        /// </summary>
        private Dictionary<string, FileInfo> m_images = new Dictionary<string, FileInfo>();

        private List<GameItem> m_finallyGames = new List<GameItem>();

        private string m_cacheFileDialogPath = "";


        public FrmLakka()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadLakkaList_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Lakka游戏列表文件";
            fileDialog.Filter = "所有文件(*.lpl)|*.lpl";
            fileDialog.InitialDirectory = m_cacheFileDialogPath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFileDialogPath = fileDialog.FileName;
                foreach (string file in fileDialog.FileNames)
                {
                    this.txtLakkaList.Text = file;
                    // Read into memory
                    m_games = readLakkaGames(file);
                    this.label1.Text = ("载入<" + m_games.Count.ToString() + ">个ROM到内存。");
                }
            }
        }
        private void btnLoadRomDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择Lakka ROM文件夹路径";
            dialog.SelectedPath = m_cacheFileDialogPath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                m_cacheFileDialogPath = foldPath;
                txtLakkaRom.Text = foldPath;
                m_roms = readRomToMem(foldPath);
                this.label1.Text = ("检测到<" + m_roms.Count.ToString() + ">个游戏ROM");
            }
        }

        private string readLine(StreamReader sr)
        {
            if (sr.EndOfStream)
            {
                return "";
            }
            string s = sr.ReadLine();
            if (s.Contains("<hidden>") || s.Trim().Length == 0)
            {
                s = sr.ReadLine();
            }
            return s.Trim();
        }
        public Dictionary<string, GameItem> readLakkaGames(string filePath)
        {
            StreamReader reader = File.OpenText(filePath);
            Dictionary<string, GameItem> games = new Dictionary<string, GameItem>();
            while (!reader.EndOfStream)
            {
                GameItem item = new GameItem();
                item.V1RomFullFileName = readLine(reader);
                if (item.V1RomFullFileName.Contains("."))
                {
                    if (!games.ContainsKey(item.V1RomFullFileName))
                    {
                        games.Add(item.V1RomFullFileName, item);
                    }
                }
                else
                {
                    MessageBox.Show("警告, ROM <" + item.V1RomFullFileName + "> 不是文件, 退出读取.");
                    break;
                }
                item.V2RomCnName = readLine(reader);
                item.V3coreBinaryPath = readLine(reader);
                item.V4EmuType = readLine(reader);
                item.V5Crc32 = readLine(reader);
                item.V6pListName = readLine(reader);

                item.removeUnSupportedFileChar();
            }
            reader.Close();
            return games;
        }
        private void writeStrToFile(FileStream fStream, string str)
        {
            byte[] data1 = System.Text.Encoding.UTF8.GetBytes(str);
            fStream.Write(data1, 0, data1.Length);

            byte[] data7 = System.Text.Encoding.UTF8.GetBytes("\r\n");
            fStream.Write(data7, 0, data7.Length);
        }
        private void btnWrite_Click(object sender, EventArgs e)
        {

        }
        private void btnRetroImageDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择ROM图片文件夹路径";
            dialog.SelectedPath = m_cacheFileDialogPath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                m_cacheFileDialogPath = foldPath;
                txtRetroImage.Text = foldPath;

                m_images = readImgToMem(foldPath);
                this.label1.Text = ("检测到<" + m_images.Count.ToString() + ">个图片");
            }
        }

        public Dictionary<string, FileInfo> readRomToMem(string dir)
        {
            Dictionary<string, FileInfo> roms = new Dictionary<string, FileInfo>();
            FileInfo[] fileList = new DirectoryInfo(dir).GetFiles();
            foreach (FileInfo file in fileList)
            {
                if (file.Extension.ToLower() == ".txt") continue;
                if (file.Extension.ToLower() == ".db") continue;
                if (file.Extension.ToLower() == ".png") continue;
                if (file.Extension.ToLower() == ".gif") continue;
                if (file.Extension.ToLower() == ".xls") continue;
                if (file.Extension.ToLower() == ".exe") continue;
                string romeName = Utils.GetFileNameWithOutExtention(file);
                if (!roms.ContainsKey(romeName)) roms.Add(romeName, file);
            }
            // Read Child Directory
            foreach (DirectoryInfo di in (new DirectoryInfo(dir)).GetDirectories())
            {
                Dictionary<string, FileInfo> romsFromChildDir = new Dictionary<string, FileInfo>();
                romsFromChildDir = readRomToMem(di.FullName);
                if (romsFromChildDir.Count == 0) continue;
                foreach(var v in romsFromChildDir)
                {
                    if (roms.ContainsKey(v.Key)) continue;
                    roms.Add(v.Key, v.Value);
                }
            }
            return roms;
        }

        private Dictionary<string, FileInfo> readImgToMem(string dir)
        {
            Dictionary<string, FileInfo> images = new Dictionary<string, FileInfo>();
            // 加载所有图片到内存中
            FileInfo[] fileList = new DirectoryInfo(dir).GetFiles("*.jpg");
            foreach (FileInfo file in fileList)
            {
                images.Add(Utils.GetFileNameWithOutExtention(file), file);
            }
            fileList = new DirectoryInfo(dir).GetFiles("*.png");
            foreach (FileInfo file in fileList)
            {
                images.Add(Utils.GetFileNameWithOutExtention(file), file);
            }
            return images;
        }
        private void readImageBitToMem(List<GameItem> games)
        {
            if (txtRetroImage.Text.Length > 0)
            {
                foreach (GameItem item in games)
                {
                    FileInfo fi = null;
                    if (!m_images.TryGetValue(item.getRomShortFileNameWithOutExtension(), out fi))
                    {
                        m_images.TryGetValue(item.V2RomCnName, out fi);
                    }
                    if (fi != null)
                    {
                        item.image = Image.FromFile(fi.FullName);
                        item.imageFullName = fi.FullName;
                    }
                }
            }
        }
        private int doAction(List<GameItem> games, string newFileName)
        {
            int count = 0;
            if (games.Count() == 0) return 0;
            //输出
            FileStream fs = File.Create(newFileName);
            foreach (GameItem item in games)
            {
                if (!m_roms.ContainsKey(item.getRomShortFileNameWithOutExtension())) continue;
                if (this.cbxCrc32.Checked) item.V5Crc32 = FileToCRC32.GetLakkaCRC32(m_roms[item.getRomShortFileNameWithOutExtension()].FullName);
                writeStrToFile(fs, item.V1RomFullFileName);
                writeStrToFile(fs, item.V2RomCnName);
                writeStrToFile(fs, item.V3coreBinaryPath);
                writeStrToFile(fs, item.V4EmuType);
                writeStrToFile(fs, item.V5Crc32);
                writeStrToFile(fs, item.V6pListName);
                count++;
            }
            fs.Flush();
            fs.Close();

            // 重新拷贝ROM
            if (this.cbxCopyRoms.Checked)
            {
                FileInfo fi1 = new FileInfo(newFileName);
                string newRomDir = fi1.DirectoryName + "\\" + fi1.Name + "_ROM";
                Directory.CreateDirectory(newRomDir);
                foreach (GameItem item in games)
                {
                    FileInfo fi = m_roms[item.getRomShortFileNameWithOutExtension()];
                    string newRomName = newRomDir + "\\" + item.getRomShortFileNameWithOutExtension() + fi.Extension;
                    try
                    {
                        // 对每一个rom
                        if (!File.Exists(newRomName))
                        {
                            fi.CopyTo(newRomName);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.label1.Text += ex.Message;
                    }
                }
            }

            if (txtRetroImage.Text.Length > 0)
            {
                // 创建新的图片目录
                FileInfo fi = new FileInfo(newFileName);
                string newImageDir = fi.DirectoryName + "\\" + fi.Name + "_IMAGE";
                Directory.CreateDirectory(newImageDir);
                foreach (GameItem item in games)
                {
                    if (item.imageFullName != "")
                    {
                        FileInfo ff = new FileInfo(item.imageFullName);
                        string newImageName = newImageDir + "\\" + item.V2RomCnName + ff.Extension;
                        try
                        {
                            // 对每一个rom，找图片并且拷贝到新名字中
                            if (!File.Exists(newImageName))
                            {
                                ff.CopyTo(newImageName);
                            }
                        }
                        catch (Exception ex)
                        {
                            this.label1.Text += ex.Message;
                        }

                    }
                }
            }

            return count;
        }

        void CheckAll()
        {
            List<string> removeList = new List<string>();
            foreach (GameItem game in m_games.Values)
            {
                if (!m_roms.ContainsKey(game.getRomShortFileNameWithOutExtension()) &&
                    !m_roms.ContainsKey(game.V2RomCnName))
                {
                    removeList.Add(game.getRomShortFileNameWithOutExtension());
                }
            }
            foreach (string s in removeList)
            {
                m_games.Remove(s);
            }
        }

        private List<GameItem> sortAndTranslate()
        {
            //排序
            List<GameItem> sortedList = new List<GameItem>();
            sortedList.AddRange(m_games.Values);
            sortedList.Sort();

            Dictionary<string, string> translateDic = new Dictionary<string, string>();
            //使用FBA中文名
            if (this.cbxUseFbaCnName.Checked)
            {
                translateDic = translateDic.Union(Utils.getFBA_res()).ToDictionary(key => key.Key, value => value.Value);
            }
            //使用FC中文名
            if (this.cbxUseFcCnName.Checked)
            {
                translateDic = translateDic.Union(Utils.getFC_res()).ToDictionary(key => key.Key, value => value.Value);
            }
            //使用MD中文名
            if (this.cbxUseMdCnName.Checked)
            {
                translateDic = translateDic.Union(Utils.getMD_res()).ToDictionary(key => key.Key, value => value.Value);
            }
            //使用SFC中文名
            if (this.cbxUseSfcCnName.Checked)
            {
                translateDic = translateDic.Union(Utils.getSFC_res()).ToDictionary(key => key.Key, value => value.Value);
            }
            //使用PCE中文名
            if (this.cbxUsePceCnName.Checked)
            {
                translateDic = translateDic.Union(Utils.getPCE_res()).ToDictionary(key => key.Key, value => value.Value);
            }

            //翻译ROM名称
            if (translateDic.Count > 0)
            {
                foreach (GameItem item in sortedList)
                {
                    if (translateDic.ContainsKey(item.getRomShortFileNameWithOutExtension()))
                    {
                        item.V2RomCnName = translateDic[item.getRomShortFileNameWithOutExtension()];
                    }
                }
            }
            return sortedList;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (m_games.Count == 0 || m_roms.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            CheckAll();

            List<GameItem> sortedList = sortAndTranslate();

            readImageBitToMem(sortedList);

            FrmEditRoms frm = new FrmEditRoms();
            frm.m_games = sortedList;
            frm.ShowDialog();
            this.m_finallyGames = frm.m_games;
            frm.Dispose();
            this.label1.Text = ("编辑<" + this.m_finallyGames.Count.ToString() + ">个ROM");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_games.Count == 0 || m_roms.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            CheckAll();
            //--------------------------------------------------------------------
            int count = 0;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "保存Lakka游戏列表文件";
            fileDialog.Filter = "所有文件(*.lpl)|*.lpl";
            fileDialog.FileName = m_cacheFileDialogPath;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_cacheFileDialogPath = fileDialog.FileName;
                List<GameItem> sortedList = sortAndTranslate();
                readImageBitToMem(sortedList);
                count = doAction(sortedList, fileDialog.FileName);

            }
            this.label1.Text = ("保存<" + count.ToString() + ">个rom到新文件中");
            MessageBox.Show(this.label1.Text);
        }
    }
}
