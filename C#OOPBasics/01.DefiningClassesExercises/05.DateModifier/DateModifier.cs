using System;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static double CalculateDifferenceBetweenDate(string firstDateToString, string secondDateToString)
        {
            DateTime firstDate = DateTime.ParseExact(firstDateToString, "yyyy MM dd",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateToString, "yyyy MM dd",
                System.Globalization.CultureInfo.InvariantCulture);

            var result = Math.Abs((firstDate - secondDate).TotalDays);
            return result;
        }
    }
}