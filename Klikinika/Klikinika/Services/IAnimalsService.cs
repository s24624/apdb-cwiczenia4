using Klikinika.Models;

namespace Klikinika.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int id);
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(Animal updatedAnimal);
}