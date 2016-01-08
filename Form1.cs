using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tx_database_back
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // import XML into a new DataSet object
            DataSet ds = new DataSet();
            ds.ReadXml("data.xml");

            bindingSource1.DataSource = ds.Tables[0];
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // retrieve the current DataRow
            DataRow drCurrent = ((DataRowView)bindingSource1.Current).Row;

            // create a temporary copy with only the current row
            DataTable dtTemp  = drCurrent.Table.Clone();
            dtTemp.ImportRow(drCurrent);

            // merge the template with the cloned table
            mailMerge1.Merge(dtTemp);
        }
        
    }
}
