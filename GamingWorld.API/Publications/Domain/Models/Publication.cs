using GamingWorld.API.Business.Domain.Models;

namespace GamingWorld.API.Publications.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        
        public short PublicationType { get; set; }
             
        public string Title { get; set; }
             
        public string Content { get; set; }
             

        
        public string UrlToImage { get; set; }
        
        public int? TournamentId { get; set; }
        
        public Tournament Tournament { get; set; }

        public string CreatedAt { get; set; }
             
             
        //Relationships
        public int GameId { get; set; }
             
        public int UserId { get; set; }
             
         }
}