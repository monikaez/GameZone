namespace GameZone.Data.Common
{
    public  static class DataConstants
    {
        public const int TitileMaxLength = 50;
        public const int TitileMinLength = 2;
        //•	Has Title – a string with min length 2 and max length 50 (required)

        public const int DescriptionMaxLength = 500;
        public const int DescriptionMinLength = 10;
        //•	Has Description – string with min length 10 and max length 500 (required)

        public const string DateFormat = "yyyy-MM-dd";
        //•	Has ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)

        public const int GenreNameMaxLength = 25;
        public const int GenreNameMinLength = 3;
        //•	Has Name – a string with min length 3 and max length 25 (required)

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        

    }
}
