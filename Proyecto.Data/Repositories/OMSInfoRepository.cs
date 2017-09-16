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

        public IList<OMSTallaxEdadMasculino> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var listaTallaxEdad = new List<OMSTallaxEdadMasculino>();
            try
            {
                var response = _omsInfoSqlService.GetListOMSTallaxEdad(idSexo, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var tallaxEdad = new OMSCamposIndicadores
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

                    listaTallaxEdad.Add(tallaxEdad);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaTallaxEdad;
        }

    }
}
