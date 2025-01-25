using System.ComponentModel.DataAnnotations;

namespace JobTitle_webapi.Model
{
    public class JobTitle
    {
        public long Id { get; set; }
        public long QissLocationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefix { get; set; }
        public string Description { get; set; }
        public long  CreateBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public bool IsRemoved { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsPermanentDeleted { get; set; }


    }
}
