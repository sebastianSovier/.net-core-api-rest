using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.IngresoPoderesModel;

namespace pensiones.api.Dal {
    public class IngresoPoderesDal {
        public DataSet ObtieneTiposPoderes(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_TIPOS_PODERES";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener tipos de poderes" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet AgregaPoder(OracleConnection cnx, AgregaPoderRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_AGREGA_PODER";
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_causante", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_grupo", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarINParametro("p_id_repre", OracleDbType.Int64, request.P_ID_REPRE);
                objComando.agregarINParametro("p_id_recep", OracleDbType.Int64, request.P_ID_RECEP);
                objComando.agregarINParametro("p_fechaNotificacion", OracleDbType.Varchar2, request.P_FECHANOTIFICACION);
                objComando.agregarINParametro("p_fechaSuscripcion", OracleDbType.Varchar2, request.P_FECHASUSCRIPCION);
                objComando.agregarINParametro("p_fechaVencimiento", OracleDbType.Varchar2, request.P_FECHAVENCIMIENTO);
                objComando.agregarINParametro("p_tipoPoder", OracleDbType.Int64, request.P_TIPOPODER);
                objComando.agregarINParametro("p_rst", OracleDbType.Int64, request.P_RST);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener tipos de poderes" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet IngresaPoderMfp(OracleConnection cnx, IngresaPoderMfpRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_INGRESA_PODER_MFP";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_cob", OracleDbType.Int64, request.P_COBERTURA);
                objComando.agregarINParametro("p_per", OracleDbType.Int64, request.P_PERIODO);
                objComando.agregarINParametro("p_cta", OracleDbType.Int64, request.P_CTA_BCO);
                objComando.agregarINParametro("p_bco", OracleDbType.Varchar2, request.P_BANCO);
                objComando.agregarINParametro("p_mes", OracleDbType.Int64, request.P_MES);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al ingresar poder mfp" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet AutorizaPoderMfp(OracleConnection cnx, AutorizaPoderMfpRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_AUTORIZA_PODER_MFP";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al autorizar poder mfp" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet CheckPoder(OracleConnection cnx, CheckPoderRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_PODERES.P_CHECK_PODER";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_idbeneficiario", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_id_recep", OracleDbType.Int64, request.P_ID_RECEP);
                objComando.agregarINParametro("p_tipoPoder", OracleDbType.Int64, request.P_TIPOPODER);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al chequear poder" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtenerListaPoderes(OracleConnection cnx, ObtieneListaPoderesRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTENER_LISTA_PODERES";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_causante", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_user", OracleDbType.Int64, request.P_USER);
                objComando.agregarINParametro("p_tipo", OracleDbType.Int64, request.P_TIPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista de poderes" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet AnulaUltimoPoder(OracleConnection cnx, AnulaUltimoPoderRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_ANULA_ULTIMO_PODER";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_causante", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_grp", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarINParametro("p_rep", OracleDbType.Int64, request.P_REPRESENTANTE);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al anular ultimo poder" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet BorraPoderes(OracleConnection cnx, BorraPoderesRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_BORRA_PODERES";
                objComando.agregarINParametro("p_correlativo", OracleDbType.Int64, request.P_CORRELATIVO);
                objComando.agregarINParametro("p_user", OracleDbType.Int64, request.P_USER);
                objComando.agregarINParametro("p_tipo", OracleDbType.Int64, request.P_TIPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);
                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al borrar poderes" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneDatosControlDocto(OracleConnection cnx, ObtieneDatosControlDoctoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_CONTROLDOC.P_OBT_RECEPCIONDOC_PODER";
                objComando.agregarINParametro("P_POLIZA", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("P_IDBEN", OracleDbType.Int64, request.P_IDBEN);
                objComando.agregarINParametro("P_TIPOPODER", OracleDbType.Int64, request.P_TIPOPODER);
                objComando.agregarOUTParametro("P_RESULTADO", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos control docto " + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
    }
}