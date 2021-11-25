using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Trendyol_Api.Models;

namespace Trendyol_Api
{
    public partial class Form1 : Form
    {

        //Trendyol'un tarafınıza verdiği bilgiler,kendinize gore uyarlayınız
        //The information that trendyol gives you, adapt it according to you

        static string RoleName = "12345";
        static string RolePass = "12345";
        static string url = "https://api.trendyol.com/sapigw/";
        static string supplierid = "12345";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDowland_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
               | SecurityProtocolType.Tls11
               | SecurityProtocolType.Tls12
               | SecurityProtocolType.Ssl3;
            string auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(RoleName + ":" + RolePass));

            short page = 0;
            short i = 0;
            #region CreatedOrder 
            var clientOrder = new RestClient(url + supplierid + "/orders?status=Created&page=" + page);
            var requestOrder = new RestRequest(Method.GET);
            requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
            requestOrder.AddHeader("Authorization", "Basic " + auth);
            requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
            IRestResponse responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
            TrendyolOrder.Root results = JsonConvert.DeserializeObject<TrendyolOrder.Root>(responseOrder.Content);
            prgBar.Maximum = results.totalElements;
        run:
            foreach (var trendOrder in results.content)
            {
                i++;
                prgBar.Value = i;
                //order package can be split,this is controlled
                //sipariş paketi bölünebilir
                clientOrder = new RestClient(url + supplierid + "/orders?status=UnPacked&orderNumber=" + trendOrder.orderNumber);
                requestOrder = new RestRequest(Method.GET);
                requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
                requestOrder.AddHeader("Authorization", "Basic " + auth);
                requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
                responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
                TrendyolOrder.Root resultsOrder = JsonConvert.DeserializeObject<TrendyolOrder.Root>(responseOrder.Content);
                //order package split
                if (resultsOrder.totalElements > 0)
                {
                    //package split orders are used to learn shipping tracking numbers
                    //paket bolmesi olan Orderler kargo takip numaralarını öğrenmek amacıyla order'a gönderilir 

                    foreach (var trendUnpacked in resultsOrder.content)
                    {
                        clientOrder = new RestClient(url + supplierid + "/orders?orderNumber=" + trendUnpacked.orderNumber);
                        requestOrder = new RestRequest(Method.GET);
                        requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
                        requestOrder.AddHeader("Authorization", "Basic " + auth);
                        requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
                        responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
                        TrendyolUnPackedOrder.Order resultsUnpacked = JsonConvert.DeserializeObject<TrendyolUnPackedOrder.Order>(responseOrder.Content);
                        var cargoTrakingNumber = resultsUnpacked.content.Where(w => w.shipmentPackageStatus != "UnPacked" || w.shipmentPackageStatus != "Cancelled" || w.shipmentPackageStatus != "UnSupplied").Select(s => new { s.cargoTrackingNumber, s.cargoTrackingLink, s.cargoProviderName, s.cargoSenderNumber }).ToList();
                        foreach (var item in cargoTrakingNumber)
                        {
                            //TODO: your's code/sizin kodlarınız
                        }

                    }
                }

                //Only the item of the order can be cancelled,this is controlled
                //Verilen siparişin sadece kalemi cancelled olabilir kontrol edilir
                clientOrder = new RestClient(url + supplierid + "/orders?status=Cancelled,UnSupplied&orderNumber=" + trendOrder.orderNumber);
                requestOrder = new RestRequest(Method.GET);
                requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
                requestOrder.AddHeader("Authorization", "Basic " + auth);
                requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
                responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
                TrendyolOrder.Root resultsCancelled = JsonConvert.DeserializeObject<TrendyolOrder.Root>(responseOrder.Content);
                foreach (var trendOdetay in trendOrder.lines)
                {
                    if (resultsCancelled.content.Count() > 0)
                    {
                        var cancelled = (resultsCancelled.content.FirstOrDefault().lines).Where(w => w.id == trendOdetay.id && w.sku == trendOdetay.sku).FirstOrDefault();
                        //TODO: your's code/sizin kodlarınız

                    }
                }
            }
            if (page <= results.totalPages)
            {
                page++;
                goto run;
            }
            #endregion

            #region Delivered
            page = 0;
            i = 0;
            prgBar.Value = 0;
        // return request can be give in case of transport
        //taşıma durumunda iade talebi verilebilir
        run1:
            clientOrder = new RestClient(url + supplierid + "/orders?status=Shipped&page=" + page);
            requestOrder = new RestRequest(Method.GET);
            requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
            requestOrder.AddHeader("Authorization", "Basic " + auth);
            requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
            responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
            TrendyolOrder.Root resultsShippedOrder = JsonConvert.DeserializeObject<TrendyolOrder.Root>(responseOrder.Content);
            prgBar.Maximum = results.totalElements;
            if (resultsShippedOrder.totalElements > 0)
            {
                foreach (var sOrder in resultsShippedOrder.content)
                {
                    i++;
                    prgBar.Value = i;

                    #region  is there a refund/iadesi var mi
                    clientOrder = new RestClient(url + supplierid + "/claims?claimItemStatus=Created&orderNumber=" + sOrder.orderNumber);
                    requestOrder = new RestRequest(Method.GET);
                    requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
                    requestOrder.AddHeader("Authorization", "Basic " + auth);
                    requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
                    responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
                    TrendyolRebate.Order resultsRebateRequest = JsonConvert.DeserializeObject<TrendyolRebate.Order>(responseOrder.Content);
                    #endregion
                    #region  Is the refund confirmed/iadesi onaylandi mi
                    clientOrder = new RestClient(url + supplierid + "/claims?claimItemStatus=Accepted&orderNumber=" + sOrder.orderNumber);
                    requestOrder = new RestRequest(Method.GET);
                    requestOrder.AddHeader("Accept", "application/json;charset=utf-8");
                    requestOrder.AddHeader("Authorization", "Basic " + auth);
                    requestOrder.AddHeader("UserAgent", supplierid + " - SelfIntegration");
                    responseOrder = clientOrder.Execute(requestOrder) as RestResponse;
                    TrendyolRebate.Order resultsRebate = JsonConvert.DeserializeObject<TrendyolRebate.Order>(responseOrder.Content);
                    #endregion
                    if (resultsRebateRequest.content.Count() > 0)
                    {
                        foreach (var RebateRequest in resultsRebateRequest.content)
                        {
                            foreach (var item in RebateRequest.items.Select(s => new { s.claimItems, s.orderLine }).ToList())
                            {
                                var rebateItems= String.Join(",", item.claimItems.Select(s => s.orderLineItemId));
                            }
                        }

                        }
                    else if (resultsRebate.content.Count() > 0)
                    {
                        foreach (var Rebate in resultsRebate.content)
                        {
                        }
                    }

                }
            }
            if (page <= results.totalPages)
            {
                page++;
                goto run1;
            }
            #endregion

            //It will be better to run it according to the web service status
            //Web servis statülerine göre çalıştırmak daha iyi olacaktır

            //Canceled,Not Procured states can be called together
            //Returned must be called separately
            //Cancelled,UnSupplied statuleri birlikte çağrılabilir
            //Returned ayrı çağrılmalıdır
        }
    }
}
