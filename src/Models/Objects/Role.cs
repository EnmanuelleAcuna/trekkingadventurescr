using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace trekkingadventurescr.Models
{
	public partial class Role : IdentityRole
	{
		public Role() : base() { }

		public Role(string roleName) : base(roleName) { }

		public string Description { get; set; }

		public override string ToString() => JsonSerializer.Serialize(this);
	}
}