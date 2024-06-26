﻿using Klikinika.Models;
using Klikinika.Services;
using Microsoft.AspNetCore.Mvc;

namespace Klikinika.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalsService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalsService.GetAnimal(id);

        if (animal==null)
        {
            return Conflict("Animal with this id does not exists");
        }
        
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody]Animal animal)
    {
        var newAnimal = _animalsService.AddAnimal(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = newAnimal.Id }, newAnimal);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id,Animal updatedAnimal)
    {
        updatedAnimal.Id = id;
        var animal = _animalsService.UpdateAnimal(updatedAnimal);

        if (animal == null)
        {
            return NotFound("Animal with this id does not exist");
        }

        return Ok(animal);
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalsService.DeleteAnimal(id);
        return NoContent();
    }

    [HttpGet("{id:int}/visits")]
    public IActionResult GetAnimalsWithVisits(int id)
    {
        return Ok(_animalsService.GetAnimalsWithVisits(id));
    }

    [HttpPost("/AddVisit")]
    public IActionResult AddVisit([FromBody]Visit visit, [FromQuery]int animalId)
    {
        var addedVisit = _animalsService.AddVisit(visit, animalId);

        if (addedVisit != null)
        {
            return CreatedAtAction(
                nameof(GetAnimal),
                new { id = addedVisit.animal.Id },
                new { Message = "Wizyta została dodana pomyślnie.", Visit = addedVisit }
            );
        }
        else
        {
            return NotFound(new { Message = "Nie znaleziono zwierzęcia o podanym Id." });
        }
    }
}