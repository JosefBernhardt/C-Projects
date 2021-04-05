/*
 * Created by SharpDevelop.
 * User: Josef Bernhardt Elektronik Chemie
 * Date: 9.3.2015
 * Time: 13:28

Einfaches Testprogramm zum Senden und empfangen von Daten
mit dem Commport des PC (USB)

Senden der Daten in der Textbox1 mit ENTER

Die Empfangsdaten werden in der Textbox 2 angezeigt

 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace SharpDevelopCommportSendText
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		// Klasse Commport
		SerialPort _serialPort;
		
		// https://msdn.microsoft.com/en-us/library/ms171728%28v=vs.85%29.aspx
		// A delegate is used to communicate with UI Thread from a non-UI thread
        // Access to Windows Forms controls is not inherently thread safe. 
        // If you have two or more threads manipulating the state of a control, 
        // it is possible to force the control into an inconsistent state. 
        // Other thread-related bugs are possible as well, 
        // including race conditions and deadlocks. 
        // It is important to ensure that access to your controls 
        // is done in a thread-safe way.
        
        // This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		public delegate void UpdateTextCallback(string message);

		// Label vom serialport Empfangssthread updaten
		public delegate void UpdateLabelCallback(string message);
		
		
		float a;
        
        float U_lp_old = 0;
        
        bool FilterEin = false;
		
		// Programm start
        void MainFormLoad(object sender, EventArgs e)
		{
			// 
			// Initialisierung
            // Anzahl der COM Ports feststellen 
            try
            {
                _serialPort = new SerialPort();
                foreach (string s in SerialPort.GetPortNames())
                {
                    // MessageBox.Show(s);
                    comboBox1.Items.Add(s); // in die Listbox eintragen
                }
                comboBox1.Sorted = true;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 4;
            }
            catch
            {
                MessageBox.Show("keine serielle Schnittstelle vorhanden", "Achtung !!!");
            }
            
            init_IIR();
		}
		
        float [] filterwerte = new float[5];
        // Moving Average Filter
		private float filter(float messwert,ref float[] werte )
		{
			float mittelwert = 0;
			for (int i=0; i<4; i++)
			{
				werte[i] = werte[i+1];
			}
			werte[4] = messwert;
		
			for (int i=0; i<5;i++)
			{
				mittelwert +=werte[i];
			}
			return (float)(mittelwert / 5.0);
		}
 

        private void init_IIR()
        {
            // Sample Frequenz
            double fs = 10.0;
            // Grenzfrequenz
            double f0 = 0.4;
            // Low Pass Old Wert
            U_lp_old = 0;
            // Dämpfungswert a (Attenuation Value)
            a = (float)(fs / ( 2.0 * 3.14 * f0));
        }
        
        float[] w = new float[] {0, 0, 0};
        
        // IIR Filter
        private float filter_IIR(float Messwert)
        {
            float U_lp_new;
            
            if ((Messwert > (U_lp_old+20)) || (Messwert < (U_lp_old - 20)))
            {
                U_lp_new = Messwert;
            }
            else
            {
                U_lp_new = U_lp_old + ((Messwert - U_lp_old) / a);
            }
            U_lp_old = U_lp_new;
            return U_lp_new;
        }
		
        // Programm beenden
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			// schliessen der Schnittstelle
			if (_serialPort.IsOpen)
			{
				_serialPort.Close();
			}
		}
		
		// Schnittstelle öffnen
		void BtnOpenClick(object sender, EventArgs e)
		{
			// evtl. aus Textbox
			// string sBaudrate = "9600";
            // Schnittstelle öffnen oder schliessen
            if (btnOpen.Text == "Open")
            {
                // Übertragungsparameter einstellen
                try
                {
                    _serialPort.PortName = comboBox1.Text;
                    _serialPort.BaudRate = int.Parse(comboBox3.Text);  //  SetPortBaudRate
                    _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");//SetPortParity
                    _serialPort.DataBits = int.Parse("8"); // 
                    _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");

                    // Set the read/write timeouts
                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

                    // erstellen eines Ereignishandler 
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

                    btnOpen.Text = "Close";
                    panel1.BackColor = Color.Green;

                    _serialPort.Open();
                }
                catch
                {
                    btnOpen.Text = "Open";
                    panel1.BackColor = Color.Red;
                    MessageBox.Show("Schnittstelle nicht mehr verfügbar..");
                }
            }
            else
            {
                btnOpen.Text = "Open";
                panel1.BackColor = Color.Red;
                try
                {
                    _serialPort.Close();
                }
                catch { }
            }
            
		}
        
		// Daten empfangen
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        	float Spannung;
        	string str = string.Empty;
            // str = _serialPort.ReadExisting();          
            try
            {
	            str = _serialPort.ReadLine();   
            	// str = _serialPort.ReadExisting(); 
	            
            	str = str.Replace('.',',');
            	
            	Spannung = float.Parse(str);
	            
            	
            	// Spannung = filter(Spannung,ref filterwerte);
	            
            	if (FilterEin == true) Spannung = filter_IIR(Spannung);
	            
           	
            	string SVoltage = Spannung.ToString("0.000");
	            
	            lblMesswert.BeginInvoke(new UpdateLabelCallback(SetLabel), new object[] { SVoltage });
	            textBox2.BeginInvoke(new UpdateTextCallback(SetTextBox), new object[] { str });              	
            }
            catch
            {
	            textBox2.BeginInvoke(new UpdateTextCallback(SetTextBox), new object[] { "Ungültige Daten.." + str });   
            }
        }

		// Daten in TextBox
        private void SetTextBox(string s)
        {
            // Fenster 2
            textBox2.Text += s + Environment.NewLine;
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }
		
        private void SetLabel(string s)
        {
            lblMesswert.Text = s;                           	
        }
                              
 		// wenn die Enter Taste losgelassen wird
		// Die Daten senden
        void TextBox1KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// txtReceive.Text = txtTransmit.Text;
				if (_serialPort.IsOpen)
				{
					byte[] Sendarray = Encoding.ASCII.GetBytes(textBox1.Text);
					_serialPort.Write(Sendarray,0,Sendarray.Length);
					// textBox1.Clear();
				}
			}
		}
		
		void BeendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void StartToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Messung Start
			timer1.Interval = int.Parse(comboBox2.Text);
			timer1.Start();
		}
		
		void StopToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Messung Stop
			timer1.Stop();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			//
			if (_serialPort.IsOpen) _serialPort.Write(textBox1.Text);
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("PSOC5 Messinterface Testsoftware\r\nJosef Bernhardt","Info");
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked) FilterEin = true; else FilterEin = false;
		}
		

	}
}
