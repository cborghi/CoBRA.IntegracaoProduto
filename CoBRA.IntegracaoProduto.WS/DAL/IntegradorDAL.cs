using Amazon.Runtime;
using CoBRA.IntegracaoProduto.WS.DAL.Acesso;
using CoBRA.IntegracaoProduto.WS.Entidade;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoBRA.IntegracaoProduto.WS.DAL
{
    public class IntegradorDAL
    {
        public void IntegrarProdutosDAL()
        {
            var model = new EBSAEntities();
            var prod = model.PRODUTOes.Where(a => a.PROD_INTEGRADO == "naoIntegrado");

            foreach (var p in prod)
            {
                var produtoProtheus = new Produto_Protheus();
                produtoProtheus.B1_COD = Convert.ToInt32(p.PROD_ID);

                #region titulo protheus

                const int COMPRIMENTO_MAXIMO_TITULO_NORMA = 58;
                string abreviacaoSegmento = p.PROD_SEGM != 0 ? model.SEGMENTOes.Where(a => a.SEGM_ID == p.PROD_SEGM).FirstOrDefault().ABREVIACAO : ""; // _segmentoDAL.GetSegmento(produto.prod_segm).Abreviacao;
                string abreviacaoAno = model.ANO_EDUCACAO.Where(a => a.AEDU_ID == p.PROD_AEDU).FirstOrDefault().ABREVIACAO; //_anoEducacaoDAL.GetAnoEducacao(int.Parse(produto.prod_ano)).Abreviacao;
                int comprimentoTitulo = p.PROD_TITULO.Length;
                bool tituloUltrapassaComprimentoNorma = comprimentoTitulo > COMPRIMENTO_MAXIMO_TITULO_NORMA;
                string titulo = p.PROD_TITULO.Substring(0, tituloUltrapassaComprimentoNorma ? COMPRIMENTO_MAXIMO_TITULO_NORMA : comprimentoTitulo);

                string tituloProtheus = string.Concat(titulo, " ", abreviacaoSegmento, " ", abreviacaoAno, " ", p.ANO_PROGRAMA);

                produtoProtheus.B1_DESC = tituloProtheus;

                #endregion

                produtoProtheus.B1_YDISCIP = model.DISCIPLINAs.Where(a => a.DISC_ID == p.PROD_DISC).FirstOrDefault().DISC_NOME; // coDisciplina.GetDisciplina(_produtoUpdateOrInsert.prod_disc).disc_nome;
                produtoProtheus.B1_YTEMA = p.PROD_TEMA != null && p.PROD_TEMA != 0 ? model.TEMAs.Where(a => a.TEMA_ID == p.PROD_TEMA).FirstOrDefault().TEMA_DESCRICAO : null;
                produtoProtheus.B1_YMERCAD = p.PROD_MERCADO.ToString(); // _produtoUpdateOrInsert.prod_mercado.ToString();
                produtoProtheus.B1_YTIPO = p.PROD_TIPO.ToString(); // _produtoUpdateOrInsert.prod_tipo.ToString();
                produtoProtheus.B1_YSEGMEN = p.PROD_SEGM != 0 ? model.SEGMENTOes.Where(a => a.SEGM_ID == p.PROD_SEGM).FirstOrDefault().SEGM_DESCRICAO : null;
                produtoProtheus.B1_YSELO = p.PROD_SELO; // _seloProtheusDAL.BuscarSeloProtheus(produtoVM.prodSeloProtheus).Descricao;
                produtoProtheus.Grupo = model.TB_SELO_PROTHEUS.Where(a => a.DESCRICAO == p.PROD_SELO).FirstOrDefault().CHAVE_GRUPO; // _seloProtheusDAL.BuscarSeloProtheus(produtoVM.prodSeloProtheus).ChaveGrupo;

                #region assunto descricao

                string assuntos = string.Empty;
                var lstAssunto = model.PRODUTO_ASSUNTO.Where(a => a.PASS_PROD == p.PROD_ID);
                 
                foreach (var ass in lstAssunto)
                {
                    if(model.ASSUNTOes.Where(a => a.ASSU_ID == ass.PASS_ASSU).Any())
                    {
                        assuntos += $"{model.ASSUNTOes.Where(a => a.ASSU_ID == ass.PASS_ASSU).FirstOrDefault().ASSU_DESCRICAO},";
                    }
                }

                produtoProtheus.B1_YASSUNT = assuntos.Trim().Length > 0 ? assuntos.Substring(0, assuntos.Length - 1) : "";

                #endregion

                produtoProtheus.B1_YPREMIA = p.PROD_PREMIACAO;
                produtoProtheus.B1_YANO = p.PROD_AEDU != null && p.PROD_AEDU != 0 ? model.ANO_EDUCACAO.Where(a => a.AEDU_ID == p.PROD_AEDU).FirstOrDefault().AEDU_DESCRICAO : null;
                produtoProtheus.B1_YCOMPOS = p.PROD_COMP != null && p.PROD_COMP != 0 ? model.COMPOSICAOs.Where(a => a.COMP_ID == p.PROD_COMP).FirstOrDefault().COMP_DESCRICAO : null;
                produtoProtheus.B5_YTITULO = p.PROD_TITULO;
                produtoProtheus.B5_YEDICAO = Convert.ToInt32(p.PROD_EDICAO);
                if (p.PROD_MIDI == 1)
                    produtoProtheus.B5_YMIDIA = "LV";
                else if (p.PROD_MIDI == 2)
                    produtoProtheus.B5_YMIDIA = "LD";
                else if (p.PROD_MIDI == 6)
                    produtoProtheus.B5_YMIDIA = "LC";
                else
                    produtoProtheus.B5_YMIDIA = "";
                int col = !string.IsNullOrEmpty(p.PROD_COLE) ? Convert.ToInt32(p.PROD_COLE) : 0;
                produtoProtheus.B1_YCOLECA = col != 0 ? model.COLECAOs.Where(a => a.COLE_ID == col).FirstOrDefault().COLE_DESCRICAO : null;
                produtoProtheus.B1_YVERSAO = p.PROD_VERSAO.ToString();
                if(model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).Any())
                {
                    produtoProtheus.B5_YPAGINA = model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_PAGINAS != null ? Convert.ToInt32(model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_PAGINAS) : 0;
                    produtoProtheus.B1_XMAGHEI = model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_ALT != null ? (float)(model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_ALT / 10) : 0;
                    produtoProtheus.B1_XMAGWID = model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_LARG != null ? (float)(model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_LARG / 10) : 0;
                    produtoProtheus.B1_PESO = model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_PESO != null ? (float)model.TB_MIOLO_PRODUTO.Where(a => a.ID_PRODUTO == p.PROD_ID).FirstOrDefault().MIOLO_FORM_PESO : 0;
                }
                else
                {
                    produtoProtheus.B5_YPAGINA = 0;
                    produtoProtheus.B1_XMAGHEI = 0;
                    produtoProtheus.B1_XMAGWID = 0;
                    produtoProtheus.B1_PESO = 0;
                }



                produtoProtheus.B1_XMAGLEI = 0;
                produtoProtheus.B5_YPUBLIC = p.PROD_PUBLICACAO;
                produtoProtheus.B1_ISBN = p.PROD_ISBN;
                produtoProtheus.B5_YSTATUS = p.PROD_STATUS;
                produtoProtheus.B1_CODBAR = p.PROD_CODBARRAS;
                produtoProtheus.B5_YSINOPS = p.PROD_SINOPSE;
                produtoProtheus.B1_PRV1 = p.PROD_PRECO == null ? 0 : p.PROD_PRECO;
                produtoProtheus.B1_OBSISBN = "";
                produtoProtheus.B1_CONTA = "11501010001";
                produtoProtheus.Origem = p.PROD_ORIGEM.ToString();
                produtoProtheus.UnidadeMedida = model.TB_UNIDADE_MEDIDA.Where(a => a.ID_UNIDADE_MEDIDA == p.PROD_UNIDADE_MEDIDA).FirstOrDefault().SIGLA;
                produtoProtheus.TipoProduto = model.TB_TIPO_PRODUTO.Where(a => a.ID_TIPO_PRODUTO == p.PROD_TIPO_PRODUTO).FirstOrDefault().SIGLA;
                produtoProtheus.Segmento = model.TB_SEGMENTO_PROTHEUS.Where(a => a.ID_SEGMENTO == p.ID_SEGMENTO).FirstOrDefault().CODIGO_SEGMENTO;

                IntegraProtheus integraProtheus = new IntegraProtheus();
                var executarIntegracao = Task.Run(async () => await IntegrarProtheus(produtoProtheus, integraProtheus));
                executarIntegracao.Wait();
            }

            BloquearProdutosDAL();
        }

        internal async Task BloquearProdutosDAL()
        {
            var model = new EBSAEntities();
            var prod = model.PRODUTOes.Where(a => a.PROD_INTEGRADO == "deletado");

            foreach (var p in prod)
            {
                try
                {
                    int codigoProduto = Convert.ToInt32(p.PROD_ID);

                    string codigoEbsa = p.PROD_EBSA;

                    bool sucessoIntegracao = await BloquearProdutoProtheus(codigoEbsa);

                    if (!sucessoIntegracao)
                    {
                        var pu = model.PRODUTOes.Where(a => a.PROD_ID == p.PROD_ID).FirstOrDefault();
                        pu.PROD_INTEGRADO = "erro";
                        model.SaveChanges();
                    }
                    else
                    {
                        var pu = model.PRODUTOes.Where(a => a.PROD_ID == p.PROD_ID).FirstOrDefault();
                        pu.PROD_INTEGRADO = "integrado";
                        pu.PROD_DATAINTEGRACAO = DateTime.Now; 
                        model.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    GravarLog($"Erro ao excluir/bloquear Produto: Descrição: {ex.Message}");
                }
            }
        }

        private string FormatarCodigoEbsa(string codigoEbsa)
        {
            return String.Format("{0:00000000000}", Convert.ToInt64(codigoEbsa));
        }

        public async Task IntegrarProtheus(Produto_Protheus produtoIntegrar, IntegraProtheus integraProtheus)
        {
            var model = new EBSAEntities();
            string codigoEbsa = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault().PROD_EBSA; // _produtoDAL.BuscarCodigoEbsa(produtoIntegrar.B1_COD);
            codigoEbsa = FormatarCodigoEbsa(codigoEbsa);

            var client = HttpClientFactory.Create();

            List<string> resultList = new List<string>();

            var url = ConfigurationManager.AppSettings["urlBase"];
            var pathProduto2 = ConfigurationManager.AppSettings["pathProduto2"];

            string stringRequest = string.Concat(
                url,
                pathProduto2.Replace("__B1_COD__", codigoEbsa));

            #region REFATORAR URGENTE
            var request = new HttpRequestMessage(HttpMethod.Get, stringRequest);
            AdicionarAutenticacao(request);
            var response = await client.SendAsync(request);
            var _status = new JObject();

            if (response.IsSuccessStatusCode)
            {
                var _teste = response.Content.ReadAsStringAsync();
                _status = JObject.Parse(_teste.Result);
            }
            else
            {
                var prod = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault();
                prod.PROD_INTEGRADO = "erro";
                model.SaveChanges();
                GravarLog($"Erro ao buscar produto no web service Protheus EBSA: {codigoEbsa}. Resposta: {response}");
            }

            if (!string.IsNullOrEmpty(_status.ToString()))
            {
                var pathProduto3 = ConfigurationManager.AppSettings["pathProduto3"];
                stringRequest = string.Concat(
                    url,
                    pathProduto3.Replace("__JSON_PRODUTO__", Protheus(produtoIntegrar, codigoEbsa)));

                var stringNoralizadaRequest = RemoverUnicode(stringRequest);

                request = _status.ToString().Contains("Produto n")
                    ? new HttpRequestMessage(HttpMethod.Post, stringNoralizadaRequest)
                    : new HttpRequestMessage(HttpMethod.Put, stringNoralizadaRequest);

                var pr = new ProdutoJsonLog();
                pr.IdUsuario = (int)model.LOGS.Where(a => a.DESCRICAO == produtoIntegrar.B1_COD + "A" || a.DESCRICAO == produtoIntegrar.B1_COD + "S").OrderBy(a => a.DATA_LOG).FirstOrDefault().USUARIO;
                pr.ProdEbsa = codigoEbsa;
                pr.UrlJson = string.Concat("(", request.Method.ToString(), ") - ", stringNoralizadaRequest);

                InserirJsonLogIntegracaoProtheus(pr);

                AdicionarAutenticacao(request);

                response = await client.SendAsync(request);

                integraProtheus.ID_USUARIO = 3317;
                integraProtheus.ID_PRODUTO = produtoIntegrar.B1_COD;
                integraProtheus.DATA = DateTime.Now;

                var respostaProtheus = response.Content.ReadAsStringAsync();
                if (respostaProtheus.Result == "")
                {
                    _status = null;
                }
                else
                {
                    _status = JObject.Parse(respostaProtheus.Result);
                }

                if (!respostaProtheus.Result.ToString().Contains("Erro") && !respostaProtheus.Result.ToString().Contains("Falha"))
                {
                    if(_status != null)
                    {
                        integraProtheus.STATUS = (_status["msg"].ToString().Contains("Falha:") ? false : true);
                        int tamanhoMensagem = _status["msg"].ToString().Trim().Length;
                        integraProtheus.MENSAGEM = _status["msg"].ToString().Substring(0, tamanhoMensagem < 500 ? tamanhoMensagem : 500);
                    }
                    
                    var pathProduto1 = ConfigurationManager.AppSettings["pathProduto1"];
                    stringRequest = string.Concat(
                        url,
                        pathProduto1);

                    request = new HttpRequestMessage(HttpMethod.Get, stringRequest);
                    AdicionarAutenticacao(request);

                    response = await client.SendAsync(request);
                    _status = new JObject();

                    if (response.IsSuccessStatusCode)
                    {
                        respostaProtheus = response.Content.ReadAsStringAsync();
                        _status = JObject.Parse(respostaProtheus.Result);
                        produtoIntegrar.DataDePublicacao = _status["PUBLICACAO"].ToString();
                        var prod = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault();
                        integraProtheus.MENSAGEM = "Sucesso: Produto gravado";
                        prod.PROD_INTEGRADO = "integrado";
                        prod.PROD_DATAINTEGRACAO = DateTime.Now;
                        model.SaveChanges();

                    }
                    else
                    {
                        var prod = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault();
                        prod.PROD_INTEGRADO = "erro";
                        model.SaveChanges();

                        GravarLog($"Erro ao integrar produto com o Protheus. EBSA: {codigoEbsa}. Resposta: {response}");
                    }

                }
                else
                {
                    if (respostaProtheus.Result.ToString().Contains("msg:"))
                    {
                        int tamanhoMensagem = _status["msg"].ToString().Trim().Length;
                        integraProtheus.MENSAGEM = _status["msg"].ToString().Substring(0, tamanhoMensagem < 500 ? tamanhoMensagem : 500);
                        GravarLog($"Erro ao integrar produto com o Protheus Resposta: {integraProtheus.MENSAGEM}");
                        integraProtheus.STATUS = false;

                        var prod = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault();
                        prod.PROD_INTEGRADO = "erro";
                        model.SaveChanges();
                    }
                    else
                    {
                        int tamanhoMensagem = respostaProtheus.Result.Trim().Length;
                        integraProtheus.MENSAGEM = respostaProtheus.Result.Substring(0, tamanhoMensagem < 500 ? tamanhoMensagem : 500);
                        GravarLog($"Erro ao integrar produto com o Protheus Resposta: {integraProtheus.MENSAGEM}");
                        integraProtheus.STATUS = false;

                        var prod = model.PRODUTOes.Where(a => a.PROD_ID == produtoIntegrar.B1_COD).FirstOrDefault();
                        prod.PROD_INTEGRADO = "erro";
                        model.SaveChanges();
                    }


                }

                Add(integraProtheus);
            }
            #endregion REFATORAR URGENTE

        }

        private void AdicionarAutenticacao(HttpRequestMessage request)
        {
            var usuario = ConfigurationManager.AppSettings["usuario"];
            var senha = ConfigurationManager.AppSettings["senha"];

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes($"{usuario}:{senha}"));
            request.Headers.Add("Authorization", "Basic " + encoded);
        }

        public static string Protheus(Produto_Protheus produto, string codigoEbsa)
        {
            return $"\"B1_COD\":\"{codigoEbsa}\"," +
                   $"\"B1_DESC\":\"{Uri.EscapeDataString(produto.B1_DESC?.Replace("\"", string.Empty)).Trim()}\"," +
                   $"\"B1_YSELO\":\"{Uri.EscapeDataString(produto.B1_YSELO?.Replace("\"", string.Empty))}\"," +
                   $"\"B1_YDISCIP\":\"{produto.B1_YDISCIP?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YTEMA\":\"{produto.B1_YTEMA?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YMERCAD\":{Convert.ToInt32(produto.B1_YMERCAD)}," +
                   $"\"B1_YTIPO\":{Convert.ToInt32(produto.B1_YTIPO)}," +
                   $"\"B1_YSEGMEN\":\"{produto.B1_YSEGMEN?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YANO\":\"{produto.B1_YANO?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YCOMPOS\":\"{produto.B1_YCOMPOS?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YASSUNT\":\"{produto.B1_YASSUNT?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YPREMIA\":\"{produto.B1_YPREMIA?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YVERSAO\":\"{produto.B1_YVERSAO?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_YCOLECA\":\"{Uri.EscapeDataString(produto.B1_YCOLECA?.Replace("\"", string.Empty))}\"," +
                   $"\"B5_YTITULO\":\"{Uri.EscapeDataString(produto.B5_YTITULO?.Replace("\"", string.Empty))}\"," +
                   $"\"B5_YEDICAO\":{produto.B5_YEDICAO}," +
                   $"\"B5_YMIDIA\":\"{produto.B5_YMIDIA?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_UM\":\"{produto.UnidadeMedida?.Replace("\"", string.Empty)}\"," +
                   $"\"B5_YPAGINA\":{produto.B5_YPAGINA}," +
                   //$"\"B5_ALTURA\":\"{produto.B5_ALTURA}\"," +
                   $"\"B1_XMAGHEI\":\"{produto.B1_XMAGHEI}\"," +
                   $"\"B1_XMAGLEI\":\"{produto.B1_XMAGLEI}\"," +
                   $"\"B1_XMAGWID\":\"{produto.B1_XMAGWID}\"," +
                   $"\"B1_PESO\":{(produto.B1_PESO / 1000).ToString().Replace(",", ".")}," +
                   $"\"B5_YPUBLIC\":\"{produto.B5_YPUBLIC?.ToString("ddMMyyyy")}\"," +
                   $"\"B1_ISBN\":\"{produto.B1_ISBN?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_CODBAR\":\"{produto.B1_CODBAR?.Replace("\"", string.Empty)}\"," +
                   //$"\"B5_YSINOPS\":\"{System.Uri.EscapeDataString(produto.B5_YSINOPS?.Replace("\"", string.Empty).Substring(0, produto.B5_YSINOPS.Replace("\"", string.Empty).Trim().Length))}\"," +
                   $"\"B1_PRV1\":{produto.B1_PRV1.ToString()?.Replace(",", ".")}," +
                   $"\"B1_OBSISBN\":\"{produto.B1_OBSISBN?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_ORIGEM\":\"{produto.Origem?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_TIPO\":\"{produto.TipoProduto.ToString().Replace("\"", string.Empty)}\"," +
                   $"\"B1_GRUPO\":\"{produto.Grupo?.Replace("\"", string.Empty)}\"," +
                   $"\"B1_MODELO\":\"{produto.Segmento}\"," +
                   $"\"B1_CONTA\":\"{produto.B1_CONTA?.Replace("\"", string.Empty)}\"";
        }

        public static string RemoverUnicode(string texto)
        {
            texto = texto
                .Replace("–", " ")
                .Replace("%E2%80%81", "%20")
                .Replace("%E2%80%82", "%20")
                .Replace("%E2%80%83", "%20")
                .Replace("%E2%80%84", "%20")
                .Replace("%E2%80%85", "%20")
                .Replace("%E2%80%86", "%20")
                .Replace("%E2%80%87", "%20")
                .Replace("%E2%80%88", "%20")
                .Replace("%E2%80%89", "%20")
                .Replace("%E2%80%8A", "%20")
                .Replace("%E2%80%8B", "%20")
                .Replace("%E2%80%8C", "%20")
                .Replace("%E2%80%8D", "%20")
                .Replace("%E2%80%8E", "%20")
                .Replace("%E2%80%8F", "%20")
                .Replace("%E2%80%90", "%20")
                .Replace("%E2%80%91", "%20")
                .Replace("%E2%80%92", "%20")
                .Replace("%E2%80%93", "%20")
                .Replace("%E2%80%94", "%20")
                .Replace("%E2%80%95", "%20")
                .Replace("%E2%80%96", "%20")
                .Replace("%E2%80%97", "%20")
                .Replace("%E2%80%98", "%20")
                .Replace("%E2%80%99", "%20")
                .Replace("%E2%80%9A", "%20")
                .Replace("%E2%80%9B", "%20")
                .Replace("%E2%80%9C", "%20")
                .Replace("%E2%80%9D", "%20")
                .Replace("%E2%80%9E", "%20")
                .Replace("%E2%80%9F", "%20")
                .Replace("%E2%80%A0", "%20")
                .Replace("%E2%80%A1", "%20")
                .Replace("%E2%80%A2", "%20")
                .Replace("%E2%80%A3", "%20")
                .Replace("%E2%80%A4", "%20")
                .Replace("%E2%80%A5", "%20")
                .Replace("%E2%80%A6", "%20")
                .Replace("%E2%80%A7", "%20")
                .Replace("%E2%80%A8", "%20")
                .Replace("%E2%80%A9", "%20")
                .Replace("%E2%80%AA", "%20")
                .Replace("%E2%80%AB", "%20")
                .Replace("%E2%80%AC", "%20")
                .Replace("%E2%80%AD", "%20")
                .Replace("%E2%80%AE", "%20")
                .Replace("%E2%80%AF", "%20")
                .Replace("%E2%80%B0", "%20")
                .Replace("%E2%80%B1", "%20")
                .Replace("%E2%80%B2", "%20")
                .Replace("%E2%80%B3", "%20")
                .Replace("%E2%80%B4", "%20")
                .Replace("%E2%80%B5", "%20")
                .Replace("%E2%80%B6", "%20")
                .Replace("%E2%80%B7", "%20")
                .Replace("%E2%80%B8", "%20")
                .Replace("%E2%80%B9", "%20")
                .Replace("%E2%80%BA", "%20")
                .Replace("%E2%80%BB", "%20")
                .Replace("%E2%80%BC", "%20")
                .Replace("%E2%80%BD", "%20")
                .Replace("%E2%80%BE", "%20")
                .Replace("%E2%80%BF", "%20")
                .Replace("%E2%81%80", "%20")
                .Replace("%E2%81%81", "%20")
                .Replace("%E2%81%82", "%20")
                .Replace("%E2%81%83", "%20")
                .Replace("%E2%81%84", "%20")
                .Replace("%E2%81%85", "%20")
                .Replace("%E2%81%86", "%20")
                .Replace("%E2%81%87", "%20")
                .Replace("%E2%81%88", "%20")
                .Replace("%E2%81%89", "%20")
                .Replace("%E2%81%8A", "%20")
                .Replace("%E2%81%8B", "%20")
                .Replace("%E2%81%8C", "%20")
                .Replace("%E2%81%8D", "%20")
                .Replace("%E2%81%8E", "%20")
                .Replace("%E2%81%8F", "%20")
                .Replace("%E2%81%90", "%20")
                .Replace("%E2%81%91", "%20")
                .Replace("%E2%81%92", "%20")
                .Replace("%E2%81%93", "%20")
                .Replace("%E2%81%94", "%20")
                .Replace("%E2%81%95", "%20")
                .Replace("%E2%81%96", "%20")
                .Replace("%E2%81%97", "%20")
                .Replace("%E2%81%98", "%20")
                .Replace("%E2%81%99", "%20")
                .Replace("%E2%81%9A", "%20")
                .Replace("%E2%81%9B", "%20")
                .Replace("%E2%81%9C", "%20")
                .Replace("%E2%81%9D", "%20")
                .Replace("%E2%81%9E", "%20")
                .Replace("%E2%81%9F", "%20")
                .Replace("%E2%81%A0", "%20")
                .Replace("%E2%81%A1", "%20")
                .Replace("%E2%81%A2", "%20")
                .Replace("%E2%81%A3", "%20")
                .Replace("%E2%81%A4", "%20")
                .Replace("%E2%81%A5", "%20")
                .Replace("%E2%81%A6", "%20")
                .Replace("%E2%81%A7", "%20")
                .Replace("%E2%81%A8", "%20")
                .Replace("%E2%81%A9", "%20")
                .Replace("%E2%81%AA", "%20")
                .Replace("%E2%81%AB", "%20")
                .Replace("%E2%81%AC", "%20")
                .Replace("%E2%81%AD", "%20")
                .Replace("%E2%81%AE", "%20")
                .Replace("%E2%81%AF", "%20")
                .Replace("%E2%81%B0", "%20")
                .Replace("%E2%81%B1", "%20")
                .Replace("%E2%81%B2", "%20")
                .Replace("%E2%81%B3", "%20")
                .Replace("%E2%81%B4", "%20")
                .Replace("%E2%81%B5", "%20")
                .Replace("%E2%81%B6", "%20")
                .Replace("%E2%81%B7", "%20")
                .Replace("%E2%81%B8", "%20")
                .Replace("%E2%81%B9", "%20")
                .Replace("%E2%81%BA", "%20")
                .Replace("%E2%81%BB", "%20")
                .Replace("%E2%81%BC", "%20")
                .Replace("%E2%81%BD", "%20")
                .Replace("%E2%81%BE", "%20")
                .Replace("%E2%81%BF", "%20")
                .Replace("%0D%0A%20", "%20");

            return texto;
        }

        public void Add(IntegraProtheus IntegraProtheus)
        {
            var model = new EBSAEntities();
            HISTORICO_INTEGRACAO_PROTHEUS hist = new HISTORICO_INTEGRACAO_PROTHEUS();
            hist.ID_PRODUTO = IntegraProtheus.ID_PRODUTO;
            hist.STATUS = IntegraProtheus.STATUS;
            hist.MENSAGEM = IntegraProtheus.MENSAGEM;
            hist.DATA = DateTime.Now;
            hist.ID_USUARIO = IntegraProtheus.ID_USUARIO;
            model.HISTORICO_INTEGRACAO_PROTHEUS.Add(hist);
            model.SaveChanges();
        }

        public void InserirJsonLogIntegracaoProtheus(ProdutoJsonLog produtoJsonLog)
        {
            try
            {
                var model = new EBSAEntities();
                var log = new TB_JSON_LOG_INTEGRACAO_PROTHEUS();
                log.ID_JSON_LOG = Guid.NewGuid();
                log.URL_JSON = produtoJsonLog.UrlJson;
                log.ID_USUARIO = produtoJsonLog.IdUsuario;
                log.PROD_EBSA = produtoJsonLog.ProdEbsa;
                model.TB_JSON_LOG_INTEGRACAO_PROTHEUS.Add(log);
                model.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> BloquearProdutoProtheus(string idProduto)
        {
            try
            {
                string urlRequisicao = GerarStringBloquearProduto(idProduto);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlRequisicao);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                httpWebRequest.Proxy = null;
                AdicionarAutenticacaoBloq(ref httpWebRequest);

                using (var response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            string mensagemRetorno = await streamReader.ReadToEndAsync();
                            return VerificarRetornoProtheus(mensagemRetorno);
                        }
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GerarStringBloquearProduto(string idProduto)
        {
            var url = ConfigurationManager.AppSettings["urlBase"];
            string urlProthues = string.Concat(url, "PRODUTOS?JSONRECEIVE={\"B1_COD\": \"__CODIGO_EBSA__\",\"B1_MSBLQL\": \"1\"}");

            return urlProthues.Replace("__CODIGO_EBSA__", idProduto);
        }

        private void AdicionarAutenticacaoBloq(ref HttpWebRequest request)
        {
            var usuario = ConfigurationManager.AppSettings["usuario"];
            var senha = ConfigurationManager.AppSettings["senha"];

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes($"{usuario}:{senha}"));
            request.Headers.Add("Authorization", "Basic " + encoded);
        }

        private bool VerificarRetornoProtheus(string retornoProtheus)
        {
            if (retornoProtheus.Contains("Sucesso: Produto gravado"))
                return true;

            return false;
        }

        protected void GravarLog(string descricao)
        {
            var logs = new LOG();
            logs.DATA_LOG = DateTime.Now;
            logs.USUARIO = 0;
            logs.ID_TIPO_LOG = 2;
            logs.ID_TIPO_SISTEMA = 1;
            logs.DESCRICAO = descricao;
            logs.IpAdress = "";
            var model = new EBSAEntities();
            model.LOGS.Add(logs);
            model.SaveChanges();
        }        
    }
}
