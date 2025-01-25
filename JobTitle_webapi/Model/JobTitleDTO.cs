using System.ComponentModel.DataAnnotations;

namespace JobTitle_webapi.Model
{
    public class JobTitleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Description { get; set; }

    }
}
