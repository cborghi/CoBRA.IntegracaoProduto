using CoBRA.IntegracaoProduto.WS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoBRA.IntegracaoProduto.WS.BIS
{
    public class IntegradorBIS
    {
        private IntegradorDAL _dal;
        public void IntegrarProdutosBIS()
        {
            try
            {
                _dal = new IntegradorDAL();
                _dal.IntegrarProdutosDAL();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
