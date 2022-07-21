using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ClienteController : Controller
    {
        string UrlBaseApiCadastro => "http://localhost:51456/api/";

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ClienteViewModel> clientes = null;

            using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
            {
                try
                {
                    var response = httpCliente.GetAsync("cliente").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var retornoApi = response.Content.ReadAsAsync<IList<ClienteViewModel>>();
                        retornoApi.Wait();
                        clientes = retornoApi.Result;
                    }
                    else
                    {
                        clientes = Enumerable.Empty<ClienteViewModel>();
                        ModelState.AddModelError(string.Empty, "Erro ao retonar a lista de clientes.");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao retonar dados dos clientes");
                }
            }

            if (clientes == null)
            {
                clientes = new List<ClienteViewModel>();
            }

            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CarregaViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            CarregaViewBags();

            if (ModelState.IsValid)
            {
                using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
                {
                    var postCliente = httpCliente.PostAsJsonAsync<ClienteEnderecoViewModel>("cliente", clienteEnderecoViewModel);
                    postCliente.Wait();
                    var resultadoPost = postCliente.Result;

                    if (resultadoPost.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao realizar cadastro do cliente");
                    }
                }

            }

            return View(clienteEnderecoViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarregaViewBags();
            var clienteEnderecoViewModel = RetornaClienteEnderecoViewModel(id);
            return View(clienteEnderecoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            CarregaViewBags();

            if (ModelState.IsValid)
            {
                using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
                {
                    var putCliente = httpCliente.PutAsJsonAsync<ClienteEnderecoViewModel>("cliente", clienteEnderecoViewModel);
                    putCliente.Wait();
                    var resultadoPut = putCliente.Result;

                    if (resultadoPut.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Erro ao realizar cadastro do cliente");
                    }
                }
            }

            return View(clienteEnderecoViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteEnderecoViewModel clienteEnderecoViewModel = null;

            using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
            {
                var response = httpCliente.GetAsync($"cliente/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var retornoApi = response.Content.ReadAsAsync<ClienteEnderecoViewModel>();
                    retornoApi.Wait();
                    clienteEnderecoViewModel = retornoApi.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao retonar dados do cliente");
                }
            }

            return View(clienteEnderecoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmacaoDelete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
            {
                var response = httpCliente.DeleteAsync($"cliente/{id}");
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarregaViewBags();
            var clienteEnderecoViewModel = RetornaClienteEnderecoViewModel(id);
            return View(clienteEnderecoViewModel);
        }

        #region Métodos Auxiliares

        private ClienteEnderecoViewModel RetornaClienteEnderecoViewModel(int id)
        {
            ClienteEnderecoViewModel clienteEnderecoViewModel = null;

            using (var httpCliente = new HttpClient() { BaseAddress = new Uri(UrlBaseApiCadastro) })
            {
                var response = httpCliente.GetAsync($"cliente/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var retornoApi = response.Content.ReadAsAsync<ClienteEnderecoViewModel>();
                    retornoApi.Wait();
                    clienteEnderecoViewModel = retornoApi.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao retonar dados do cliente");
                }
            }

            return clienteEnderecoViewModel;
        }

        private void CarregaViewBags()
        {
            ViewBag.DicionarioOrgaoEspedicao = RetornaDicionarioOrgaoExpedicao();
            ViewBag.DicionarioUf = RetornaDicionarioDicionarioUf();
            ViewBag.DicionarioEstadoCivil = RetornaDicionarioEstadoCivil();
            ViewBag.DicionarioGenero = RetornaDicionarioGenero();
        }

        private Dictionary<string, string> RetornaDicionarioOrgaoExpedicao()
        {
            return new Dictionary<string, string>
            {
               {"SSP" , "Secretaria de Segurança Pública"},
               {"SJC" , "Secretaria de Justiça e Cidadania"},
               {"SJT" ,"Secretaria de Justiça e Trabalho"},
               {"CC" ,  "Cartório Civil"},
               {"PIPC" , "Postos de Identificação da Polícia Civil"}
            };
        }

        private Dictionary<string, string> RetornaDicionarioDicionarioUf()
        {
            return new Dictionary<string, string>
            {
                {"RO","RO"},
                {"AC","AC"},
                {"AM","AM"},
                {"RR","RR"},
                {"PA","PA"},
                {"AP","AP"},
                {"TO","TO"},
                {"MA","MA"},
                {"PI","PI"},
                {"CE","CE"},
                {"RN","RN"},
                {"PB","PB"},
                {"PE","PE"},
                {"AL","AL"},
                {"SE","SE"},
                {"BA","BA"},
                {"MG","MG"},
                {"ES","ES"},
                {"RJ","RJ"},
                {"SP","SP"},
                {"PR","PR"},
                {"SC","SC"},
                {"RS","RS"},
                {"MS","MS"},
                {"MT","MT"},
                {"GO","GO"},
                {"DF","DF"},
            };
        }

        private Dictionary<string, string> RetornaDicionarioGenero()
        {
            return new Dictionary<string, string>
            {
                { "Masculino", "Masculino"},
                { "Feminino", "Feminino"},
                { "Não Informar", "Não Informar"}
            };
        }

        private Dictionary<string, string> RetornaDicionarioEstadoCivil()
        {
            return new Dictionary<string, string>
            {
                { "Solteiro", "Solteiro"},
                { "Casado", "Casado"},
                { "Divorciado", "Divorciado"},
            };
        }

        #endregion
    }
}