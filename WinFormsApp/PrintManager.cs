using System.Drawing.Printing;

namespace WinFormsApp
{
    internal class PrintManager
    {
        private const int FirstColumnMaxItems = 4;
        private const int SecondColumnMaxItems = 8;

        private static int NumberOfPrintedItems = 0;
        private static int MaxPlayersPerPage = 12;
        private static int MaxMatchesPerPage = 4;

        private static int PagesPrinted = 0;
        private static int i = 0;

        internal static void ResetVariables()
        {
            MaxPlayersPerPage = 12;
            PagesPrinted = 0;
            NumberOfPrintedItems = 0;
            i = 0;
        }

        internal static void PrintPlayers(Control parent, PrintPageEventArgs e)
        {
            int offsetX = 10, offsetY = 10;

            for (; i < parent.Controls.Count; i++, NumberOfPrintedItems++)
            {
                if (PagesPrinted == 1)
                {
                    PagesPrinted = 0;
                    NumberOfPrintedItems = 0;
                    MaxPlayersPerPage = 12;
                }
                if (MaxPlayersPerPage-- == 0)
                {
                    e.HasMorePages = true;
                    PagesPrinted++;
                    break;
                }

                var child = parent.Controls[i];
                Bitmap bmp = new(child.Width, child.Height);
                child.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                if (NumberOfPrintedItems == FirstColumnMaxItems)
                {
                    offsetX = child.Width + 30;
                    offsetY = 10;
                }
                if (NumberOfPrintedItems == SecondColumnMaxItems)
                {
                    offsetX = (child.Width + 30) * 2;
                    offsetY = 10;
                }

                e.Graphics?.DrawImage(bmp, e.MarginBounds.X + offsetX, e.MarginBounds.Y + offsetY);
                offsetY += child.Height;
            }
        }

        internal static void PrintMatches(Control parent, PrintPageEventArgs e)
        {
            int offsetX = 0, offsetY = 50;

            for (; i < parent.Controls.Count; i++)
            {
                if (PagesPrinted == 1)
                {
                    PagesPrinted = 0;
                    MaxMatchesPerPage = 4;
                }
                if (MaxMatchesPerPage-- == 0)
                {
                    e.HasMorePages = true;
                    PagesPrinted++;
                    break;
                }

                var child = parent.Controls[i];
                Bitmap bmp = new(child.Size.Width, child.Size.Height);
                child.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                e.Graphics?.DrawImage(bmp, offsetX, offsetY);
                offsetY += child.Size.Height;
            }
        }
    }
}
