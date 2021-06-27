using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Models {
    public class GarantiaEstatalModel {

        public class ObtieneListaBeneficiariosRequestModel {
            public Int64 P_POLIZA { get; set; }
        }
        public class ObtieneListaBeneficiariosResponseModel {
            public Int64 BEN_RELACION { get; set; }
            public Int64 NAT_ID { get; set; }
            public string NAT_NOMBRE { get; set; }
            public string NAT_AP_PAT { get; set; }
            public string NAT_AP_MAT { get; set; }
            public Int64 NAT_NUMRUT { get; set; }
            public string NAT_DV { get; set; }
            public string DESC_RELACION { get; set; }
            public Int64 BNF_GRP_PAG { get; set; }
            public Int64 BNF_GRUPO { get; set; }
            public string CALLE { get; set; }
            public string COMUNA { get; set; }
            public string CIUDAD { get; set; }
            public string TELEFONO1 { get; set; }

            public string NACIONALIDAD { get; set; }
            public string ESTCIVIL { get; set; }
            public string PROFESION { get; set; }

        }
        public class ObtieneDatosSolicitudGeRequestModel {
            public Int64 P_POLIZA { get; set; }

        }
        public class ObtieneDatosSolicitudGeResponseModel {
            public Int64 SOL_CORR_ID { get; set; }
            public Int64 SOL_BEN_NN { get; set; }
            public Int64 SOL_POL_NN { get; set; }
            public Int64 SOL_TIP_NN { get; set; }
            public Int64 SOL_SUC_TA { get; set; }
            public string SOL_FEC_SOL_FC { get; set; }

        }
        public class ObtieneGrupoPagoRequestModel {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_GRUPO { get; set; }

        }
        public class ObtieneGrupoPagoResponseModel {
            public Int64 GRP_GRUPO { get; set; }
            public Int64 GRP_ISAPRE { get; set; }
            public Int64 NAT_ID { get; set; }
            public string NAT_NOMBRE { get; set; }
            public string NAT_AP_PAT { get; set; }
            public string NAT_AP_MAT { get; set; }
            public Int64 NAT_NUMRUT { get; set; }
            public string NAT_DV { get; set; }
            public Int64 GRP_LIQ { get; set; }
            public Int64 GRP_ID_DOM { get; set; }
            public string NACIONALIDAD { get; set; }
            public string DESCRIPCION_NACIONALIDAD { get; set; }
            public string PROFESION { get; set; }
            public string DESCRIPCION_PROFESION { get; set; }
            public string ESTADOGE { get; set; }
            public string DESCRIPCIONESTADOGE { get; set; }
            public Int64 ID_RELACION { get; set; }
            public string DESC_RELACION { get; set; }

            public string CALLE { get; set; }
            public string COMUNA { get; set; }
            public string CIUDAD { get; set; }
            public string TELEFONO1 { get; set; }
            public string TELEFONO2 { get; set; }
            public string PROVINCIA { get; set; }


        }
        public class ValidaSiContinuaSegundaTablaRequestModel {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_GRUPO { get; set; }

        }
        public class ValidaSiContinuaSegundaTablaResponseModel {

            public Int64 NAT_ID { get; set; }
        }
        public class ObtieneDatosControlDoctoRequestModel {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_IDBEN { get; set; }
            public string P_TIPOSOL { get; set; }

        }
        public class ObtieneDatosControlDoctoResponseModel {

            public Int64 IDTRANSACCION { get; set; }
            public Int64 NUMRELACION { get; set; }
            public string MOVIMIENTO { get; set; }
            public string ESTADO { get; set; }
            public Int64 IDACTIVIDADESP { get; set; }
            public Int64 CARACTERISTICA { get; set; }
            public string MODALIDADPOLIZA { get; set; }
            public string IDACTIVIDAD { get; set; }
            public Int64 IDPROCESO { get; set; }
            public Int64 CRPROCESO { get; set; }
            public Int64 CAUSALEXTINCION { get; set; }
            public Int64 IDPODER { get; set; }
            public Int64 INDFALLECIMIENTO { get; set; }
            public Int64 INDTIPOCERTCIVIL { get; set; }
            public Int64 INDFORMAPAGO { get; set; }


        }
        public class ValidaSolicitudGeRequestModel {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_TIPO { get; set; }
            public Int64 P_RST { get; set; }
            public Int64 P_BEN_ID { get; set; }

        }
        public class ValidaSolicitudGeResponseModel {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ValidaExisteSolicitudGeResponseModel {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ValidaExisteSolicitudGeRequestModel {
            public Int64 P_LINEA { get; set; }
            public Int64 P_POLIZA { get; set; }
            public Int64 P_TIPO { get; set; }
            public Int64 P_BEN_ID { get; set; }

        }
        public class ObtieneEstadoGeResponseModel {
            public string ESTADOGE { get; set; }
        }
        public class ObtieneEstadoGeRequestModel {
            public Int64 P_POLIZA { get; set; }
            public Int64 P_CAUSA { get; set; }
            public Int64 P_BEN { get; set; }
            public Int64 P_LIN { get; set; }

        }
        public class ObtieneCheckEstadoGeResponseModel {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ObtieneCheckEstadoGeRequestModel {
            public Int64 P_POL { get; set; }
            public Int64 P_CAU { get; set; }
            public Int64 P_BEN { get; set; }
            public string P_EST { get; set; }
            public Int64 P_COD { get; set; }

        }
        public class ExisteBenApsResponseModel {
            public Int64 P_RESULTADO { get; set; }
        }
        public class IngresaSolicitudGeRequestModel {
            public string P_ID_CRE { get; set; }
            public Int64 P_POL { get; set; }
            public string P_FEC_SOL { get; set; }
            public Int64 P_IDBEN { get; set; }
            public string P_RUTEJECUTIVO { get; set; }
            public string P_SUCURSAL { get; set; }
        }
        public class IngresaSolicitudGeResponseModel {
            public Int64 P_RESULTADO { get; set; }
        }
        public class ExisteBenApsRequestModel {
            public Int64 P_POL { get; set; }
            public Int64 P_BEN { get; set; }
            public Int64 P_LIN { get; set; }

        }
        public class ObtieneGrupoPagoPolizaRequestModel {
            public Int64 P_POLIZA { get; set; }
            public string P_TIPOBEN { get; set; }
            public string P_SITUACION { get; set; }

        }
        public class ObtieneGrupoPagoPolizaResponseModel {
            public Int64 ID { get; set; }
            public Int64 IDGRUPOPAGO { get; set; }
            public Int64 IDGRUPOFAMILIAR { get; set; }
            public Int64 ULTIMOPERIODOLIQ { get; set; }
            public string IDTIPOBENEFICIARIO { get; set; }
            public string DESCTIPOBENEFICIARIO { get; set; }
            public string IDESTADO { get; set; }
            public string DESCESTADO { get; set; }
            public string IDSITUACIONPAGO { get; set; }
            public string DESCSITUACIONPAGO { get; set; }
            public Int64 IDRELACION { get; set; }
            public string DESCRELACION { get; set; }
            public string NOMBRE { get; set; }
            public string APELLIDOPATERNO { get; set; }
            public string APELLIDOMATERNO { get; set; }
            public Int64 NUMERORUT { get; set; }
            public string DVRUT { get; set; }
            public string TIENE_CARGAS { get; set; }
            public string TIENE_CERT_CIVIL { get; set; }
            public string TIENE_CERT_ESTUDIO { get; set; }
            public string TIENE_DEC_RENTA { get; set; }
            public string TIENE_LIQUIDACION { get; set; }
            public string TIENE_FUN { get; set; }
            public string TIENE_MANDATO { get; set; }
            public string TIENE_PNC { get; set; }
        }
        public class ObtieneListaGrupoPagoRequestModel {
            public Int64 P_POLIZA { get; set; }

        }
        public class ObtieneListaGrupoPagoResponseModel {
            public Int64 GRP_GRUPO { get; set; }
            public Int64 NAT_ID { get; set; }
            public string NAT_NOMBRE { get; set; }
            public string NAT_AP_PAT { get; set; }
            public string NAT_AP_MAT { get; set; }
            public Int64 NAT_NUMRUT { get; set; }
            public string NAT_DV { get; set; }
            public string DESC_RELACION { get; set; }
            public string NACIONALIDAD { get; set; }
            public string DESCRIPCION_NACIONALIDAD { get; set; }
            public string PROFESION { get; set; }
            public string DESCRIPCION_PROFESION { get; set; }
            public string ESTADOGE { get; set; }
            public Int64 ID_RELACION { get; set; }
            public string DESCRIPCIONESTADOGE { get; set; }
            public Int64 EDAD { get; set; }
        }
    }
}
