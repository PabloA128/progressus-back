﻿using MercadoPago.Resource.Preference;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Dtos.MembresiaDtos;
using ProgressusWebApi.Models.MembresiaModels;
using ProgressusWebApi.Repositories.MembresiaRepositories.Interfaces;
using ProgressusWebApi.Services.MembresiaServices.Interfaces;
using WebApiMercadoPago.Repositories;
using WebApiMercadoPago.Repositories.Interface;

namespace ProgressusWebApi.Services.MembresiaServices
{
    public class SolicitudDePagoService : ISolicitudDePagoService
    {
        private readonly ISolicitudDePagoRepository _repository;
        private readonly IMercadoPagoRepository _mercadoPagoRepository;



        public SolicitudDePagoService(ISolicitudDePagoRepository repository, IMercadoPagoRepository mercadoPagoRepository)
        {
            _repository = repository;
            _mercadoPagoRepository = mercadoPagoRepository;
        }
        public async Task<List<SolicitudDePago>> ObtenerSolicitudesDePagoDeSocio(string identityUserId)
        {
            return await _repository.ObtenerSolicitudesDePagoDeSocio(identityUserId);
        }

        public async Task<SolicitudDePago> CrearSolicitudDePago(CrearSolicitudDePagoDto dto)
        {
            SolicitudDePago solicitudACrear = new SolicitudDePago()
            {
                MembresiaId = dto.MembresiaId,
                TipoDePagoId = dto.TipoDePagoId,
                IdentityUserId = dto.SocioId,
                FechaCreacion = DateTime.Now,
            };
            SolicitudDePago solicitudCreada = _repository.CrearSolicitudDePagoAsync(solicitudACrear).Result;
            EstadoSolicitud pendiente = _repository.ObtenerEstadoSolicitudPorNombreAsync("Pendiente").Result;
            HistorialSolicitudDePago historialPendienteACrear = new HistorialSolicitudDePago()
            {
                EstadoSolicitud = pendiente,
                EstadoSolicitudId = pendiente.Id,
                SolicitudDePago = solicitudCreada,
                SolicitudDePagoId = solicitudCreada.Id,
                FechaCambioEstado = DateTime.Now,
            };
            HistorialSolicitudDePago historialPendiente = _repository.CrearHistorialSolicitudDePagoAsync(historialPendienteACrear).Result;
            return solicitudCreada;
        }
        public async Task<IActionResult> RegistrarPagoEnEfectivo(int idSolicitudDePago)
        {
            HistorialSolicitudDePago historialActual = _repository.ObtenerUltimoHistorialDeUnaSolicitudAsync(idSolicitudDePago).Result;
            EstadoSolicitud estadoActual = _repository.ObtenerEstadoSolicitudPorIdAsync(historialActual.EstadoSolicitudId).Result;

            if (estadoActual.Nombre != "Pendiente")
            {
                return new BadRequestObjectResult("El estado actual del pago no está en Pendiente");
            }
            EstadoSolicitud estadoConfirmado = _repository.ObtenerEstadoSolicitudPorNombreAsync("Confirmado").Result;
            HistorialSolicitudDePago historialSolicitudDePago = new HistorialSolicitudDePago()
            {
                FechaCambioEstado = DateTime.Now,
                SolicitudDePagoId = idSolicitudDePago,
                EstadoSolicitud = estadoConfirmado,
                EstadoSolicitudId = estadoConfirmado.Id,
                SolicitudDePago = await _repository.ObtenerSolicitudDePagoPorIdAsync(idSolicitudDePago),
            };
            HistorialSolicitudDePago historialConfirmado = _repository.CrearHistorialSolicitudDePagoAsync(historialSolicitudDePago).Result;
            return new OkObjectResult(historialConfirmado);
        }
        public async Task<IActionResult> CancelarSolicitudDePago(int idSolicitudDePago)
        {
            HistorialSolicitudDePago historialActual = _repository.ObtenerUltimoHistorialDeUnaSolicitudAsync(idSolicitudDePago).Result;
            EstadoSolicitud estadoActual = _repository.ObtenerEstadoSolicitudPorIdAsync(historialActual.EstadoSolicitudId).Result;

            if (estadoActual.Nombre != "Pendiente")
            {
                return new BadRequestObjectResult("El estado actual del pago no está en Pendiente");
            }
            EstadoSolicitud estadoCancelado = _repository.ObtenerEstadoSolicitudPorNombreAsync("Cancelado").Result;
            HistorialSolicitudDePago historialSolicitudDePago = new HistorialSolicitudDePago()
            {
                FechaCambioEstado = DateTime.Now,
                SolicitudDePagoId = idSolicitudDePago,
                EstadoSolicitud = estadoCancelado,
                EstadoSolicitudId = estadoCancelado.Id,
                SolicitudDePago = await _repository.ObtenerSolicitudDePagoPorIdAsync(idSolicitudDePago),
            };
            HistorialSolicitudDePago historialConfirmado = _repository.CrearHistorialSolicitudDePagoAsync(historialSolicitudDePago).Result;
            return new OkObjectResult(historialConfirmado);
        }

