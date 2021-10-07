using $ext_projectname$.ViewModels.AppObject;

namespace $safeprojectname$
{
    public class GoogleResult
    {
        public string Kind { get; set; }
        public int TotalItems { get; set; }
        public Book_vw[] Items { get; set; }
    }
}