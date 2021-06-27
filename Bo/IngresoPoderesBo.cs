using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using pensiones.api.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.IngresoPoderesModel;

namespace pensiones.api.Bo {
    public class IngresoPoderesBo {

        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        public List<ObtieneTiposPoderesResponse> ObtieneTiposPoderes(IConfiguration config) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            List<ObtieneTiposPoderesResponse> respuesta = new List<ObtieneTiposPoderesResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneTiposPoderes(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneTiposPoderesResponse() {
                                         ID = Convert.ToInt64(rw["ID"]),
                                         ID_TEXTO = Convert.ToString(rw["ID_TEXTO"]),
                                         OTRO = Convert.ToInt64(rw["OTRO"]),
                                         TEXTO = Convert.ToString(rw["TEXTO"]),

                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public AgregaPoderResponse AgregaPoder(IConfiguration config, AgregaPoderRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            AgregaPoderResponse respuesta = new AgregaPoderResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    DateTime fechaNotificacion = DateTime.ParseExact(request.P_FECHANOTIFICACION, "yyyy-mm-dd", cultureInfo);

                    request.P_FECHANOTIFICACION = fechaNotificacion.ToString("dd-mm-yyyy");
                    DateTime fechaSuscripcion = DateTime.ParseExact(request.P_FECHASUSCRIPCION, "yyyy-mm-dd", cultureInfo);

                    request.P_FECHASUSCRIPCION = fechaSuscripcion.ToString("dd-mm-yyyy");
                    DateTime fechaVencimiento = DateTime.ParseExact(request.P_FECHAVENCIMIENTO, "yyyy-mm-dd", cultureInfo);

                    request.P_FECHAVENCIMIENTO = fechaVencimiento.ToString("dd-mm-yyyy");
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.AgregaPoder(cnx, request).Tables[0].Rows[0][0]);

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public IngresaPoderMfpResponse IngresaPoderMfp(IConfiguration config, IngresaPoderMfpRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            IngresaPoderMfpResponse respuesta = new IngresaPoderMfpResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.IngresaPoderMfp(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public AutorizaPoderMfpResponse AutorizaPoderMfp(IConfiguration config, AutorizaPoderMfpRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            AutorizaPoderMfpResponse respuesta = new AutorizaPoderMfpResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.AutorizaPoderMfp(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<CheckPoderResponse> CheckPoder(IConfiguration config, CheckPoderRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            List<CheckPoderResponse> respuesta = new List<CheckPoderResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.CheckPoder(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new CheckPoderResponse() {
                                         CONT = Convert.ToInt64(rw["CONT"]),
                                     }).ToList();

                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaPoderesResponse> ObtieneListaPoderes(IConfiguration config, ObtieneListaPoderesRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaPoderesResponse> respuesta = new List<ObtieneListaPoderesResponse>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtenerListaPoderes(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaPoderesResponse() {
                                         NAT_DV = Convert.ToString(rw["POD_FEC_INICIO"]),
                                         NAT_NUMRUT = Convert.ToInt64(rw["POD_FEC_INICIO"]),
                                         POD_CORR = Convert.ToInt64(rw["POD_FEC_INICIO"]),
                                         POD_ID_RECEPTOR = Convert.ToInt64(rw["POD_FEC_INICIO"]),
                                         POD_FEC_INICIO = Convert.ToString(rw["POD_FEC_INICIO"]),
                                         POD_FEC_TERMINO = Convert.ToString(rw["POD_FEC_TERMINO"]),
                                     }).ToList();
                        foreach (var item in respuesta) {
                            if (respuesta[0].POD_FEC_INICIO != "" && respuesta[0].POD_FEC_INICIO != null) {
                                DateTime fechaDefuncion = DateTime.ParseExact(respuesta[0].POD_FEC_INICIO, "dd-MM-yyyy h:mm:ss", cultureInfo);

                                respuesta[0].POD_FEC_INICIO = fechaDefuncion.ToString("dd-MM-yyyy");
                            }
                            if (respuesta[0].POD_FEC_TERMINO != "" && respuesta[0].POD_FEC_TERMINO != null) {
                                DateTime fechaInvalidez = DateTime.ParseExact(respuesta[0].POD_FEC_TERMINO, "dd-MM-yyyy h:mm:ss", cultureInfo);

                                respuesta[0].POD_FEC_TERMINO = fechaInvalidez.ToString("dd-MM-yyyy");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public AnulaUltimoPoderResponse AnulaUltimoPoder(IConfiguration config, AnulaUltimoPoderRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            AnulaUltimoPoderResponse respuesta = new AnulaUltimoPoderResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.AnulaUltimoPoder(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public BorraPoderesResponse BorraPoderes(IConfiguration config, BorraPoderesRequest request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            BorraPoderesResponse respuesta = new BorraPoderesResponse();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.BorraPoderes(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneDatosControlDoctoResponseModel> ObtieneDatosControlDocto(IConfiguration config, ObtieneDatosControlDoctoRequestModel request) {
            IngresoPoderesDal dal = new IngresoPoderesDal();
            MConexion con = new MConexion(config);
            List<ObtieneDatosControlDoctoResponseModel> respuesta = new List<ObtieneDatosControlDoctoResponseModel>();
            DataSet cursorRespuesta = null;

            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneDatosControlDocto(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneDatosControlDoctoResponseModel() {
                                         CARACTERISTICA = Convert.ToString(Convert.IsDBNull(rw["caracteristica"])),
                                         CAUSALEXTINCION = Convert.ToInt64(Convert.IsDBNull(rw["causalExtincion"])),
                                         CRPROCESO = Convert.ToString(rw["crProceso"]),
                                         ESTADO = Convert.ToString(rw["estado"]),
                                         IDACTIVIDAD = Convert.ToString(rw["idActividad"]),
                                         IDACTIVIDADESP = Convert.ToInt64(rw["idActividadEsp"]),
                                         IDPODER = Convert.ToInt64(Convert.IsDBNull(rw["idPoder"])),
                                         IDPROCESO = Convert.ToString(rw["idProceso"]),
                                         IDTRANSACCION = Convert.ToInt64(rw["idTransaccion"]),
                                         INDFALLECIMIENTO = Convert.ToInt64(Convert.IsDBNull(rw["indFallecimiento"])),
                                         INDFORMAPAGO = Convert.ToInt64(Convert.IsDBNull(rw["indFormaPago"])),
                                         INDTIPOCERTCIVIL = Convert.ToInt64(Convert.IsDBNull(rw["indTipoCertCivil"])),
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
