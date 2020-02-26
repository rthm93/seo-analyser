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
        /// <summary>
        /// Get landing page.
        /// </summary>
        /// <returns>Landing page.</returns>
        public ActionResult Index()
        {
            return View(new AnalyseRequest());
        }

        /// <summary>
        /// Analyses input from user.
        /// </summary>
        /// <param name="request">Analyse request.</param>
        /// <returns>Analysis results.</returns>
        public async Task<ActionResult> Analyse(AnalyseRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Text or URL is required!";
                return View("Index", request);
            }

            var result = new AnalysisResult(request);

            if(!new bool[]
            {
                request.IsCalculateKeywordsInMetaTags,
                request.IsCalculateNumberOfExternalLinks,
                request.IsCalculateOccurrencesOfEachWords
            }.Any(x => x))
            {
                ViewBag.Warning = "No Analysis Result Type selected!";
                return View(result);
            }

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