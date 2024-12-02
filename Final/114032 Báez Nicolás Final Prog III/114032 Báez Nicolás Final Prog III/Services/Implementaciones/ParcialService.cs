using _114032_Báez_Nicolás_Final_Prog_III.Dominio;
using _114032_Báez_Nicolás_Final_Prog_III.Models;
using _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;
using _114032_Báez_Nicolás_Final_Prog_III.Response;
using _114032_Báez_Nicolás_Final_Prog_III.Services.Interfaces;
using _114032_Báez_Nicolás_Final_Prog_III.Validators;
using AutoMapper;

namespace _114032_Báez_Nicolás_Final_Prog_III.Services.Implementaciones;

public class ParcialService : IParcialService
{
    private readonly IExtraRepository _extraRepository;
    private readonly ISucursalesRepository _sucursalesRepository;
    private readonly IMapper _mapper;
    private readonly PostSucursalesDtoValidators _postSucursalesDtoValidators;
    private readonly PutSucursalDtoValidator _putSucursalDtoValidator;

    public ParcialService(IExtraRepository extraRepository, ISucursalesRepository sucursalesRepository,
        IMapper mapper, PostSucursalesDtoValidators postSucursalDtoValidator, PutSucursalDtoValidator putSucursalDtoValidator)
    {
        _extraRepository = extraRepository;
        _sucursalesRepository = sucursalesRepository;
        _mapper = mapper;
        _postSucursalesDtoValidators = postSucursalDtoValidator;
        _putSucursalDtoValidator = putSucursalDtoValidator;
    }

    //1) Get de provincias
    public async Task<BaseReponse<List<GetProvinciasDto>>> GetProvincias()
    {
        var response = new BaseReponse<List<GetProvinciasDto>>();

        try
        {
            var provincias = await _extraRepository.GetProvincias();
            response.Success = true;
            response.Data = _mapper.Map<List<GetProvinciasDto>>(provincias);
            response.Message = "Provincias obtenidas correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener provincias";
            throw;
        }
    }

    //2) Get de tipos
    public async Task<BaseReponse<List<GetTiposDto>>> GetTipos()
    {
        var response = new BaseReponse<List<GetTiposDto>>();

        try
        {
            var tipos = await _extraRepository.GetTipos();
            response.Success = true;
            response.Data = _mapper.Map<List<GetTiposDto>>(tipos);
            response.Message = "Tipos obtenidos correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener tipos";
            throw;
        }
    }

    //3) Get de Configuraciones
    public async Task<BaseReponse<List<GetConfiguracionesDto>>> GetConfiguraciones()
    {
        var response = new BaseReponse<List<GetConfiguracionesDto>>();

        try
        {
            var configuraciones = await _extraRepository.GetConfiguraciones();
            response.Success = true;
            response.Data = _mapper.Map<List<GetConfiguracionesDto>>(configuraciones);
            response.Message = "Configuraciones obtenidas correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener configuraciones";
            throw;
        }
    }

    //4) Post de sucursal
    public async Task<BaseReponse<PostSucursalDto>> PostSucursal(PostSucursalDto postSucursalDto)
    {
        var response = new BaseReponse<PostSucursalDto>();

        var validationResult = _postSucursalesDtoValidators.Validate(postSucursalDto);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(" | ", validationResult.Errors.Select(x => x.ErrorMessage));
            response.Success = false;
            response.Message = errors;
            return response;
        }

        try
        {
            var sucursal = _mapper.Map<Sucursales>(postSucursalDto);
            sucursal.Id = Guid.NewGuid();
            sucursal.FechaAlta = DateTime.Now;

            var sucursalCreada = await _sucursalesRepository.PostSucursal(sucursal);

            response.Success = true;
            response.Data = _mapper.Map<PostSucursalDto>(sucursalCreada);
            response.Message = "Sucursal creada correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al crear la sucursal";
            throw;
        }
    }

    //5) Get de sucursal que NO es de bs as y su fecha de creación es la más actual
    public async Task<BaseReponse<GetSucursalesDto>> GetSucursalNoBsAsMasActual()
    {
        var response = new BaseReponse<GetSucursalesDto>();

        try
        {
            var sucursal = await _sucursalesRepository.GetSucursalNoBsAsMasActual();
            response.Success = true;
            response.Data = _mapper.Map<GetSucursalesDto>(sucursal);
            response.Message = "Sucursal obtenida correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener la sucursal";
            throw;
        }
    }

    //6) Get de todas las sucursales
    public async Task<BaseReponse<List<GetSucursalesDto>>> GetAllSucursales()
    {
        var response = new BaseReponse<List<GetSucursalesDto>>();

        try
        {
            var sucursales = await _extraRepository.GetSucursales();
            response.Success = true;
            response.Data = _mapper.Map<List<GetSucursalesDto>>(sucursales);
            response.Message = "Sucursales obtenidas correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener sucursales";
            throw;
        }
    }

    //7) Put de sucursal
    public async Task<BaseReponse<PutSucursalDto>> PutSucursal(PutSucursalDto putSucursalDto)
    {
        var response = new BaseReponse<PutSucursalDto>();

        var validationResult = _putSucursalDtoValidator.Validate(putSucursalDto);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(" | ", validationResult.Errors.Select(x => x.ErrorMessage));
            response.Success = false;
            response.Message = errors;
            return response;
        }

        try
        {
            var sucursal = _mapper.Map<Sucursales>(putSucursalDto);

            var sucursalActualizada = await _sucursalesRepository.PutSucursal(sucursal);

            response.Success = true;
            response.Data = _mapper.Map<PutSucursalDto>(sucursalActualizada);
            response.Message = "Sucursal actualizada correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al actualizar la sucursal";
            throw;
        }
    }

    //8) Sucursal por id
    public async Task<BaseReponse<GetSucursalesDto>> GetSucursalById(Guid id)
    {
        var response = new BaseReponse<GetSucursalesDto>();

        try
        {
            var sucursal = await _extraRepository.GetSucursalById(id);
            response.Success = true;
            response.Data = _mapper.Map<GetSucursalesDto>(sucursal);
            response.Message = "Sucursal obtenida correctamente";
            return response;
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Error al obtener la sucursal";
            throw;
        }
    }
    
}
