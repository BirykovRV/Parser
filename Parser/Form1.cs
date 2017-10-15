using Parser.Core;
using Parser.Core.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class MainForm : Form
    {
        ParserWorker<string[]> parser;

        public MainForm()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                new HabraParser()
                );
            parser.OnComplited += Parser_OnComplited;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void Parser_OnComplited(object obj)
        {
            MessageBox.Show("All Work Done!");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabraSettings((int)numericStart.Value, (int)numericEnd.Value);
            parser.Start();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
