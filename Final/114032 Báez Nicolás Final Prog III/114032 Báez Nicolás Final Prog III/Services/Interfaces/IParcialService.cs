using _114032_Báez_Nicolás_Final_Prog_III.Dominio;
using _114032_Báez_Nicolás_Final_Prog_III.Response;

namespace _114032_Báez_Nicolás_Final_Prog_III.Services.Interfaces;

public interface IParcialService
{
    //1) Get de provincias
    Task<BaseReponse<List<GetProvinciasDto>>> GetProvincias();

    //2) Get de tipos
    Task<BaseReponse<List<GetTiposDto>>> GetTipos();

    //3) Get de Configuraciones
    Task<BaseReponse<List<GetConfiguracionesDto>>> GetConfiguraciones();

    //4) Post de sucursal
    Task<BaseReponse<PostSucursalDto>> PostSucursal (PostSucursalDto postSucursalDto);

    //5) Get de sucursal que NO es de bs as y su fecha de creación es la más actual
    Task<BaseReponse<GetSucursalesDto>> GetSucursalNoBsAsMasActual();

    //6) Get de todas las sucursales
    Task<BaseReponse<List<GetSucursalesDto>>> GetAllSucursales();

    //7) Put de sucursal
    Task<BaseReponse<PutSucursalDto>> PutSucursal(PutSucursalDto putSucursalDto);

    //8) Sucursal por id
    Task<BaseReponse<GetSucursalesDto>> GetSucursalById(Guid id);
}
