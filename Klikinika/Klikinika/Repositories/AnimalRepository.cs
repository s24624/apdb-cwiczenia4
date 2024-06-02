using Klikinika.Models;

namespace Klikinika.Repositories;

public class AnimalRepository : IAnimalsRepository
{
    public static List<Animal> ListOfAnimals { get; } = new List<Animal>()
    {
        new Animal()
        {
            Id = 1,Imie = "Zula",Kategoria = "Pies",Masa = 25,KolorSiersci = "Szaro-Biały"
        }
    };

    public static Dictionary<Animal, List<Visit>> AnimalsWithVisits = new Dictionary<Animal, List<Visit>>()
    {
        {
            ListOfAnimals[0], new List<Visit>()
            {
                new Visit()
                {
                    data = "2023-01-03",animal = ListOfAnimals[0],
                    opis = "Wizyta kontrolna", cena = 40
                },
                new Visit(){
                    data = "2023-01-16", animal = ListOfAnimals[0],
                    opis = "Sczepienie",cena = 120
                }
            }
        }
    };

    
    public IEnumerable<Animal> GetAnimals()
    {
        return ListOfAnimals;
    }

    public Animal GetAnimal(int id)
    {
        foreach (var animal in ListOfAnimals)
        {
            if (animal.Id == id)
                return animal;
        }

        return null;
    }

    public Animal AddAnimal(Animal animal)
    {
        ListOfAnimals.Add(animal);
        return animal;
    }

    public Animal UpdateAnimal(Animal updatedAnimal)
    {
        
        var animalToUptade = ListOfAnimals.FirstOrDefault(a => a.Id == updatedAnimal.Id);

        if (animalToUptade!=null)
        {
            animalToUptade.Id = updatedAnimal.Id;
            animalToUptade.KolorSiersci = updatedAnimal.KolorSiersci;
            animalToUptade.Kategoria = updatedAnimal.Kategoria;
            animalToUptade.Imie = updatedAnimal.Imie;
            animalToUptade.Masa = updatedAnimal.Masa;
        }

        return animalToUptade;
    }

    public Animal DeleteAnimal(int id)
    {
        foreach (var var in ListOfAnimals)
        {
            if (var.Id == id)
            {
                ListOfAnimals.Remove(var);
            }    
        }

        return null;
    }

    public IEnumerable<Visit> GetAnimalsWithVisits(int id)
    {
        List<Visit> visits = null;
        foreach (var animal in AnimalsWithVisits)
        {
            if (animal.Key.Id == id)
                visits = animal.Value;
        }

        return visits;
    }

    public Visit AddVisit(Visit visit, int animalId)
    {
        foreach (var kvp in AnimalsWithVisits)
        {
            if (kvp.Key.Id == animalId)
            {
                visit.animal = kvp.Key;
                kvp.Value.Add(visit);
            }
        }

        return visit;
    }
}