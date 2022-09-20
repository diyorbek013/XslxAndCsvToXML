using CsvHelper.Configuration.Attributes;

namespace TaskXslx.DTO
{
    public class PersonExport
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<AnimalExport> Pets { get; set; }
    }
}
