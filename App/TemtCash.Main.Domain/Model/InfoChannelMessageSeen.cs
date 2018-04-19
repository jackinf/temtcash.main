using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemtCash.Main.Domain.Model
{
    /// <summary>
    /// Many-2-Many for infochannel message and user
    /// </summary>
    public class InfoChannelMessageSeen
    {
        // TODO: we don't need Id here

        [Key, Column(Order = 0)]
        public int InfoChannelMessageId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }
    }
}