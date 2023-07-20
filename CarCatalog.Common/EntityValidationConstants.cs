namespace CarCatalog.Common
{
    public class EntityValidationConstants
    {
        public static class CarValidations
        {
            public const int BrandMinValue = 3;
            public const int BrandMaxValue = 20;

            public const int ModelMinValue = 3;
            public const int ModelMaxValue = 40;

            public const int CarTypeMinValue = 3;
            public const int CarTypeMaxValue = 20;

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
    }
}