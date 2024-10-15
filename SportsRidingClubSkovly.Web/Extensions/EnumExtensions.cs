namespace SportsRidingClubSkovly.Web.Extensions
{
    public static class EnumExtensions
    {
        public static string ReplaceUnderscores(this Enum _enum)
        {
            var enumString = _enum.ToString();
            return enumString.Replace('_', ' ');
        }
    }
}
