namespace OutLoud_Test.DataAccess.Entities
{
    public class ApplicationSettings
    {
        public string Secret { get; set; }

        public string Site { get; set; }

        public string ExpireTime { get; set; }

        public string Audience { get; set; }

        public string RefreshToken { get; set; }

        public string GrantType { get; set; }

        public string ClientId { get; set; }
    }
}
