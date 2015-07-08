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
    using PagedList;
    using SportSystem.Common;
    using SportSystem.Web.InputModels;
    using AutoMapper;
    using SportSystem.Models;
    using Microsoft.AspNet.Identity;

    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data) : base(data){}

        public ActionResult Index(int? page)
        {
            var matches = this.Data.Matches
                .All()
                .OrderBy(x => x.Date)
                .Project()
                .To<MatchViewModel>()
                .ToPagedList(page.HasValue ? page.Value : GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);

            return View(matches);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var match = this.Data.Matches
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<MatchDetailsViewModel>()
                .FirstOrDefault();

            return View(match);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.User.Identity.GetUserId();
                comment.Date = DateTime.Now;
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentDb);
            }

            return this.Json("Error");
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Bet(BetInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var bet = Mapper.Map<Bet>(model);
                bet.UserId = this.User.Identity.GetUserId();
                this.Data.Bets.Add(bet);
                this.Data.SaveChanges();

                var bets = this.Data.Bets
                    .All()
                    .Where(x => x.MatchId == bet.MatchId && x.TeamId == bet.TeamId)
                    .Sum(x => x.Ammount);

                return this.Content(bets.ToString());
            }

            return this.Json("Error");
        }
    }
}