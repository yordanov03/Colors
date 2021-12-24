namespace Colors.Domain.Common
{
    public static class ModelConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;
        public const int CityMinLength = 4;
        public const int CityMaxLength = 50;
        public const int ColorMaxLength = 15;
        public const int ZipcodeMaxLength = 5;
        public const string ZipcodeRegexPattern = "^[0-9]{5}$";
    }
}
