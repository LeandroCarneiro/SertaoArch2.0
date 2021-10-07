using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Entities
{
    [Table("tbl_Book")]
    public class Book : EntityBase<long>
    {
        public string Etag { get; set; }
        public string SelfLink { get; set; }
        public long VolumeInfoId { get; set; }
    }
}