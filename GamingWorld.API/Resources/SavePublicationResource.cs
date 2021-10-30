using System.ComponentModel.DataAnnotations;

namespace GamingWorld.API.Resources
{
    public class SavePublicationResource
    {

        [Required] public short PublicationType { get; set; }
             
        [Required] [MinLength(15)] public string Title { get; set; }
             
        [Required] [MinLength(40)] public string Content { get; set; }
             
        public int ParticipantLimit { get; set; }
             
        public int PrizePool { get; set; }
             
        public string TDate { get; set; }
             
        public string THour { get; set; }
             
        [Required] public string PublicatedAt { get; set; }
        
        public int GameId { get; set; }
             
       [Required] public int UserId { get; set; }

    }
}

