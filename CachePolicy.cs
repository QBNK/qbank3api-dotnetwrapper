using QBankApi.Enums;

namespace QBankApi
{
    public class CachePolicy
    {
        public int Lifetime { get; }
        public CacheType Type { get; protected set; }

        public CachePolicy(CacheType type, int lifetime)
        {
            Type = type;
            Lifetime = lifetime;
        }

        protected void SetCacheType(CacheType type)
        {
            Type = type;
        }

        public bool IsEnabled()
        {
            return Type != CacheType.Off;
        }
    }
}