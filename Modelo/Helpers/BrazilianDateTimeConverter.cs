using Newtonsoft.Json.Converters;

namespace Skuta.Model.Helpers
{
    public class BrazilianDateTimeConverter : IsoDateTimeConverter
    {
        public BrazilianDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
