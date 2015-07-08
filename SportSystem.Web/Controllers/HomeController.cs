namespace SportSystem.Web.Controllers
{
    using SportSystem.Common;
    using SportSystem.Data;
    using SportSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using SportSystem.Models;
    using AutoMapper;

    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data) : base(data) { }

        public ActionResult Index()
        {
            var model = new HomeScreenViewModel();
            model.Matches = this.Data.Matches
                .All()
                .OrderByDescending(x => x.Bets.Count())
                .Take(GlobalConstants.HomeScreenMatchesCount)
                .Project()
                .To<MatchViewModel>()
                .ToList();

            model.Teams = this.Data.Teams
                .All()
                .OrderByDescending(x => x.Votes.Count())
                .Take(GlobalConstants.HomeScreenTeamsCount)
                .Project()
                .To<TeamViewModel>()
                .ToList();

            return View(model);
        }
    }
}