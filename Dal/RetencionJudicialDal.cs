using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static pensiones.api.Models.RetencionJudicialModel;

namespace pensiones.api.Dal {
    public class RetencionJudicialDal {
        public DataSet ActualizaCargaRj(OracleConnection cnx, ActualizaCargaRjRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_ACTUALIZA_CARGA_RJ";
                objComando.agregarINParametro("p_corr_rj", OracleDbType.Int64, request.P_CORR_RJ);
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BENEFICIARIO);
                objComando.agregarINParametro("p_carga", OracleDbType.Int64, request.P_CARGA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al actualizar carga retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaRj(OracleConnection cnx, ObtieneListaRjRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_LISTA_RETJUD";
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet AgregaRj(OracleConnection cnx, AgregaRjRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_AGREGA_RETJUD";
                objComando.agregarINParametro("p_corr", OracleDbType.Int64, request.P_CORR);
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BENEFICIARIO);
                objComando.agregarINParametro("p_grp", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarINParametro("p_id_ben_rj", OracleDbType.Int64, request.P_ID_BEN_RJ);
                objComando.agregarINParametro("p_frm", OracleDbType.Int64, request.P_FRM);
                objComando.agregarINParametro("p_nro_exp", OracleDbType.Varchar2, request.P_NRO_EXP);
                objComando.agregarINParametro("p_fec_emi", OracleDbType.Varchar2, request.P_FEC_EMI);
                objComando.agregarINParametro("p_fec_rcp", OracleDbType.Varchar2, request.P_FEC_RCP);
                objComando.agregarINParametro("p_juez", OracleDbType.Varchar2, request.P_JUEZ);
                objComando.agregarINParametro("p_prc", OracleDbType.Double, double.Parse(request.P_PRC.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_mto", OracleDbType.Double, double.Parse(request.P_MTO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_mes_ini", OracleDbType.Int64, request.P_MES_INI);
                objComando.agregarINParametro("p_dir", OracleDbType.Varchar2, request.P_DIR);
                objComando.agregarINParametro("p_cmn", OracleDbType.Varchar2, request.P_CMN);
                objComando.agregarINParametro("p_ciu", OracleDbType.Varchar2, request.P_CIU);
                objComando.agregarINParametro("p_suc_ta", OracleDbType.Int64, request.P_SUC_TA);
                objComando.agregarINParametro("p_bco_nn", OracleDbType.Int64, request.P_BCO_NN);
                objComando.agregarINParametro("p_cta_cr", OracleDbType.Int64, request.P_CTA_CR);
                objComando.agregarINParametro("p_rst", OracleDbType.Int64, request.P_RST);
                objComando.agregarINParametro("p_forma_pago", OracleDbType.Int64, request.P_FORMA_PAGO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al agregar retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneSecuenciaRj(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_SEC_RET_JUD";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener secuencia retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneRetencionesJud(OracleConnection cnx, ObtieneRetencionesJudRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_RETENCIONES_JUD";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_grp", OracleDbType.Int64, request.P_GRUPO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener retenciones judiciales" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneMontoPensionVejInv(OracleConnection cnx, ObtienePensionVejInvRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_ULTIMA_PENSION";
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_grp", OracleDbType.Int64, request.P_GRP);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener pension vejez e invalidez" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneMontoPensionSobre(OracleConnection cnx, ObtienePensionSobreRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_ULTIMA_PEN_BEN";
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_grp", OracleDbType.Int64, request.P_GRP);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener pension sobrevivencia" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet CheckRetJudicial(OracleConnection cnx, CheckRetJudicialRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_CHECK_RET_JUD";
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_benRJ", OracleDbType.Int64, request.P_BENRJ);
                objComando.agregarINParametro("p_expediente", OracleDbType.Varchar2, request.P_EXPEDIENTE);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validar retencion judicial anterior" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtienePeriodoActual(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_PERIODO_ACTUAL";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener periodo actual" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }

        public DataSet CheckRetJud(OracleConnection cnx, CheckRetJudRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_RETENCIONES_JUD";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_cau", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BENEFICIARIO);
                objComando.agregarINParametro("p_benRJ", OracleDbType.Int64, request.P_BENEFICIARIO_RJ);
                objComando.agregarINParametro("p_expediente", OracleDbType.Varchar2, request.P_EXPEDIENTE);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validar retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaRjParaEliminar(OracleConnection cnx, ObtieneListaRjParaEliminarRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTENER_LISTA_RETJUD";
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
                throw new Exception("Error al obtener lista rj para eliminar" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet BorraRetencionJudicial(OracleConnection cnx, BorraRetencionJudicialRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_BORRA_RET_JUD";
                objComando.agregarINParametro("p_corr", OracleDbType.Int64, request.P_CORR);
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_LINEA);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_PRODUCTO);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_DOCUMENTO);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_causante", OracleDbType.Int64, request.P_CAUSANTE);
                objComando.agregarINParametro("p_tipo", OracleDbType.Int64, request.P_TIPO);
                objComando.agregarINParametro("p_user", OracleDbType.Int64, request.P_USER);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al borrar retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneEstadoGe(OracleConnection cnx, ObtenerEstadoGeRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_EST_GE";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener estado ge retencion judicial" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet CheckTieneGarantiaEstatal(OracleConnection cnx, CheckTieneGarantiaEstatalRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_TIENE_GARANTIA_ESTATAL";
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al check tiene garantia estatal" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneMontoMinimo(OracleConnection cnx, ObtieneMontoMinimoPensionRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_MONTO_PEN_MIN";
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRD);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_ase", OracleDbType.Int64, request.P_ASE);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_per", OracleDbType.Int64, request.P_PER);
                objComando.agregarINParametro("p_relacion", OracleDbType.Int64, request.P_RELACION);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener monto minimo" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneMontoBonoPension(OracleConnection cnx, ObtieneBonoMontoMinimoPensionRequest request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_BONO_PEN_MIN";
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_PRD);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_POL);
                objComando.agregarINParametro("p_ase", OracleDbType.Int64, request.P_ASE);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_per", OracleDbType.Int64, request.P_PER);
                objComando.agregarINParametro("p_relacion", OracleDbType.Int64, request.P_RELACION);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener monto minimo" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaFormaDescuentos(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_CODIGOS_FORMA_DESC";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista forma descuentos" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneValidacionFechas(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_VAL_FECHAS";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al validacion fechas" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaAsignacionFamiliar(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_CODIGOS_SI_NO";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista asignacion familiar" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaFormaPago(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_CODIGOS_FORMA_PAGO";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista forma pago" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneListaBancos(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_RETENCIONJUDICIAL.P_OBTIENE_CODIGOS_BANCOS";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista bancos" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
        public DataSet ObtieneDatosControlDocto(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_CONTROLDOC.P_OBT_RECEPCIONDOC_RETJUD";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener lista bancos" + ex.Message);
            } finally {
                cnx.Dispose();

            }
        }
    }
}
