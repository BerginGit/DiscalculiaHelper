
namespace DiscalculiaHelper
{
    partial class TestesForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestesForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pergunta = new System.Windows.Forms.Label();
            this.botao_Resposta1 = new System.Windows.Forms.Button();
            this.botao_Resposta2 = new System.Windows.Forms.Button();
            this.botao_Resposta3 = new System.Windows.Forms.Button();
            this.botao_Resposta4 = new System.Windows.Forms.Button();
            this.botao_Memoria = new System.Windows.Forms.Button();
            this.botao_Raciocinio = new System.Windows.Forms.Button();
            this.botao_Estimativa = new System.Windows.Forms.Button();
            this.botao_Espacial = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.botao_Salvar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // pergunta
            // 
            resources.ApplyResources(this.pergunta, "pergunta");
            this.pergunta.Name = "pergunta";
            this.pergunta.Tag = "";
            // 
            // botao_Resposta1
            // 
            resources.ApplyResources(this.botao_Resposta1, "botao_Resposta1");
            this.botao_Resposta1.Name = "botao_Resposta1";
            this.botao_Resposta1.UseVisualStyleBackColor = true;
            this.botao_Resposta1.Click += new System.EventHandler(this.BotaoResposta1_Click);
            // 
            // botao_Resposta2
            // 
            resources.ApplyResources(this.botao_Resposta2, "botao_Resposta2");
            this.botao_Resposta2.Name = "botao_Resposta2";
            this.botao_Resposta2.UseVisualStyleBackColor = true;
            this.botao_Resposta2.Click += new System.EventHandler(this.BotaoResposta2_Click);
            // 
            // botao_Resposta3
            // 
            resources.ApplyResources(this.botao_Resposta3, "botao_Resposta3");
            this.botao_Resposta3.Name = "botao_Resposta3";
            this.botao_Resposta3.UseVisualStyleBackColor = true;
            this.botao_Resposta3.Click += new System.EventHandler(this.BotaoResposta3_Click);
            // 
            // botao_Resposta4
            // 
            resources.ApplyResources(this.botao_Resposta4, "botao_Resposta4");
            this.botao_Resposta4.Name = "botao_Resposta4";
            this.botao_Resposta4.UseVisualStyleBackColor = true;
            this.botao_Resposta4.Click += new System.EventHandler(this.BotaoResposta4_Click);
            // 
            // botao_Memoria
            // 
            resources.ApplyResources(this.botao_Memoria, "botao_Memoria");
            this.botao_Memoria.Name = "botao_Memoria";
            this.botao_Memoria.UseVisualStyleBackColor = true;
            this.botao_Memoria.Click += new System.EventHandler(this.BotaoMemoria_Click);
            // 
            // botao_Raciocinio
            // 
            resources.ApplyResources(this.botao_Raciocinio, "botao_Raciocinio");
            this.botao_Raciocinio.Name = "botao_Raciocinio";
            this.botao_Raciocinio.UseVisualStyleBackColor = true;
            this.botao_Raciocinio.Click += new System.EventHandler(this.BotaoRaciocinio_Click);
            // 
            // botao_Estimativa
            // 
            resources.ApplyResources(this.botao_Estimativa, "botao_Estimativa");
            this.botao_Estimativa.Name = "botao_Estimativa";
            this.botao_Estimativa.UseVisualStyleBackColor = true;
            this.botao_Estimativa.Click += new System.EventHandler(this.BotaoEstimativa_Click);
            // 
            // botao_Espacial
            // 
            resources.ApplyResources(this.botao_Espacial, "botao_Espacial");
            this.botao_Espacial.Name = "botao_Espacial";
            this.botao_Espacial.UseVisualStyleBackColor = true;
            this.botao_Espacial.Click += new System.EventHandler(this.BotaoEspacial_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // botao_Salvar
            // 
            resources.ApplyResources(this.botao_Salvar, "botao_Salvar");
            this.botao_Salvar.Name = "botao_Salvar";
            this.botao_Salvar.UseVisualStyleBackColor = true;
            this.botao_Salvar.Click += new System.EventHandler(this.BotaoSalvar_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.botao_Salvar);
            this.Controls.Add(this.botao_Espacial);
            this.Controls.Add(this.botao_Estimativa);
            this.Controls.Add(this.botao_Raciocinio);
            this.Controls.Add(this.botao_Memoria);
            this.Controls.Add(this.botao_Resposta4);
            this.Controls.Add(this.botao_Resposta3);
            this.Controls.Add(this.botao_Resposta2);
            this.Controls.Add(this.botao_Resposta1);
            this.Controls.Add(this.pergunta);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label pergunta;
        private System.Windows.Forms.Button botao_Resposta1;
        private System.Windows.Forms.Button botao_Resposta2;
        private System.Windows.Forms.Button botao_Resposta3;
        private System.Windows.Forms.Button botao_Resposta4;
        private System.Windows.Forms.Button botao_Memoria;
        private System.Windows.Forms.Button botao_Raciocinio;
        private System.Windows.Forms.Button botao_Estimativa;
        private System.Windows.Forms.Button botao_Espacial;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button botao_Salvar;
    }
}

