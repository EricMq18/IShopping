using IShopping.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IShopping.Controller
{
    public class ExportarCsvController
    {

        public ExportarCsvController() 
        {

        }

        public String CriarFicheiro(string diretorio, int UserID)
        {
            string nomeUser = "";

            using (var db = new ShoppingContext())
            {
                var user = db.users.FirstOrDefault(u => u.id == UserID);
                nomeUser = user.username;
            }

            string nomeArquivo = $"{nomeUser}_{UserID}_{DateTime.Now}.csv";
            string caminho = Path.Combine(diretorio, nomeArquivo);

            var linhas = new List<String>();

            ;

            using (var db = new ShoppingContext())
            {

                var comprasFechadas = db.compras
                    .Include(c => c.listaCompra.Select(i => i.artigo))
                    .Where(c => c.estado == Estado.fechado && c.userCriador.id == UserID)
                    .ToList();

                foreach (var compras in comprasFechadas)
                {                    
                    foreach(var item in compras.listaCompra)
                    {
                        string nomeCompra = compras.nome?.Replace(";", ",") ?? "";
                        string dataCriacao = compras.dataCriacao.ToString("dd/MM/yyyy HH:mm:ss");
                        string dataFechada = compras.dataFechar?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                        string nomeArtigo = item.artigo?.Nome?.Replace(";", ",") ?? "";
                        
                        string artigoPrevisto = item.IsPrevisto ? "Sim" : "Não";
                        string artigoNaoPrevisto = !item.IsPrevisto ? "Sim" : "Não";

                        string quantidadePrevista = item.quantidadePrevista.ToString();
                        string quantidadeAdquirida = item.quantidadeAdquirida.ToString();

                        string precoUnitario = item.precoUnitario.ToString("F2");
                        
                        string linha = $"{nomeCompra};{dataCriacao};{dataFechada};{nomeArtigo};{artigoPrevisto};{artigoNaoPrevisto};{quantidadePrevista};{quantidadeAdquirida};{precoUnitario}";
                        linhas.Add(linha);
                    }                    
                }
                File.WriteAllLines(caminho, linhas, Encoding.UTF8);
            }

            return caminho;
        }
    }
}
