using TaskXslx.DTO;
using TaskXslx.Entities;

namespace TaskXslx.Mappers
{
    public static class Mapper
    {
        public static Person ToEntity(this PersonDto dto)
        {
            var person = new Person();
            person.Age = dto.Age;
            person.Name = dto.PersonName;
            person.Pets = new List<Pet>();
            if (dto.Pet1 != "-")
                person.Pets.Add(new Pet()
                {
                    Name = dto.Pet1,
                    Type = dto.Pet1Type
                });
            if (dto.Pet2 != "-")
                person.Pets.Add(new Pet()
                {
                    Name = dto.Pet2,
                    Type = dto.Pet2Type
                });
            if (dto.Pet3 != "-")
                person.Pets.Add(new Pet()
                {
                    Name = dto.Pet3,
                    Type = dto.Pet3Type
                });
            return person;
        }

        public static PersonExport ToExport(this Person person)
        {
            var exp = new PersonExport();
            exp.Age = person.Age;
            exp.Name = person.Name;
            if (person.Pets != null)
                exp.Pets = person.Pets.Select(p => p.ToExport()).ToList();
            return exp;
        }

        public static AnimalExport ToExport(this Pet pet)
        {
            var exp = new AnimalExport();
            exp.Name = pet.Name;
            exp.Type = pet.Type;
            return exp;
        }
    }
}
