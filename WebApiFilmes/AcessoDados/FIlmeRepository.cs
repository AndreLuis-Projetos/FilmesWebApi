using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFilmes.Models;

namespace WebApiFilmes.AcessoDados
{
    public static  class FIlmeRepository 
    {
        
        private static  List<Filme> listaFilme; 
         
        
        static FIlmeRepository()
        {
            listaFilme = new List<Filme>()
            {
                new Filme() { Id = 1, Nome="Matrix", Descricao="Um jovem programador é atormentado por estranhos pesadelos nos quais sempre está conectado por cabos a um imenso sistema de computadores do futuro. ", AnoLancamento=new DateTime(1999 ,05 ,21), AvaliarFilme=9 },
                new Filme() { Id = 2, Nome = "O senhor dos Aneis: A sociedade do anel", Descricao = "Um hobbit recebe de presente de seu tio um anel mágico e maligno que precisa ser destruído antes que caia nas mãos do mal, pois o futuro da civilização depende do destino desse ane", AnoLancamento = new DateTime(2002,01,01), AvaliarFilme=8 },
                new Filme() { Id = 3, Nome = "batman begins", Descricao = "O jovem Bruce Wayne viaja para o Extremo Oriente, onde recebe treinamento em artes marciais do mestre Henri Ducard", AnoLancamento = new DateTime(2005,06 ,17), AvaliarFilme=9 }

            };

        }
        
        public static void Deletar(int id)
        {
           
            listaFilme.RemoveAll(f => f.Id == id);
        }

        public static  List<Filme> ListarFilmes()
        {
             return listaFilme.ToList(); 
        }

        public static Filme ObterFilmePorId(int id)
        {
            return listaFilme.FirstOrDefault(f => f.Id == id);   
        }

        public static Filme ObterFilmePorNome(string nome)
        {
            return listaFilme.FirstOrDefault(f => f.Nome.Contains(nome));  
        }

        public static void Alterar(Filme filme)
        {
            var alterarFilme = listaFilme.Find(f=> f.Id==filme.Id);
            alterarFilme.Nome = filme.Nome;
            alterarFilme.Descricao = filme.Descricao;
            alterarFilme.AvaliarFilme = filme.AvaliarFilme;
            alterarFilme.AnoLancamento = filme.AnoLancamento; 


        }

        public static void Salvar(Filme filme)
        {
            filme.Id = listaFilme.Count() + 1;

            listaFilme.Add(filme);
        }
    }
}
