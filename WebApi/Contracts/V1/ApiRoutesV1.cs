namespace WebApi.Contracts.V1
{
    public class ApiRoutesV1
    {
        public const string Root = "api";
        public const string Version = "v1";
        public static readonly string ApiUrl = Root + "/" + Version;

        public static class Items
        {
            public static readonly string GetAll = ApiUrl + "/Items";
            public static readonly string Get = ApiUrl + "/Items/{Id}";
            public static readonly string Create = ApiUrl + "/Items";
        }
    }
}
