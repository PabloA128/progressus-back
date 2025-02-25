﻿using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.MembresiaDtos;
using ProgressusWebApi.Models.MembresiaModels;

namespace ProgressusWebApi.Services.MembresiaServices.Interfaces
{
    public interface ISolicitudDePagoService
    {
        Task<SolicitudDePago> CrearSolicitudDePago(CrearSolicitudDePagoDto dto);
        Task<IActionResult> RegistrarPagoEnEfectivo(int idSolicitudDePago);
        Task<IActionResult> RegistrarPagoConMercadoPago(int idSolicitudDePago);
        Task<IActionResult> CancelarSolicitudDePago(int idSolicitudDePago);
        Task<IActionResult> ObtenerEstadoActualDeSolicitud(int idSolicitudDePago);
        Task<SolicitudDePago> ObtenerSolicitudDePagoDeSocio(string solicitudDePago);
        Task<List<SolicitudDePago>> ObtenerSolicitudesDePagoDeSocio(string identityUserId);

        Task<SolicitudDePago> ConfirmarPagoConMercadoPago(int solicitudDePagoId);
        Task<IActionResult> ConsultarVigenciaDeMembresia(string userId);
        Task<IActionResult> ObtenerTiposDePago();
        Task<IActionResult> ObtenerTodasLasSolicitudesDeUnSocio(string identityUserId);

       // Task<SolicitudDePago> ObtenerSolicitudDePagoDeSocioSinNutricional(string identityUserId);
    }


    
}
