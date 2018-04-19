using System;
using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    /// <summary>
    /// TODO: What is this?
    /// </summary>
    public class DayPeriod : BaseModel<int>
    {
        public float DayBeginSum { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Comment { get; set; }

        [Required]
        public string Status { get; set; }

        //
        // Foreign reference
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int? UserId { get; set; }

        // TODO: What is this?
        public int? ExternalId { get; set; }
    }
}