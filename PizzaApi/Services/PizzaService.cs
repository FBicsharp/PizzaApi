using PizzaApi.Models;

namespace PizzaApi.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId => Pizzas.Max(x=>x.Id)+1;
    static PizzaService()
    {
        Pizzas = Generate10RandomPizza();
    }

    private static List<Pizza> Generate10RandomPizza(){
        return Enumerable.Range(1, 10).Select(index => new Pizza
            {
                Id=index,
                Name = $"Pizza_{index}",
                IsGlutenFree = (index%3>0 ? true:false)
            })
            .ToList();  
    }



    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}