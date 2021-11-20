using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscalculiaHelper
{
    class Prova
    {
        List<Questao> questoes;
        string nome;
        public Prova(string nome, List<Questao> questoes)
        {
            this.nome = nome;
            this.questoes = questoes;
        }

        public List<Questao> GetQuestoes()
        {
            return questoes;
        }
    }
}
