using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Models {
    public class RetencionJudicialModel {
        public class ActualizaCargaRjRequest {
            public Int64 P_CORR_RJ { get; set; }
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }

            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_BENEFICIARIO { get; set; }
            public Int64 P_CARGA { get; set; }

        }
        public class ActualizaCargaRjResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtieneValidacionFechasResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtienePensionVejInvRequest {
            public Int64 P_POL { get; set; }
            public Int64 P_GRP { get; set; }

        }
        public class ObtienePensionVejInvResponse {
            public Int64 MONTO { get; set; }
        }
        public class ObtienePensionSobreRequest {
            public Int64 P_POL { get; set; }
            public Int64 P_GRP { get; set; }
            public Int64 P_BEN { get; set; }
        }
        public class ObtienePensionsSobreResponse {
            public Int64 MONTO { get; set; }
        }
        public class CheckRetJudicialRequest {
            public Int64 P_POL { get; set; }
            public Int64 P_BEN { get; set; }
            public Int64 P_BENRJ { get; set; }
            public string P_EXPEDIENTE { get; set; }

        }
        public class CheckRetJudicialResponse {
            public Int64 CANT { get; set; }
        }
        public class ObtienePeriodoActualResponse {
            public string FECHA { get; set; }
        }
        public class ObtieneListaRjRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }

        }
        public class ObtieneListaRjResponse {
            public Int64 RJ_CORR { get; set; }
            public Int64 RJ_NRO_EXP { get; set; }
            public string NAT_NOMBRE { get; set; }
            public string NAT_AP_PAT { get; set; }
            public string NAT_AP_MAT { get; set; }
        }
        public class ObtieneRetencionesJudRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_GRUPO { get; set; }
        }
        public class ObtieneRetencionesJudResponse {
            public Int64 RJ_CORR { get; set; }
            public Int64 RJ_BEN { get; set; }
            public string NAT_NOMBRE { get; set; }
            public string BEN_RET_JUD { get; set; }
            public Double MONTO { get; set; }
        }
        public class AgregaRjRequest {
            public Int64 P_CORR { get; set; }
            public Int64 P_LINEA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_BENEFICIARIO { get; set; }
            public Int64 P_GRUPO { get; set; }
            public Int64 P_ID_BEN_RJ { get; set; }
            public Int64 P_FRM { get; set; }
            public string P_NRO_EXP { get; set; }
            public string P_FEC_EMI { get; set; }
            public string P_FEC_RCP { get; set; }
            public string P_JUEZ { get; set; }
            public double P_PRC { get; set; }
            public double P_MTO { get; set; }
            public Int64 P_MES_INI { get; set; }
            public string P_DIR { get; set; }
            public string P_CMN { get; set; }
            public string P_CIU { get; set; }
            public Int64 P_SUC_TA { get; set; }
            public Int64 P_BCO_NN { get; set; }
            public Int64 P_CTA_CR { get; set; }
            public Int64 P_RST { get; set; }
            public Int64 P_FORMA_PAGO { get; set; }
        }
        public class AgregaRjResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtieneSecuenciaRjResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class CheckRetJudRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_BENEFICIARIO { get; set; }
            public Int64 P_BENEFICIARIO_RJ { get; set; }
            public string P_EXPEDIENTE { get; set; }
        }
        public class CheckRetJudResponse {
            public Int64 CANTIDAD { get; set; }

        }
        public class ObtieneListaRjParaEliminarRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public string P_USER { get; set; }
            public Int64 P_TIPO { get; set; }
        }
        public class ObtieneListaRjParaEliminarResponse {
            public Int64 RJ_LIN { get; set; }
            public Int64 RJ_PRD { get; set; }
            public Int64 RJ_POL { get; set; }
            public Int64 RJ_DOC { get; set; }
            public Int64 RJ_CORR { get; set; }
            public Int64 RJ_ID_BEN_RJ { get; set; }
            public Int64 NAT_NUMRUT { get; set; }
            public string NAT_DV { get; set; }
            public string NRO_EXP { get; set; }


        }
        public class BorraRetencionJudicialRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_CORR { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public string P_USER { get; set; }
            public Int64 P_TIPO { get; set; }
        }

        public class BorraRetencionJudicialResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtieneMontoMinimoPensionRequest {
            public Int64 P_PRD { get; set; }
            public Int64 P_POL { get; set; }
            public Int64 P_ASE { get; set; }
            public Int64 P_BEN { get; set; }
            public Int64 P_PER { get; set; }
            public Int64 P_RELACION { get; set; }
        }

        public class ObtieneMontoMinimoPensionResponse {
            public Int64 PMIN_MTO_MENOR_70 { get; set; }
            public Int64 PMIN_MTO_MAYOR_70 { get; set; }
            public Int64 BON_MTO_MENOR_70 { get; set; }
            public Int64 BON_MTO_MAYOR_70 { get; set; }
            public Int64 PMIN_MTO_MTO_MAYOR_75 { get; set; }
            public Int64 BON_MAYOR_75 { get; set; }
        }
        public class ObtieneBonoMontoMinimoPensionRequest {
            public Int64 P_PRD { get; set; }
            public Int64 P_POL { get; set; }
            public Int64 P_ASE { get; set; }
            public Int64 P_BEN { get; set; }
            public Int64 P_PER { get; set; }
            public Int64 P_RELACION { get; set; }
        }

        public class ObtieneBonoMontoMinimoPensionResponse {
            public Int64 BON_MTO_MENOR_70 { get; set; }
            public Int64 BON_MTO_MAYOR_70 { get; set; }
            public Int64 BON_MAYOR_75 { get; set; }

        }
        public class ObtenerEstadoGeRequest {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_BEN { get; set; }
        }

        public class ObtenerEstadoGeResponse {
            public string ESTADOGE { get; set; }
        }
        public class CheckTieneGarantiaEstatalRequest {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_BEN { get; set; }
        }

        public class CheckTieneGarantiaEstatalResponse {
            public Int64 CGEEST { get; set; }
        }

        public class ObtieneListaFormaDescuentoResponse {
            public Int64 ID { get; set; }
            public string TEXTO { get; set; }
            public string ID_TEXTO { get; set; }


        }
        public class ObtieneListaAsigFamiliarResponse {
            public Int64 ID { get; set; }
            public string TEXTO { get; set; }
            public string ID_TEXTO { get; set; }

        }
        public class ObtieneListaBancosResponse {
            public Int64 ID { get; set; }
            public string TEXTO { get; set; }
            public string ID_TEXTO { get; set; }

        }
        public class ObtieneListaFormaPagoResponse {
            public Int64 ID { get; set; }
            public string TEXTO { get; set; }
            public string ID_TEXTO { get; set; }

        }
        public class ObtieneDatosControlDoctoResponseModel {
            public Int64 IDTRANSACCION { get; set; }
            public Int64 NUMRELACION { get; set; }
            public string MOVIMIENTO { get; set; }
            public string ESTADO { get; set; }
            public Int64 IDACTIVIDADESP { get; set; }
            public string CARACTERISTICA { get; set; }
            public string MODALIDADPOLIZA { get; set; }
            public string IDACTIVIDAD { get; set; }
            public string IDPROCESO { get; set; }
            public string CRPROCESO { get; set; }
            public Int64 CAUSALEXTINCION { get; set; }
            public Int64 IDPODER { get; set; }
            public Int64 INDFALLECIMIENTO { get; set; }
            public Int64 INDTIPOCERTCIVIL { get; set; }
            public Int64 INDFORMAPAGO { get; set; }

        }
    }
}
