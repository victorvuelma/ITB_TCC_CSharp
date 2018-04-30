﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIX
{
    public partial class txtUIX : UserControl
    {
        public txtUIX()
        {
            InitializeComponent();
        }

        public String Campo {
            get => AccessibleName;
            set {
                AccessibleName = value;
                lbl.Text = value + ":";
                int x = lbl.Size.Width - 5;
                box.Location = new Point(x, box.Location.Y);
            }
        }

        public new Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                Campo = Campo;
            }
        }

        public override String Text { get => box.Text; set => box.Text = value; }

        public new Size Size
        {
            get => base.Size;
            set
            {
                Size current = base.Size;
                box.Size = new Size(value.Width - lbl.Size.Width, box.Size.Height);
                base.Size = value;
            }
        }

        public int MaxLength { get => box.MaxLength; set => box.MaxLength = value; }

    }
}
