using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace trekkingadventurescr.Models
{
	public class User : IdentityUser
	{
		public User() : base() { }

		public User(string userName) : base(userName) { }

		public string NumeroIdentificacion { get; set; }
		public string Nombre { get; set; }
		public string PrimerApellido { get; set; }
		public string SegundoApellido { get; set; }
		public bool Activo { get; set; } = true;

		[NotMapped]
		public override bool EmailConfirmed { get; set; }

		[NotMapped]
		public override string PhoneNumber { get; set; }

		[NotMapped]
		public override bool PhoneNumberConfirmed { get; set; }

		[NotMapped]
		public override bool TwoFactorEnabled { get; set; }

		[NotMapped]
		public override DateTimeOffset? LockoutEnd { get; set; }

		[NotMapped]
		public override bool LockoutEnabled { get; set; }

		[NotMapped]
		public override int AccessFailedCount { get; set; }

		[NotMapped]
		public override string ConcurrencyStamp { get; set; }
	}
}