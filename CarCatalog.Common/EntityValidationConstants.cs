namespace CarCatalog.Common
{
    public class EntityValidationConstants
    {
        public static class CarValidations
        {
            public enum TransmissionType
            {
                Manual = 0,
                Automatic = 1
            }

            public enum EngineType
            {
                Gasoline = 0,
                Diesel = 1,
                Gas = 2,
                Electric = 3,
                Hybrid = 4
            }

            public const int BrandMinValue = 3;
            public const int BrandMaxValue = 20;

            public const int ModelMinValue = 3;
            public const int ModelMaxValue = 40;

            public const int CarTypeMinValue = 3;
            public const int CarTypeMaxValue = 20;

            public const string HorsepowerMinValue = "50";
            public const string HorsepowerMaxValue = "1000";

            public const string EngineDisplacementMinValue = "1";
            public const string EngineDisplacementMaxValue = "8";

            public const string MileageMinValue = "1000";
            public const string MileageMaxValue = "1500000";

            public const string WeightMinValue = "500";
            public const string WeightMaxValue = "3500";

            public const string FuelConsumptionMinValue = "4";
            public const string FuelConsumptionMaxValue = "40";

            public const string PriceMinValue = "200";
            public const string PriceMaxValue = "200000";

            public const int ImageUrlMaxValue = 2048;

            public const int DescriptionMaxValue = 200;
        }

        public static class CarSellerValidations
        {
            public const int UsernameMinValue = 3;
            public const int UsernameMaxValue = 20;

            public const int PhoneNumberMinValue = 10;
            public const int PhoneNumberMaxValue = 15;

            public const int EmailMinValue = 10;
            public const int EmailMaxValue = 20;

            public const int AddressMinValue = 10;
            public const int AddressMaxValue = 50;
        }

        public static class CarBuyerValidations
        {
            public const int UsernameMinValue = 3;
            public const int UsernameMaxValue = 20;

            public const int PhoneNumberMinValue = 10;
            public const int PhoneNumberMaxValue = 15;

            public const int EmailMinValue = 10;
            public const int EmailMaxValue = 20;
        }

        public static class CarDealerValidations
        {
            public const int NameMinValue = 3;
            public const int NameMaxValue = 20;

            public const int PhoneNumberMinValue = 10;
            public const int PhoneNumberMaxValue = 15;

            public const int AddressMinValue = 10;
            public const int AddressMaxValue = 50;
        }

        public static class User
        {
            public const int PasswordMinValue = 6;
            public const int PasswordMaxValue = 100;

            public const int FirstNameMinValue = 1;
            public const int FirstNameMaxValue = 15;

            public const int LastNameMinValue = 1;
            public const int LastNameMaxValue = 15;
        }
    }
}