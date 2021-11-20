using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscalculiaHelper
{
    class Questao
    {
        List<string> opcoes;
        int gabarito_idx;
        Dictionary<Lingua.Idioma, string> lingua_pergunta;
        Bitmap imagem;

        //Criar um construtor de Questao
        public Questao(string pergunta_pt, string pergunta_en, Bitmap imagem, List<string> opcoes, int gabarito_idx) {
            this.imagem = imagem;
            this.opcoes = opcoes;
            this.gabarito_idx = gabarito_idx;
            lingua_pergunta = new Dictionary<Lingua.Idioma, string>() { {Lingua.Idioma.PORTUGUES , pergunta_pt} , {Lingua.Idioma.INGLES , pergunta_en} };   
        }
        //Criar Get dos atributos de Questao
        public Bitmap GetImagem()
        {
            return imagem;
        }

        public string GetPergunta(Lingua.Idioma idioma)
        {
            return lingua_pergunta[idioma];
        }

        public bool Gabarito(int resposta_idx)
        {
            return resposta_idx == gabarito_idx;
        }

        public List<string> GetOpcoes()
        {
            return opcoes;
        }
    }
}
