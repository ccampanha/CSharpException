﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Cliente
    {
        public string Nome { get; set; }
        private string _cpf;

        public string CPF
        {
            get
            {
                return _cpf;

            }
            set
            {
                //escrever  logica de validação
                _cpf = value;
            }


        }
        public string Profissao { get; set; }
    }
}

