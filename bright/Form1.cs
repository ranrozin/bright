using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace bright
{
    public partial class Form1 : Form
    {
        public delegate void SetControlCallback();
        public ImageMan im;
        private volatile bool _shouldStop = true;
        public Form1()
        {
            Log.AddEntry("about to initilize compnenets");

            InitializeComponent();

            Log.AddEntry("Done with initilize compnenets");

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.TopMost = true;

            Log.AddEntry("about to get an EnRoute instance");

            Enroute.enr = Enroute.getEnroute();
            if (Enroute.enr == null)
            {
                MessageBox.Show("This Application can't work without EnRoute opened");
                Exit();
            }

            Log.AddEntry("Got an EnRoute instance");
            Log.AddEntry("about to get the active drawing");

            Enroute.drawing = Enroute.enr.ActiveDrawing;

            Log.AddEntry("Got the get the active drawing");

            im = new ImageMan();
            // The thread section below is for a way to determine if there is a selction in EnRoute
            // otherwise the controls will be disabled - The thread check every 10 seconds
            Log.AddEntry("Created an instance of ImageMan");

            Thread th = new Thread(CheckIfSelection);
            th.Start();
            Log.AddEntry("started the thread with CheckIfSelection");


        }

        private void trackBarContrast_MouseUp(Object sender, EventArgs e)
        {
            contrastAndBright(trackBarContrast.Value, trackBarBrightness.Value);

        }

        private void trackBarBrightness_MouseUp(Object sender, EventArgs e)
        {
            contrastAndBright(trackBarContrast.Value, trackBarBrightness.Value);
        }

        private void trackBarBrightness_Scroll(object sender, System.EventArgs e)
        {
            // Display the trackbar value in the text box.
            txtBrightnessValue.Text = "" + trackBarBrightness.Value;
        }

        private void contrastAndBright(int contrastValue, int brightnessValue)
        {

            Enroute.drawing = Enroute.enr.ActiveDrawing;
            if (Enroute.drawing == null)
            // if there is no active drawing create one.
            {
                MessageBox.Show("Please open a document first ");
            }
            Enroute.selection = Enroute.drawing.Selection;
            Enroute.selection.Copy();
            Image cpImage = getImageFromClipboard();
            if (cpImage != null)
            {
                if (im.OrgIamge == null)
                    im.Load(Utils.imageToByteArray(cpImage));
                im.BandC(brightnessValue, contrastValue);
                Clipboard.SetImage(im.getImage());
                Enroute.selection.DeleteMembers();
                Enroute.selection.Paste();
            }
        }

        private void contrast(int value)
        {

            Enroute.drawing = Enroute.enr.ActiveDrawing;
            if (Enroute.drawing == null)
            // if there is no active drawing create one.
            {
                MessageBox.Show("Please open a document first ");
            }
            Enroute.selection = Enroute.drawing.Selection;
            //Enroute.selection.SelectAll();
            Enroute.selection.Copy();
            Image cpImage = getImageFromClipboard();
            if (cpImage != null)
            {
                if (im.OrgIamge == null)
                    im.Load(Utils.imageToByteArray(cpImage));
                    im.Contrast(value);
                Clipboard.SetImage(im.getImage());
                Enroute.selection.DeleteMembers();
                Enroute.selection.Paste();
            }
        }


        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            //this.Invalidate();
            //this.Update();
            txtContrastValue.Text = "" + trackBarContrast.Value;
        }

        private Image getImageFromClipboard()
        {
            Image cpImage = null;
            if (Clipboard.ContainsImage())
            {
                cpImage = Clipboard.GetImage();
            }
            return cpImage;
        }

        private bool CheckIfImageExist()

        {
            if (Clipboard.ContainsImage())
            {
                return true;
            }
            return false;
        }

        private void Exit()
        {
            _shouldStop = false;
            Application.Exit();

        }
        private void CheckIfSelection()
        {
            bool locked = false;
            SetControlCallback enable = new SetControlCallback(enableAllElements);
            SetControlCallback disable = new SetControlCallback(lockAllElements);
            while (_shouldStop)
            {
                try
                {

                    Enroute.drawing = Enroute.enr.ActiveDrawing;
                    Enroute.selection = Enroute.drawing.Selection;

                    if (Enroute.selection != null && Enroute.selection.Count == 0)
                    {
                        this.Invoke(disable);
                        locked = true;
                        //im.Original  = true;
                        //im.OrgIamge = null;

                    }
                    else
                    {
                        this.Invoke(enable);
                        locked = false;

                    }
                    Thread.Sleep(1000);
                }
                catch
                {
                    if (!locked)
                    {
                        try
                        {
                            this.Invoke(disable);
                            locked = true;
                        }
                        catch { }
                    }

                }

            }
        }

        private void lockAllElements()
        {
            foreach (Control c in this.Controls)
            {
                if (!(c is Label || c.Name == "btnExit"))
                {
                    c.Enabled = false;
                }
            }

        }
        private void enableAllElements()
        {
            foreach (Control c in this.Controls)
            {
                if (!(c is Label))
                {
                    c.Enabled = true;
                }
            }
        }

        public class TrackBarWithoutFocus : TrackBar
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                SolidBrush myBrush = new SolidBrush(Color.Green);
                e.Graphics.FillRectangle(myBrush, ClientRectangle);
            }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
            public extern static int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            private static int MakeParam(int loWord, int hiWord)
            {
                return (hiWord << 16) | (loWord & 0xffff);
            }

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                SendMessage(this.Handle, 0x0128, MakeParam(1, 0x1), 0);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (im.OrgIamge != null)
            {
                Clipboard.SetImage(im.OrgIamge);
                Enroute.selection.DeleteMembers();
                Enroute.selection.Paste();

                trackBarBrightness.Value = 0;
                trackBarContrast.Value = 0;
                txtContrastValue.Text = "0";
                txtBrightnessValue.Text = "0";
            }
        }

        private void txtContrastValue_Leave(object sender, EventArgs e)
        {
            if (int.Parse(txtContrastValue.Text) > 100)
                trackBarContrast.Value = 100;
            else if (int.Parse(txtContrastValue.Text) < -100)
                trackBarContrast.Value = -100;
            trackBarContrast.Value = int.Parse(txtContrastValue.Text);
            contrastAndBright(trackBarContrast.Value, trackBarBrightness.Value);

        }

        private void txtBrightnessValue_Leave(object sender, EventArgs e)
        {
            if (int.Parse(txtBrightnessValue.Text) > 100)
                trackBarBrightness.Value = 100;
            else if (int.Parse(txtBrightnessValue.Text) < -100)
                trackBarBrightness.Value = -100;

            trackBarBrightness.Value = int.Parse(txtBrightnessValue.Text);
            contrastAndBright(trackBarContrast.Value,trackBarBrightness.Value);

        }
    }
}   
