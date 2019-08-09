using CrudsApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Administrativo.Services
{
    public class ApiServices
    {
        HttpClient client = new HttpClient();
        WebClient response = new WebClient();

        #region Bancos
        public List<Bancos> listaBancos(int idCompany)
        {
            try
            {
             //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                 string url = "http://localhost:64705/api/BancosApi?idCompany=" + idCompany;

                var respond02 = response.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<Bancos>>(respond02);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Bancos> getBanco(int idBanco,int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/BancosApi?idBanco=" + idBanco + "&idCompany=" + idCompany;

                 var respond02 = response.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<Bancos>>(respond02);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public String saveBanco(Bancos banco, int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/BancosApi?idCompany=" +  idCompany;

                JsonSerializerSettings ConfigJson = new JsonSerializerSettings();
                ConfigJson.NullValueHandling = NullValueHandling.Ignore;
                byte[] Datos = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(banco, Formatting.None, ConfigJson));
                HttpWebRequest WReq = (HttpWebRequest)HttpWebRequest.Create(url);
                WReq.ContentType = "application/json; charset=UTF-8";
                WReq.ContentLength = Datos.Length;
                WReq.Method = "POST";
                WReq.GetRequestStream().Write(Datos, 0, Datos.Length);
                HttpWebResponse res = (HttpWebResponse)WReq.GetResponse();
                Encoding Codificacion = ASCIIEncoding.UTF8;
                StreamReader SReader = new StreamReader(res.GetResponseStream(), Codificacion);
                var ResultadoCadena = SReader.ReadToEnd();
                return "Succes";
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public String deleteBanco(int idBanco, int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/BancosApi/" + idBanco + "?idCompany=" + idCompany;

                WebRequest request = WebRequest.Create(url);
                request.Method = "DELETE";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return "Succes";
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<string> saveBanco02(Bancos banco,int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/BancosApi?idCompany=" + idCompany;

                var uri  = new Uri(string.Format(url, banco));

                var request = JsonConvert.SerializeObject(banco);

                var content = new StringContent(request, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }

                return "Succes";


            }
            catch (Exception ex)
            {
                return "Error";
            }

        }

        //public async Task<string> deleteBanco(int idBanco, int idCompany)
        //{
        //    try
        //    {
        //        //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
        //        string url = "http://localhost:64705/api/BancosApi/" + idBanco + "?idCompany=" + idCompany;

        //        var uri = new Uri(string.Format(url));

        //        //var request = JsonConvert.SerializeObject(banco);

        //        //var content = new StringContent(request, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = null;
        //        response = await client.DeleteAsync(uri);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return "Error";
        //        }

        //        return "Succes";


        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error";
        //    }

        //}
        #endregion

        #region Cuentas
        public List<CuentasView> listaCuentas(int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/CuentasApi?idCompany=" + idCompany;

                var respond02 = response.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<CuentasView>>(respond02);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Cuentas> getCuenta(int idCuenta,int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/CuentasApi/" + idCuenta + "?idCompany=" + idCompany;

                var respond02 = response.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<Cuentas>>(respond02);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TiposCuentas> listaTiposCuentas(int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/TiposCuentasApi?idCompany=" + idCompany;

                var respond02 = response.DownloadString(url);

                var result = JsonConvert.DeserializeObject<List<TiposCuentas>>(respond02);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public String saveCuenta(Cuentas cuenta, int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/CuentasApi?idCompany=" + idCompany;

                JsonSerializerSettings ConfigJson = new JsonSerializerSettings();
                ConfigJson.NullValueHandling = NullValueHandling.Ignore;
                byte[] Datos = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(cuenta, Formatting.None, ConfigJson));
                HttpWebRequest WReq = (HttpWebRequest)HttpWebRequest.Create(url);
                WReq.ContentType = "application/json; charset=UTF-8";
                WReq.ContentLength = Datos.Length;
                WReq.Method = "POST";
                WReq.GetRequestStream().Write(Datos, 0, Datos.Length);
                HttpWebResponse res = (HttpWebResponse)WReq.GetResponse();
                Encoding Codificacion = ASCIIEncoding.UTF8;
                StreamReader SReader = new StreamReader(res.GetResponseStream(), Codificacion);
                var ResultadoCadena = SReader.ReadToEnd();
                return "Succes";
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public String deleteCuenta(int idCuenta, int idCompany)
        {
            try
            {
                //   string url = "http://54.94.191.184:1313/api/ComproApi/" + id + "?idCom=" + idCompany;
                string url = "http://localhost:64705/api/BancosApi/" + idCuenta + "?idCompany=" + idCompany;

                WebRequest request = WebRequest.Create(url);
                request.Method = "DELETE";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return "Succes";
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
    }
}