using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        /*
            ? [BindProperty] se utiliza para enlazar
            ?   la propiedad NewPizza a la página de Razor.
            ? Al realizarse una solicitud HTTP POST,
            ?   la propiedad NewPizza se rellenará
            ?   con la entrada del usuario.
        */
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            _service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
    }
}
