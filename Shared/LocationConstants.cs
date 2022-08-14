﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class LocationConstants
    {
        public static readonly string IdNotNullMessage = "ID deve ser informado.";
        public static NicknameConstants Nickname; //nickname?
        public static PasswordConstants Password; //password?

        public const int EmailMaxLength = 256; // RFC 5321

        //Password?

    }
    public class NicknameConstants
    {
        public readonly int MaxLength;
        public readonly int MinLength;

        public readonly string MaxLengthMessage;
        public readonly string MinLengthMessage;
        public readonly string NotNullMessage;

        public NicknameConstants()
        {
            MaxLength = 20;
            MinLength = 3;
            MaxLengthMessage = $"Nickname não pode conter mais de {MaxLength} caracteres.";
            MinLengthMessage = $"Nickname deve conter pelo menos {MinLength} caracteres.";
            NotNullMessage = "Nickname deve ser informado.";
        }
    }
    public class PasswordConstants
    {
        public readonly int MaxLength;
        public readonly int MinLength;

        public readonly string MaxLengthMessage;
        public readonly string MinLengthMessage;
        public readonly string NotNullMessage;
        public readonly string InvalidPasswordMessage;
        public readonly string ConfirmPasswordMessage;



        public PasswordConstants()
        {
            MaxLength = 15;
            MinLength = 6;
            MaxLengthMessage = $"Senha não pode conter mais de {MaxLength} caracteres.";
            MinLengthMessage = $"Senha deve conter pelo menos {MinLength} caracteres.";
            NotNullMessage = "Senha deve ser informada.";
            InvalidPasswordMessage = "Pelo menos um caractere minusculo.\r\n" +
                                     "Pelo menos um caractere maiusculo.\r\n" +
                                     "Pelo menos um dígito.\r\n" +
                                     "Pelo menos um símbolo.";
            ConfirmPasswordMessage = "As senhas devem corresponder.";
        }
    }
}
