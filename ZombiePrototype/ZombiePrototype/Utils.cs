using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Matrix = Microsoft.Xna.Framework.Matrix;

namespace ZombiePrototype
{
    public static class Utils
    {
        public readonly static int X_DIMENSION_SIZE = 800;
        public readonly static int Y_DIMENSION_SIZE = 600;

        public readonly static int X_ENTITY_SIZE = 1;
        public readonly static int Y_ENTITY_SIZE = 1;

        public readonly static int DEGREE_VISION = 360;
        private static Random random = new Random(); 

        public static Vector2 generateLocationVector()
        {
            float xRandomDim = random.Next(0, X_DIMENSION_SIZE);
            float yRandomDim = random.Next(0, Y_DIMENSION_SIZE);
            return (new Vector2(xRandomDim, yRandomDim));
        }

        public static Vector2 generateDirectionVector()
        {
            float xDirection = random.Next(-1, 2);
            float yDirection = random.Next(-1, 2);
            return (new Vector2(xDirection, yDirection));
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        { 
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(9, 20, 372, 13);
          textBox.SetBounds(12, 36, 372, 20);
          buttonOk.SetBounds(228, 72, 75, 23);
          buttonCancel.SetBounds(309, 72, 75, 23);

          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          form.ClientSize = new Size(396, 107);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          return dialogResult;
        }
        }
}
