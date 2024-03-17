﻿namespace CadastroPessoa_API.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public String Message { get; set; } = String.Empty;

        public bool Sucess { get; set; } = true;
    }
}
