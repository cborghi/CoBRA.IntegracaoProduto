using CoBRA.IntegracaoProduto.WS.BIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoBRA.IntegracaoProduto.WS
{
    public partial class IntegrarProduto : ServiceBase
    {
        private Timer _timer;
        private IntegradorBIS _bis;

        public IntegrarProduto()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer = new Timer(Integrar, null, 0, 3600000);
        }

        protected override void OnStop()
        {

        }
        public void Integrar(object state)
        {
            try
            {
                IntegrarProdutos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IntegrarProdutos()
        {
            _bis = new IntegradorBIS();
            _bis.IntegrarProdutosBIS();
        }
    }
}
