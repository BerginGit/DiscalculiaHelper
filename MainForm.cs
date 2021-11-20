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

namespace DiscalculiaHelper
{
    
    public partial class MainForm : Form
    {
        public int pass;

        public MainForm()
        {
            
            this.Controls.Clear();
            InitializeComponent();
            
        }

        private void BotaoContinue_Click(object sender, EventArgs e)
        {
            Aluno.nome = textBox1.Text;
            Aluno.idade = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            pass = 1;
            TestesForm myForm = new TestesForm();
            this.Hide();
            myForm.Show();

        }

        private void SelecionarLingua_ComboBox1(object sender, EventArgs e)
        {
            Lingua.idioma = (Lingua.Idioma)comboBox1.SelectedIndex;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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
