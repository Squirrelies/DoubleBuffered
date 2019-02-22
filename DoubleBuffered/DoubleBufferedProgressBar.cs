using System.Drawing;
using System.Windows.Forms;

namespace DoubleBuffered
{
    public class DoubleBufferedProgressBar : Control
    {
        public DoubleBufferedProgressBar()
        {
            // Set control styles.
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Selectable, false);

            // Set some defaults.
            this.minimum = 0;
            this.maximum = 100;
            this.value = 0;

            // Set default bar colors.
            this.BackColor = Color.DimGray;
            this.ForeColor = Color.Firebrick;
        }

        // Storage variables.
        private double value;
        private double minimum;
        private double maximum;
        private SolidBrush foreBrush;

        // Public properties.
        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                Invalidate();
            }
        }

        public double Minimum
        {
            get
            {
                return this.minimum;
            }
            set
            {
                this.minimum = value;
                Invalidate();
            }
        }

        public double Maximum
        {
            get
            {
                return this.maximum;
            }
            set
            {
                this.maximum = value;
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;

                if (this.foreBrush != null)
                    this.foreBrush.Dispose();

                this.foreBrush = new SolidBrush(base.ForeColor);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF rc = new RectangleF(
                1,
                1,
                (float)(this.Width * (Value - Minimum) / Maximum) - 2f,
                this.Height - 2f
                );
            e.Graphics.FillRectangle(this.foreBrush, rc);
            base.OnPaint(e);
        }
    }
}
