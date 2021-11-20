using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace DiscalculiaHelper
{
    public partial class SalvarForm : Form
    {
        public SalvarForm()
        {
            switch (Lingua.idioma)
            {
                case Lingua.Idioma.PORTUGUES:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
                    break;
                case Lingua.Idioma.INGLES:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();

            //Mecanica para puxar os dados do aluno
            var select = "SELECT * FROM Aluno";

            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //String para conexao
            var c = new SqlCeConnection(@"Data Source=|DataDirectory|\Aluno.sdf");
            var dataAdapter = new SqlCeDataAdapter(select, c);

            var commandBuilder = new SqlCeCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void BotaoExportarCSV_Click(object sender, EventArgs e)
        {           
            // Cria uma aplicacao excel para poder transformar em CSV 
            Microsoft.Office.Interop.Excel._Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet xlWorkSheet = null;               
            xlWorkSheet = xlWorkBook.ActiveSheet;
            xlWorkSheet.Name = "Aluno";
            try
            {
                //Puxar dados do DataGrid
                for (int i = 1; i < dataGridView1.Columns.Count+1; i++)
                {
                    //Popular as colunas na planilha excel
                    xlWorkSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                //Exportar linhas e colunas
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    for (int k = 0; k < dataGridView1.ColumnCount; k++)
                    {
                        //Popular as linhas na planilha excel
                        xlWorkSheet.Cells[j + 2, k + 1] = dataGridView1.Rows[j].Cells[k].Value.ToString();
                    }
                }
                //Mecanica para salvar arquivo como csv
                var saveFileDialoge = new SaveFileDialog();
                saveFileDialoge.FileName = "Aluno";
                saveFileDialoge.DefaultExt = ".csv";
                if (saveFileDialoge.ShowDialog() == DialogResult.OK)
                {
                    xlWorkBook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                ResponderTraduzido("Arquivo CSV Salvo!", "CSV File Saved!");
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                  
            }          
        }
        private void DeletarCelula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int AlunoId= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
            bool result = PerguntarTraduzido("Você deseja deletar?", "Deletar Aluno", "Do you want to delete?", "Delete Student");
            if (result)
            {
                //estabelecer conexao ao banco para deletar
                string connection = @"Data Source=|DataDirectory|\Aluno.sdf";
                SqlCeConnection cn = new SqlCeConnection(connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    cn.Open();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
                // Criar o comando de deletar.
                SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Aluno WHERE Id = @Id", cn);
                // Adicionar os parametros ao comando.
                cmd.Parameters.AddWithValue("@Id", AlunoId);
                cmd.ExecuteNonQuery();
                var select = "SELECT * FROM Aluno";
                var c = new SqlCeConnection(@"Data Source=|DataDirectory|\Aluno.sdf"); // Your Connection String here
                var dataAdapter = new SqlCeDataAdapter(select, c);
                var commandBuilder = new SqlCeCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {                
            }
        }
        private void ResponderTraduzido(string portugues, string ingles)
        {
            if (Lingua.idioma == 0)
            {
                MessageBox.Show("", portugues);
            }
            else
            {
                MessageBox.Show("", ingles);
            }
        }
        private bool PerguntarTraduzido(string portugues, string portuguesBoxnome, string ingles, string inglesBoxnome)
        {
            bool ativador = false;
            if (Lingua.idioma == 0)
            {
                DialogResult result = MessageBox.Show(portugues, portuguesBoxnome, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ativador = true;
                }
                else
                {
                    ativador = false;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(ingles, inglesBoxnome, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ativador = true;
                }
                else
                {
                    ativador = false;
                }
            }
            return ativador;
        }
        private void SalvarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PerguntarTraduzido("Você deseja sair?", "Fechar Aplicativo", "Do you want to exit?", "Close App"))
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
