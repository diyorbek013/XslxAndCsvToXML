using CsvHelper;
using Ganss.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaskXslx.Data;
using TaskXslx.DTO;
using TaskXslx.Mappers;

namespace TaskXslx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly AnimalDbContext _context;

        public AnimalsController(ILogger<AnimalsController> logger, AnimalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("/importcsv")]
        public async Task<IActionResult> Import([FromForm] FileModel file)
        {
            List<PersonDto> records;
            using (TextReader reader = new StreamReader(file.ImportFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, new CultureInfo("en-Us")))
            {
                records = csv.GetRecords<PersonDto>().ToList();
            }
            var persons = records.Select(r => r.ToEntity()).ToList();
            _context.Persons.AddRange(persons);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"{records.Count} datas added.");
            return Ok();
        }

        [HttpPost("/importxsls")]
        public async Task<IActionResult> Importxlsx([FromForm] FileModel file)
        {
            var persons1 = new ExcelMapper(file.ImportFile.OpenReadStream()).Fetch<PersonDto>();
            var persons = persons1.Select(r => r.ToEntity()).ToList();
            _context.Persons.AddRange(persons);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        public IActionResult Export()
        {
            var people = new PersonsExport();
            people.People = _context.Persons.Include(p => p.Pets).Select(p => p.ToExport()).ToList();
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(PersonsExport));
            System.IO.MemoryStream file = new MemoryStream();
            writer.Serialize(file, people);
            byte[] b = file.ToArray();
            return File(b, "application/xml");
        }
    }
}
