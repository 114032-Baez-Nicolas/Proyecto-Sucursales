using _114032_Báez_Nicolás_Final_Prog_III.Dominio;
using _114032_Báez_Nicolás_Final_Prog_III.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _114032_Báez_Nicolás_Final_Prog_III.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcialController : ControllerBase
    {
        private readonly IParcialService _parcialService;

        public ParcialController(IParcialService parcialService)
        {
            _parcialService = parcialService;
        }

        //1) Get de provincias
        [HttpGet("GetProvincias")]

        public async Task<IActionResult> GetProvincias()
        {
            var response = await _parcialService.GetProvincias();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //2) Get de tipos
        [HttpGet("GetTipos")]
        public async Task<IActionResult> GetTipos()
        {
            var response = await _parcialService.GetTipos();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //3) Get de Configuraciones
        [HttpGet("GetConfiguraciones")]
        public async Task<IActionResult> GetConfiguraciones()
        {
            var response = await _parcialService.GetConfiguraciones();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //4) Post de sucursal
        [HttpPost("PostSucursal")]
        public async Task<IActionResult> PostSucursal([FromBody] PostSucursalDto postSucursalDto)
        {
            var response = await _parcialService.PostSucursal(postSucursalDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //5) Get de sucursal que NO es de bs as y su fecha de creación es la más actual
        [HttpGet("GetSucursalNoBsAsMasActual")]
        public async Task<IActionResult> GetSucursalNoBsAsMasActual()
        {
            var response = await _parcialService.GetSucursalNoBsAsMasActual();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //6) Get de todas las sucursales
        [HttpGet("GetAllSucursales")]
        public async Task<IActionResult> GetAllSucursales()
        {
            var response = await _parcialService.GetAllSucursales();
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //7) Put de sucursal
        [HttpPut("PutSucursal")]
        public async Task<IActionResult> PutSucursal([FromBody] PutSucursalDto putSucursalDto)
        {
            var response = await _parcialService.PutSucursal(putSucursalDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        //8) Sucursal por id
        [HttpGet("GetSucursalById/{id}")]
        public async Task<IActionResult> GetSucursalById(Guid id)
        {
            var response = await _parcialService.GetSucursalById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
