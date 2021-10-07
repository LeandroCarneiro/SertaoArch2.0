using ComplexFaker;
using $ext_projectname$.ViewModels.AppObject;
using $ext_projectname$.ViewModels.AppObjects;
using System.Collections.Generic;

namespace $safeprojectname$.Mocks
{
    public static class MockFaker
    {
        public static List<News_vw> NewsMock
        {
            get
            {
                var mock = new FakeDataService().Generate<List<News_vw>>();
                return mock;
            }
        }

        public static List<Tweet_vw> TweetsMock
        {
            get
            {
                var mock = new FakeDataService().Generate<List<Tweet_vw>>();
                return mock;
            }
        }
        public static List<Book_vw> BooksMock
        {
            get
            {
                var mock = new FakeDataService().Generate<List<Book_vw>>();
                return mock;
            }
        }
    }
}
