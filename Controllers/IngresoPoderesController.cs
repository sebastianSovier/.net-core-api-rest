using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using pensiones.api.Bo;
using static pensiones.api.Models.IngresoPoderesModel;

namespace pensiones.api.Controllers {
    [ApiController]
    public class IngresoPoderesController : ControllerBase {
        IngresoPoderesBo Bo = new IngresoPoderesBo();

        private readonly IConfiguration _config;

        public IngresoPoderesController(IConfiguration config) {
            _config = config;
        }

        [HttpPost]
        [Route("IngresoPoderes/ObtieneTiposPoderes")]
        public async Task<string> ObtieneTiposPoderes() {

            List<ObtieneTiposPoderesResponse> respuesta = new List<ObtieneTiposPoderesResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneTiposPoderes(_config));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/ObtieneListaPoderes")]
        public async Task<string> ObtieneListaPoderes(ObtieneListaPoderesRequest request) {

            List<ObtieneListaPoderesResponse> respuesta = new List<ObtieneListaPoderesResponse>();
            try {
                respuesta = await Task.Run(() => Bo.ObtieneListaPoderes(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/AgregaPoder")]
        public async Task<string> AgregaPoder(AgregaPoderRequest request) {

            AgregaPoderResponse respuesta = new AgregaPoderResponse();
            try {
                respuesta = await Task.Run(() => Bo.AgregaPoder(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/IngresaPoderMfp")]
        public async Task<string> IngresaPoderMfp(IngresaPoderMfpRequest request) {

            IngresaPoderMfpResponse respuesta = new IngresaPoderMfpResponse();
            try {
                respuesta = await Task.Run(() => Bo.IngresaPoderMfp(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/AutorizaPoderMfp")]
        public async Task<string> AutorizaPoderMfp(AutorizaPoderMfpRequest request) {

            AutorizaPoderMfpResponse respuesta = new AutorizaPoderMfpResponse();
            try {
                respuesta = await Task.Run(() => Bo.AutorizaPoderMfp(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/CheckPoder")]
        public async Task<string> CheckPoder(CheckPoderRequest request) {

            List<CheckPoderResponse> respuesta = new List<CheckPoderResponse>();
            try {
                respuesta = await Task.Run(() => Bo.CheckPoder(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/ObtieneDatosControlDocto")]
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
        [Route("IngresoPoderes/AnulaUltimoPoder")]
        public async Task<string> AnulaUltimoPoder(AnulaUltimoPoderRequest request) {

            AnulaUltimoPoderResponse respuesta = new AnulaUltimoPoderResponse();
            try {
                respuesta = await Task.Run(() => Bo.AnulaUltimoPoder(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
        [HttpPost]
        [Route("IngresoPoderes/BorraPoderes")]
        public async Task<string> BorraPoderes(BorraPoderesRequest request) {

            BorraPoderesResponse respuesta = new BorraPoderesResponse();
            try {
                respuesta = await Task.Run(() => Bo.BorraPoderes(_config, request));

                return JsonConvert.SerializeObject(respuesta);
            } catch (Exception) {
                return JsonConvert.SerializeObject("99");
            }
        }
    }
}
