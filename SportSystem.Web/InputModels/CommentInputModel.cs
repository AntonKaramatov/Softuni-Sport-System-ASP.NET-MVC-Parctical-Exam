namespace SportSystem.Web.InputModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel : IMapTo<Comment>
    {
        [Required]
        public string Content { get; set; }

        public int MatchId { get; set; }
    }
}