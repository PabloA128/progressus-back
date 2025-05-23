﻿namespace ProgressusWebApi.Dtos.NotificacionDtos
{
	public class PlantillaNotificacionDto
	{
		public int Id { get; set; }
		public int TipoNotificacionId { get; set; }
		public string RolId { get; set; }
		public string Titulo { get; set; }
		public string Cuerpo { get; set; }
		public string? DiaSemana { get; set; }
		public string? MomentoDia { get; set; }
		public DateTime FechaCreacion { get; set; }
	}
}
