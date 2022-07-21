using System.Collections.Generic;

namespace WebForm.Utils
{
    public static class Utilidades
    {
        public static Dictionary<string, string> RetornaDicionarioOrgaoExpedicao()
        {
            return new Dictionary<string, string>
            {
               {"" , ""},
               {"SSP" , "Secretaria de Segurança Pública"},
               {"SJC" , "Secretaria de Justiça e Cidadania"},
               {"SJT" ,"Secretaria de Justiça e Trabalho"},
               {"CC" ,  "Cartório Civil"},
               {"PIPC" , "Postos de Identificação da Polícia Civil"}
            };
        }

        public static Dictionary<string, string> RetornaDicionarioUf()
        {
            return new Dictionary<string, string>
            {
                {"" , ""},
                {"RO","RO"},
                {"AC","AC"},
                {"AM","AM"},
                {"RR","RR"},
                {"PA","PA"},
                {"AP","AP"},
                {"TO","TO"},
                {"MA","MA"},
                {"PI","PI"},
                {"CE","CE"},
                {"RN","RN"},
                {"PB","PB"},
                {"PE","PE"},
                {"AL","AL"},
                {"SE","SE"},
                {"BA","BA"},
                {"MG","MG"},
                {"ES","ES"},
                {"RJ","RJ"},
                {"SP","SP"},
                {"PR","PR"},
                {"SC","SC"},
                {"RS","RS"},
                {"MS","MS"},
                {"MT","MT"},
                {"GO","GO"},
                {"DF","DF"},
            };
        }

        public static Dictionary<string, string> RetornaDicionarioGenero()
        {
            return new Dictionary<string, string>
            {
                {"" , ""},
                { "Masculino", "Masculino"},
                { "Feminino", "Feminino"},
                { "Não Informar", "Não Informar"}
            };
        }

        public static Dictionary<string, string> RetornaDicionarioEstadoCivil()
        {
            return new Dictionary<string, string>
            {
                {"" , ""},
                { "Solteiro", "Solteiro"},
                { "Casado", "Casado"},
                { "Divorciado", "Divorciado"},
            };
        }
    }
}