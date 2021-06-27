using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using pensiones.api.Dal;
using pensiones.api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Bo {
    public class CuotaMortuariaBo {

        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        public CuotaMortuariaBo() {
        }

        public IngresaActualizaCuotaMortuariaResponseModel IngresoCuotaMortuaria(IConfiguration config, IngresaActualizaCuotaMortuariaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {

                DateTime fechaFactura = DateTime.ParseExact(request.P_CUO_FEC_FACTURA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaliquida = DateTime.ParseExact(request.P_CUO_FEC_LIQUIDA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaPago = DateTime.ParseExact(request.P_CUO_FEC_PAGO, "yyyy-mm-dd", cultureInfo);
                DateTime fechaSolicitud = DateTime.ParseExact(request.P_CUO_FEC_SOLICITUD, "yyyy-mm-dd", cultureInfo);

                request.P_CUO_FEC_FACTURA = fechaFactura.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_LIQUIDA = fechaliquida.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_PAGO = fechaPago.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_SOLICITUD = fechaSolicitud.ToString("dd-mm-yyyy");

                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.IngresoCuotaMortuaria(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public IngresaActualizaCuotaMortuariaResponseModel ActualizaCuotaMortuaria(IConfiguration config, IngresaActualizaCuotaMortuariaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {
                DateTime fechaFactura = DateTime.ParseExact(request.P_CUO_FEC_FACTURA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaliquida = DateTime.ParseExact(request.P_CUO_FEC_LIQUIDA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaPago = DateTime.ParseExact(request.P_CUO_FEC_PAGO, "yyyy-mm-dd", cultureInfo);
                DateTime fechaSolicitud = DateTime.ParseExact(request.P_CUO_FEC_SOLICITUD, "yyyy-mm-dd", cultureInfo);

                request.P_CUO_FEC_FACTURA = fechaFactura.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_LIQUIDA = fechaliquida.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_PAGO = fechaPago.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_SOLICITUD = fechaSolicitud.ToString("dd-mm-yyyy");

                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ActualizaCuotaMortuaria(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public IngresaActualizaCuotaMortuariaResponseModel InsertaCuotaMortuaria(IConfiguration config, IngresaActualizaCuotaMortuariaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {
                DateTime fechaFactura = DateTime.ParseExact(request.P_CUO_FEC_FACTURA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaliquida = DateTime.ParseExact(request.P_CUO_FEC_LIQUIDA, "yyyy-mm-dd", cultureInfo);
                DateTime fechaPago = DateTime.ParseExact(request.P_CUO_FEC_PAGO, "yyyy-mm-dd", cultureInfo);
                DateTime fechaSolicitud = DateTime.ParseExact(request.P_CUO_FEC_SOLICITUD, "yyyy-mm-dd", cultureInfo);

                request.P_CUO_FEC_FACTURA = fechaFactura.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_LIQUIDA = fechaliquida.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_PAGO = fechaPago.ToString("dd-mm-yyyy");
                request.P_CUO_FEC_SOLICITUD = fechaSolicitud.ToString("dd-mm-yyyy");

                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.IngresaNuevaCuotaMortuaria(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneCuotaMortuariaResponseModel> ObtieneCuotaMortuaria(IConfiguration config, ObtieneCuotaMortuariaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            DataSet cursorRespuesta = null;
            List<ObtieneCuotaMortuariaResponseModel> datos = new List<ObtieneCuotaMortuariaResponseModel>();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneCuotaMortuaria(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        datos = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                 select new ObtieneCuotaMortuariaResponseModel() {
                                     CUO_RUT_RECEPTOR = Convert.ToInt64(rw["CUO_RUT_RECEPTOR"]),
                                     CUO_DV_RECEPTOR = Convert.ToString(rw["CUO_DV_RECEPTOR"]),
                                     CUO_NOM_RECEPTOR = Convert.ToString(rw["CUO_NOM_RECEPTOR"]),
                                     CUO_RUT_EMPRESA = Convert.ToInt64(rw["CUO_RUT_EMPRESA"]),
                                     CUO_DV_EMPRESA = Convert.ToString(rw["CUO_DV_EMPRESA"]),
                                     CUO_NOM_EMPRESA = Convert.ToString(rw["CUO_NOM_EMPRESA"]),
                                     CUO_SUC_EMPRESA = Convert.ToString(rw["CUO_SUC_EMPRESA"]),
                                     CUO_NUM_FACTURA = Convert.ToInt64(rw["CUO_NUM_FACTURA"]),
                                     CUO_FEC_FACTURA = Convert.ToString(rw["CUO_FEC_FACTURA"]),
                                     CUO_MTO_APROBADO = Convert.ToDouble(rw["CUO_MTO_APROBADO"]),
                                     CUO_MTO_COBRADO = Convert.ToDouble(rw["CUO_MTO_COBRADO"]),
                                     CUO_FEC_SOLICITUD = Convert.ToString(rw["CUO_FEC_SOLICITUD"]),
                                     CUO_FEC_PAGO = Convert.ToString(rw["CUO_FEC_PAGO"]),
                                     CUO_FEC_LIQUIDA = Convert.ToString(rw["CUO_FEC_LIQUIDA"]),
                                     CUO_SUCURSAL = Convert.ToInt64(rw["CUO_SUCURSAL"]),
                                     SUC_NOMB = Convert.ToString(rw["SUC_NOMB"]),
                                     CUO_MTO_PAGO = Convert.ToDouble(rw["CUO_MTO_PAGO"]),
                                     CUO_MTO_LIQUIDO = Convert.ToDouble(rw["CUO_MTO_LIQUIDO"]),
                                     CUO_SALDO = Convert.ToDouble(rw["CUO_SALDO"]),
                                     CUO_ESTADO = Convert.ToInt64(rw["CUO_ESTADO"]),
                                     ESTADO_TEXTO = Convert.ToString(rw["ESTADO_TEXTO"]),
                                     FECHA_SOLICITUD_DDMMYYYY = Convert.ToString(rw["CUO_FEC_SOLICITUD"]),
                                     FECHA_FACTURA_DDMMYYYY = Convert.ToString(rw["CUO_FEC_FACTURA"])
                                 }).ToList();
                        DateTime fechaFactura = DateTime.ParseExact(datos[0].CUO_FEC_FACTURA, "dd-mm-yyyy", cultureInfo);
                        DateTime fechaliquida = DateTime.ParseExact(datos[0].CUO_FEC_LIQUIDA, "dd-mm-yyyy", cultureInfo);
                        DateTime fechaPago = DateTime.ParseExact(datos[0].CUO_FEC_PAGO, "dd-mm-yyyy", cultureInfo);
                        DateTime fechaSolicitud = DateTime.ParseExact(datos[0].CUO_FEC_SOLICITUD, "dd-mm-yyyy", cultureInfo);

                        datos[0].CUO_FEC_FACTURA = fechaFactura.ToString("yyyy-mm-dd");
                        datos[0].CUO_FEC_LIQUIDA = fechaliquida.ToString("yyyy-mm-dd");
                        datos[0].CUO_FEC_PAGO = fechaPago.ToString("yyyy-mm-dd");
                        datos[0].CUO_FEC_SOLICITUD = fechaSolicitud.ToString("yyyy-mm-dd");
                        datos[0].FECHA_SOLICITUD_DDMMYYYY = fechaSolicitud.ToString("dd-mm-yyyy");
                        datos[0].FECHA_FACTURA_DDMMYYYY = fechaFactura.ToString("dd-mm-yyyy");
                    }

                }


            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return datos;
        }
        public ObtieneCertificadoDefuncionResponseModel ObtieneCertDefuncion(IConfiguration config, ObtieneCertificadoDefuncionRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            ObtieneCertificadoDefuncionResponseModel respuesta = new ObtieneCertificadoDefuncionResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = dal.ValidarCertificadoDefuncion(cnx, request).Tables[0].Rows[0][0].ToString();
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public GuardarPersonaResponseModel GuardarPersona(IConfiguration config, GuardarPersonaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            GuardarPersonaResponseModel respuesta = new GuardarPersonaResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.GuardarPersona(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public ActualizaAtributoSieteResponseModel ActualizarAtributoSiete(IConfiguration config, ActualizaAtributoSieteRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            ActualizaAtributoSieteResponseModel respuesta = new ActualizaAtributoSieteResponseModel();
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.P_RESULTADO = Convert.ToInt64(dal.ActualizaAtributoSiete(cnx, request).Tables[0].Rows[0][0]);

                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public ObtieneValorUfResponseModel ObtieneUf(IConfiguration config, ObtieneValorUfRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            ObtieneValorUfResponseModel respuesta = new ObtieneValorUfResponseModel();
            try {
                DateTime fechaUf = DateTime.ParseExact(request.P_FECHA, "yyyy-mm-dd", cultureInfo);

                request.P_FECHA = fechaUf.ToString("dd-mm-yyyy");

                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    respuesta.MONTO = Convert.ToDouble(dal.ObtieneValorUf(cnx, request).Tables[0].Rows[0][0]);
                }
            } catch (Exception) {
                respuesta.MONTO = 0;
                return respuesta;
            }
            return respuesta;
        }
        public List<ObtieneSucursalesResponseModel> ObtieneSucursales(IConfiguration config) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtieneSucursalesResponseModel> respuesta = new List<ObtieneSucursalesResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtenerSucursales(cnx);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneSucursalesResponseModel() {
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

        public List<ObtieneDatosEjecutivoResponseModel> ObtieneDatosEjecutivo(IConfiguration config, ObtieneDatosEjecutivoRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtieneDatosEjecutivoResponseModel> respuesta = new List<ObtieneDatosEjecutivoResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtienDatosEjecutivo(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneDatosEjecutivoResponseModel() {
                                         APELLIDOMATERNO = Convert.ToString(rw["ApellidoMaterno"]),
                                         APELLIDOPATERNO = Convert.ToString(rw["ApellidoPaterno"]),
                                         CARGO = Convert.ToString(rw["Cargo"]),
                                         CENTROCOSTO = Convert.ToString(rw["CentroCosto"]),
                                         CODIGOCARGO = Convert.ToInt64(rw["CodigoCargo"]),
                                         CODIGOCENTROCOSTO = Convert.ToInt64(rw["CodigoCentroCosto"]),
                                         CODIGOSUCURSAL = Convert.ToInt64(rw["CodigoSucursal"]),
                                         DIGITORUTEMPLEADO = Convert.ToString(rw["DigitoRutEmpleado"]),
                                         DIGITORUTJEFATURA = Convert.ToString(Convert.IsDBNull(rw["DigitoRutJefatura"])),
                                         EMAIL = Convert.ToString(rw["EMail"]),
                                         RUTEMPLEADO = Convert.ToInt64(rw["RutEmpleado"]),
                                         NOMBRES = Convert.ToString(rw["Nombres"]),
                                         RUTJEFATURA = Convert.ToInt64(Convert.IsDBNull(rw["RutJefatura"])),
                                         SUCURSAL = Convert.ToString(rw["Sucursal"]),
                                         USUARIODATABASE = Convert.ToString(EvaluaNullDb(rw, "UsuarioDataBase")),
                                         USUARIONT = Convert.ToString(rw["usuarioNT"]),
                                     }).ToList();
                    }
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }

        public List<ObtienePersonaResponseModel> ObtienePersona(IConfiguration config, ObtienePersonaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtienePersonaResponseModel> respuesta = new List<ObtienePersonaResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtienePersona(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtienePersonaResponseModel() {
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_FEC_NACIM = Convert.ToString(rw["NAT_FEC_NACIM"]),
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         NAT_RST = Convert.ToString(rw["NAT_RST"]),
                                         NAT_SEXO = Convert.ToString(rw["NAT_SEXO"])
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneCausanteResponseModel> ObtieneCausante(IConfiguration config, ObtieneCausanteRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtieneCausanteResponseModel> respuesta = new List<ObtieneCausanteResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtieneCausante(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneCausanteResponseModel() {
                                         NAT_NUMRUT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         NAT_AP_PAT = Convert.ToString(rw["NAT_AP_PAT"]),
                                         NAT_AP_MAT = Convert.ToString(rw["NAT_AP_MAT"]),
                                         NAT_FEC_NACIM = Convert.ToString(rw["NAT_FEC_NACIM"]),
                                         NAT_ID = Convert.ToInt64(rw["NAT_ID"]),
                                         NAT_NOMBRE = Convert.ToString(rw["NAT_NOMBRE"]),
                                         NAT_DV = Convert.ToString(rw["NAT_DV"]),
                                         NAT_FEC_MUERTE = Convert.ToString(rw["NAT_FEC_MUERTE"])
                                     }).ToList();
                        DateTime fechaDeNac = DateTime.ParseExact(respuesta[0].NAT_FEC_NACIM, "dd-MM-yyyy h:mm:ss", cultureInfo);

                        respuesta[0].NAT_FEC_NACIM = fechaDeNac.ToString("dd-MM-yyyy");

                        if (respuesta[0].NAT_FEC_MUERTE != "" && respuesta[0].NAT_FEC_MUERTE != null) {
                            DateTime fechaDefuncion = DateTime.ParseExact(respuesta[0].NAT_FEC_MUERTE, "dd-MM-yyyy h:mm:ss", cultureInfo);
                            respuesta[0].NAT_FEC_MUERTE = fechaDefuncion.ToString("dd-MM-yyyy");
                        }
                    }
                }

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneBeneficiarioResponseModel> ObtieneBeneficiario(IConfiguration config, ObtieneBeneficiarioRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtieneBeneficiarioResponseModel> respuesta = new List<ObtieneBeneficiarioResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtienDatosBeneficiario(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtieneBeneficiarioResponseModel() {
                                         BNF_GRUPO = Convert.ToInt64(rw["BNF_GRUPO"]),
                                         BEN_RELACION = Convert.ToInt64(rw["ben_relacion"]),
                                     }).ToList();
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return respuesta;
        }
        public List<ObtieneDatosControlDoctoResponseModel> ObtieneDatosControlDocto(IConfiguration config, ObtieneDatosControlDoctoRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
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
                                         INDFALLECIMIENTO = Convert.ToInt64(rw["indFallecimiento"]),
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
        public List<ObtienePolizaResponseModel> ObtieneDatosPoliza(IConfiguration config, ObtienePolizaRequestModel request) {
            CuotaMortuariaDal dal = new CuotaMortuariaDal();
            MConexion con = new MConexion(config);
            List<ObtienePolizaResponseModel> respuesta = new List<ObtienePolizaResponseModel>();
            DataSet cursorRespuesta = null;
            try {
                using (OracleConnection cnx = con.getConexion("Data:DefaultConnection:ConnectionString")) {
                    cursorRespuesta = dal.ObtienePoliza(cnx, request);
                    if (cursorRespuesta.Tables[0].Rows.Count > 0) {
                        respuesta = (from rw in cursorRespuesta.Tables[0].AsEnumerable()
                                     select new ObtienePolizaResponseModel() {
                                         POL_LINEA = Convert.ToInt64(rw["pol_linea"]),
                                         POL_PRODUCTO = Convert.ToInt64(rw["pol_producto"]),
                                         POL_DOCUMENTO = Convert.ToInt64(rw["pol_documento"]),
                                         POL_POLIZA = Convert.ToInt64(rw["pol_poliza"]),
                                         POL_ATRB06 = Convert.ToInt64(rw["pol_atrb06"]),
                                         POL_ATRB07 = Convert.ToInt64(rw["pol_atrb07"]),
                                         NUM_RUT_NAT = Convert.ToInt64(rw["NAT_NUMRUT"]),
                                         FEC_INICIO_PAGO = Convert.ToString(rw["FEC_INICIO_PAGO"]),
                                         SIN_TIPO = Convert.ToInt64(rw["SIN_TIPO"]),
                                     }).ToList();
                        DateTime fechaDeNac = DateTime.ParseExact(respuesta[0].FEC_INICIO_PAGO, "dd-MM-yyyy h:mm:ss", cultureInfo);

                        respuesta[0].FEC_INICIO_PAGO = fechaDeNac.ToString("dd-MM-yyyy");
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

