using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pensiones.api.Bo;
using static pensiones.api.Models.GarantiaEstatalModel;

namespace pensiones.api.Controllers {
    [ApiController]
    public class GarantiaEstatalController : ControllerBase {
        GarantiaEstatalBo Bo = new GarantiaEstatalBo();

        private readonly IConfiguration _config;

        public GarantiaEstatalController(IConfiguration config) {
            _config = config;
        }

        [HttpPost]
        [Route("GarantiaEstatal/ObtieneListaBeneficiarios")]
        public async Task<string> ObtieneListaBeneficiarios(ObtieneListaBeneficiariosRequestModel request) {

            List<ObtieneListaBeneficiariosResponseModel> respuesta = new List<ObtieneListaBeneficiariosResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaBeneficiarios(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneDatosSolicitudGe")]
        public async Task<string> ObtieneDatosSolicitudGe(ObtieneDatosSolicitudGeRequestModel request) {

            List<ObtieneDatosSolicitudGeResponseModel> respuesta = new List<ObtieneDatosSolicitudGeResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneDatosSolicitudGe(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ExisteBenAps")]
        public async Task<string> ExisteBenAps(ExisteBenApsRequestModel request) {

            ExisteBenApsResponseModel respuesta = new ExisteBenApsResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ExisteBenAps(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneListaGrupoPagoPoliza")]
        public async Task<string> ObtieneListaGrupoPagoPoliza(ObtieneGrupoPagoPolizaRequestModel request) {

            List<ObtieneGrupoPagoPolizaResponseModel> respuesta = new List<ObtieneGrupoPagoPolizaResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneGrupoPagoPoliza(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneBeneficiarioGrupoPago")]
        public async Task<string> ObtieneGrupoPago(ObtieneGrupoPagoRequestModel request) {

            List<ObtieneGrupoPagoResponseModel> respuesta = new List<ObtieneGrupoPagoResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneGrupoPago(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ValidaSiContinuaSegundaTabla")]
        public async Task<string> ValidaSiContinuaSegundaTabla(ValidaSiContinuaSegundaTablaRequestModel request) {

            List<ValidaSiContinuaSegundaTablaResponseModel> respuesta = new List<ValidaSiContinuaSegundaTablaResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ValidaSiContinuaSegundaTabla(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneDatosControlDocto")]
        public async Task<string> ObtieneDatosControlDocto(ObtieneDatosControlDoctoRequestModel request) {

            List<ObtieneDatosControlDoctoResponseModel> respuesta = new List<ObtieneDatosControlDoctoResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneDatosControlDocto(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ValidaSolicitudGE")]
        public async Task<string> ValidaSolicitudGarantiaEstatal(ValidaSolicitudGeRequestModel request) {

            ValidaSolicitudGeResponseModel respuesta = new ValidaSolicitudGeResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ValidaSolicitudGarantiaEstatal(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }

        [HttpPost]
        [Route("GarantiaEstatal/IngresaActualizaSolicitugGe")]
        public async Task<string> IngresaActualizaSolicitugGe(IngresaSolicitudGeRequestModel request) {

            IngresaSolicitudGeResponseModel respuesta = new IngresaSolicitudGeResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.GuardaActualizaSolicitudGe(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }

        [HttpPost]
        [Route("GarantiaEstatal/ObtieneListaGrupoPagoBeneficiarios")]
        public async Task<string> ObtieneListaGrupoPago(ObtieneListaGrupoPagoRequestModel request) {

            List<ObtieneListaGrupoPagoResponseModel> respuesta = new List<ObtieneListaGrupoPagoResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaGrupoPagoPoliza(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ValidaExisteSolicitudGE")]
        public async Task<string> ValidaExisteSolicitudGE(ValidaExisteSolicitudGeRequestModel request) {

            ValidaExisteSolicitudGeResponseModel respuesta = new ValidaExisteSolicitudGeResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ValidaExisteSolicitudGarantiaEstatal(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneEstadoGe")]
        public async Task<string> ObtieneEstadoGe(ObtieneEstadoGeRequestModel request) {

            List<ObtieneEstadoGeResponseModel> respuesta = new List<ObtieneEstadoGeResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneEstadoGE(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneCheckEstadoGe")]
        public async Task<string> ObtieneCheckEstadoGe(ObtieneCheckEstadoGeRequestModel request) {

            ObtieneCheckEstadoGeResponseModel respuesta = new ObtieneCheckEstadoGeResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneCheckEstadoGe(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("GarantiaEstatal/ObtieneCausante")]
        public async Task<string> ObtieneCausante(Models.ObtieneCausanteRequestModel request) {

            List<Models.ObtieneCausanteResponseModel> respuesta = new List<Models.ObtieneCausanteResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneCausante(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
    }
}
