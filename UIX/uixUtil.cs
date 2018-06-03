﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIX
{
    class uixUtil
    {

        private static char[] NUM_CHARS = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};

        public static char[] getChars(uixAllowedChars allowedChars)
        {
            switch (allowedChars)
            {
                case uixAllowedChars.INT:
                    return NUM_CHARS;
                default:
                    return new char[] { };
            }
        }

        public static void defineSizeForWidht(Control ctl, int widht)
        {
            ctl.AutoSize = true;
            while (ctl.Width > widht)
            {
                ctl.Font = uixFont.fontSize(ctl.Font, ctl.Font.Size - 0.1f);
            }
            ctl.AutoSize = false;
            ctl.Size = new Size(widht, ctl.Height);
        }


    }
}
