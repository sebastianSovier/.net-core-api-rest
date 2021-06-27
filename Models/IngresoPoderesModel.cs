using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Models {
    public class IngresoPoderesModel {

        public class ObtieneTiposPoderesResponse {
            public Int64 ID { get; set; }
            public string TEXTO { get; set; }
            public string ID_TEXTO { get; set; }
            public Int64 OTRO { get; set; }
        }
        public class AgregaPoderRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_GRUPO { get; set; }
            public Int64 P_ID_REPRE { get; set; }
            public Int64 P_ID_RECEP { get; set; }
            public string P_FECHANOTIFICACION { get; set; }
            public string P_FECHASUSCRIPCION { get; set; }
            public string P_FECHAVENCIMIENTO { get; set; }
            public Int64 P_TIPOPODER { get; set; }
            public Int64 P_RST { get; set; }
        }
        public class AgregaPoderResponse {
            public Int64 P_RESULTADO { get; set; }
        }

        public class IngresaPoderMfpRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_COBERTURA { get; set; }
            public Int64 P_PERIODO { get; set; }
            public Int64 P_CTA_BCO { get; set; }
            public string P_BANCO { get; set; }
            public Int64 P_MES { get; set; }

        }
        public class IngresaPoderMfpResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class AutorizaPoderMfpRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }

        }
        public class AutorizaPoderMfpResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class CheckPoderRequest {
            public Int64 P_TIPOPODER { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_ID_RECEP { get; set; }

        }
        public class CheckPoderResponse {
            public Int64 CONT { get; set; }

        }
        public class ObtieneListaPoderesRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }

            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_USER { get; set; }
            public Int64 P_TIPO { get; set; }

        }
        public class ObtieneListaPoderesResponse {
            public Int64 POD_CORR { get; set; }
            public string POD_FEC_INICIO { get; set; }
            public string POD_FEC_TERMINO { get; set; }
            public Int64 POD_ID_RECEPTOR { get; set; }
            public Int64 NAT_NUMRUT { get; set; }
            public string NAT_DV { get; set; }

        }
        public class AnulaUltimoPoderRequest {
            public Int64 P_LINEA { get; set; }
            public Int64 P_DOCUMENTO { get; set; }
            public Int64 P_PRODUCTO { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSANTE { get; set; }
            public Int64 P_GRUPO { get; set; }
            public Int64 P_REPRESENTANTE { get; set; }
        }
        public class AnulaUltimoPoderResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class BorraPoderesRequest {
            public Int64 P_CORRELATIVO { get; set; }
            public Int64 P_USER { get; set; }
            public Int64 P_TIPO { get; set; }
        }
        public class BorraPoderesResponse {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtieneDatosControlDoctoRequestModel {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_IDBEN { get; set; }
            public Int64 P_TIPOPODER { get; set; }
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
