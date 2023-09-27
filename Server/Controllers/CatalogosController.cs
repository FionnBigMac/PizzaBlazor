using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Server.Data;
using PizzaBlazor.Shared.Models;

namespace PizzaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CatalogosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //[HttpGet("tamanos")] es recomendable que cada endpoint tenga su nombre
        [HttpGet]
        public async Task<List<Tamanos>> Tamanos()
        {
            List<Tamanos> tamanos = new List<Tamanos>();
            //linq
            tamanos = await context.Tamanos.ToListAsync();
            //SELECT * FROM Tamanos

            //tamanos = new List<Tamanos>() hardcoded
            //{
            //    new Tamanos{Id = 1, Tamano = "Personal", Precio = 10.0f},
            //    new Tamanos{Id = 2, Tamano = "Chica", Precio = 20.0f},
            //    new Tamanos{Id = 3, Tamano = "Mediana", Precio = 30.0f},
            //    new Tamanos{Id = 4, Tamano = "Grande", Precio = 40.0f},
            //};
            return tamanos;
            
        }

        [HttpGet("tipomasa")]
        public async Task<List<TipoMasa>> Masas()
        {
            List<TipoMasa> masas = new List<TipoMasa>();
            masas = await context.Masas.ToListAsync();
            //masas = new List<TipoMasa>()
            //{
            //    new TipoMasa{Id = 1, Tipo = "Tradicional", Precio = 20.0f},
            //    new TipoMasa{Id = 2, Tipo = "Crunch", Precio = 25.0f},
            //    new TipoMasa{Id = 3, Tipo = "Orilla de queso", Precio = 35.0f},
            //    new TipoMasa{Id = 4, Tipo = "Sartén", Precio = 10.0f},
            //};
            return masas;
        }

        [HttpGet("ingredientes")]
        public async Task<List<Ingrediente>> Ingredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes = await context.Ingredientes.ToListAsync();
            //ingredientes = new List<Ingrediente>()
            //{
            //    new Ingrediente{Id = 1, Nombre = "Queso", Precio = 20.0f},
            //    new Ingrediente{Id = 2, Nombre = "Peperoni", Precio = 35.0f},
            //    new Ingrediente{Id = 3, Nombre = "Carnes frías", Precio = 30.0f},
            //    new Ingrediente{Id = 4, Nombre = "Champiñon", Precio = 15.0f},
            //    new Ingrediente{Id = 5, Nombre = "Jamón", Precio = 20.0f},
            //};
            return ingredientes;
        }

        [HttpPost("nvoingrediente")]
        public async Task<int> NvoIngrediente(Ingrediente nvoIngrediente)
        {
            context.Add(nvoIngrediente);
            await context.SaveChangesAsync();
            return nvoIngrediente.Id;
        }
    }
}
