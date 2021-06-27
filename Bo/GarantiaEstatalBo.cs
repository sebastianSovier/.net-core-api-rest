using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using pensiones.api.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.GarantiaEstatalModel;

namespace pensiones.api.Bo {
    public class GarantiaEstatalBo {

        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        public List<ObtieneGrupoPagoResponseModel> ObtieneGrupoPago(IConfiguration config, ObtieneGrupoPagoRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneGrupoPagoResponseModel> respuesta = new List<ObtieneGrupoPagoResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneGrupoPago(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneGrupoPagoResponseModel() {
                                         DESCRIPCION_NACIONALIDAD = Convert.ToString(rw["descripcion_nacionalidad"]),
                                         DESCRIPCION_PROFESION = Convert.ToString(rw["descripcion_profesion"]),
                                         GRP_GRUPO = Convert.ToInt64(rw["grp_grupo"]),
                                         GRP_ID_DOM = Convert.ToInt64(rw["GRP_ID_DOM"]),
                                         GRP_ISAPRE = Convert.ToInt64(rw["grp_isapre"]),
                                         GRP_LIQ = Convert.ToInt64(rw["grp_liq"]),
                                         NACIONALIDAD = Convert.ToString(rw["nacionalidad"]),
                                         NAT_AP_MAT = Convert.ToString(rw["nat_ap_mat"]),
                                         NAT_AP_PAT = Convert.ToString(rw["nat_ap_pat"]),
                                         NAT_DV = Convert.ToString(rw["nat_dv"]),
                                         NAT_ID = Convert.ToInt64(rw["nat_id"]),
                                         NAT_NOMBRE = Convert.ToString(rw["nat_nombre"]),
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         PROFESION = Convert.ToString(rw["PROFESION"]),
                                         ESTADOGE = Convert.ToString(rw["ESTADOGE"]),
                                         // DESCRIPCIONESTADOGE = Convert.ToString(rw["DESCRIPCIONESTADOGE"]),
                                         DESC_RELACION = Convert.ToString(rw["DESC_RELACION"]),
                                         ID_RELACION = Convert.ToInt64(rw["ID_RELACION"]),
                                         CALLE = Convert.ToString(rw["CALLE"]),
                                         CIUDAD = Convert.ToString(rw["CIUDAD"]),
                                         COMUNA = Convert.ToString(rw["COMUNA"]),
                                         PROVINCIA = Convert.ToString(rw["PROVINCIA"]),
                                         TELEFONO1 = Convert.ToString(rw["TELEFONO1"]),
                                         TELEFONO2 = Convert.ToString(rw["TELEFONO2"]),
                                     }).ToList();

                        foreach (var item in respuesta) {
                            if (item.ESTADOGE == "SO") {
                                item.DESCRIPCIONESTADOGE = "Pensionado o Beneficiario registra una solicitud de Garantia Estatal en proceso";
                            } else if (item.ESTADOGE == "AE") {
                                item.DESCRIPCIONESTADOGE = "Resolucion de GE enviada a la SAFP para su aprobación. La acreditación se encuentra enviada";
                            } else if (item.ESTADOGE == "SE") {
                                item.DESCRIPCIONESTADOGE = "Suspensión de Resolución enviada a la SAFP para su aprobación. La Suspensión se encuentra enviada";
                            } else if (item.ESTADOGE == "RE") {
                                item.DESCRIPCIONESTADOGE = "Garantía Estatal Rechazada";
                            } else if (item.ESTADOGE == "BP") {
                                item.DESCRIPCIONESTADOGE = "Beneficiario Potencial de Garantía Estatal";
                            } else if (item.ESTADOGE == "AC") {
                                item.DESCRIPCIONESTADOGE = "Garantía Estatal aprobada. Acreditado";
                            } else if (item.ESTADOGE == "AR") {
                                item.DESCRIPCIONESTADOGE = "Resolución de GE Aprobada por la SAFP";
                            } else if (item.ESTADOGE == "SR") {
                                item.DESCRIPCIONESTADOGE = "Resolución de suspensión de GE aprobada por la SAFP. Suspendido Resuelto";
                            } else if (item.ESTADOGE == "EA") {
                                item.DESCRIPCIONESTADOGE = "Beneficiario en proceso de Actualización Anual. En Actualización";
                            } else if (item.ESTADOGE == "AP") {
                                item.DESCRIPCIONESTADOGE = "Actualización de Pensión";
                            } else if (item.ESTADOGE == "AS") {
                                item.DESCRIPCIONESTADOGE = "Resolución de suspensión de GE aprobada. Acreditado Suspendido";
                            } else if (item.ESTADOGE == "SU") {
                                item.DESCRIPCIONESTADOGE = "Suspendido por la compañía";
                            } else if (item.ESTADOGE == "SP") {
                                item.DESCRIPCIONESTADOGE = "Seleccionado Preliminar";
                            } else {
                                item.DESCRIPCIONESTADOGE = "No existe en cartera de GE";
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaBeneficiariosResponseModel> ObtieneListaBeneficiarios(IConfiguration config, ObtieneListaBeneficiariosRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaBeneficiariosResponseModel> respuesta = new List<ObtieneListaBeneficiariosResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaBeneficiarios(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaBeneficiariosResponseModel() {
                                         BNF_GRP_PAG = Convert.ToInt64(rw["BNF_GRP_PAG"]),
                                         BEN_RELACION = Convert.ToInt64(rw["BEN_RELACION"]),
                                         BNF_GRUPO = Convert.ToInt64(rw["BNF_GRUPO"]),
                                         DESC_RELACION = Convert.ToString(rw["DESC_RELACION"]),
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_DV = Convert.ToString(rw["NAT_DV"]),
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         CALLE = Convert.ToString(rw["CALLE"]),
                                         COMUNA = Convert.ToString(rw["COMUNA"]),
                                         CIUDAD = Convert.ToString(rw["CIUDAD"]),
                                         TELEFONO1 = Convert.ToString(rw["TELEFONO1"]),
                                         NACIONALIDAD = Convert.ToString(rw["NACIONALIDAD"]),
                                         ESTCIVIL = Convert.ToString(rw["ESTCIVIL"]),
                                         PROFESION = Convert.ToString(rw["PROFESION"]),
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ValidaSiContinuaSegundaTablaResponseModel> ValidaSiContinuaSegundaTabla(IConfiguration config, ValidaSiContinuaSegundaTablaRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ValidaSiContinuaSegundaTablaResponseModel> respuesta = new List<ValidaSiContinuaSegundaTablaResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ValidaSiContinuaSegundaTabla(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ValidaSiContinuaSegundaTablaResponseModel() {
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneDatosControlDoctoResponseModel> ObtieneDatosControlDocto(IConfiguration config, ObtieneDatosControlDoctoRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneDatosControlDoctoResponseModel> respuesta = new List<ObtieneDatosControlDoctoResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneDatosControlDocto(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneDatosControlDoctoResponseModel() {
                                         CARACTERISTICA = Convert.ToInt64(Convert.IsDBNull(rw["caracteristica"])),
                                         CAUSALEXTINCION = Convert.ToInt64(Convert.IsDBNull(rw["causalExtincion"])),
                                         CRPROCESO = Convert.ToInt64(rw["CRPROCESO"]),
                                         ESTADO = Convert.ToString(rw["ESTADO"]),
                                         IDACTIVIDAD = Convert.ToString(rw["IDACTIVIDAD"]),
                                         IDACTIVIDADESP = Convert.ToInt64(rw["IDACTIVIDADESP"]),
                                         IDPODER = Convert.ToInt64(Convert.IsDBNull(rw["idPoder"])),
                                         IDPROCESO = Convert.ToInt64(rw["IDPROCESO"]),
                                         IDTRANSACCION = Convert.ToInt64(rw["IDTRANSACCION"]),
                                         INDFALLECIMIENTO = Convert.ToInt64(Convert.IsDBNull(rw["INDFALLECIMIENTO"])),
                                         INDFORMAPAGO = Convert.ToInt64(Convert.IsDBNull(rw["indFormaPago"])),
                                         INDTIPOCERTCIVIL = Convert.ToInt64(Convert.IsDBNull(rw["indTipoCertCivil"])),
                                         MODALIDADPOLIZA = Convert.ToString(rw["MODALIDADPOLIZA"]),
                                         MOVIMIENTO = Convert.ToString(rw["MOVIMIENTO"]),
                                         NUMRELACION = Convert.ToInt64(rw["NUMRELACION"]),

                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ExisteBenApsResponseModel ExisteBenAps(IConfiguration config, ExisteBenApsRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            ExisteBenApsResponseModel respuesta = new ExisteBenApsResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ExisteBenAps(cnx, request).Tables[0].Rows[0][0]);

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneGrupoPagoPolizaResponseModel> ObtieneGrupoPagoPoliza(IConfiguration config, ObtieneGrupoPagoPolizaRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneGrupoPagoPolizaResponseModel> respuesta = new List<ObtieneGrupoPagoPolizaResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaGrupoPagoPoliza(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneGrupoPagoPolizaResponseModel() {
                                         APELLIDOMATERNO = Convert.ToString(rw["APELLIDOMATERNO"]),
                                         APELLIDOPATERNO = Convert.ToString(rw["APELLIDOPATERNO"]),
                                         DESCESTADO = Convert.ToString(rw["DESCESTADO"]),
                                         DESCRELACION = Convert.ToString(rw["DESCRELACION"]),
                                         DESCSITUACIONPAGO = Convert.ToString(rw["DESCSITUACIONPAGO"]),
                                         DESCTIPOBENEFICIARIO = Convert.ToString(rw["DESCTIPOBENEFICIARIO"]),
                                         DVRUT = Convert.ToString(rw["DVRUT"]),
                                         ID = Convert.ToInt64(rw["ID"]),
                                         IDESTADO = Convert.ToString(rw["IDESTADO"]),
                                         IDGRUPOFAMILIAR = Convert.ToInt64(rw["IDGRUPOFAMILIAR"]),
                                         IDGRUPOPAGO = Convert.ToInt64(rw["IDGRUPOPAGO"]),
                                         IDRELACION = Convert.ToInt64(rw["IDRELACION"]),
                                         IDSITUACIONPAGO = Convert.ToString(rw["IDSITUACIONPAGO"]),
                                         IDTIPOBENEFICIARIO = Convert.ToString(rw["IDTIPOBENEFICIARIO"]),
                                         NOMBRE = Convert.ToString(rw["NOMBRE"]),
                                         NUMERORUT = Convert.ToInt64(rw["NUMERORUT"]),
                                         TIENE_CARGAS = Convert.ToString(rw["TIENE_CARGAS"]),
                                         TIENE_CERT_CIVIL = Convert.ToString(rw["TIENE_CERT_CIVIL"]),
                                         TIENE_CERT_ESTUDIO = Convert.ToString(rw["TIENE_CERT_ESTUDIO"]),
                                         TIENE_DEC_RENTA = Convert.ToString(rw["TIENE_DEC_RENTA"]),
                                         TIENE_FUN = Convert.ToString(rw["TIENE_FUN"]),
                                         TIENE_LIQUIDACION = Convert.ToString(rw["TIENE_LIQUIDACION"]),
                                         TIENE_MANDATO = Convert.ToString(rw["TIENE_MANDATO"]),
                                         TIENE_PNC = Convert.ToString(rw["TIENE_PNC"]),
                                         ULTIMOPERIODOLIQ = Convert.ToInt64(Convert.IsDBNull(rw["ULTIMOPERIODOLIQ"])),
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ValidaSolicitudGeResponseModel ValidaSolicitudGarantiaEstatal(IConfiguration config, ValidaSolicitudGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            ValidaSolicitudGeResponseModel respuesta = new ValidaSolicitudGeResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ValidaSolicitudGarantiaEstatal(cnx, request).Tables[0].Rows[0][0]);

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ValidaExisteSolicitudGeResponseModel ValidaExisteSolicitudGarantiaEstatal(IConfiguration config, ValidaExisteSolicitudGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            ValidaExisteSolicitudGeResponseModel respuesta = new ValidaExisteSolicitudGeResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ValidaExisteSolicitudGe(cnx, request).Tables[0].Rows[0][0]);

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneListaGrupoPagoResponseModel> ObtieneListaGrupoPagoPoliza(IConfiguration config, ObtieneListaGrupoPagoRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneListaGrupoPagoResponseModel> respuesta = new List<ObtieneListaGrupoPagoResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneListaGrupoPago(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneListaGrupoPagoResponseModel() {
                                         DESCRIPCION_NACIONALIDAD = Convert.ToString(rw["DESCRIPCION_NACIONALIDAD"]),
                                         DESCRIPCION_PROFESION = Convert.ToString(rw["DESCRIPCION_PROFESION"]),
                                         GRP_GRUPO = Convert.ToInt64(rw["GRP_GRUPO"]),
                                         NACIONALIDAD = Convert.ToString(rw["NACIONALIDAD"]),
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_DV = Convert.ToString(rw["NAT_DV"]),
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         PROFESION = Convert.ToString(rw["PROFESION"]),
                                         ID_RELACION = Convert.ToInt64(rw["ID_RELACION"]),
                                         DESC_RELACION = Convert.ToString(rw["DESC_RELACION"]),
                                         ESTADOGE = Convert.ToString(rw["ESTADOGE"]),
                                         EDAD = Convert.ToInt64(rw["EDAD"]),


                                     }).ToList();
                        foreach (var item in respuesta) {
                            if (item.ESTADOGE == "SO") {
                                item.DESCRIPCIONESTADOGE = "Pensionado o Beneficiario registra una solicitud de Garantia Estatal en proceso";
                            } else if (item.ESTADOGE == "AE") {
                                item.DESCRIPCIONESTADOGE = "Resolucion de GE enviada a la SAFP para su aprobación. La acreditación se encuentra enviada";
                            } else if (item.ESTADOGE == "SE") {
                                item.DESCRIPCIONESTADOGE = "Suspensión de Resolución enviada a la SAFP para su aprobación. La Suspensión se encuentra enviada";
                            } else if (item.ESTADOGE == "RE") {
                                item.DESCRIPCIONESTADOGE = "Garantía Estatal Rechazada";
                            } else if (item.ESTADOGE == "BP") {
                                item.DESCRIPCIONESTADOGE = "Beneficiario Potencial de Garantía Estatal";
                            } else if (item.ESTADOGE == "AC") {
                                item.DESCRIPCIONESTADOGE = "Garantía Estatal aprobada. Acreditado";
                            } else if (item.ESTADOGE == "AR") {
                                item.DESCRIPCIONESTADOGE = "Resolución de GE Aprobada por la SAFP";
                            } else if (item.ESTADOGE == "SR") {
                                item.DESCRIPCIONESTADOGE = "Resolución de suspensión de GE aprobada por la SAFP. Suspendido Resuelto";
                            } else if (item.ESTADOGE == "EA") {
                                item.DESCRIPCIONESTADOGE = "Beneficiario en proceso de Actualización Anual. En Actualización";
                            } else if (item.ESTADOGE == "AP") {
                                item.DESCRIPCIONESTADOGE = "Actualización de Pensión";
                            } else if (item.ESTADOGE == "AS") {
                                item.DESCRIPCIONESTADOGE = "Resolución de suspensión de GE aprobada. Acreditado Suspendido";
                            } else if (item.ESTADOGE == "SU") {
                                item.DESCRIPCIONESTADOGE = "Suspendido por la compañía";
                            } else if (item.ESTADOGE == "SP") {
                                item.DESCRIPCIONESTADOGE = "Seleccionado Preliminar";
                            } else {
                                item.DESCRIPCIONESTADOGE = "No existe en cartera de GE";
                            }

                        }
                    }

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneEstadoGeResponseModel> ObtieneEstadoGE(IConfiguration config, ObtieneEstadoGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneEstadoGeResponseModel> respuesta = new List<ObtieneEstadoGeResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneEstadoGE(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneEstadoGeResponseModel() {
                                         ESTADOGE = Convert.ToString(rw["ESTADOGE"])
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneDatosSolicitudGeResponseModel> ObtieneDatosSolicitudGe(IConfiguration config, ObtieneDatosSolicitudGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<ObtieneDatosSolicitudGeResponseModel> respuesta = new List<ObtieneDatosSolicitudGeResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneDatosSolicitudGe(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneDatosSolicitudGeResponseModel() {
                                         SOL_BEN_NN = Convert.ToInt64(rw["SOL_BEN_NN"]),
                                         SOL_CORR_ID = Convert.ToInt64(rw["SOL_CORR_ID"]),
                                         SOL_FEC_SOL_FC = Convert.ToString(rw["SOL_FEC_SOL_FC"]),
                                         SOL_POL_NN = Convert.ToInt64(rw["SOL_POL_NN"]),
                                         SOL_SUC_TA = Convert.ToInt64(rw["SOL_SUC_TA"]),
                                         SOL_TIP_NN = Convert.ToInt64(rw["SOL_TIP_NN"]),
                                     }).ToList();


                        foreach (var item in respuesta) {
                            DateTime fechaSolicitud = DateTime.ParseExact(item.SOL_FEC_SOL_FC, "dd-MM-yyyy h:mm:ss", cultureInfo);

                            item.SOL_FEC_SOL_FC = fechaSolicitud.ToString("dd-MM-yyyy");
                        }


                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public ObtieneCheckEstadoGeResponseModel ObtieneCheckEstadoGe(IConfiguration config, ObtieneCheckEstadoGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            ObtieneCheckEstadoGeResponseModel respuesta = new ObtieneCheckEstadoGeResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {

                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ObtieneCheckEstadoGe(cnx, request).Tables[0].Rows[0][0]);


                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public IngresaSolicitudGeResponseModel GuardaActualizaSolicitudGe(IConfiguration config, IngresaSolicitudGeRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            IngresaSolicitudGeResponseModel respuesta = new IngresaSolicitudGeResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    DateTime fechaSolicitud = DateTime.ParseExact(request.P_FEC_SOL, "yyyy-mm-dd", cultureInfo);

                    request.P_FEC_SOL = fechaSolicitud.ToString("dd-mm-yyyy");
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.GuardaActualizaSolicitudGe(cnx, request).Tables[0].Rows[0][0]);


                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public List<Models.ObtieneCausanteResponseModel> ObtieneCausante(IConfiguration config, Models.ObtieneCausanteRequestModel request) {
            GarantiaEstatalDal dal = new GarantiaEstatalDal();
            MConexion con = new MConexion(config);
            List<Models.ObtieneCausanteResponseModel> respuesta = new List<Models.ObtieneCausanteResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneCausante(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new Models.ObtieneCausanteResponseModel() {
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_FEC_NACIM = Convert.ToString(rw["NAT_FEC_NACIM"]),
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         NAT_DV = Convert.ToString(rw["NAT_DV"]),
                                         NAT_FEC_MUERTE = Convert.ToString(rw["NAT_FEC_MUERTE"]),
                                         EDAD = Convert.ToInt64(rw["EDAD"]),
                                         FECHAINVALIDEZ = Convert.ToString(rw["FECHAINVALIDEZ"]),
                                         SEXO = Convert.ToString(rw["SEXO"]),

                                     }).ToList();
                        DateTime fechaDeNac = DateTime.ParseExact(respuesta[0].NAT_FEC_NACIM, "dd-MM-yyyy h:mm:ss", cultureInfo);

                        respuesta[0].NAT_FEC_NACIM = fechaDeNac.ToString("dd-MM-yyyy");

                        if (respuesta[0].NAT_FEC_MUERTE != "" && respuesta[0].NAT_FEC_MUERTE != null) {
                            DateTime fechaDefuncion = DateTime.ParseExact(respuesta[0].NAT_FEC_MUERTE, "dd-MM-yyyy h:mm:ss", cultureInfo);

                            respuesta[0].NAT_FEC_MUERTE = fechaDefuncion.ToString("dd-MM-yyyy");
                        }
                        if (respuesta[0].FECHAINVALIDEZ != "" && respuesta[0].FECHAINVALIDEZ != null) {
                            DateTime fechaInvalidez = DateTime.ParseExact(respuesta[0].FECHAINVALIDEZ, "dd-MM-yyyy h:mm:ss", cultureInfo);

                            respuesta[0].FECHAINVALIDEZ = fechaInvalidez.ToString("dd-MM-yyyy");
                        }
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
