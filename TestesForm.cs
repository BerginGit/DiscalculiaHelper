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
    public partial class TestesForm : Form
    {
        int questionNumber = 1;
        int perguntas_Tipo;
        int i_Memoria;
        int i_Raciocinio;
        int i_Estimativa;
        int i_Espacial;
        float TotalMemoria;
        float TotalRaciocinio;
        float TotalEstimativa;
        float TotalEspacial;
        public TestesForm()
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
            pictureBox1.Image = Properties.Resources.vazio;           
        }
        //Botoes de respostas
        private void BotaoResposta1_Click(object sender, EventArgs e)
        {
            string resposta = (sender as Button).Text;
            Aluno.AdicionarResposta(0);
            ResponderTraduzido();
            CalcularMedia();
        }
        private void BotaoResposta2_Click(object sender, EventArgs e)
        {
            string resposta = (sender as Button).Text;
            Aluno.AdicionarResposta(1);
            ResponderTraduzido();
            CalcularMedia();
        }
        private void BotaoResposta3_Click(object sender, EventArgs e)
        {
            string resposta = (sender as Button).Text;
            Aluno.AdicionarResposta(2);
            ResponderTraduzido();
            CalcularMedia();
        }
        private void BotaoResposta4_Click(object sender, EventArgs e)
        {
            string resposta = (sender as Button).Text;
            Aluno.AdicionarResposta(3);
            ResponderTraduzido();
            CalcularMedia();
        }

        //Metodos para esconder e mostrar
        private void EsconderBotoesTestes() 
        {
            botao_Resposta1.Visible = true;
            botao_Resposta2.Visible = true;
            botao_Resposta3.Visible = true;
            botao_Resposta4.Visible = true;
            botao_Memoria.Visible = false;
            botao_Raciocinio.Visible = false;
            botao_Estimativa.Visible = false;
            botao_Espacial.Visible = false;
            botao_Salvar.Visible = false;
            pergunta.Visible = true;
        }
        private void EsconderBotoesRespostas()
        {
            botao_Resposta1.Visible = false;
            botao_Resposta2.Visible = false;
            botao_Resposta3.Visible = false;
            botao_Resposta4.Visible = false;
            botao_Memoria.Visible = true;
            botao_Raciocinio.Visible = true;
            botao_Estimativa.Visible = true;
            botao_Espacial.Visible = true;
            botao_Salvar.Visible = true;
            pergunta.Visible = false;
        }

        //Botoes dos testes para treinamento
        private void BotaoMemoria_Click(object sender, EventArgs e)
        {
            perguntas_Tipo = 0;
            Treinamento.prova_atual = 0;
            PopularQuestao();
            EsconderBotoesTestes();
            BotaoTestesTimer(12);
        }
        private void BotaoRaciocinio_Click(object sender, EventArgs e)
        {
            perguntas_Tipo = 1;
            Treinamento.prova_atual = 1;
            PopularQuestao();
            EsconderBotoesTestes();
            BotaoTestesTimer(30);
        }
        private void BotaoEstimativa_Click(object sender, EventArgs e)
        {
            perguntas_Tipo = 2;
            Treinamento.prova_atual = 2;
            PopularQuestao();
            EsconderBotoesTestes();
            BotaoTestesTimer(30);
        }
        private void BotaoEspacial_Click(object sender, EventArgs e)
        {
            perguntas_Tipo = 3;
            Treinamento.prova_atual = 3;
            PopularQuestao();
            EsconderBotoesTestes();
            BotaoTestesTimer(60);
        }

        //Metodos populador de provas e calcular medias
        private void PopularQuestao()
        {
            var questao_atual = Treinamento.ProxQuestao();
            if (questao_atual != null)
            {
                pictureBox1.Image = questao_atual.GetImagem();
                pergunta.Text = questao_atual.GetPergunta(Lingua.idioma);
                var opcoes = questao_atual.GetOpcoes();
                botao_Resposta1.Text = opcoes[0];
                botao_Resposta2.Text = opcoes[1];
                botao_Resposta3.Text = opcoes[2];
                botao_Resposta4.Text = opcoes[3];
            }
            else
            {
                EsconderBotoesRespostas();
                timer1.Enabled = false;
                questionNumber = 1;
                progressBar1.Value = 0;
                pictureBox1.Image = Properties.Resources.vazio;
                perguntas_Tipo = 0;
            }
        }
        private void CalcularMedia()
        {
            questionNumber++;
            if (questionNumber > Treinamento.provas[perguntas_Tipo].GetQuestoes().Count)
            {
                EsconderBotoesRespostas();
                timer1.Enabled = false;
                questionNumber = 1;
                progressBar1.Value = 0;
                pictureBox1.Image = Properties.Resources.vazio;
                float media = Aluno.VerificarGabarito(Treinamento.provas[Treinamento.prova_atual]) * 100;
                switch (perguntas_Tipo)
                {
                    case 0:
                        TotalMemoria = TotalMemoria + media;
                        i_Memoria++;
                        break;
                    case 1:
                        TotalRaciocinio = TotalRaciocinio + media;
                        i_Raciocinio++;
                        break;
                    case 2:
                        TotalEstimativa = TotalEstimativa + media;
                        i_Estimativa++;
                        break;
                    case 3:
                        TotalEspacial = TotalEspacial + media;
                        i_Espacial++;
                        break;
                }
                Aluno.LimparGabarito();
            }
            progressBar1.Value = 0;
            PopularQuestao();
        }

        //Metodos para contagem e mecanicas do timer
        private void BotaoTestesTimer(int max)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;
            timer1.Tick += new EventHandler(Timer1_Tick);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                if (progressBar1.Value > 3 && perguntas_Tipo == 0)
                {
                    pictureBox1.Image = Properties.Resources.vazio;
                }
            }
            else
            {
                timer1.Enabled = false;
                if (Lingua.idioma == 0)
                {
                    MessageBox.Show("Acabou o tempo!");
                }
                else
                {
                    MessageBox.Show("Time's up!");
                }
                timer1.Enabled = true;
                Aluno.AdicionarResposta(-1);
                CalcularMedia();
            }
        }

        //Metodos para salvar, traduzir e fechar o applicativo
        private void BotaoSalvar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Aluno.media_memoria = TotalMemoria / i_Memoria;
            Aluno.media_raciocinio = TotalRaciocinio / i_Raciocinio;
            Aluno.media_estimativa = TotalEstimativa / i_Estimativa;
            Aluno.media_espacial = TotalEspacial / i_Espacial;           
            //criacao da conexao ao banco
            string connection = @"Data Source=|DataDirectory|\Aluno.sdf";
            SqlCeConnection cn = new SqlCeConnection(connection);
            try
            {
                cn.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
            SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Aluno(Nome, Idade, MediaMemoria, MediaRaciocinio, MediaEstimativa, MediaEspacial)" +
                "VALUES(@nome, @idade, @mediaMemoria, @mediaRaciocinio, @mediaEstimativa, @mediaEspacial)", cn);
            cmd.Parameters.AddWithValue("@nome", Aluno.nome);
            cmd.Parameters.AddWithValue("@idade", Aluno.idade);
            cmd.Parameters.AddWithValue("@mediaMemoria", Aluno.media_memoria);
            cmd.Parameters.AddWithValue("@mediaRaciocinio", Aluno.media_raciocinio);
            cmd.Parameters.AddWithValue("@mediaEstimativa", Aluno.media_estimativa);
            cmd.Parameters.AddWithValue("@mediaEspacial", Aluno.media_espacial);
            try
            {
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    if (Lingua.idioma == 0)
                    {
                        MessageBox.Show("Client: " + " adicionado ao banco de dados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Client: " + " added to database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                else
                {
                    if (Lingua.idioma == 0)
                    {
                        MessageBox.Show("Client: " + " Falha ao adionar ao banco de dados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Client: " + " Failed to add to database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SalvarForm myForm = new SalvarForm();
            myForm.Show();
        }
        private void ResponderTraduzido()
        {
            timer1.Enabled = false;
            if (Lingua.idioma == 0)
            {
                MessageBox.Show("Respondido");
            }
            else
            {
                MessageBox.Show("Answered");
            }
            timer1.Enabled = true;
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
        private void TestesForm_FormClosing(object sender, FormClosingEventArgs e)
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
