﻿using Microsoft.AspNetCore.Identity;

namespace ProgressusWebApi.Models.MembresiaModels
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public IdentityUser? User { get; set; }
        public string? UserId { get; set; }
    }
}
