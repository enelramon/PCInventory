using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
namespace PCInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
    

        // GET: api/Equipo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipo
        [HttpPost]
        public void Post([FromBody] Equipos equipo)
        {
            EquiposBLL.Guardar(equipo);

        }
 
    }
}
