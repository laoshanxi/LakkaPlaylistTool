using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace LakkaPlaylistTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 编辑Lakka列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLakkaEdit_Click(object sender, EventArgs e)
        {
            Form frm = new FrmLakka();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        /// <summary>
        /// 根据ROM目录生成Lakka列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateLakka_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "请选择 游戏ROM所在的文件夹";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FrmLakka lakka = new FrmLakka();
                    ICollection<FileInfo> files = lakka.readRomToMem(dialog.SelectedPath).Values;
                    lakka.Dispose();
                    Dictionary<string, GameItem> games = new Dictionary<string, GameItem>();
                    foreach (FileInfo fi in files)
                    {
                        GameItem item = new GameItem();
                        item.V1RomFullFileName = fi.FullName;
                        item.V2RomCnName = fi.FullName.Remove(fi.FullName.LastIndexOf(fi.Extension)); //item.getRomShortFileNameWithOutExtension();
                        item.V3coreBinaryPath = "DETECT_CORE";
                        item.V4EmuType = "DETECT_TYPE";
                        item.V5Crc32 = "DETECT";
                        item.V6pListName = "PLAY_LIST_FILE_NAME";
                        item.removeUnSupportedFileChar();
                        games.Add(item.V1RomFullFileName, item);
                    }

                    using (SaveFileDialog fileDialog = new SaveFileDialog())
                    {
                        fileDialog.Title = "保存Lakka游戏列表文件";
                        fileDialog.Filter = "所有文件(*.lpl)|*.lpl";
                        fileDialog.InitialDirectory = dialog.SelectedPath;
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //排序
                            List<GameItem> sortedList = new List<GameItem>();
                            sortedList.AddRange(games.Values);
                            sortedList.Sort();

                            FileStream fs = File.Create(fileDialog.FileName);
                            foreach (GameItem item in sortedList)
                            {
                                Utils.WriteStrToFile(fs, item.V1RomFullFileName);
                                Utils.WriteStrToFile(fs, item.V2RomCnName);
                                Utils.WriteStrToFile(fs, item.V3coreBinaryPath);
                                Utils.WriteStrToFile(fs, item.V4EmuType);
                                Utils.WriteStrToFile(fs, item.V5Crc32);
                                Utils.WriteStrToFile(fs, item.V6pListName);
                            }
                            fs.Flush();
                            fs.Close();
                            MessageBox.Show("成功转换<" + games.Count.ToString() + ">个游戏");
                        }
                    }
                }
            }
        }

        private void btnRetro_Click(object sender, EventArgs e)
        {

        }

        private Dictionary<string, GameItem> readRetroGames(string filePath)
        {
            Dictionary<string, GameItem> games = new Dictionary<string, GameItem>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode gameList = doc.SelectSingleNode("gameList");
            foreach (XmlNode game in gameList.ChildNodes)
            {
                GameItem item = new GameItem();
                // 将节点转换为元素，便于得到节点的属性值
                XmlElement xe = (XmlElement)game;
                item.V1RomFullFileName = "LAKKA_ROM_DIR/" + xe.SelectSingleNode("path").InnerText.Split('/').Last<string>();
                item.V2RomCnName = xe.SelectSingleNode("name").InnerText.Trim().Replace("/", ""); ;
                item.V3coreBinaryPath = "DETECT_CORE";
                item.V4EmuType = "DETECT_TYPE";
                item.V5Crc32 = "DETECT";
                item.V6pListName = "PLAY_LIST_FILE_NAME";
                item.removeUnSupportedFileChar();
                games.Add(item.V1RomFullFileName, item);
            }
            return games;
        }

        /// <summary>
        /// 转换Retro列表为Lakka格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetro2Lakka_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择Retro游戏列表文件";
                fileDialog.Filter = "所有文件(*.xml)|*.xml";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;

                    // Read into memory
                    Dictionary<string, GameItem> games = readRetroGames(file);

                    // Construct lpl file Name
                    FileInfo fi = new FileInfo(file);
                    string newLakkaFileName = fi.DirectoryName + "\\" + Utils.GetFileNameWithOutExtention(fi) + ".lpl";

                    // Create lakka list file
                    FileStream fs = File.Create(newLakkaFileName);
                    foreach (GameItem item in games.Values)
                    {
                        Utils.WriteStrToFile(fs, item.V1RomFullFileName);
                        Utils.WriteStrToFile(fs, item.V2RomCnName);
                        Utils.WriteStrToFile(fs, item.V3coreBinaryPath);
                        Utils.WriteStrToFile(fs, item.V4EmuType);
                        Utils.WriteStrToFile(fs, item.V5Crc32);
                        Utils.WriteStrToFile(fs, item.V6pListName);
                    }
                    fs.Flush();
                    fs.Close();
                    MessageBox.Show("成功转换 <" + games.Count.ToString() + "> 个ROM");

                }
            }
        }

        /// <summary>
        /// 转换Lakka列表为Retro格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLakka2Retro_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Lakka游戏列表文件";
            fileDialog.Filter = "所有文件(*.lpl)|*.lpl";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;

                // Read into memory
                FrmLakka frm = new FrmLakka();
                Dictionary<string, GameItem> games = frm.readLakkaGames(file);

                FileInfo fi = new FileInfo(file);
                string newRetroFileName = fi.DirectoryName + "\\" + Utils.GetFileNameWithOutExtention(fi) + ".xml";
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlNode rootNode = xmlDoc.CreateElement("gameList");
                xmlDoc.AppendChild(rootNode);
                foreach (GameItem item in games.Values)
                {
                    XmlNode gameNode = xmlDoc.CreateElement("game");
                    rootNode.AppendChild(gameNode);

                    XmlNode pathNode = xmlDoc.CreateElement("path");
                    pathNode.InnerText = item.V1RomFullFileName;
                    gameNode.AppendChild(pathNode);

                    XmlNode nameNode = xmlDoc.CreateElement("name");
                    nameNode.InnerText = item.V2RomCnName;
                    gameNode.AppendChild(nameNode);

                    XmlNode imgNode = xmlDoc.CreateElement("image");
                    imgNode.InnerText = item.V2RomCnName + ".png";
                    gameNode.AppendChild(imgNode);

                    XmlNode vdoNode = xmlDoc.CreateElement("video");
                    vdoNode.InnerText = item.getRomShortFileNameWithOutExtension() + ".mp4";
                    gameNode.AppendChild(vdoNode);

                    // Other empty attributes
                    XmlNode dscNode = xmlDoc.CreateElement("desc");
                    dscNode.InnerText = "";
                    gameNode.AppendChild(dscNode);

                    XmlNode rtNode = xmlDoc.CreateElement("rating");
                    rtNode.InnerText = "";
                    gameNode.AppendChild(rtNode);

                    XmlNode rlsdNode = xmlDoc.CreateElement("releasedate");
                    rlsdNode.InnerText = "";
                    gameNode.AppendChild(rlsdNode);

                    XmlNode dvlpdNode = xmlDoc.CreateElement("developer");
                    dvlpdNode.InnerText = "";
                    gameNode.AppendChild(dvlpdNode);

                    XmlNode pblsNode = xmlDoc.CreateElement("publisher");
                    pblsNode.InnerText = "";
                    gameNode.AppendChild(pblsNode);

                    XmlNode gnrNode = xmlDoc.CreateElement("genre");
                    gnrNode.InnerText = "";
                    gameNode.AppendChild(gnrNode);

                    XmlNode plyNode = xmlDoc.CreateElement("players");
                    plyNode.InnerText = "";
                    gameNode.AppendChild(plyNode);
                }
                xmlDoc.InsertBefore(Declaration, xmlDoc.DocumentElement);
                xmlDoc.Save(newRetroFileName);
                MessageBox.Show("成功转换 <" + games.Count.ToString() + "> 个游戏到文件<" + newRetroFileName + ">中。");
            }
        }

        /// <summary>
        /// Retro列表中文名称前添加大写字母
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCharToRetroList_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择Retro游戏列表文件";
                fileDialog.Filter = "所有文件(*.xml)|*.xml";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;

                    // Read into memory
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);
                    XmlNode gameList = doc.SelectSingleNode("gameList");
                    if (gameList != null)
                    {
                        foreach (XmlNode game in gameList.ChildNodes)
                        {
                            GameItem item = new GameItem();
                            // 将节点转换为元素，便于得到节点的属性值
                            XmlElement xe = (XmlElement)game;
                            XmlNode node = xe.SelectSingleNode("name");
                            node.InnerText = Utils.AddPYCharToStr(node.InnerText.Trim());
                        }
                    }

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = fileDialog.FileName;
                        saveFileDialog.Title = "保存新的Retro游戏列表文件";
                        saveFileDialog.Filter = "所有文件(*.xml)|*.xml";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            doc.Save(saveFileDialog.FileName);
                        }
                    }

                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Test Code.
        }
    }
}
