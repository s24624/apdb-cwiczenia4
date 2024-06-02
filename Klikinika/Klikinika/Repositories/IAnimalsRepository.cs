using Klikinika.Models;

namespace Klikinika.Repositories;

public interface IAnimalsRepository
{
    
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int id);
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(Animal updatedAnimal);
    Animal DeleteAnimal(int id);
    IEnumerable<Visit> GetAnimalsWithVisits(int id);
    Visit AddVisit(Visit visit,int id);
}