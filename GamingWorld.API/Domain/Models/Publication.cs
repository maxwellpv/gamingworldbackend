namespace GamingWorld.API.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        
        public short PublicationType { get; set; }
             
        public string Title { get; set; }
             
        public string Content { get; set; }
             
        public int ParticipantLimit { get; set; }
             
        public int PrizePool { get; set; }
             
        public string TDate { get; set; }
             
        public string THour { get; set; }
             
        public string PublicatedAt { get; set; }
             
        //Faltaria el de almacenar imagen en la BDD
             
        //Relationships
        public int GameId { get; set; }
             
        public int UserId { get; set; }
             
         }
}