using Oracle.ManagedDataAccess.Client;
using pensiones.api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Dal {
    public class CuotaMortuariaDal {
        public DataSet IngresoCuotaMortuaria(OracleConnection cnx, IngresaActualizaCuotaMortuariaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_AGREGA_CUOTA_MORT";
                objComando.agregarINParametro("p_cuo_lin", OracleDbType.Int64, request.P_CUO_LIN);//3
                objComando.agregarINParametro("p_cuo_prd", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_cuo_doc", OracleDbType.Int64, request.P_CUO_DOC);//2
                objComando.agregarINParametro("p_cuo_pol", OracleDbType.Int64, request.P_CUO_POL);//viene en url 
                objComando.agregarINParametro("p_cuo_rut_recep", OracleDbType.Int64, request.P_CUO_RUT_RECEPTOR);
                objComando.agregarINParametro("p_cuo_dv_recep", OracleDbType.Varchar2, request.P_CUO_DV_RECEPTOR);
                objComando.agregarINParametro("p_cuo_nom_recep", OracleDbType.Varchar2, request.P_CUO_NOM_RECEPTOR);
                objComando.agregarINParametro("p_cuo_rut_empresa", OracleDbType.Int64, request.P_CUO_RUT_EMPRESA);
                objComando.agregarINParametro("p_cuo_dv_empresa", OracleDbType.Varchar2, request.P_CUO_DV_EMPRESA);
                objComando.agregarINParametro("p_cuo_nom_empresa", OracleDbType.Varchar2, request.P_CUO_NOM_EMPRESA);
                objComando.agregarINParametro("p_cuo_suc_empresa", OracleDbType.Varchar2, request.P_CUO_SUC_EMPRESA);
                objComando.agregarINParametro("p_cuo_num_factura", OracleDbType.Int64, request.P_CUO_NUM_FACTURA);
                objComando.agregarINParametro("p_cuo_fec_factura", OracleDbType.Varchar2, request.P_CUO_FEC_FACTURA);
                objComando.agregarINParametro("p_cuo_mto_aprobado", OracleDbType.Int64, request.P_CUO_MTO_APROBADO);
                objComando.agregarINParametro("p_cuo_mto_cobrado", OracleDbType.Int64, request.P_CUO_MTO_COBRADO);
                objComando.agregarINParametro("p_cuo_fec_solicitud", OracleDbType.Varchar2, request.P_CUO_FEC_SOLICITUD);
                objComando.agregarINParametro("p_cuo_fec_pago", OracleDbType.Varchar2, request.P_CUO_FEC_PAGO);
                objComando.agregarINParametro("p_cuo_fec_liquida", OracleDbType.Varchar2, request.P_CUO_FEC_LIQUIDA);
                objComando.agregarINParametro("p_cuo_sucursal", OracleDbType.Int64, request.P_CUO_SUCURSAL);
                objComando.agregarINParametro("p_cuo_mto_pago", OracleDbType.Int64, request.P_CUO_MTO_PAGO);
                objComando.agregarINParametro("p_cuo_mto_liquido", OracleDbType.Double, double.Parse(request.P_CUO_MTO_LIQUIDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_cuo_saldo", OracleDbType.Double, double.Parse(request.P_CUO_SALDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_cuo_estado", OracleDbType.Int64, request.P_CUO_ESTADO);
                objComando.agregarOUTParametro("p_cuo_resultado", OracleDbType.Int32, 5);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al ingresar cuota mortuaria" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ActualizaCuotaMortuaria(OracleConnection cnx, IngresaActualizaCuotaMortuariaRequestModel request) {
            MCommand objComando = new MCommand();

            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_ACTUALIZA_CUOTA_MORTUORIA";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_CUO_LIN);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_CUO_DOC);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_CUO_POL);
                objComando.agregarINParametro("p_rut_recep", OracleDbType.Int64, request.P_CUO_RUT_RECEPTOR);
                objComando.agregarINParametro("p_dv_recep", OracleDbType.Varchar2, request.P_CUO_DV_RECEPTOR);
                objComando.agregarINParametro("p_nom_recep", OracleDbType.Varchar2, request.P_CUO_NOM_RECEPTOR);
                objComando.agregarINParametro("p_rut_empresa", OracleDbType.Int64, request.P_CUO_RUT_EMPRESA);
                objComando.agregarINParametro("p_dv_empresa", OracleDbType.Varchar2, request.P_CUO_DV_EMPRESA);
                objComando.agregarINParametro("p_nom_empresa", OracleDbType.Varchar2, request.P_CUO_NOM_EMPRESA);
                objComando.agregarINParametro("p_suc_empresa", OracleDbType.Varchar2, request.P_CUO_SUC_EMPRESA);
                objComando.agregarINParametro("p_num_factura", OracleDbType.Int64, request.P_CUO_NUM_FACTURA);
                objComando.agregarINParametro("p_fec_factura", OracleDbType.Varchar2, request.P_CUO_FEC_FACTURA);
                objComando.agregarINParametro("p_mto_aprobado", OracleDbType.Int64, request.P_CUO_MTO_APROBADO);
                objComando.agregarINParametro("p_mto_cobrado", OracleDbType.Int64, request.P_CUO_MTO_COBRADO);
                objComando.agregarINParametro("p_fec_solicitud", OracleDbType.Varchar2, request.P_CUO_FEC_SOLICITUD);
                objComando.agregarINParametro("p_fec_pago", OracleDbType.Varchar2, request.P_CUO_FEC_PAGO);
                objComando.agregarINParametro("p_fec_liquida", OracleDbType.Varchar2, request.P_CUO_FEC_LIQUIDA);
                objComando.agregarINParametro("p_sucursal", OracleDbType.Int64, request.P_CUO_SUCURSAL);
                objComando.agregarINParametro("p_mto_pago", OracleDbType.Int64, request.P_CUO_MTO_PAGO);
                objComando.agregarINParametro("p_mto_liquido", OracleDbType.Double, double.Parse(request.P_CUO_MTO_LIQUIDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_saldo", OracleDbType.Double, double.Parse(request.P_CUO_SALDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_estado", OracleDbType.Int64, request.P_CUO_ESTADO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int32, 5);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al actualizar cuota mortuaria" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet IngresaNuevaCuotaMortuaria(OracleConnection cnx, IngresaActualizaCuotaMortuariaRequestModel request) {
            MCommand objComando = new MCommand();

            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_INSERT_CUOTA_MORTUORIA ";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_CUO_LIN);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_CUO_DOC);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_CUO_POL);
                objComando.agregarINParametro("p_rut_recep", OracleDbType.Int64, request.P_CUO_RUT_RECEPTOR);
                objComando.agregarINParametro("p_dv_recep", OracleDbType.Varchar2, request.P_CUO_DV_RECEPTOR);
                objComando.agregarINParametro("p_nom_recep", OracleDbType.Varchar2, request.P_CUO_NOM_RECEPTOR);
                objComando.agregarINParametro("p_rut_empresa", OracleDbType.Int64, request.P_CUO_RUT_EMPRESA);
                objComando.agregarINParametro("p_dv_empresa", OracleDbType.Varchar2, request.P_CUO_DV_EMPRESA);
                objComando.agregarINParametro("p_nom_empresa", OracleDbType.Varchar2, request.P_CUO_NOM_EMPRESA);
                objComando.agregarINParametro("p_suc_empresa", OracleDbType.Varchar2, request.P_CUO_SUC_EMPRESA);
                objComando.agregarINParametro("p_num_factura", OracleDbType.Int64, request.P_CUO_NUM_FACTURA);
                objComando.agregarINParametro("p_fec_factura", OracleDbType.Varchar2, request.P_CUO_FEC_FACTURA);
                objComando.agregarINParametro("p_mto_aprobado", OracleDbType.Double, double.Parse(request.P_CUO_MTO_APROBADO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_mto_cobrado", OracleDbType.Double, double.Parse(request.P_CUO_MTO_COBRADO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_fec_solicitud", OracleDbType.Varchar2, request.P_CUO_FEC_SOLICITUD);
                objComando.agregarINParametro("p_fec_pago", OracleDbType.Varchar2, request.P_CUO_FEC_PAGO);
                objComando.agregarINParametro("p_fec_liquida", OracleDbType.Varchar2, request.P_CUO_FEC_LIQUIDA);
                objComando.agregarINParametro("p_sucursal", OracleDbType.Int64, request.P_CUO_SUCURSAL);
                objComando.agregarINParametro("p_mto_pago", OracleDbType.Double, double.Parse(request.P_CUO_MTO_PAGO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_mto_liquido", OracleDbType.Double, double.Parse(request.P_CUO_MTO_LIQUIDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_saldo", OracleDbType.Double, double.Parse(request.P_CUO_SALDO.ToString().Replace(".", ",")));
                objComando.agregarINParametro("p_estado", OracleDbType.Int64, request.P_CUO_ESTADO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int32, 5);


                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al ingresar nueva cuota mortuaria" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneCuotaMortuaria(OracleConnection cnx, ObtieneCuotaMortuariaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_CUOTA_MORT";
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_CUO_LIN);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_CUO_DOC);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_CUO_POL);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al actualizar cuota mortuaria" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ActualizaAtributoSiete(OracleConnection cnx, ActualizaAtributoSieteRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_ACTUALIZA_ATRIB_7";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_CUO_LIN);
                objComando.agregarINParametro("p_prd", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_doc", OracleDbType.Int64, request.P_CUO_DOC);
                objComando.agregarINParametro("p_pol", OracleDbType.Int64, request.P_CUO_POL);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int32, 5);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al actualizar atributo siete" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneDatosControlDocto(OracleConnection cnx, ObtieneDatosControlDoctoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dr = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_CONTROLDOC.P_OBT_RECEPCIONDOC_CMORT";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dr = objComando.ejecutarRefCursorSP();

                return dr;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos control docto" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ValidarCertificadoDefuncion(OracleConnection cnx, ObtieneCertificadoDefuncionRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet response = new DataSet();
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_CHECK_CERTIFICADO_DEFUN";
                objComando.agregarINParametro("p_lin", OracleDbType.Int64, request.P_LIN);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarINParametro("p_tip", OracleDbType.Int64, request.P_TIP);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                return objComando.ejecutarRefCursorSP();
            } catch (Exception ex) {
                throw new Exception("Error al obtener certificado de defuncion" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }

        public DataSet ObtenerSucursales(OracleConnection cnx) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_CODIGOS_SUCURSALES";
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener sucursales" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtienePersona(OracleConnection cnx, ObtienePersonaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_BUSCA_PERSONA_RUT";
                objComando.agregarINParametro("p_prut", OracleDbType.Int64, request.P_PRUT);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener persona" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneCausante(OracleConnection cnx, ObtieneCausanteRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_CAUSANTE";
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
        public DataSet ObtienePoliza(OracleConnection cnx, ObtienePolizaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_GET_POLIZA_SCN";
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_POLIZA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos poliza" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtieneValorUf(OracleConnection cnx, ObtieneValorUfRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_VALOR_UF";
                objComando.agregarINParametro("p_fecha", OracleDbType.Varchar2, request.P_FECHA);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos poliza" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtienDatosEjecutivo(OracleConnection cnx, ObtieneDatosEjecutivoRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_CONSULTAUSUARIOSPW.P_infoUsuario";
                objComando.agregarINParametro("p_idUsuario", OracleDbType.Varchar2, request.IDEJECUTIVO);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos ejecutivo" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
        public DataSet ObtienDatosBeneficiario(OracleConnection cnx, ObtieneBeneficiarioRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PENSIONES_WEB.P_OBTIENE_BENEFICIARIO";
                objComando.agregarINParametro("p_linea", OracleDbType.Int64, request.P_CUO_LIN);
                objComando.agregarINParametro("p_producto", OracleDbType.Int64, request.P_CUO_PRD);
                objComando.agregarINParametro("p_documento", OracleDbType.Int64, request.P_CUO_DOC);
                objComando.agregarINParametro("p_poliza", OracleDbType.Int64, request.P_CUO_POL);
                objComando.agregarINParametro("p_ben", OracleDbType.Int64, request.P_BEN);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.RefCursor, 0);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al obtener datos beneficiario" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }

        public DataSet GuardarPersona(OracleConnection cnx, GuardarPersonaRequestModel request) {
            MCommand objComando = new MCommand();
            DataSet dt = null;
            try {
                // var a = Convert.ToDateTime(fecha_cambio);
                objComando.Connection = cnx;
                objComando.CommandText = "PKG_PWEB_PERSONA.PRC_AGREGAR_PERSONA_GE";
                objComando.agregarINParametro("P_RUT", OracleDbType.Int64, request.P_RUT);
                objComando.agregarINParametro("P_DV", OracleDbType.Varchar2, request.P_DV);
                objComando.agregarINParametro("P_NOMBRE", OracleDbType.Varchar2, request.P_NOMBRE);
                objComando.agregarINParametro("P_APE_PAT", OracleDbType.Varchar2, request.P_APE_PAT);
                objComando.agregarINParametro("P_APE_MAT", OracleDbType.Varchar2, request.P_APE_MAT);
                objComando.agregarOUTParametro("p_resultado", OracleDbType.Int64, 8);

                dt = objComando.ejecutarRefCursorSP();

                return dt;
            } catch (Exception ex) {
                throw new Exception("Error al guardar persona" + ex.Message);
            } finally {
                cnx.Dispose();
            }
        }
    }
}
