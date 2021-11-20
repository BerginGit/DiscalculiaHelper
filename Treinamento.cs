using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscalculiaHelper
{
    class Treinamento
    {
        public static int prova_atual;
        public static int questao_atual = -1;
        //Lista para popular questoes nas provas de cada teste
        public static List<Prova> provas = new List<Prova>
        {
            new Prova("Memoria",new List<Questao>(){
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources.memoria_6,
                        new List<string>(){"3","4","5","6" },
                        3),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources.memoria_2,
                        new List<string>(){"2","3","4","5" },
                        0),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources.memoria_4,
                        new List<string>(){"2","3","4","5" },
                        2),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources.memoria_5,
                        new List<string>(){"2","3","4","5" },
                        3),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources._5_organizado,
                        new List<string>(){"3","4","5","6" },
                        2),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources._7_organizado,
                        new List<string>(){"6","7","8","9" },
                        1),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources._6_organizado,
                        new List<string>(){"6","7","8","9" },
                        0),
                new Questao("Quantas bolinhas apareceram?",
                        "How many dots appeared?",
                        Properties.Resources._10_organizado,
                        new List<string>(){"7","8","9","10" },
                        3)} ),
            new Prova("Raciocinio",new List<Questao>(){
                new Questao("Quanto vale a soma acima?",
                        "How much is the sum above?",
                        Properties.Resources.Raciocinio_100_num,
                        new List<string>(){ "1010", "500", "100", "5050" },
                        2),
                new Questao("Se quatro mais quatro igual a oito," +
                        "quanto seria quarenta mais quarenta?",
                        "If four plus four equals eight," +
                        "how much would be fourty plus fourty?",
                        Properties.Resources.vazio,
                        new List<string>(){ "4040", "80", "400", "88" },
                        1),
                new Questao("Se quatro mais quatro igual a oito," +
                        "quanto seria quarenta mais quarenta?",
                        "If four plus four equals eight," +
                        "how much would be fourty plus fourty?",
                        Properties.Resources.vazio,
                        new List<string>(){ "500", "100", "5050", "1010" },
                        1),
                new Questao("Quanto vale a soma acima?",
                        "How much is the sum above?",
                        Properties.Resources.Raciocinio_80_num,
                        new List<string>(){ "80", "4040", "88", "400" },
                        0)} ),
            new Prova("Estimativa",new List<Questao>(){
                new Questao("Qual numero abaixo esta mais proximo do numero 170?",
                        "What number below is closest to 170?",
                        Properties.Resources.vazio,
                        new List<string>(){ "0", "100", "200", "300" },
                        2),
                new Questao("Qual numero abaixo esta mais proximo do numero 730?",
                        "What number below is closest to 730?",
                        Properties.Resources.vazio,
                        new List<string>(){ "500", "600", "700", "800" },
                        2),
                new Questao("Qual numero abaixo esta mais proximo do numero 580?",
                        "What number below is closest to 580?",
                        Properties.Resources.vazio,
                        new List<string>(){ "300", "400", "500", "600" },
                        3),
                new Questao("Qual numero abaixo esta mais proximo do numero 390?",
                        "What number below is closest to 390?",
                        Properties.Resources.vazio,
                        new List<string>(){ "300", "400", "500", "600" },
                        1),
                new Questao("Qual numero abaixo esta mais proximo do numero 970?",
                        "What number below is closest to 970?",
                        Properties.Resources.vazio,
                        new List<string>(){ "700", "800", "900", "1000" },
                        3),
                new Questao("Qual numero abaixo esta mais proximo do numero 40?",
                        "What number below is closest to 40?",
                        Properties.Resources.vazio,
                        new List<string>(){ "0", "100", "200", "300" },
                        0),
                new Questao("Qual numero abaixo esta mais proximo do numero 240?",
                        "What number below is closest to 240?",
                        Properties.Resources.vazio,
                        new List<string>(){ "200", "250", "300", "350" },
                        1),
                new Questao("Qual numero abaixo esta mais proximo do numero 540?",
                        "What number below is closest to 540?",
                        Properties.Resources.vazio,
                        new List<string>(){ "400", "450", "500", "550" },
                        3),
                new Questao("Qual numero abaixo esta mais proximo do numero 180?",
                        "What number below is closest to 180?",
                        Properties.Resources.vazio,
                        new List<string>(){ "150", "200", "250", "300" },
                        1),
                new Questao("Qual numero abaixo esta mais proximo do numero 940?",
                        "What number below is closest to 390?",
                        Properties.Resources.vazio,
                        new List<string>(){ "900", "950", "1000", "1050" },
                        0)} ),
            new Prova("Espacial",new List<Questao>(){
                new Questao("Onde ficaria o numero 2 na linha acima?",
                        "Where should the number 2 be on the line above?",
                        Properties.Resources.estimativa_coracao,
                        new List<string>(){ "♥", "♣", "♦", "♠" },
                        0),
                new Questao("Onde ficaria o numero 6 na linha acima?",
                        "Where should the number 6 be on the line above?",
                        Properties.Resources.estimativa_coracao,
                        new List<string>(){ "♥", "♣", "♦", "♠" },
                        2),
                new Questao("Onde ficaria o numero 9 na linha acima?",
                        "Where should the number 9 be on the line above?",
                        Properties.Resources.estimativa_coracao,
                        new List<string>(){ "♥", "♣", "♦", "♠" },
                        3),
                new Questao("Onde ficaria o numero 4 na linha acima?",
                        "Where should the number 4 be on the line above?",
                        Properties.Resources.estimativa_coracao,
                        new List<string>(){ "♥", "♣", "♦", "♠" },
                        1)}
            )
        };
        public static Questao ProxQuestao()
        {
            questao_atual++;
            if (questao_atual < provas[prova_atual].GetQuestoes().Count)
            {
                return provas[prova_atual].GetQuestoes()[questao_atual];
            }
            else
            {
                questao_atual = -1;
                return null;
            }
        }
    }
}
