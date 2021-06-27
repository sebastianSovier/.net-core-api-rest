using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pensiones.api.Models {
    public class IngresaActualizaCuotaMortuariaRequestModel {
        public Int64 P_CUO_LIN { get; set; }
        public Int64 P_CUO_PRD { get; set; }
        public Int64 P_CUO_DOC { get; set; }
        public Int64 P_CUO_POL { get; set; }
        public Int64 P_CUO_RUT_RECEPTOR { get; set; }
        public string P_CUO_DV_RECEPTOR { get; set; }
        public string P_CUO_NOM_RECEPTOR { get; set; }
        public Int64 P_CUO_RUT_EMPRESA { get; set; }
        public string P_CUO_DV_EMPRESA { get; set; }
        public string P_CUO_NOM_EMPRESA { get; set; }
        public string P_CUO_SUC_EMPRESA { get; set; }
        public Int64 P_CUO_NUM_FACTURA { get; set; }
        public string P_CUO_FEC_FACTURA { get; set; }
        public Double P_CUO_MTO_APROBADO { get; set; }
        public Double P_CUO_MTO_COBRADO { get; set; }
        public string P_CUO_FEC_SOLICITUD { get; set; }
        public string P_CUO_FEC_PAGO { get; set; }
        public string P_CUO_FEC_LIQUIDA { get; set; }
        public Int64 P_CUO_SUCURSAL { get; set; }
        public Double P_CUO_MTO_PAGO { get; set; }
        public Double P_CUO_MTO_LIQUIDO { get; set; }
        public Double P_CUO_SALDO { get; set; }
        public Int64 P_CUO_ESTADO { get; set; }
    }
    public class IngresaActualizaCuotaMortuariaResponseModel {
        public Int64 P_RESULTADO { get; set; }

    }
    public class ObtieneCuotaMortuariaRequestModel {
        public Int64 P_CUO_LIN { get; set; }
        public Int64 P_CUO_PRD { get; set; }
        public Int64 P_CUO_DOC { get; set; }
        public Int64 P_CUO_POL { get; set; }

    }

    public class ActualizaAtributoSieteRequestModel {
        public Int64 P_CUO_LIN { get; set; }
        public Int64 P_CUO_PRD { get; set; }
        public Int64 P_CUO_DOC { get; set; }
        public Int64 P_CUO_POL { get; set; }

    }
    public class ActualizaAtributoSieteResponseModel {
        public Int64 P_RESULTADO { get; set; }

    }
    public class ObtieneCuotaMortuariaResponseModel {
        public Int64 CUO_RUT_RECEPTOR { get; set; }
        public string CUO_DV_RECEPTOR { get; set; }
        public string CUO_NOM_RECEPTOR { get; set; }
        public Int64 CUO_RUT_EMPRESA { get; set; }
        public string CUO_DV_EMPRESA { get; set; }
        public string CUO_NOM_EMPRESA { get; set; }
        public string CUO_SUC_EMPRESA { get; set; }
        public Int64 CUO_NUM_FACTURA { get; set; }
        public string CUO_FEC_FACTURA { get; set; }
        public Double CUO_MTO_APROBADO { get; set; }
        public Double CUO_MTO_COBRADO { get; set; }
        public string CUO_FEC_SOLICITUD { get; set; }
        public string CUO_FEC_PAGO { get; set; }
        public string CUO_FEC_LIQUIDA { get; set; }
        public Int64 CUO_SUCURSAL { get; set; }
        public string SUC_NOMB { get; set; }
        public Double CUO_MTO_PAGO { get; set; }
        public Double CUO_MTO_LIQUIDO { get; set; }
        public Double CUO_SALDO { get; set; }
        public Int64 CUO_ESTADO { get; set; }
        public string ESTADO_TEXTO { get; set; }
        public string FECHA_SOLICITUD_DDMMYYYY { get; set; }
        public string FECHA_FACTURA_DDMMYYYY { get; set; }
    }
    public class ObtieneCertificadoDefuncionRequestModel {
        public Int64 P_LIN { get; set; }
        public Int64 P_BEN { get; set; }
        public Int64 P_TIP { get; set; }

    }
    public class ObtieneCertificadoDefuncionResponseModel {
        public string P_RESULTADO { get; set; }

    }
    public class ObtieneSucursalesResponseModel {
        public Int64 ID { get; set; }
        public string TEXTO { get; set; }
        public string ID_TEXTO { get; set; }

    }
    public class ObtienePersonaRequestModel {
        public Int64 P_PRUT { get; set; }
    }
    public class ObtienePersonaResponseModel {
        public Int64 NAT_NUMRUT { get; set; }
        public string NAT_AP_PAT { get; set; }
        public string NAT_AP_MAT { get; set; }
        public string NAT_NOMBRE { get; set; }
        public Int64 NAT_ID { get; set; }
        public string NAT_FEC_NACIM { get; set; }
        public string NAT_SEXO { get; set; }
        public string NAT_RST { get; set; }
    }
    public class ObtieneCausanteRequestModel {
        public Int64 P_PERSONA_RUT { get; set; }
        public Int64 P_POLIZA { get; set; }
    }
    public class ObtieneCausanteResponseModel {
        public Int64 NAT_ID { get; set; }
        public string NAT_NOMBRE { get; set; }
        public string NAT_AP_PAT { get; set; }
        public string NAT_AP_MAT { get; set; }
        public Int64 NAT_NUMRUT { get; set; }
        public string NAT_DV { get; set; }
        public string NAT_FEC_MUERTE { get; set; }
        public string NAT_FEC_NACIM { get; set; }
        public string FECHAINVALIDEZ { get; set; }
        public Int64 EDAD { get; set; }
        public string SEXO { get; set; }

    }
    public class ObtienePolizaRequestModel { //1 SOBREVIVENCIA // 8 vejez // 2 invalidez
        public Int64 P_POLIZA { get; set; }
    }
    public class ObtienePolizaResponseModel {
        public Int64 NAT_ID { get; set; }
        public Int64 POL_LINEA { get; set; }
        public Int64 POL_PRODUCTO { get; set; }
        public Int64 POL_DOCUMENTO { get; set; }
        public Int64 POL_POLIZA { get; set; }
        public Int64 POL_ATRB06 { get; set; }
        public Int64 POL_ATRB07 { get; set; }
        public Int64 NUM_RUT_NAT { get; set; }
        public string FEC_INICIO_PAGO { get; set; }
        public Int64 SIN_TIPO { get; set; }

    }
    public class GuardarPersonaRequestModel {
        public Int64 P_RUT { get; set; }
        public string P_DV { get; set; }
        public string P_NOMBRE { get; set; }
        public string P_APE_PAT { get; set; }
        public string P_APE_MAT { get; set; }
    }
    public class GuardarPersonaResponseModel {
        public Int64 P_RESULTADO { get; set; }

    }
    public class ObtieneValorUfRequestModel {
        public string P_FECHA { get; set; }
    }
    public class ObtieneValorUfResponseModel {
        public Double MONTO { get; set; }

    }
    public class RespuestaControlDocumentosRequestModel {
        public Int64 P_TRANSACCION { get; set; }
        public string P_CIA { get; set; }
        public string P_PROCESO { get; set; }
        public Int64 P_POLIZA { get; set; }
        public Int64 P_RUTCLIENTE { get; set; }
    }
    public class RespuestaControlDocumentosResponseModel {
        public Int64 REMESABLE { get; set; }

    }


    public class ObtieneDatosControlDoctoRequestModel {
        public Int64 P_POLIZA { get; set; }
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
    public class ObtieneDatosEjecutivoRequestModel {
        public string IDEJECUTIVO { get; set; }
    }
    public class ObtieneDatosEjecutivoResponseModel {
        public Int64 CODIGOCARGO { get; set; }
        public string CARGO { get; set; }
        public Int64 CODIGOCENTROCOSTO { get; set; }
        public string CENTROCOSTO { get; set; }
        public Int64 CODIGOSUCURSAL { get; set; }
        public string SUCURSAL { get; set; }
        public string FECHAINGRESO { get; set; }
        public string FECHAFINIQUITO { get; set; }
        public string CODIGOMARCA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOPATERNO { get; set; }
        public string APELLIDOMATERNO { get; set; }
        public Int64 RUTEMPLEADO { get; set; }
        public string DIGITORUTEMPLEADO { get; set; }
        public string EMAIL { get; set; }
        public Int64 RUTJEFATURA { get; set; }
        public string DIGITORUTJEFATURA { get; set; }
        public string USUARIODATABASE { get; set; }
        public string USUARIONT { get; set; }

    }
    public class ObtieneBeneficiarioRequestModel {
        public Int64 P_CUO_LIN { get; set; }
        public Int64 P_CUO_PRD { get; set; }
        public Int64 P_CUO_DOC { get; set; }
        public Int64 P_CUO_POL { get; set; }
        public Int64 P_BEN { get; set; }
    }
    public class ObtieneBeneficiarioResponseModel {
        public Int64 BNF_GRUPO { get; set; }

        public Int64 BEN_RELACION { get; set; }

    }
}
