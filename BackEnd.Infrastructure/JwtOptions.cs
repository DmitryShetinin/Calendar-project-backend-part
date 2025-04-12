namespace BackEnd.Infrastructure
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpritesHours { get; set; }
    }
}
