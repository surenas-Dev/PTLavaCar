using System.Text.Json.Serialization;

namespace PTLavaCar.Models
{
    public class DBEntity
    {
        public int CodeError { get; set; }

        private string? _MsgError;

        [JsonIgnore]
        public string? PKLabel { get; set; }

        [JsonIgnore]
        public string? FKLabel { get; set; }

        public string? MsgError
        {
            get => GetMessageError(CodeError, _MsgError);
            set => _MsgError = value;
        }

        public DBEntity()
        {
        }

        public DBEntity(Exception exception)
        {
            CodeError = exception.HResult;
            MsgError = exception.Message;
        }

        private string? GetMessageError(int Codigo, string? mensaje)
        {
            var msg = "";

            switch (Codigo)
            {
                case EnumMsgError.DuplicateKeyDB:
                    msg = $"¡Ya existe un registro con el mismo '{PKLabel}' ingresado!";
#if DEBUG
                    msg = mensaje;
#endif

                    return msg;

                case EnumMsgError.FKErrorDB:
                    msg = $"¡El registro no puede tener efecto porque se encuentra relacionado a '{FKLabel}'!";
#if DEBUG
                    msg = mensaje;
#endif

                    return msg;

                case EnumMsgError.UKDuplicatekeyDB:
                    msg = $"¡Ya existe un registro con el mismo '{PKLabel}' ingresado!";
#if DEBUG
                    msg = mensaje;
#endif

                    return msg;

                default:
                    return mensaje;
            }
        }
    }
}
