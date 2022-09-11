using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController  : ControllerBase
{
    

    private readonly ILogger<PizzaController> _logger;

    public PizzaController (ILogger<PizzaController> logger)
    {
        _logger = logger;
    }
#region ACTION
    
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]    
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound();
        return pizza;
    }
    [HttpPost()]    
    public IActionResult CreatePizza(Pizza newPizza)
    {
        PizzaService.Add(newPizza);        
        return CreatedAtAction(nameof(CreatePizza), new { id = newPizza.Id }, newPizza);
    }
    
    [HttpPut("{id}")]    
    public IActionResult UpdatePizza(int id, Pizza newPizza)
    {

        if (id!=newPizza.Id)
            return BadRequest();            

        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();            

        PizzaService.Update(newPizza);
        return NoContent();               
    }
    
    [HttpDelete("{id}")]    
    public IActionResult deletePizza(int id)
    {
         var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound(); 

        PizzaService.Delete(id);
        return NoContent();
    }

    






#endregion
}
