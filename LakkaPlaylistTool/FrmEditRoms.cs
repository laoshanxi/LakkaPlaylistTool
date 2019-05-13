using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LakkaPlaylistTool
{
    public partial class FrmEditRoms : Form
    {
        public List<GameItem> m_games = null;
        public FrmEditRoms()
        {
            InitializeComponent();
        }

        private void FrmEditRoms_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = new BindingList<GameItem>(m_games);
            this.dataGridView1.Refresh();
            this.dataGridView1.Show();
        }
    }
}
