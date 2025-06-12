using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new Error(
            "Usuario.Found",
            "El usuario con el Id especificado no fue encontrado"
        );

        public static Error AlreadyExists = new Error(
            "Usuario.AlreadyExists",
            "El usuario ya existe"
        );

        public static Error InvalidCredentials = new Error(
            "Usuario.InvalidCredentials",
            "Credenciales invalidas"
        );
    }
}
