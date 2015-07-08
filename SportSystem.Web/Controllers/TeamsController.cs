namespace SportSystem.Web.Controllers
{
    using SportSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using SportSystem.Web.ViewModels;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using SportSystem.Models;
    using SportSystem.Web.InputModels;

    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data) : base(data) {}

        [Authorize]
        public ActionResult Details(int id)
        {
            var team = this.Data.Teams
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();
            var teamViewModel = Mapper.Map<TeamDetailsViewModel>(team);
            teamViewModel.HasVoted = team.Votes.Any(x => x.UserId == userId);

            return View(teamViewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            var team = this.Data.Teams.Find(id);
            if (team != null)
            {
                var userHasVoted = team.Votes.Any(x => x.UserId == this.User.Identity.GetUserId());
                if (!userHasVoted)
                {
                    this.Data.Votes.Add(new Vote
                    {
                        TeamId = id,
                        UserId = this.User.Identity.GetUserId()
                    });
                    this.Data.SaveChanges();
                }

                var votesCount = team.Votes.Count();
                return this.Content(votesCount.ToString());
            }

            return new EmptyResult(); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadPlayers();
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = Mapper.Map<Team>(model);
                this.Data.Teams.Add(team);
                this.Data.Players
                    .All()
                    .Where(x => model.PlayersIds.Contains(x.Id))
                    .Each(x => x.TeamId = team.Id);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = team.Id });
            }

            this.LoadPlayers();
            return this.View();
        }

        private void LoadPlayers()
        {
            this.ViewBag.Players = this.Data.Players
            .All()
            .Where(x => x.TeamId == null)
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
        }
    }
}