        public async Task<IActionResult> ObtenerEstadoActualDeSolicitud(int idSolicitudDePago)
        {
            HistorialSolicitudDePago historialSolicitudDePago = _repository.ObtenerUltimoHistorialDeUnaSolicitudAsync(idSolicitudDePago).Result;
            EstadoSolicitud estadoActual = _repository.ObtenerEstadoSolicitudPorIdAsync(historialSolicitudDePago.EstadoSolicitudId).Result;
            SolicitudDePago solicitudActual = _repository.ObtenerSolicitudDePagoPorIdAsync(historialSolicitudDePago.SolicitudDePagoId).Result;
            historialSolicitudDePago.SolicitudDePago = solicitudActual;
            historialSolicitudDePago.EstadoSolicitud = estadoActual;
            return new OkObjectResult(historialSolicitudDePago);

        }

        public async Task<SolicitudDePago> ObtenerSolicitudDePagoDeSocio(string identityUserId)
        {
            SolicitudDePago solicitud = await _repository.ObtenerSolicitudDePagoDeSocio(identityUserId);
            return solicitud;
        }

        public async Task<IActionResult> ObtenerTiposDePago()
        {
            var tipos = await _repository.ObtenerTiposDePagos();
            return new OkObjectResult(tipos);
        }

        public async Task<IActionResult> ConsultarVigenciaDeMembresia(string userId)
        {
            var vigencia = _repository.ConsultarVigenciaDeMembresia(userId);
            return new OkObjectResult(vigencia);
        }

        public async Task<IActionResult> RegistrarPagoConMercadoPago(int idSolicitudDePago)
        {
            SolicitudDePago solicitud = _repository.ObtenerSolicitudDePagoPorIdAsync(idSolicitudDePago).Result;
            Preference pref = await _mercadoPagoRepository.CreatePreferenceAsync(solicitud);
            //solicitud.preferenceIdMercadoPago = pref.Id;
            if (solicitud != null)
            {
                await _repository.ActualizarSolicitud(solicitud);
            }

            return new OkObjectResult(pref);

        }


     



        public async Task<IActionResult> ObtenerTodasLasSolicitudesDeUnSocio(string identityUserId)
        {
            return await _repository.ObtenerTodasLasSolicitudesDeUnSocio(identityUserId);
        }

        public async Task<SolicitudDePago> ConfirmarPagoConMercadoPago(int solicitudDePagoId)
        {
            if (solicitudDePagoId != null)
            {
                await this.RegistrarPagoEnEfectivo(solicitudDePagoId);
            }

            HistorialSolicitudDePago historialActual = _repository.ObtenerUltimoHistorialDeUnaSolicitudAsync(solicitudDePagoId).Result;
            EstadoSolicitud estadoActual = _repository.ObtenerEstadoSolicitudPorIdAsync(historialActual.EstadoSolicitudId).Result;

            if (estadoActual.Nombre != "Pendiente")
            {
                return null;
            }
            EstadoSolicitud estadoConfirmado = _repository.ObtenerEstadoSolicitudPorNombreAsync("Confirmado").Result;
            HistorialSolicitudDePago historialSolicitudDePago = new HistorialSolicitudDePago()
            {
                FechaCambioEstado = DateTime.Now,
                SolicitudDePagoId = solicitudDePagoId,
                EstadoSolicitud = estadoConfirmado,
                EstadoSolicitudId = estadoConfirmado.Id,
                SolicitudDePago = await _repository.ObtenerSolicitudDePagoPorIdAsync(solicitudDePagoId),
            };
            HistorialSolicitudDePago historialConfirmado = _repository.CrearHistorialSolicitudDePagoAsync(historialSolicitudDePago).Result;
            SolicitudDePago solicitud = await _repository.ObtenerSolicitudDePagoPorIdAsync(solicitudDePagoId);
            return solicitud;
        }
    }
}