using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.GarantiaEstatalModel;

namespace pensiones.api.Dal {
    public class GarantiaEstatalDal {

        public DataSet ObtieneGrupoPago(OracleConnection cnx, ObtieneGrupoPagoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_OBTIENE_GRUPO_PAGO";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_grupo", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener grupo pago" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ValidaSiContinuaSegundaTabla(OracleConnection cnx, ValidaSiContinuaSegundaTablaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_GET_BEN_GRUPO_PAGO_GE";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_grupo", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validar si continua a segunda tabla grupo pago" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneDatosSolicitudGe(OracleConnection cnx, ObtieneDatosSolicitudGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTENER_LISTA_SOLICITUDES_GE";
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos solicitud" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneListaBeneficiarios(OracleConnection cnx, ObtieneListaBeneficiariosRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_OBTIENE_LISTA_BEN_GE";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener beneficiarios" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }

        public DataSet ObtieneListaGrupoPagoPoliza(OracleConnection cnx, ObtieneGrupoPagoPolizaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try { ///este proc llena la primera tabla
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_DATOSGENERALES.P_OBT_LISTADOBENLEGALES";
                objComando.agregarINParametro("P_POLIZA", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("P_TIPOBEN", OracleDbType.Varchar2, request.P_TIPOBEN);
                objComando.agregarINParametro("P_SITUACION", OracleDbType.Varchar2, request.P_SITUACION);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener beneficiarios" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneDatosControlDocto(OracleConnection cnx, ObtieneDatosControlDoctoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {

                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_CONTROLDOC.P_OBT_RECEPCIONDOC_GEST";
                objComando.agregarINParametro("P_POLIZA", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("P_IDBEN", OracleDbType.Int64, request.P_IDBEN);
                objComando.agregarINParametro("P_TIPOSOL", OracleDbType.Varchar2, request.P_TIPOSOL);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos control docto" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ValidaSolicitudGarantiaEstatal(OracleConnection cnx, ValidaSolicitudGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_VERIFICA_SOLICITUD";
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_tipo", OracleDbType.Int64, request.P_TIPO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Varchar2, request.P_POLIZA);
                objComando.agregarINParametro("p_rst", OracleDbType.Int64, request.P_RST);
                objComando.agregarINParametro("p_ben_id", OracleDbType.Varchar2, request.P_BEN_ID);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validar solicitud garantia estatal" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneListaGrupoPago(OracleConnection cnx, ObtieneListaGrupoPagoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {

                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_OBTIENE_LISTA_GRUPO_PAGO";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista grupo pago" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ValidaExisteSolicitudGe(OracleConnection cnx, ValidaExisteSolicitudGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {

                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_EXISTE_SOL_GE";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN_ID);
                objComando.agregarINParametro("p_tip", OracleDbType.Int64, request.P_TIPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validar existe solicitud ge" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneEstadoGE(OracleConnection cnx, ObtieneEstadoGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_EST_GE";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSA);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LIN);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener estado ge" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneCheckEstadoGe(OracleConnection cnx, ObtieneCheckEstadoGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_CHECK_ESTADO_GE";
                objComando.agregarINParametro("P_POL", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("P_CAU", OracleDbType.Int64, request.P_CAU);
                objComando.agregarINParametro("P_BEN", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("P_EST", OracleDbType.Varchar2, request.P_EST);
                objComando.agregarINParametro("P_COD", OracleDbType.Int64, request.P_COD);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener check estado ge" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ExisteBenAps(OracleConnection cnx, ExisteBenApsRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_EXISTE_BEN_APS";
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LIN);

                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener si existe ben en aps" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet GuardaActualizaSolicitudGe(OracleConnection cnx, IngresaSolicitudGeRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_INSERT_SOL_CON_BEN";
                objComando.agregarINParametro("p_id_cre", OracleDbType.Varchar2, request.P_ID_CRE.Trim());
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_fec_sol", OracleDbType.Varchar2, request.P_FEC_SOL);
                objComando.agregarINParametro("p_idben", OracleDbType.Int64, request.P_IDBEN);
                objComando.agregarINParametro("p_rutejecutivo", OracleDbType.Varchar2, request.P_RUTEJECUTIVO);
                objComando.agregarINParametro("p_sucursal", OracleDbType.Varchar2, request.P_SUCURSAL);

                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener si existe ben en aps" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneCausante(OracleConnection cnx, Models.ObtieneCausanteRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_GARESTATAL.P_OBTIENE_CAUSANTE";
                objComando.agregarINParametro("p_persona_rut", OracleDbType.Int64, request.P_PERSONA_RUT);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener causante" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
    }
}
