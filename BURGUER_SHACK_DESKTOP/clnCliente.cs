﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BURGUER_SHACK_DESKTOP
{
    class clnCliente
    {

        private int _cod;

        private String _nome;
        private String _docCPF;

        private String _contatoTelCel;
        private String _contatoTelRes;
        private String _contatoEmail;

        public int Cod { get => _cod; set => _cod = value; }
        public String Nome { get => _nome; set => _nome = value; }
        public String DocCPF { get => _docCPF; set => _docCPF = value; }
        public String ContatoTelCel { get => _contatoTelCel; set => _contatoTelCel = value; }
        public String ContatoTelRes { get => _contatoTelRes; set => _contatoTelRes = value; }
        public String ContatoEmail { get => _contatoEmail; set => _contatoEmail = value; }
    }
}