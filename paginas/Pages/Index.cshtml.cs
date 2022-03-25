using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using paginas.Models;
using System.Threading.Tasks;

namespace paginas.Pages
{
    public class IndexModel : PageModel
    {
        public ILogger<IndexModel> _logger;

        public List<PersonaClass> FileModels { get; private set; } = new List<PersonaClass>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
