using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IShopping.Controller
{
    public class OrcamentoController
    {
        public List<string> ObterAnosComOrcamentos()
        {
            using (var db = new ShoppingContext())
            {
                // O Entity Framework traduz isto para SQL perfeito (SELECT DISTINCT YEAR(mes))
                return db.orcamentos
                         .Select(o => o.mes.Year)
                         .Distinct()
                         .OrderByDescending(ano => ano) // Anos mais recentes primeiro
                         .Select(ano => ano.ToString())
                         .ToList();
            }
        }
        // Ler dados para a ListBox (Formatado como "Mês/Ano - Valor€")
        public object ObterOrcamentosParaLista(string anoFiltro = "Todos")
        {
            using (var db = new ShoppingContext())
            {
                var orcamentos = db.orcamentos.ToList();

                // Se o filtro não for "Todos", filtramos apenas os que correspondem ao ano escolhido
                if (anoFiltro != "Todos" && !string.IsNullOrWhiteSpace(anoFiltro))
                {
                    orcamentos = orcamentos.Where(o => o.mes.Year.ToString() == anoFiltro).ToList();
                }

                var listaFormatada = orcamentos.Select(o => new
                {
                    o.id,
                    DisplayText = o.mes.ToString("MM/yyyy") + " - " + o.valor_max.ToString("C2")
                });

                return listaFormatada.ToList();
            }
        }

        // Obter detalhes de um orçamento para preencher o formulário
        public orcamento ObterOrcamentoPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                // O Include obriga a BD a trazer também os dados do userCriador e userAlterador
                return db.orcamentos
                         .Include(o => o.userCriador)
                         .Include(o => o.userAlterador)
                         .FirstOrDefault(o => o.id == id);
            }
        }

        // Criar
        public void AdicionarOrcamento(DateTime mes, decimal valorMax, int userId)
        {
            using (var db = new ShoppingContext())
            {
                var userLogado = db.users.FirstOrDefault(u => u.id == userId);

                db.orcamentos.Add(new orcamento
                {
                    mes = mes,
                    valor_max = valorMax,
                    userCriador = userLogado
                });

                db.SaveChanges();
            }
        }

        // Atualizar
        public void AtualizarOrcamento(int id, DateTime novoMes, decimal novoValorMax, int userId)
        {
            using (var db = new ShoppingContext())
            {
                var orcamento = db.orcamentos.FirstOrDefault(o => o.id == id);
                var userLogado = db.users.FirstOrDefault(u => u.id == userId);

                if (orcamento != null)
                {
                    orcamento.mes = novoMes;
                    orcamento.valor_max = novoValorMax;
                    orcamento.userAlterador = userLogado;
                    db.SaveChanges();
                }
            }
        }

        // Eliminar
        public void EliminarOrcamento(int id)
        {
            using (var db = new ShoppingContext())
            {
                var orcamento = db.orcamentos.FirstOrDefault(o => o.id == id);
                if (orcamento != null)
                {
                    db.orcamentos.Remove(orcamento);
                    db.SaveChanges();
                }
            }
        }
    }
}
