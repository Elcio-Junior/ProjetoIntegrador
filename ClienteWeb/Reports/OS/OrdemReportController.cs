using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Servico;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace ClienteWeb.Reports.OS
{
    public class OrdemReportController : Controller
    {
        private Contexto db = new Contexto();

        // GET: OrdemReport
        public ActionResult ImprimirOS(int OrdemId)
        {
            var localReport = new LocalReport
            {
                ReportPath = Server.MapPath("~/Reports/OS/OrdemReport.rdlc")
            };

            var ordem = db.Ordens.Find(OrdemId);
            var itens = ordem.Itens;

            localReport.SetParameters(new ReportParameter("Titulo", "Ordem de Serviço (OS)"));
            localReport.SetParameters(new ReportParameter("OS", ordem.Id.ToString()));
            localReport.SetParameters(new ReportParameter("Nome", ordem.Cliente.Nome));
            localReport.SetParameters(new ReportParameter("Descricao", ordem.Descricao));
            localReport.SetParameters(new ReportParameter("Abertura", ordem.Abertura.ToString("dd/MM/yyyy")));
            localReport.SetParameters(new ReportParameter("Fechamento", ordem.Fechamento?.ToString("dd/MM/yyyy")));
            localReport.SetParameters(new ReportParameter("Equipamento", ordem.Equipamento?.Modelo));
            localReport.SetParameters(new ReportParameter("Total", itens.Sum(n=>n.Valor * n.Quantidade).ToString()));

            var lista = itens.Select(n => new OrdemItemModelReport
            {
                OrdemItemId = n.Id,
                Quantidade = n.Quantidade,
                Valor = n.Valor*(n.Quantidade),

                ServicoId = n.ServicoId,
                Descricao = n.ServicoP.Descricao,
                ValorUnitario = n.Valor
            });
            
            localReport.DataSources.Add(new ReportDataSource("DataSet1", lista));
            localReport.Refresh();


            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] bytes;

            string deviceInfo = null;

            //Renderiza o relatório em bytes
            bytes = localReport.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            //salvando o arquivo no servidor
            string nomeArquivo = "OS_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + "." + reportType;
            string filePathLog = Server.MapPath("~/Log/" + nomeArquivo);
            using (var fs = new FileStream(filePathLog, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            //Descomente a linha abaixo para realizar o download do arquivo automaticamente
            //Response.AddHeader("content-disposition", "attachment; filename=" + nomeArquivo);

            return File(bytes, mimeType);

            //return View();
        }
    }
}