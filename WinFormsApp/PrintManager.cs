using System.Drawing.Printing;

namespace WinFormsApp
{
    internal class PrintManager
    {
        internal static void PrintPlayers(Control parent, PrintPageEventArgs e)
        {
            int x = 10, y = 10;

            for (int i = 0; i < parent.Controls.Count; i++)
            {
                var child = parent.Controls[i];
                Bitmap bmp = new(child.Size.Width, child.Size.Height);
                parent.Controls[i].DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = 0,
                    Width = bmp.Width,
                    Height = bmp.Height
                });
                if (i == 4)
                {
                    x = child.Size.Width + 30;
                    y = 10;
                }
                if (i == 8)
                {
                    x = (child.Size.Width + 30) * 2;
                    y = 10;
                }
                e.Graphics?.DrawImage(bmp, e.MarginBounds.X + x, e.MarginBounds.Y + y);
                y += child.Size.Height;
            }
        }

        internal static void PrintMatches(Control parent, PrintPageEventArgs e)
        {
            int x = 0, y = 0;

            for (int i = 0; i < parent.Controls.Count; i++)
            {
                var child = parent.Controls[i];
                Bitmap bmp = new(child.Size.Width, child.Size.Height);
                parent.Controls[i].DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = 0,
                    Width = bmp.Width,
                    Height = bmp.Height
                });
                if (i == 4)
                {
                    x = 0;
                    y = 0;
                }
                e.Graphics?.DrawImage(bmp, x, y);
                y += child.Size.Height;
            }
        }
    }
}
