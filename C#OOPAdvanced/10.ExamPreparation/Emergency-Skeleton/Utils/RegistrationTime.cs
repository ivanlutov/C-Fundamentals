namespace Emergency_Skeleton.Utils
{
    using Emergency_Skeleton.Contracts;

    public class RegistrationTime : IRegistrationTime
    {
        private int hour;

        private int minutes;

        private int day;

        private int month;

        private int year;

        public RegistrationTime(string registrationTime)
        {
            this.InitializeData(this.ParseData(registrationTime));
        }

        private int[] ParseData(string registrationTime)
        {
            string[] splittedRegistrationTime = registrationTime.Split(' ');

            string hourAndMinutes = splittedRegistrationTime[0];
            string date = splittedRegistrationTime[1];

            string[] splittedHoursAndMinutes = hourAndMinutes.Split(':');
            string[] splittedDate = date.Split('/');

            int hour = int.Parse(splittedHoursAndMinutes[0]);
            int minutes = int.Parse(splittedHoursAndMinutes[1]);

            int day = int.Parse(splittedDate[0]);
            int month = int.Parse(splittedDate[1]);
            int year = int.Parse(splittedDate[2]);

            int[] parsedData = new int[5];

            parsedData[0] = hour;
            parsedData[1] = minutes;
            parsedData[2] = day;
            parsedData[3] = month;
            parsedData[4] = year;

            return parsedData;
        }

        private void InitializeData(int[] data)
        {
            this.hour = data[0];
            this.minutes = data[1];
            this.day = data[2];
            this.month = data[3];
            this.year = data[4];
        }

        public override string ToString()
        {
            string hour = this.hour < 10 ? "0" + this.hour : this.hour + "";
            string minutes = this.minutes < 10 ? "0" + this.minutes : this.minutes + "";
            string day = this.day < 10 ? "0" + this.day : this.day + "";
            string month = this.month < 10 ? "0" + this.month : this.month + "";

            string result = hour + ":" + minutes + " " + day + "/" + month + "/" + this.year;
            return result;
        }
    }
}