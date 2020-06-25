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

        // GET: api/Equipos
        [HttpGet]
        public ActionResult<List<Equipos>> Get()
        {
            return EquiposBLL.GetEquipos();
        }

        // GET: api/Equipos/1
        [HttpGet("{id}")]
        public ActionResult<Equipos> Get(int id)
        {
            return EquiposBLL.Buscar(id);
        }

        [HttpPost]
        public void Post([FromBody] Equipos equipos)
        {
            EquiposBLL.Guardar(equipos);
        }
    }
}
