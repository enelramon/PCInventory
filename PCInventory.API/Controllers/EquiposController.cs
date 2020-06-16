using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PCInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Equipos>> Get()
        {
            return EquiposBLL.GetEquipos();
        }

        [HttpGet("{id}")]
        public void Get(int id)
        {
             EquiposBLL.Buscar(id);
        }

        [HttpPost]
        public void Post ([FromBody] Equipos equipos)
        {
             EquiposBLL.Guardar(equipos);
        }
    }
}
