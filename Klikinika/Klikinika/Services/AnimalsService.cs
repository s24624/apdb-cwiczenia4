using Klikinika.Models;
using Klikinika.Repositories;

namespace Klikinika.Services;

public class AnimalsService : IAnimalsService
{
    private IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _animalsRepository.GetAnimals();
    }

    public Animal GetAnimal(int id)
    {
        return _animalsRepository.GetAnimal(id);
    }

    public Animal AddAnimal(Animal animal)
    {
        _animalsRepository.AddAnimal(animal);
        return animal;
    }

    public Animal UpdateAnimal(Animal updatedAnimal)
    {
        _animalsRepository.UpdateAnimal(updatedAnimal);
        return updatedAnimal;
    }

    public Animal DeleteAnimal(int id)
    {
        _animalsRepository.DeleteAnimal(id);
        return null;
    }

    public IEnumerable<Visit> GetAnimalsWithVisits(int id)
    {
        return _animalsRepository.GetAnimalsWithVisits(id);
    }

    public Visit AddVisit(Visit visit, int animalId)
    {
        _animalsRepository.AddVisit(visit, animalId);
        return visit;
    }
}