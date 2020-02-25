using AngleSharp.Html.Parser;
using SeoAnalyser.Models;
using SeoAnalyser.Utilities;
using SeoAnalyser.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeoAnalyser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new AnalyseRequest());
        }

        public async Task<ActionResult> Analyse(AnalyseRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Text or URL is required!";
                return View("Index", request);
            }

            var result = new AnalysisResult(request);

            try
            {
                ISeoAnalyser analyser = Uri.IsWellFormedUriString(request.Input, UriKind.Absolute) ? new HtmlAnalyser(new LinkAnalyser(), new MetaAnalyser(), new WordAnalyser()) as ISeoAnalyser : new WordAnalyser() as ISeoAnalyser;
                result = await analyser.Analyse(request);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = $"{request.Input} is invalid!";
            }
            catch(Exception)
            {
                ViewBag.Error = $"Unknown error.";
            }

            return View(result);
        }
    }
}