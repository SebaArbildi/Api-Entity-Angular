using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;
using DocSystEntities.StyleStructure;

namespace DocSystWindowsApp
{
    public partial class FormatForm : UserControl
    {
        private IList<Format> realFormatList { get; set; }
        private IList<StyleClass> realStyleClassList { get; set; }
        private IFormatBusinessLogic formatBusinessLogic { get; set; }
        private IStyleClassBusinessLogic styleClassBusinessLogic { get; set; }


        public FormatForm()
        {
            InitializeComponent();
            styleClassBusinessLogic = new StyleClassBusinessLogic(new StyleClassDataAccess(), new StyleBusinessLogic(new StyleDataAccess()));
            formatBusinessLogic = new FormatBusinessLogic(new FormatDataAccess(), styleClassBusinessLogic);
            LoadListFormat();
            LoadListStyleClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Format format = new Format();
                format.Name = this.textBox1.Text;
                formatBusinessLogic.Add(format);
                MessageBox.Show("Formato creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Refresh();
        }

        private void Refresh()
        {
            Clear();
            LoadListFormat();
            LoadListStyleClass();
        }


        private void Clear()
        {
            this.textBox1.Clear();
        }

        private void LoadListFormat()
        {
            this.listBox1.Items.Clear();
            realFormatList = formatBusinessLogic.Get();
            foreach (Format format in realFormatList)
            {
                this.listBox1.Items.Add(format.Name);
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void LoadListStyleClass()
        {
            this.listBox2.Items.Clear();
            realStyleClassList = styleClassBusinessLogic.Get();
            foreach (StyleClass styleClass in realStyleClassList)
            {
                this.listBox2.Items.Add(styleClass.Name);
            }
            if (listBox2.Items.Count > 0)
            {
                listBox2.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indexFormat = listBox1.SelectedIndex;
            Guid formatId = realFormatList.ElementAt(indexFormat).Id;
            formatBusinessLogic.Delete(formatId);
            MessageBox.Show("Formato eliminado");
            Refresh();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indexFormat = listBox1.SelectedIndex;
            int indexStyleClass = listBox2.SelectedIndex;
            Guid formatId = realFormatList.ElementAt(indexFormat).Id;
            StyleClass styleClass = realStyleClassList.ElementAt(indexStyleClass);
            try
            {
                formatBusinessLogic.AddStyle(formatId, styleClass);
                MessageBox.Show("Clase de estilo agregada");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormatForm_Load(object sender, EventArgs e)
        {

        }
    }
}
