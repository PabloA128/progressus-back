﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Dtos.MembresiaDtos;
using ProgressusWebApi.Models.MembresiaModels;
using ProgressusWebApi.Repositories.MembresiaRepositories;
using ProgressusWebApi.Repositories.MembresiaRepositories.Interfaces;
using ProgressusWebApi.Services.MembresiaServices;
using ProgressusWebApi.Services.MembresiaServices.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class SolicitudDePagoController : ControllerBase
{
    private readonly ISolicitudDePagoService _solicitudDePagoService;
    private readonly ProgressusDataContext _context;
    private readonly IMembresiaRepository _membresiaRepository; // Declarar el campo
    private readonly ISolicitudDePagoRepository _solicitudDePagoRepository;



    public SolicitudDePagoController(ISolicitudDePagoService solicitudDePagoService, ProgressusDataContext context, IMembresiaRepository membresiaRepository, ISolicitudDePagoRepository solicitudDePagoRepository)
    {
        _solicitudDePagoService = solicitudDePagoService;

        _solicitudDePagoRepository = solicitudDePagoRepository;
        _context = context;
        _membresiaRepository = membresiaRepository; // Inicializar el campo

    }

    [HttpPost("CrearSolicitudDePago")]
    public async Task<IActionResult> CrearSolicitudDePago(CrearSolicitudDePagoDto dto)
    {
        SolicitudDePago solicitud = await _solicitudDePagoService.CrearSolicitudDePago(dto);
        return Ok(solicitud);
    }

    [HttpPut("RegistrarPagoEnEfectivo")]
    public async Task<IActionResult> RegistrarPagoEnEfectivo(int idSolicitudDePago)
    {
        var solicitudExistente = await _solicitudDePagoService.RegistrarPagoEnEfectivo(idSolicitudDePago);
        if (solicitudExistente == null)
            return NotFound(); // Retornar 404 si no se encuentra la solicitud
        return Ok(solicitudExistente); // Retornar la solicitud actualizada
    }

    [HttpPut("RegistrarPagoConMercadoPago")]
    public async Task<IActionResult> RegistrarPagoConMercadoPago(int idSolicitudDePago)
    {
        var solicitud = await _solicitudDePagoService.RegistrarPagoConMercadoPago(idSolicitudDePago);
        if (solicitud == null)
            return NotFound(); // Retornar 404 si no se encuentra la solicitud
        return Ok(solicitud); // Retornar la solicitud actualizada
    }

    [HttpPut("CancelarSolicitudDePago")]
    public async Task<IActionResult> CancelarSolicitudDePago(int idSolicitudDePago)
    {
        var solicitudExistente = await _solicitudDePagoService.CancelarSolicitudDePago(idSolicitudDePago);
        if (solicitudExistente == null)
            return NotFound(); // Retornar 404 si no se encuentra la solicitud
        return Ok(solicitudExistente); // Retornar la solicitud cancelada
    }

    [HttpGet("ObtenerEstadoActualDeSolicitud")]
    public async Task<IActionResult> ObtenerEstadoActualDeSolicitud(int idSolicitudDePago)
    {
        return new OkObjectResult(_solicitudDePagoService.ObtenerEstadoActualDeSolicitud(idSolicitudDePago).Result);
    }

    [HttpGet("ObtenerSolicitudDePagoDeSocio")]
    public async Task<IActionResult> ObtenerSolicitudDePagoDeSocio(string IdentityUserId)
    {
        return new OkObjectResult(_solicitudDePagoService.ObtenerSolicitudDePagoDeSocio(IdentityUserId).Result);
    }

    [HttpGet("ObtenerTiposDePagos")]
    public async Task<IActionResult> ObtenerTiposDePagos()
    {
        return new OkObjectResult(await _solicitudDePagoService.ObtenerTiposDePago());
    }

    [HttpGet("ConsultarVigenciaDeMembresia")]
    public async Task<IActionResult> ConsultarVigenciaDeMembresia(string identityUserId)
    {
        return new OkObjectResult(await _solicitudDePagoService.ConsultarVigenciaDeMembresia(identityUserId));
    }

    [HttpGet("ObtenerTodasLasSolicitudesDeUnSocio")]
    public async Task<IActionResult> ObtenerTodasLasSolicitudesDeUnSocio(string identityUserId)
    {
        return new OkObjectResult(await _solicitudDePagoService.ObtenerTodasLasSolicitudesDeUnSocio(identityUserId));
    }

    [HttpGet("pagos-efectivo-confirmados")]
    public async Task<IActionResult> ObtenerPagosEfectivoConfirmadosAsync()
    {
        var pagosEfectivo = await _context.SolicitudDePagos
            .Where(s => s.TipoDePagoId == 1) // Filtra por pagos en efectivo
            .Join(
                _context.HistorialSolicitudDePagos,
                solicitud => solicitud.Id,
                historial => historial.SolicitudDePagoId,
                (solicitud, historial) => new { solicitud, historial }
            )
            .Where(joined => joined.historial.EstadoSolicitudId == 2) // Filtra por estado confirmado
            .Select(joined => new PagoEfectivoConfirmadoDto
            {
                TipoMembresiaId = joined.solicitud.MembresiaId,
                FechaPago = joined.historial.FechaCambioEstado
            })
            .ToListAsync();

        if (!pagosEfectivo.Any())
        {
            return NotFound("No se encontraron pagos en efectivo confirmados.");
        }

        return Ok(pagosEfectivo);
    }

    
  
    

    [HttpGet("pagos-efectivo-Usuario")]
    public async Task<IActionResult> ObtenerPagosEfectivoConfirmadosUsuario()
    {
        var pagosEfectivo = await _context.SolicitudDePagos
           //   .Where(s => s.TipoDePagoId == 1) // Filtra por pagos en efectivo
              .Join(
                  _context.HistorialSolicitudDePagos,
                  solicitud => solicitud.Id,
                  historial => historial.SolicitudDePagoId,
                  (solicitud, historial) => new { solicitud, historial }
              )
              .Join(
                  _context.Socios, // Tabla de Socios
                  joined => joined.solicitud.IdentityUserId,
                  socio => socio.UserId, // Relación entre UserId de SolicitudDePagos y Socio
                  (joined, socio) => new
                  {
                      joined.solicitud,
                      joined.historial,
                      socio
                  }
              )
              .Join(
                  _context.Membresias, // Tabla de Membresías
                  joined => joined.solicitud.MembresiaId,
                  membresia => membresia.Id, // Relación entre MembresiaId
                  (joined, membresia) => new
                  {
                      joined.solicitud,
                      joined.historial,
                      joined.socio,
                      membresia
                  }
              )
              .Where(joined => joined.historial.EstadoSolicitudId == 2) // Filtra por estado confirmado
              .Select(joined => new PagoEfectivoUserConfirmadoDto
              {
                  TipoMembresiaId = joined.solicitud.MembresiaId,
                  NombreMembresia = joined.membresia.Nombre, // Nombre de la membresía
                  PrecioMembresia = joined.membresia.Precio, // Precio de la membresía
                  FechaPago = joined.historial.FechaCambioEstado,
                  IdentityUserId = joined.socio.UserId,
                  Nombre = joined.socio.Nombre,
                  Apellido = joined.socio.Apellido
              })
              .ToListAsync();

        if (!pagosEfectivo.Any())
        {
            return NotFound("No se encontraron pagos en efectivo confirmados.");
        }

        return Ok(pagosEfectivo);
    }

    
    [HttpGet("ObtenerSolicitudDePagoDeSocioSinNutricional/{identityUserId}")]
    public async Task<SolicitudDePago> ObtenerSolicitudDePagoDeSocioSinNutricional(string identityUserId)
    {
        // Obtener la solicitud de pago más reciente del socio, excluyendo las que tienen MembresiaId = 15
        SolicitudDePago? solicitud = await _context.SolicitudDePagos
            .Where(s => s.IdentityUserId == identityUserId && s.MembresiaId != 15)
            .Include(s => s.HistorialSolicitudDePagos)
            .ThenInclude(h => h.EstadoSolicitud)
            .OrderByDescending(s => s.FechaCreacion)
            .FirstOrDefaultAsync();

        // Si no se encuentra ninguna solicitud, devolver null
        if (solicitud == null)
        {
            return null;
        }

        // Cargar el TipoDePago y la Membresia de manera asíncrona
        solicitud.TipoDePago = await _solicitudDePagoRepository.ObtenerTipoDePagoPorIdAsync(solicitud.TipoDePagoId);
        solicitud.Membresia = await _membresiaRepository.GetById(solicitud.MembresiaId);

        return solicitud;
    }

    

    [HttpGet("balance-ingresos/{mes}")]
    public async Task<IActionResult> ObtenerBalanceDeIngresosPorMesAsync(int mes)
    {
        if (mes < 1 || mes > 12)
        {
            return BadRequest("El mes proporcionado no es válido. Debe estar entre 1 y 12.");
        }

        // Diccionario para los valores por TipoMembresiaId
        var membresiaValores = new Dictionary<int, decimal>
    {
        { 9, 10000 },
        { 10, 27000 },
        { 11, 50000 },
        { 12, 90000 }
    };

        // Filtrar los datos relevantes desde la base de datos
        var ingresosDb = await _context.SolicitudDePagos
            .Join(
                _context.HistorialSolicitudDePagos,
                solicitud => solicitud.Id,
                historial => historial.SolicitudDePagoId,
                (solicitud, historial) => new { solicitud, historial }
            )
            .Where(joined =>
                joined.historial.EstadoSolicitudId == 2 && // Pagos confirmados
                joined.historial.FechaCambioEstado.Month == mes // Filtrar por mes
            )
            .Select(joined => new
            {
                TipoMembresiaId = joined.solicitud.MembresiaId
            })
            .ToListAsync();

        // Filtrar los registros relevantes y calcular el monto en memoria
        var montoTotal = ingresosDb
            .Where(ingreso => membresiaValores.ContainsKey(ingreso.TipoMembresiaId)) // Filtrar por membresías válidas
            .Sum(ingreso => membresiaValores[ingreso.TipoMembresiaId]); // Calcular el total

        if (montoTotal == 0)
        {
            return NotFound($"No se encontraron ingresos confirmados para el mes {mes}.");
        }

        return Ok(new
        {
            Mes = mes,
            MontoTotal = montoTotal
        });
    }

    [HttpGet("solicitudes-confirmadas-por-mes")]
    public async Task<IActionResult> ObtenerSolicitudesConfirmadasPorMesAsync()
    {
        // Obtener las solicitudes en estado confirmado y agruparlas por mes
        var solicitudesPorMes = await _context.SolicitudDePagos
            .Join(
                _context.HistorialSolicitudDePagos,
                solicitud => solicitud.Id,
                historial => historial.SolicitudDePagoId,
                (solicitud, historial) => new { solicitud, historial }
            )
            .Where(joined => joined.historial.EstadoSolicitudId == 2) // Filtrar por estado confirmado
            .GroupBy(
                joined => joined.historial.FechaCambioEstado.Month, // Agrupar por mes
                joined => new
                {
                    joined.solicitud.Id,
                    TipoMembresiaId = joined.solicitud.MembresiaId,
                    FechaPago = joined.historial.FechaCambioEstado
                }
            )
            .Select(grupo => new
            {
                Mes = grupo.Key, // Mes
                Solicitudes = grupo.ToList() // Lista de solicitudes del mes
            })
            .OrderBy(grupo => grupo.Mes) // Ordenar por mes
            .ToListAsync();

        if (!solicitudesPorMes.Any())
        {
            return NotFound("No se encontraron solicitudes confirmadas agrupadas por mes.");
        }

        return Ok(solicitudesPorMes);
    }
    [HttpGet("ObtenerSolicitudesDePagoDeUnSocio")]
    public async Task<IActionResult> ObtenerSolicitudesDePagoDeSocio(string identityUserId)
    {
        var solicitudes = await _solicitudDePagoService.ObtenerSolicitudesDePagoDeSocio(identityUserId);
        if (solicitudes == null || !solicitudes.Any())
        {
            return NotFound("No se encontraron solicitudes de pago para el socio especificado.");
        }
        return Ok(solicitudes);
    }




    [HttpGet("balance-ingresos")]
    public async Task<IActionResult> ObtenerBalanceDeIngresosPorTodosLosMesesAsync()
    {
        // Diccionario para los valores por TipoMembresiaId
        var membresiaValores = new Dictionary<int, decimal>
 {
     { 9, 10000 },
     { 10, 27000 },
     { 11, 50000 },
     { 12, 90000 }
 };

        // Filtrar los datos relevantes desde la base de datos
        var ingresosDb = await _context.SolicitudDePagos
            .Join(
                _context.HistorialSolicitudDePagos,
                solicitud => solicitud.Id,
                historial => historial.SolicitudDePagoId,
                (solicitud, historial) => new { solicitud, historial }
            )
            .Where(joined =>
                joined.historial.EstadoSolicitudId == 2 // Pagos confirmados
            )
            .Select(joined => new
            {
                TipoMembresiaId = joined.solicitud.MembresiaId,
                Mes = joined.historial.FechaCambioEstado.Month
            })
            .ToListAsync();

        // Calcular el monto por cada mes
        var ingresosPorMes = ingresosDb
            .Where(ingreso => membresiaValores.ContainsKey(ingreso.TipoMembresiaId)) // Filtrar por membresías válidas
            .GroupBy(ingreso => ingreso.Mes) // Agrupar por mes
            .Select(grupo => new
            {
                Mes = grupo.Key,
                MontoTotal = grupo.Sum(ingreso => membresiaValores[ingreso.TipoMembresiaId]) // Sumar los valores
            })
            .ToList();

        // Agregar meses sin ingresos con monto 0
        var todosLosMeses = Enumerable.Range(1, 12)
            .Select(mes => new
            {
                Mes = mes,
                MontoTotal = ingresosPorMes.FirstOrDefault(i => i.Mes == mes)?.MontoTotal ?? 0
            })
            .OrderBy(m => m.Mes)
            .ToList();

        return Ok(todosLosMeses);
    }






}
