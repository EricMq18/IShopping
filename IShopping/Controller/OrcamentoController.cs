using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IShopping.Controller
{
    public class OrcamentoController
    {
        // Ler dados para a ListBox (Formatado como "Mês/Ano - Valor€")
        public object ObterOrcamentosParaLista()
        {
            using (var db = new ShoppingContext())
            {
                var orcamentos = db.orcamentos.ToList();

                // Criamos um texto amigável para mostrar na lista
                return orcamentos.Select(o => new
                {
                    o.Id,
                    DisplayText = o.Mes.ToString("MM/yyyy") + " - " + o.ValorMax.ToString("C2") // Formato de moeda
                }).ToList();
            }
        }

        // Obter detalhes de um orçamento para preencher o formulário
        public Orcamento ObterOrcamentoPorId(int id)
        {
            using (var db = new ShoppingContext())
            {
                return db.orcamentos.FirstOrDefault(o => o.Id == id);
            }
        }

        // Criar
        public void AdicionarOrcamento(DateTime mes, decimal valorMax)
        {
            using (var db = new ShoppingContext())
            {
                db.orcamentos.Add(new Orcamento { Mes = mes, ValorMax = valorMax });
                db.SaveChanges();
            }
        }

        // Atualizar
        public void AtualizarOrcamento(int id, DateTime novoMes, decimal novoValorMax)
        {
            using (var db = new ShoppingContext())
            {
                var orcamento = db.orcamentos.FirstOrDefault(o => o.Id == id);
                if (orcamento != null)
                {
                    orcamento.Mes = novoMes;
                    orcamento.ValorMax = novoValorMax;
                    db.SaveChanges();
                }
            }
        }

        // Eliminar
        public void EliminarOrcamento(int id)
        {
            using (var db = new ShoppingContext())
            {
                var orcamento = db.orcamentos.FirstOrDefault(o => o.Id == id);
                if (orcamento != null)
                {
                    db.orcamentos.Remove(orcamento);
                    db.SaveChanges();
                }
            }
        }
    }
}
