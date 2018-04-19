using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeysCloud.Main.DAL.Model
{
    public class Classification : BaseModel<int>
    {
        public string Name { get; set; }

        [InverseProperty(nameof(ClassificationValue.Classification))]
        public List<ClassificationValue> Values { get; set; }
    }
}