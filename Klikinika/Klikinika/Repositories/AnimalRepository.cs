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
}