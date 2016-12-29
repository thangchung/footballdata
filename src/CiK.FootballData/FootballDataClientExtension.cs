namespace CiK.FootballData
{
    public static class FootballDataClientExtension
    {
        public static string GetProtocolByString(this Protocol protocol)
        {
            switch (protocol)
            {
                case Protocol.HTTPS:
                    return "https";
                case Protocol.HTTP:
                    return "http";
                default:
                    return "http";
            }
        }
    }
}