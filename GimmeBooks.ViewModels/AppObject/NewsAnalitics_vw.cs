using System;

namespace $safeprojectname$.AppObject
{
    public class NewsAnalitics_vw : EntityBase_vw<long>
    {
        public string NewsTitle { get; set; }
        public int RelatedTweetsCount { get; set; }
        public int RelatedBooksCount { get; set; }
        public DateTime Date { get; set; }
    }
}
