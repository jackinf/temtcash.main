namespace SpeysCloud.Main.DAL.Model
{
    public class ClassificationValue : BaseModel<int>
    {
        public string Value { get; set; }

        //
        // One-2-Many and Many-2-One references
        //

        public int ClassificationId { get; set; }
        public Classification Classification { get; set; }
    }
}