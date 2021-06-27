using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using pensiones.api.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.RetencionJudicialModel;

namespace pensiones.api.Bo {
    public class RetencionJudicialBo {

        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        public ActualizaCargaRjResponse ActualizaCargaRj(IConfiguration config, ActualizaCargaRjRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            ActualizaCargaRjResponse respuesta = new ActualizaCargaRjResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {

                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ActualizaCargaRj(cnx, request).Tables[0].Rows[0][0]);


                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ObtieneValidacionFechasResponse ObtieneValidacionFechas(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            ObtieneValidacionFechasResponse respuesta = new ObtieneValidacionFechasResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {

                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ObtieneValidacionFechas(cnx).Tables[0].Rows[0][0]);


                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public AgregaRjResponse AgregarRj(IConfiguration config, AgregaRjRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            AgregaRjResponse respuesta = new AgregaRjResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    DateTime fechaEmision = DateTime.ParseExact(request.P_FEC_EMI, "yyyy-mm-dd", cultureInfo);

                    request.P_FEC_EMI = fechaEmision.ToString("dd-mm-yyyy");
                    DateTime fechaRecepcion = DateTime.ParseExact(request.P_FEC_RCP, "yyyy-mm-dd", cultureInfo);

                    request.P_FEC_RCP = fechaRecepcion.ToString("dd-mm-yyyy");

                    respuesta.P_RESULTADO = Convert.ToInt64(dal.AgregaRj(cnx, request).Tables[0].Rows[0][0]);


                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ObtieneSecuenciaRjResponse ObtieneSecuenciaRj(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            ObtieneSecuenciaRjResponse respuesta = new ObtieneSecuenciaRjResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ObtieneSecuenciaRj(cnx).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public CheckRetJudResponse CheckRetJud(IConfiguration config, CheckRetJudRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            CheckRetJudResponse respuesta = new CheckRetJudResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.CANTIDAD = Convert.ToInt64(dal.CheckRetJud(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public BorraRetencionJudicialResponse BorraRetencionJudicial(IConfiguration config, BorraRetencionJudicialRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            BorraRetencionJudicialResponse respuesta = new BorraRetencionJudicialResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.BorraRetencionJudicial(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtienePensionVejInvResponse> ObtieneMontoPensionVejInv(IConfiguration config, ObtienePensionVejInvRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtienePensionVejInvResponse> respuesta = new List<ObtienePensionVejInvResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneMontoPensionVejInv(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtienePensionVejInvResponse() {
                                         MONTO = Convert.ToInt64(rw["MONTO"]),

                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<CheckRetJudicialResponse> CheckRetencionJudicial(IConfiguration config, CheckRetJudicialRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<CheckRetJudicialResponse> respuesta = new List<CheckRetJudicialResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.CheckRetJudicial(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new CheckRetJudicialResponse() {
                                         CANT = Convert.ToInt64(rw["CANT"]),

                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtienePeriodoActualResponse> ObtienePeriodoActual(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtienePeriodoActualResponse> respuesta = new List<ObtienePeriodoActualResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtienePeriodoActual(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtienePeriodoActualResponse() {
                                         FECHA = Convert.ToString(rw["FECHA"]),

                                     }).ToList();
                        foreach (var item in respuesta) {
                            if (respuesta[0].FECHA != "" && respuesta[0].FECHA != null) {
                                DateTime fecha = DateTime.ParseExact(respuesta[0].FECHA, "dd-MM-yyyy h:mm:ss", cultureInfo);

                                respuesta[0].FECHA = fecha.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtienePensionsSobreResponse> ObtieneMontoPensionSobre(IConfiguration config, ObtienePensionSobreRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtienePensionsSobreResponse> respuesta = new List<ObtienePensionsSobreResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneMontoPensionSobre(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtienePensionsSobreResponse() {
                                         MONTO = Convert.ToInt64(rw["MONTO"]),

                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public List<ObtieneListaRjResponse> ObtieneListaRj(IConfiguration config, ObtieneListaRjRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaRjResponse> respuesta = new List<ObtieneListaRjResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaRj(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaRjResponse() {
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         RJ_CORR = Convert.ToInt64(rw["RJ_CORR"]),
                                         RJ_NRO_EXP = Convert.ToInt64(rw["RJ_NRO_EXP"]),
                                     }).ToList();

                    }
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaRjParaEliminarResponse> ObtieneListaRjParaEliminar(IConfiguration config, ObtieneListaRjParaEliminarRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaRjParaEliminarResponse> respuesta = new List<ObtieneListaRjParaEliminarResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaRjParaEliminar(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaRjParaEliminarResponse() {
                                         NAT_DV = Convert.ToString(rw["NAT_DV"]),
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         NRO_EXP = Convert.ToString(rw["NRO_EXP"]),
                                         RJ_CORR = Convert.ToInt64(rw["RJ_CORR"]),
                                         RJ_DOC = Convert.ToInt64(rw["RJ_DOC"]),
                                         RJ_ID_BEN_RJ = Convert.ToInt64(rw["RJ_ID_BEN_RJ"]),
                                         RJ_LIN = Convert.ToInt64(rw["RJ_LIN"]),
                                         RJ_POL = Convert.ToInt64(rw["RJ_POL"]),
                                         RJ_PRD = Convert.ToInt64(rw["RJ_PRD"]),
                                     }).ToList();

                    }
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneRetencionesJudResponse> ObtieneRetencionesJudiciales(IConfiguration config, ObtieneRetencionesJudRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneRetencionesJudResponse> respuesta = new List<ObtieneRetencionesJudResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneRetencionesJud(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneRetencionesJudResponse() {
                                         BEN_RET_JUD = Convert.ToString(rw["BEN_RET_JUD"]),
                                         MONTO = Convert.ToDouble(rw["MONTO"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         RJ_CORR = Convert.ToInt64(rw["RJ_CORR"]),
                                         RJ_BEN = Convert.ToInt64(rw["RJ_BEN"]),
                                     }).ToList();

                    }
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaFormaDescuentoResponse> ObtieneListaFormaDescuento(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaFormaDescuentoResponse> respuesta = new List<ObtieneListaFormaDescuentoResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaFormaDescuentos(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaFormaDescuentoResponse() {

                                         ID = Convert.ToInt64(rw["ID"]),
                                         TEXTO = Convert.ToString(rw["TEXTO"]),
                                         ID_TEXTO = Convert.ToString(rw["ID_TEXTO"]),
                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaAsigFamiliarResponse> ObtieneAsignacionFamiliar(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaAsigFamiliarResponse> respuesta = new List<ObtieneListaAsigFamiliarResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaAsignacionFamiliar(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaAsigFamiliarResponse() {

                                         ID = Convert.ToInt64(rw["ID"]),
                                         TEXTO = Convert.ToString(rw["TEXTO"]),
                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaFormaPagoResponse> ObtieneFormaPago(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaFormaPagoResponse> respuesta = new List<ObtieneListaFormaPagoResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaFormaPago(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaFormaPagoResponse() {
                                         ID = Convert.ToInt64(rw["ID"]),
                                         TEXTO = Convert.ToString(rw["TEXTO"]),
                                         ID_TEXTO = Convert.ToString(rw["ID_TEXTO"]),
                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaBancosResponse> ObtieneBancos(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaBancosResponse> respuesta = new List<ObtieneListaBancosResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaBancos(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaBancosResponse() {

                                         ID = Convert.ToInt64(rw["ID"]),
                                         TEXTO = Convert.ToString(rw["TEXTO"]),
                                         ID_TEXTO = Convert.ToString(rw["ID_TEXTO"]),
                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtenerEstadoGeResponse> ObtieneEstadoGE(IConfiguration config, ObtenerEstadoGeRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtenerEstadoGeResponse> respuesta = new List<ObtenerEstadoGeResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneEstadoGe(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtenerEstadoGeResponse() {
                                         ESTADOGE = Convert.ToString(rw["ESTADOGE"])
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<CheckTieneGarantiaEstatalResponse> CheckTieneGarantiaEstatal(IConfiguration config, CheckTieneGarantiaEstatalRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<CheckTieneGarantiaEstatalResponse> respuesta = new List<CheckTieneGarantiaEstatalResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.CheckTieneGarantiaEstatal(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new CheckTieneGarantiaEstatalResponse() {
                                         CGEEST = Convert.ToInt64(rw["p_resultado"])
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneMontoMinimoPensionResponse> ObtieneMontoMinimoPension(IConfiguration config, ObtieneMontoMinimoPensionRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneMontoMinimoPensionResponse> respuesta = new List<ObtieneMontoMinimoPensionResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneMontoMinimo(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneMontoMinimoPensionResponse() {
                                         PMIN_MTO_MENOR_70 = Convert.ToInt64(rw["PMIN_MTO_MENOR_70"]),
                                         BON_MAYOR_75 = Convert.ToInt64(rw["BON_MAYOR_75"]),
                                         BON_MTO_MAYOR_70 = Convert.ToInt64(rw["BON_MTO_MAYOR_70"]),
                                         BON_MTO_MENOR_70 = Convert.ToInt64(rw["BON_MTO_MENOR_70"]),
                                         PMIN_MTO_MAYOR_70 = Convert.ToInt64(rw["PMIN_MTO_MAYOR_70"]),
                                         PMIN_MTO_MTO_MAYOR_75 = Convert.ToInt64(rw["MTO_MAYOR_75"])

                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneBonoMontoMinimoPensionResponse> ObtieneBonoMontoMinimoPension(IConfiguration config, ObtieneBonoMontoMinimoPensionRequest request) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneBonoMontoMinimoPensionResponse> respuesta = new List<ObtieneBonoMontoMinimoPensionResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneMontoBonoPension(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneBonoMontoMinimoPensionResponse() {
                                         BON_MAYOR_75 = Convert.ToInt64(rw["BON_MAYOR_75"]),
                                         BON_MTO_MAYOR_70 = Convert.ToInt64(rw["BON_MTO_MAYOR_70"]),
                                         BON_MTO_MENOR_70 = Convert.ToInt64(rw["BON_MTO_MENOR_70"]),
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneDatosControlDoctoResponseModel> ObtieneDatosControlDocto(IConfiguration config) {
            RetencionJudicialDal dal = new RetencionJudicialDal();
            MConexion con = new MConexion(config);
            List<ObtieneDatosControlDoctoResponseModel> respuesta = new List<ObtieneDatosControlDoctoResponseModel>();
            DataSet cursorRespuesta = null;

            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneDatosControlDocto(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneDatosControlDoctoResponseModel() {
                                         CARACTERISTICA = Convert.ToString(EvaluaNullDb(rw, "caracteristica")),
                                         CAUSALEXTINCION = Convert.ToInt64(EvaluaNullDb(rw, "causalExtincion")),
                                         CRPROCESO = Convert.ToString(rw["crProceso"]),
                                         ESTADO = Convert.ToString(rw["estado"]),
                                         IDACTIVIDAD = Convert.ToString(rw["idActividad"]),
                                         IDACTIVIDADESP = Convert.ToInt64(rw["idActividadEsp"]),
                                         IDPODER = Convert.ToInt64(EvaluaNullDb(rw, "idPoder")),
                                         IDPROCESO = Convert.ToString(rw["idProceso"]),
                                         IDTRANSACCION = Convert.ToInt64(rw["idTransaccion"]),
                                         INDFALLECIMIENTO = Convert.ToInt64(EvaluaNullDb(rw, "indFallecimiento")),
                                         INDFORMAPAGO = Convert.ToInt64(EvaluaNullDb(rw, "indFormaPago")),
                                         INDTIPOCERTCIVIL = Convert.ToInt64(EvaluaNullDb(rw, "indTipoCertCivil")),
                                         MODALIDADPOLIZA = Convert.ToString(rw["modalidadPoliza"]),
                                         MOVIMIENTO = Convert.ToString(rw["movimiento"]),
                                         NUMRELACION = Convert.ToInt64(rw["numRelacion"])
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public string EvaluaNullDb(DataRow row,
                           string fieldName) {
            if (!DBNull.Value.Equals(row[fieldName]))
                return (string)row[fieldName];
            else
                return "0";
        }
    }
}
