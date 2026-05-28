using IShopping.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    public class EstatisticasController
    {
        // Requisito 21.a
        public object ObterEstatisticasOrcamentos()
        {
            using (var context = new ShoppingContext())
            {
                var orcamentos = context.orcamentos.ToList();

                return orcamentos.Select(o => {
                    decimal totalGasto = context.itemCompras
                        .Where(i => i.compra.dataCriacao.Month == o.mes.Month && i.compra.dataCriacao.Year == o.mes.Year)
                        .Sum(i => (decimal?)(i.quantidadeAdquirida * i.precoUnitario)) ?? 0;

                    return new
                    {
                        Mês = o.mes.ToString("MM/yyyy"),
                        Orçamento_Máximo = o.valor_max,
                        Total_Gasto = totalGasto,
                        Diferença = o.valor_max - totalGasto
                    };
                }).ToList();
            }
        }

        // Requisito 21.b
        public object ObterEstatisticasComprasFechadas()
        {
            using (var context = new ShoppingContext())
            {
                var comprasFechadas = context.compras
                    .Include(c => c.listaCompra)
                    .Where(c => c.estado == Estado.fechado).ToList();

                return comprasFechadas.Select(c => {
                    int totalItens = c.listaCompra.Sum(i => i.quantidadeAdquirida);

                    // SOLUÇÃO: Usamos o OfType<> para filtrar as classes derivadas criadas pelo Erick!
                    int previstos = c.listaCompra.OfType<ArtigoPrevisto>().Sum(i => i.quantidadeAdquirida);
                    int naoPrevistos = c.listaCompra.OfType<ArtigoNaoPrevisto>().Sum(i => i.quantidadeAdquirida);

                    return new
                    {
                        Lista_de_Compras = c.nome,
                        Data_Fecho = c.dataFechar,
                        Artigos_Previstos = totalItens > 0 ? (previstos * 100.0 / totalItens).ToString("0.00") + "%" : "0%",
                        Artigos_Nao_Previstos = totalItens > 0 ? (naoPrevistos * 100.0 / totalItens).ToString("0.00") + "%" : "0%"
                    };
                }).ToList();
            }
        }

        // Requisito 21.c (Parte 1: Sugestão de Orçamento)
        public decimal CalcularOrcamentoSugerido()
        {
            using (var context = new ShoppingContext())
            {
                var orcamentosAnteriores = context.orcamentos
                    .Where(o => o.mes < DateTime.Now)
                    .Select(o => o.valor_max).ToList();

                if (orcamentosAnteriores.Any())
                {
                    return orcamentosAnteriores.Average();
                }
                return 250.00m; // Orçamento padrão se não houver histórico
            }
        }

        // Requisito 21.c (Parte 2: Sugestão de Compras baseada na semana do mês)
        public object GerarListaSugestaoSemanal()
        {
            // Determinar a semana atual (1ª, 2ª, 3ª ou 4ª)
            int diaAtual = DateTime.Now.Day;
            int semanaAtual = ((diaAtual - 1) / 7) + 1;

            using (var context = new ShoppingContext())
            {
                var itensSugeridos = context.itemCompras
                    .Include(i => i.artigo)
                    .Include(i => i.compra)
                    .ToList() // Trazemos para memória para usar a lógica de semanas em C#
                    .Where(i => i.compra != null
                             && i.compra.dataCriacao.Month != DateTime.Now.Month
                             && (((i.compra.dataCriacao.Day - 1) / 7) + 1) == semanaAtual)
                    .GroupBy(i => i.artigo.Nome)
                    .Select(g => new {
                        Artigo_Sugerido = g.Key,
                        Frequencia_de_Compra_nesta_Semana = g.Count()
                    })
                    .OrderByDescending(g => g.Frequencia_de_Compra_nesta_Semana)
                    .ToList();

                return itensSugeridos;
            }
        }
    }
}