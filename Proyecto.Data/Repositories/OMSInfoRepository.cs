using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;
using Proyecto.Data.SqlServices;
using System;
using System.Collections.Generic;
using System.Data;

namespace Proyecto.Data.Repositories
{
    public class OMSInfoRepository : IOMSInfoRepository, IRepository
    {
        private readonly OMSInfoSqlService _omsInfoSqlService;

        public OMSInfoRepository()
        {
            _omsInfoSqlService = new OMSInfoSqlService();
        }

        public IList<OMSCamposIndicadores> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaIndicadores = new List<OMSCamposIndicadores>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSTallaxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var indicadores = new OMSCamposIndicadores
                    {
                        Meses = Convert.ToInt32(dataRow["Meses"]),
                        L = Convert.ToDecimal(dataRow["L"].ToString()),
                        M = Convert.ToDecimal(dataRow["M"].ToString()),
                        S = Convert.ToDecimal(dataRow["S"].ToString()),
                        SD = Convert.ToDecimal(dataRow["SD"].ToString()),
                        SD3neg = Convert.ToDecimal(dataRow["SD3neg"].ToString()),
                        SD2neg = Convert.ToDecimal(dataRow["SD2neg"].ToString()),
                        SD1neg = Convert.ToDecimal(dataRow["SD1neg"].ToString()),
                        SD0 = Convert.ToDecimal(dataRow["SD0"].ToString()),
                        SD1 = Convert.ToDecimal(dataRow["SD1"].ToString()),
                        SD2 = Convert.ToDecimal(dataRow["SD2"].ToString()),
                        SD3 = Convert.ToDecimal(dataRow["SD3"].ToString()),
                    };

                    listaIndicadores.Add(indicadores);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaIndicadores;
        }

        public IList<OMSCamposIndicadores> GetListOMSPesoxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaIndicadores = new List<OMSCamposIndicadores>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSPesoxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var indicadores = new OMSCamposIndicadores
                    {
                        Meses = Convert.ToInt32(dataRow["Meses"]),
                        L = Convert.ToDecimal(dataRow["L"].ToString()),
                        M = Convert.ToDecimal(dataRow["M"].ToString()),
                        S = Convert.ToDecimal(dataRow["S"].ToString()),
                        SD3neg = Convert.ToDecimal(dataRow["SD3neg"].ToString()),
                        SD2neg = Convert.ToDecimal(dataRow["SD2neg"].ToString()),
                        SD1neg = Convert.ToDecimal(dataRow["SD1neg"].ToString()),
                        SD0 = Convert.ToDecimal(dataRow["SD0"].ToString()),
                        SD1 = Convert.ToDecimal(dataRow["SD1"].ToString()),
                        SD2 = Convert.ToDecimal(dataRow["SD2"].ToString()),
                        SD3 = Convert.ToDecimal(dataRow["SD3"].ToString()),
                    };

                    listaIndicadores.Add(indicadores);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaIndicadores;
        }
        public IList<OMSCamposIndicadores> GetListOMSIMCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaIndicadores = new List<OMSCamposIndicadores>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSIMCxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var indicadores = new OMSCamposIndicadores
                    {
                        Meses = Convert.ToInt32(dataRow["Meses"]),
                        L = Convert.ToDecimal(dataRow["L"].ToString()),
                        M = Convert.ToDecimal(dataRow["M"].ToString()),
                        S = Convert.ToDecimal(dataRow["S"].ToString()),
                        SD3neg = Convert.ToDecimal(dataRow["SD3neg"].ToString()),
                        SD2neg = Convert.ToDecimal(dataRow["SD2neg"].ToString()),
                        SD1neg = Convert.ToDecimal(dataRow["SD1neg"].ToString()),
                        SD0 = Convert.ToDecimal(dataRow["SD0"].ToString()),
                        SD1 = Convert.ToDecimal(dataRow["SD1"].ToString()),
                        SD2 = Convert.ToDecimal(dataRow["SD2"].ToString()),
                        SD3 = Convert.ToDecimal(dataRow["SD3"].ToString()),
                    };

                    listaIndicadores.Add(indicadores);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaIndicadores;
        }
        public IList<OMSCamposIndicadores> GetListOMSPCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaIndicadores = new List<OMSCamposIndicadores>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSPCxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var indicadores = new OMSCamposIndicadores
                    {
                        Meses = Convert.ToInt32(dataRow["Meses"]),
                        L = Convert.ToDecimal(dataRow["L"].ToString()),
                        M = Convert.ToDecimal(dataRow["M"].ToString()),
                        S = Convert.ToDecimal(dataRow["S"].ToString()),
                        SD3neg = Convert.ToDecimal(dataRow["SD3neg"].ToString()),
                        SD2neg = Convert.ToDecimal(dataRow["SD2neg"].ToString()),
                        SD1neg = Convert.ToDecimal(dataRow["SD1neg"].ToString()),
                        SD0 = Convert.ToDecimal(dataRow["SD0"].ToString()),
                        SD1 = Convert.ToDecimal(dataRow["SD1"].ToString()),
                        SD2 = Convert.ToDecimal(dataRow["SD2"].ToString()),
                        SD3 = Convert.ToDecimal(dataRow["SD3"].ToString()),
                    };

                    listaIndicadores.Add(indicadores);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaIndicadores;
        }
        public IList<OMSCamposIndicadores> GetListOMSPMBxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaIndicadores = new List<OMSCamposIndicadores>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSPMBxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var indicadores = new OMSCamposIndicadores
                    {
                        Meses = Convert.ToInt32(dataRow["Meses"]),
                        L = Convert.ToDecimal(dataRow["L"].ToString()),
                        M = Convert.ToDecimal(dataRow["M"].ToString()),
                        S = Convert.ToDecimal(dataRow["S"].ToString()),
                        SD3neg = Convert.ToDecimal(dataRow["SD3neg"].ToString()),
                        SD2neg = Convert.ToDecimal(dataRow["SD2neg"].ToString()),
                        SD1neg = Convert.ToDecimal(dataRow["SD1neg"].ToString()),
                        SD0 = Convert.ToDecimal(dataRow["SD0"].ToString()),
                        SD1 = Convert.ToDecimal(dataRow["SD1"].ToString()),
                        SD2 = Convert.ToDecimal(dataRow["SD2"].ToString()),
                        SD3 = Convert.ToDecimal(dataRow["SD3"].ToString()),
                    };

                    listaIndicadores.Add(indicadores);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaIndicadores;
        }
    }
}
