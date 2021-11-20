using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscalculiaHelper
{
    class Aluno
    {
        public static string nome;
        public static int idade;
        public static float media_memoria;
        public static float media_raciocinio;
        public static float media_estimativa;
        public static float media_espacial;
        //criar uma variavel tipo lista com respostas do aluno 
        public static List<int> respostas_idx = new List<int>();

        public static void AdicionarResposta(int resposta_idx)
        {
            respostas_idx.Add(resposta_idx);
        }
        public static float VerificarGabarito(Prova prova)
        {
            int i = 0;
            int acertos = 0;
            foreach (int resposta_idx in respostas_idx)
            {
                if(prova.GetQuestoes()[i].Gabarito(resposta_idx))
                {
                    acertos++;
                }
                i++;
            }
            return (float)acertos / (float)i;
        }
        public static void LimparGabarito()
        {
            respostas_idx.Clear();
        }
    }
}
