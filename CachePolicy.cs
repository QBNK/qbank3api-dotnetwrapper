using QBankApi.Enums;

namespace QBankApi
{
    public class CachePolicy
    {
        internal int Lifetime { get; set; }
        internal CacheType Type { get; set; }

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

        public CacheType GetCacheType()
        {
            return Type;
        }

        public int GetLifetime()
        {
            return Lifetime;
        }
    }
}