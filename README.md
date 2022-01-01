# trekkingadventurescr

# Scaffold
dotnet ef dbcontext scaffold "Server=217.71.206.171;Uid=trekkingadventurescr;Pwd=costa2020;Database=trekkingadventurescr;SslMode=Preferred;TreatTinyAsBoolean=False;" Pomelo.EntityFrameworkCore.MySQL -o Models/Data/EntityFramework -f -c trekkingadventurescr_DB_Context --no-build

User emanuelUser = new User {
	UserName = "emanuelTrekking",
	Email = "emanuelacu@gmail.com",
	Nombre = "Enmanuelle",
	PrimerApellido = "Acuna",
	SegundoApellido = "Arguedas",
	NumeroIdentificacion = "206830685"
};

await _UserManager.CreateAsync(emanuelUser, "emanuelTrekking08.");

User sergioUser = new User
{
	UserName = "sergioTrekking",
	Email = "sergio@gmail.com",
	Nombre = "Enmanuelle",
	PrimerApellido = "Acuna",
	SegundoApellido = "Arguedas",
	NumeroIdentificacion = "206830685"
};

await _UserManager.CreateAsync(sergioUser, "sergioTrekking21.");