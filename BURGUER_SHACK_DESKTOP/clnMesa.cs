﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BURGUER_SHACK_DESKTOP
{
    class clnMesa
    {

        private int _cod;

        private bool _uso;

        public int Cod { get => _cod; set => _cod = value; }
        public bool Uso { get => _uso; set => _uso = value; }

        
        public List<clnMesa> getMesas()
        {
            List<clnMesa> mesas = new List<clnMesa>();

            for (int i = 1; i <= 25; i++)
            {
                clnMesa mesa = new clnMesa();
                mesa.Cod = i;
                mesa.Uso = (i % 3 == 0);
                mesas.Add(mesa);
            }

            return mesas;
        }

    }
}