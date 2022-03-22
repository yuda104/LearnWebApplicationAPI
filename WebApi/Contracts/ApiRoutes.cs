namespace WebApi.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string ApiUrl = Root + "";

        public static class Items
        {
            public const string GetAll = ApiUrl + "/Items";
            public const string Get = ApiUrl + "/Items/{Id}";
            public const string Create = ApiUrl + "/Items";
            public const string Update = ApiUrl + "/Items/{Id}";
            public const string Delete = ApiUrl + "/Items/{Id}";
        }

    }
}
