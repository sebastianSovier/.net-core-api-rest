using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pensiones.api.Bo;
using static pensiones.api.Models.RetencionJudicialModel;

namespace pensiones.api.Controllers {
    [ApiController]
    public class RetencionJudicialController : ControllerBase {
        RetencionJudicialBo Bo = new RetencionJudicialBo();

        private readonly IConfiguration _config;

        public RetencionJudicialController(IConfiguration config) {
            _config = config;
        }
        [HttpPost]
        [Route("RetencionJudicial/ActualizaCargaRj")]
        public async Task<string> ActualizaCargaRj(ActualizaCargaRjRequest request) {

            ActualizaCargaRjResponse respuesta = new ActualizaCargaRjResponse();
            try {
                respuesta = await Task.Run(() => Bo.ActualizaCargaRj(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/AgregarRj")]
        public async Task<string> AgregarRj(AgregaRjRequest request) {

            AgregaRjResponse respuesta = new AgregaRjResponse();
            try {
                respuesta = await Task.Run(() => Bo.AgregarRj(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneSecuenciaRj")]
        public async Task<string> ObtieneSecuenciaRj() {

            ObtieneSecuenciaRjResponse respuesta = new ObtieneSecuenciaRjResponse();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneSecuenciaRj(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/CheckRetJud")]
        public async Task<string> CheckRetJud(CheckRetJudRequest request) {

            CheckRetJudResponse respuesta = new CheckRetJudResponse();
            try {
                respuesta = await Task.Run(() => Bo.CheckRetJud(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/BorraRetencionJudicial")]
        public async Task<string> BorraRetencionJudicial(BorraRetencionJudicialRequest request) {

            BorraRetencionJudicialResponse respuesta = new BorraRetencionJudicialResponse();
            try {
                respuesta = await Task.Run(() => Bo.BorraRetencionJudicial(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneValidacionFecha")]
        public async Task<string> ObtieneValidacionFecha() {

            ObtieneValidacionFechasResponse respuesta = new ObtieneValidacionFechasResponse();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneValidacionFechas(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneMontoPensionVejInv")]
        public async Task<string> ObtieneMontoPensionVejInv(ObtienePensionVejInvRequest request) {
            List<ObtienePensionVejInvResponse> respuesta = new List<ObtienePensionVejInvResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneMontoPensionVejInv(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneEstadoGe")]
        public async Task<string> ObtieneEstadoGe(ObtenerEstadoGeRequest request) {

            List<ObtenerEstadoGeResponse> respuesta = new List<ObtenerEstadoGeResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneEstadoGE(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/CheckTieneGarantiaEstatal")]
        public async Task<string> CheckTieneGarantiaEstatal(CheckTieneGarantiaEstatalRequest request) {
            List<CheckTieneGarantiaEstatalResponse> respuesta = new List<CheckTieneGarantiaEstatalResponse>();
            try {
                respuesta = await Task.Run(() => Bo.CheckTieneGarantiaEstatal(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneMontoMinimo")]
        public async Task<string> ObtieneMontoMinimo(ObtieneMontoMinimoPensionRequest request) {
            List<ObtieneMontoMinimoPensionResponse> respuesta = new List<ObtieneMontoMinimoPensionResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneMontoMinimoPension(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneBonoMontoMinimo")]
        public async Task<string> ObtieneBonoMontoMinimo(ObtieneBonoMontoMinimoPensionRequest request) {
            List<ObtieneBonoMontoMinimoPensionResponse> respuesta = new List<ObtieneBonoMontoMinimoPensionResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneBonoMontoMinimoPension(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneMontoPensionSobre")]
        public async Task<string> ObtieneMontoPensionSobre(ObtienePensionSobreRequest request) {

            List<ObtienePensionsSobreResponse> respuesta = new List<ObtienePensionsSobreResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneMontoPensionSobre(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaRj")]
        public async Task<string> ObtieneListaRj(ObtieneListaRjRequest request) {

            List<ObtieneListaRjResponse> respuesta = new List<ObtieneListaRjResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaRj(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/CheckRetJudicial")]
        public async Task<string> CheckRetJudicial(CheckRetJudicialRequest request) {

            List<CheckRetJudicialResponse> respuesta = new List<CheckRetJudicialResponse>();
            try {
                respuesta = await Task.Run(() => Bo.CheckRetencionJudicial(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaRjParaEliminar")]
        public async Task<string> ObtieneListaRjParaEliminar(ObtieneListaRjParaEliminarRequest request) {

            List<ObtieneListaRjParaEliminarResponse> respuesta = new List<ObtieneListaRjParaEliminarResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaRjParaEliminar(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtienePeriodoActual")]
        public async Task<string> ObtienePeriodoActual() {

            List<ObtienePeriodoActualResponse> respuesta = new List<ObtienePeriodoActualResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtienePeriodoActual(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }

        [HttpPost]
        [Route("RetencionJudicial/ObtieneDatosControlDocto")]
        public async Task<string> ObtieneDatosControlDocto() {

            List<ObtieneDatosControlDoctoResponseModel> respuesta = new List<ObtieneDatosControlDoctoResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneDatosControlDocto(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneRetencionesJudiciales")]
        public async Task<string> ObtieneRetencionesJudiciales(ObtieneRetencionesJudRequest request) {

            List<ObtieneRetencionesJudResponse> respuesta = new List<ObtieneRetencionesJudResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneRetencionesJudiciales(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaFormaPago")]
        public async Task<string> ObtieneListaFormaPago() {

            List<ObtieneListaFormaPagoResponse> respuesta = new List<ObtieneListaFormaPagoResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneFormaPago(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaFormaDescuento")]
        public async Task<string> ObtieneListaFormaDescuento() {

            List<ObtieneListaFormaDescuentoResponse> respuesta = new List<ObtieneListaFormaDescuentoResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaFormaDescuento(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaAsigFamiliar")]
        public async Task<string> ObtieneListaAsigFamiliar() {

            List<ObtieneListaAsigFamiliarResponse> respuesta = new List<ObtieneListaAsigFamiliarResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneAsignacionFamiliar(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("RetencionJudicial/ObtieneListaBancos")]
        public async Task<string> ObtieneListaBancos() {

            List<ObtieneListaBancosResponse> respuesta = new List<ObtieneListaBancosResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneBancos(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
    }
}
