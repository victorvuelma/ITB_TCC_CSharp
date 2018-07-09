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
    public partial class btnUIX : Button
    {

        public new event EventHandler Click;

        private Color _hoverColor;
        private Color _backColor;

        public btnUIX()
        {
            InitializeComponent();

            HoverColor = Color.Transparent;
        }

        public Color HoverColor { get => _hoverColor; set => _hoverColor = value; }

        public String Description
        {
            get => lbl.Text;
            set
            {
                lbl.Text = value;
                base.Text = value;
                update();
            }
        }

        public new Image Image { get => pic.Image; set => pic.Image = value; }

        public String ImageLocation { get => pic.ImageLocation; set => pic.ImageLocation = value; }

        private void update()
        {
            int MARGIN = 3;

            pnl.Size = new Size(Size.Width - (MARGIN * 2), Size.Height - (MARGIN * 2));
            pnl.Location = new Point(MARGIN, MARGIN);

            lbl.AutoSize = true;
            lbl.Location = new Point(0, pnl.Height - lbl.Height);
            int height = lbl.Height;
            lbl.AutoSize = false;
            lbl.Size = new Size(pnl.Width, height);

            int picSize = pnl.Height - lbl.Height;
            pic.Size = new Size(picSize, picSize);
            pic.Location = new Point((pnl.Width / 2) - (picSize / 2), 0);
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            _backColor = BackColor;
            BackColor = HoverColor;
        }

        private void onMouseLeave(object sender, EventArgs e)
        {
            BackColor = _backColor;
        }

        private void onClick(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Click != null)
                {
                    Click(null, e);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnUIX_BackColorChanged(object sender, EventArgs e)
        {
            pic.BackColor = BackColor;
            lbl.BackColor = BackColor;
            pnl.BackColor = BackColor;
        }

        private void btnUIX_FontChanged(object sender, EventArgs e)
        {
            update();
        }

        private void btnUIX_SizeChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}
