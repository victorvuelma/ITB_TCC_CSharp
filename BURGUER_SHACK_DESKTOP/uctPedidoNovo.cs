﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BURGUER_SHACK_DESKTOP
{
    public partial class uctPedidoNovo : UserControl
    {

        private int _mesa;

        public uctPedidoNovo()
        {
            InitializeComponent();
        }

        public int Mesa { get => _mesa; set => _mesa = value; }
    }
}
