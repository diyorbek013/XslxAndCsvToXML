using CsvHelper.Configuration.Attributes;

namespace TaskXslx.DTO
{
    public class PersonDto
    {
        [Name("PersonName")]
        public string PersonName { get; set; }

        [Name("Age")]
        public int Age { get; set; }

        [Name("Pet 1")]
        public string Pet1 { get; set; }

        [Name("Pet 1 Type")]
        public string Pet1Type { get; set; }

        [Name("Pet 2")]
        public string Pet2 { get; set; }

        [Name("Pet 2 Type")]
        public string Pet2Type { get; set; }

        [Name("Pet 3")]
        public string Pet3 { get; set; }

        [Name("Pet 3 Type")]
        public string Pet3Type { get; set; }
    }
}
