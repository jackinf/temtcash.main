using System;
using System.ComponentModel.DataAnnotations;

namespace SpeysCloud.Main.DAL.Model
{
    public abstract class BaseModel<TKey> where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public TKey? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public TKey? UpdatedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public TKey? DeletedBy { get; set; }
    }
}