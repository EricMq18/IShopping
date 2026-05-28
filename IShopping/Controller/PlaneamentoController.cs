using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    // O Carteiro específico para a grelha de Planeamento
    public class CompraPlaneamentoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Alteracao { get; set; } // Pode ser nulo se nunca foi alterada
        public string Criador { get; set; }
    }

    public class PlaneamentoController
    {
        // Este método recebe o texto da ComboBox e devolve a lista já filtrada!
        public List<CompraPlaneamentoDTO> ObterListaCompras(string filtro)
        {
            using (var context = new ShoppingContext())
            {
                var query = context.compras.Include(c => c.userCriador).AsQueryable();

                if (!string.IsNullOrEmpty(filtro))
                {
                    if (filtro == "Abertas")
                    {
                        query = query.Where(c => c.estado == Estado.aberto);
                    }
                    else if (filtro == "Fechadas")
                    {
                        query = query.Where(c => c.estado == Estado.fechado);
                    }
                }

                return query.Select(c => new CompraPlaneamentoDTO
                {
                    ID = c.id,
                    Nome = c.nome,
                    Estado = c.estado.ToString(),
                    Data_Criacao = c.dataCriacao,
                    Data_Alteracao = c.DataAlteracao,
                    Criador = c.userCriador != null ? c.userCriador.username : "Desconhecido"
                }).ToList();
            }
        }
    }
}