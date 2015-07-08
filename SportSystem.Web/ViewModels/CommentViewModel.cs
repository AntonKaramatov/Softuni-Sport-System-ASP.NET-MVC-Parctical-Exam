namespace SportSystem.Web.ViewModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string UserUserName { get; set; }
    }
}
