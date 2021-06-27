using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using pensiones.api.Bo;
using pensiones.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pensiones.api.Controllers {
    [ApiController]
    public class CuotaMortuariaController : ControllerBase {
        CuotaMortuariaBo Bo = new CuotaMortuariaBo();

        private readonly IConfiguration _config;

        public CuotaMortuariaController(IConfiguration config) {
            _config = config;
        }
        // GET: api/<CuotaMortuariaController>
        [HttpPost]
        [Route("CuotaMortuaria/GuardarSolicitud")]
        public async Task<string> GuardarCuotaMortuaria(IngresaActualizaCuotaMortuariaRequestModel request) {

            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.IngresoCuotaMortuaria(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }

        [HttpPost]
        [Route("CuotaMortuaria/ModificarSolicitud")]
        public async Task<string> ModificarCuotaMortuaria(IngresaActualizaCuotaMortuariaRequestModel request) {

            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ActualizaCuotaMortuaria(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/InsertaCuotaMortuaria")]
        public async Task<string> InsertaCuotaMortuaria(IngresaActualizaCuotaMortuariaRequestModel request) {

            IngresaActualizaCuotaMortuariaResponseModel respuesta = new IngresaActualizaCuotaMortuariaResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.InsertaCuotaMortuaria(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneCuotaMortuaria")]
        public async Task<string> ObtieneCuotaMortuaria(ObtieneCuotaMortuariaRequestModel request) {

            List<ObtieneCuotaMortuariaResponseModel> respuesta = new List<ObtieneCuotaMortuariaResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneCuotaMortuaria(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneCausante")]
        public async Task<string> ObtieneCausante(ObtieneCausanteRequestModel request) {

            List<ObtieneCausanteResponseModel> respuesta = new List<ObtieneCausanteResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneCausante(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ActualizarAtributoSiete")]
        public async Task<string> ActualizarAtributoSiete(ActualizaAtributoSieteRequestModel request) {

            ActualizaAtributoSieteResponseModel respuesta = new ActualizaAtributoSieteResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ActualizarAtributoSiete(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneCertificadoDefuncion")]
        public async Task<string> ObtieneCertificadoDefuncion(ObtieneCertificadoDefuncionRequestModel request) {

            ObtieneCertificadoDefuncionResponseModel respuesta = new ObtieneCertificadoDefuncionResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneCertDefuncion(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneDatosBeneficiario")]
        public async Task<string> ObtieneDatosBeneficiario(ObtieneBeneficiarioRequestModel request) {

            List<ObtieneBeneficiarioResponseModel> respuesta = new List<ObtieneBeneficiarioResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneBeneficiario(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneSucursales")]
        public async Task<string> ObtieneSucursales() {

            List<ObtieneSucursalesResponseModel> respuesta = new List<ObtieneSucursalesResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneSucursales(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtienePersona")]
        public async Task<string> ObtienePersona(ObtienePersonaRequestModel request) {

            List<ObtienePersonaResponseModel> respuesta = new List<ObtienePersonaResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtienePersona(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneDatosPoliza")]
        public async Task<string> ObtieneDatosPoliza(ObtienePolizaRequestModel request) {

            List<ObtienePolizaResponseModel> respuesta = new List<ObtienePolizaResponseModel>();
            try {
                List<ObtienePolizaResponseModel> polizas = await Task.Run(() => Bo.ObtieneDatosPoliza(_config, request));

                foreach (ObtienePolizaResponseModel p in polizas) {
                    ObtieneCausanteRequestModel ocr = new ObtieneCausanteRequestModel();
                    ocr.P_PERSONA_RUT = p.NUM_RUT_NAT;
                    ocr.P_POLIZA = p.POL_POLIZA;
                    p.NAT_ID = Bo.ObtieneCausante(_config, ocr).First().NAT_ID;
                    respuesta.Add(p);
                }

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneDatosEjecutivo")]
        public async Task<string> ObtieneDatosEjecutivo(ObtieneDatosEjecutivoRequestModel request) {

            List<ObtieneDatosEjecutivoResponseModel> respuesta = new List<ObtieneDatosEjecutivoResponseModel>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneDatosEjecutivo(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/GuardarPersona")]
        public async Task<string> GuardarPersona(GuardarPersonaRequestModel request) {

            GuardarPersonaResponseModel respuesta = new GuardarPersonaResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.GuardarPersona(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("CuotaMortuaria/ObtieneDatosControlDocto")]
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
        [Route("CuotaMortuaria/ObtieneUf")]
        public async Task<string> ObtieneUf(ObtieneValorUfRequestModel request) {

            ObtieneValorUfResponseModel respuesta = new ObtieneValorUfResponseModel();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneUf(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
    }
}
