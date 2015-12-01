namespace TurnOffScreenAndMouse
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        GlobalKeyboardHook gHook;
        string[] args;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            args = Environment.GetCommandLineArgs();
            gHook = new GlobalKeyboardHook();

            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);

            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                gHook.HookedKeys.Add(key);
            }

            gHook.hook();

            SwitchDevices(args, false, textBox1);
            TurnOffMonitor.Off();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {        
            Application.Exit();
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SwitchDevices(args, true, textBox1);
            gHook.unhook();
        }

        private void SwitchDevices(string[] args, bool enable, TextBox textBox)
        {
            if (args.Length >= 2)
            {
                for (int i = 1; i <  args.Length; i += 2)
                {
                    Guid deviceGuid = new Guid();
                    string deviceInstancePath = string.Empty;

                    // args[i] can be mouse path or other device guid
                    if (i == 1 && args.Length % 2 == 0)
                    {
                        // Mouse guid
                        deviceGuid = new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}");
                        deviceInstancePath = args[i];
                        i--;
                    }
                    else
                    {
                        // After the mouse, you must enter the guid and device path
                        deviceGuid = new Guid(args[i]);
                        deviceInstancePath = args[i + 1];
                    }

                    textBox.Text += deviceGuid + " -> " + 
                        (enable ? "Enabled" : "Disabled") + Environment.NewLine;
                    DeviceHelper.SetDeviceEnabled(deviceGuid, deviceInstancePath, enable);
                }
            }
        }
    }
}
