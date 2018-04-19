using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    // TODO: What is Profile?
    public class InfoChannelMessageProfile
    {
        [Key]
        public int Id { get; set; }

        public int InfoChannelMessageId { get; set; }

        // TODO: What is this?
        public string Profile { get; set; }
    }
}