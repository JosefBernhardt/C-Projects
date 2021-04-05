/*

 
 Entwicklungsumgebung: Sharp Develop
 Programmiersprache:   C#

 Josef Bernhardt
 
 Ansteuern eines PSOC Interfacec
 
 
 // XML Datenformat der Testdaten
<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <Versuch>
    <Nummer>1</Nummer>
    <Kommando>1000</Drehzahl>
    <Zeit>2</Zeit>
  </Versuch>
</DocumentElement>
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;


namespace FaulhaberMotTest_V
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        static SerialPort _serialPort;

        // Variable für Versuch

        DataSet myData = new DataSet();

        // var for Filename
        string FileName = string.Empty;

        int step = 0;

        int experimentalcount = 1;

        int linecount = 0;

        Thread versuch;

        public delegate void UpdateButtonCallback(string message);

        public delegate void UpdateDataGridView();

        public delegate void UpdatePauseButton();



        // Help Threads for start stop 
        ManualResetEvent beenden_event = new ManualResetEvent(false);

        // Help Threads for pause and resume
        ManualResetEvent pause_event = new ManualResetEvent(true);


        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Programm beenden
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                
                myData.WriteXml(FileName);
            }
            catch
            {
            }
        }

        // Buttons freigeben
        private void EnableButtons()
        {
            btnDateiNeu.Enabled = true;
            btnStartDrehzahlVersuch.Enabled = true;
            comboBox2.Visible = true;
        }


        // Buttons sperren
        private void DisableButtons()
        {
            btnPause.Enabled = false;
            btnDateiNeu.Enabled = false;
            btnStartDrehzahlVersuch.Enabled = false;
            comboBox2.Visible = false;
        }

        // Schnittstelle öffnen
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string sBaudrate = comboBox3.Text;

            // Schnittstelle öffnen oder schliessen
            if (btnOpen.Text == "Open")
            {
                // Übertragungsparameter einstellen
                try
                {
                    _serialPort.PortName = comboBox1.Text;
                    _serialPort.BaudRate = int.Parse(sBaudrate);  //  SetPortBaudRate
                    _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");//SetPortParity
                    _serialPort.DataBits = int.Parse("8"); // 
                    _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");

                    // Set the read/write timeouts
                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

                    btnOpen.Text = "Close";
                    panel1.BackColor = Color.Green;

                    EnableButtons();

                    label1.Text = "Baudrate = " + sBaudrate;

                    _serialPort.Open();
                }
                catch
                {
                    btnOpen.Text = "Open";
                    label1.Text = string.Empty;
                    panel1.BackColor = Color.Red;
                    MessageBox.Show("Schnittstelle nicht mehr verfügbar..");
                }
            }
            else
            {
                btnOpen.Text = "Open";
                panel1.BackColor = Color.Red;

                // Timer abschalten
                // timer1.Enabled = false;

                // Sendebuttons sperren
                DisableButtons();

                label1.Text = "";

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
            this.Invoke(new EventHandler(SetTextBox));
        }

        // Daten in TextBox
        private void SetTextBox(object s, EventArgs e)
        {
            // textBox1.Text = textBox1.Text +  _serialPort.ReadExisting();
            string str = string.Empty;
            str = _serialPort.ReadExisting();

            // Fenster txtReceiveV
            txtReceiveV.Text += str;
            txtReceiveV.SelectionStart = txtReceiveV.Text.Length;
            txtReceiveV.ScrollToCaret();
        }

        // Combobox für den Comport anklicken
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Close();
                }
                catch { }
                btnOpen.Text = "Schnittstelle öffnen";
                panel1.BackColor = Color.Red;
                EnableButtons();
            }
        }

        // Senden von einem ASCII Hex String
        // zB Daten aus einer Textbox
        // Die Daten müssen durch Komma oder Strichpunkt 
        // getrennt sein
        // Beispiel:   "1B,3F,47,3A"
        private void SendenHexBytes(string s)
        {
            // Zaehler fuer Sendearray
            byte count = 0;

            // String s zerlegen und Teilstring in Stringarray Sendedaten speichern
            string[] SendeDaten = s.Split(',');

            // SendeArray erzeugen
            byte[] tx = new byte[SendeDaten.Length];

            // jeden Teilstring behandeln
            foreach (string TeilString in SendeDaten)
            {
                try
                {
                    // teilstring in Byte umwandeln
                    byte b = byte.Parse(TeilString, System.Globalization.NumberStyles.HexNumber);
                    // in SendeArray ablegen
                    tx[count] = b;
                    // Zehler erhoehen
                    count++;
                }
                catch
                {
                    // Fehlerbehandlung
                }
            }

            try
            {
                if (_serialPort.IsOpen)
                {
                    // Array SendenHexBytes
                    _serialPort.Write(tx, 0, tx.Length);
                }
            }
            catch { }

        }

        // ASCII Zeichen seriell senden
        private void SendenAsciiString(string s)
        {
            // SendeArray erzeugen                    
            byte[] SendArray = Encoding.ASCII.GetBytes(s);

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write(SendArray, 0, SendArray.Length);
                }
            }
            catch { }
        }

        // Starten des Programmes
        private void Form1_Load(object sender, EventArgs e)
        {
            // Selectbox aktualisieren

            string currentDir = Environment.CurrentDirectory;

            DirectoryInfo ParentDirectory = new DirectoryInfo(currentDir);

            
            comboBox3.SelectedIndex = 4;
            
            try
            {
                System.IO.FileInfo[] versuchsfiles = ParentDirectory.GetFiles("*.xml");

                for (int i = 0; i < versuchsfiles.Length; ++i)
                {
                    comboBox2.Items.Add(versuchsfiles[i].Name);
                }

                comboBox2.Sorted = true;
                comboBox2.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("keine Versuchsdateien vorhanden\nBitte die Datei versuch_zeit_clear.xml\nin das Programmverzeichnis kopieren");
                Close();
            }
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
            }
            catch
            {
                MessageBox.Show("keine serielle Schnittstelle vorhanden", "Achtung !!!");
            }
            DisableButtons();
        }


        // Info Modal ausgeben
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 			MessageBox.Show("PSOC Testsoftware  V 1.0 vom 31.10.2015\r\nJosef Bernhardt\r\nE-Mail: josef@bernhardt.de");

            AboutBox1 infobox = new AboutBox1();
            infobox.ShowDialog();
        }

 
        public void Versuch()
        {

            experimentalcount++;
            string strRowData = string.Empty;
            // dataGridView1.BeginInvoke(new UpdateDataGridView(UpdateDataGrid), new object[] { });
            for (int intX = linecount; intX <= dataGridView1.Rows.Count - 1; intX++)
            {
                //  for pause and resume
                pause_event.WaitOne(Timeout.Infinite);

                // for break
                if (beenden_event.WaitOne(0)) break;

                strRowData = string.Empty;
                strRowData += dataGridView1.Rows[intX].Cells[1].Value;

                SendenAsciiString(strRowData);

                strRowData = string.Empty;
                strRowData += dataGridView1.Rows[intX].Cells[2].Value;

                try
                {
                    step = intX;
                    dataGridView1.BeginInvoke(new UpdateDataGridView(UpdateDataGridStep), new object[] { });
                    int delaytime = int.Parse(strRowData);
                    Thread.Sleep(delaytime);

                }
                catch
                {
                    // MessageBox.Show("DataGridView Update Error..");
                }
                //sende_drehzahl("0");
            }
            btnStartDrehzahlVersuch.BeginInvoke(new UpdateButtonCallback(UpdateButton), new object[] { "Start" });
            btnPause.BeginInvoke(new UpdatePauseButton(UpdateDataPauseButton), new object[] { });
            toolStripStatusLabel1.Text = "Stop";

        }

        // Text des Buttons Versuch Start vom Thread heraus ändern
        private void UpdateButton(string message)
        {
            btnStartDrehzahlVersuch.Text = message;
        }

        // Buttons Pause vom Thread heraus disabeln
        private void UpdateDataPauseButton()
        {
            btnPause.Enabled = false;
        }

        // Selected Cell vom Thread heraus verändern
        private void UpdateDataGrid()
        {
            try
            {
                dataGridView1.Focus();
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                // dataGridView1.CurrentCell = dataGridView1.Rows[linecount].Cells[0];
                dataGridView1.Refresh();
                dataGridView1.Update();
            }
            catch { MessageBox.Show("DataGridView Update Error.."); }
        }

        // Durch das DataGridView von Thread heraus durchstepen
        private void UpdateDataGridStep()
        {
            try
            {
                // dataGridView1.CurrentCell = dataGridView1.Rows[step + 1].Cells[0];

                dataGridView1.CurrentCell = dataGridView1.Rows[step].Cells[0];
                dataGridView1.Refresh();
                dataGridView1.Update();
            }
            catch { }
        }

        // Form2 mit dem Button NEW aufufen
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();

            // Combobox aktualisieren

            string currentDir = Environment.CurrentDirectory;

            DirectoryInfo ParentDirectory = new DirectoryInfo(currentDir);

            // label8.Text = currentDir; 

            System.IO.FileInfo[] versuchsfiles = ParentDirectory.GetFiles("*.xml");

            comboBox2.Items.Clear();

            for (int i = 0; i < versuchsfiles.Length; ++i)
            {
                comboBox2.Items.Add(versuchsfiles[i].Name);
            }
            comboBox2.Sorted = true;
            comboBox2.SelectedIndex = 0;
        }

        // neue Versuchsdatei auswählen
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileName = comboBox2.Text;

            // Dataset löschen
            myData.Clear();
            // Xml-Datei in das DataSet laden
            myData.ReadXml(FileName);
            // Daten vom DataSet ins DataGridView übertragen
            dataGridView1.DataSource = myData.Tables[0];
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }


        // Versuch starten mit Threading
        // 
        private void btnStartDrehzahlVersuch_Click(object sender, EventArgs e)
        {
            if (btnStartDrehzahlVersuch.Text == "Start")
            {
                toolStripStatusLabel1.Text = "Start";
                linecount = 0;
                btnStartDrehzahlVersuch.Text = "Stop";
                btnPause.Enabled = true;
                versuch = new Thread(new ThreadStart(Versuch));
                versuch.IsBackground = true;
                beenden_event.Reset();
                versuch.Start();
            }
            else
            {
                // versuch.Abort();
                beenden_event.Set();
                pause_event.Set();
                versuch.Join();

                btnStartDrehzahlVersuch.Text = "Start";
                btnPause.Enabled = false;
                // sende_drehzahl("0");
                toolStripStatusLabel1.Text = "Stop";
            }

        }


        private void btnPause_Click(object sender, EventArgs e)
        {
            // Pause Versuchsablauf
            if (btnPause.Text == "Pause")
            {
                // versuch.Abort();
                btnPause.Text = "Resume";
                //sende_drehzahl("0");
                pause_event.Reset();
                btnStartDrehzahlVersuch.Enabled = false;
            }
            else
            {
                btnPause.Text = "Pause";
                // versuch = new Thread(new ThreadStart(Versuch));
                // versuch.IsBackground = true;
                // versuch.Start();
                pause_event.Set();
                btnStartDrehzahlVersuch.Enabled = true;

            }
        }


        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Save
            myData.WriteXml(FileName);
        }

        // Datei laden
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Load
            // Dataset löschen
            // Load
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Dataset löschen
                myData.Clear();
                FileName = openDialog.FileName;
                // Xml-Datei in das DataSet laden
                myData.ReadXml(FileName);
                // Daten vom DataSet ins DataGridView übertragen
                dataGridView1.DataSource = myData.Tables[0];
            }
        }

        // in der Timer2 Routine wird die Checkbox1 und
        // der toolStripStatusLabel1.Text abgefragt.
        // Sind beide Bedingungen OK 
        // wird der Button Start per Software betätigt.
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked && (toolStripStatusLabel1.Text == "Stop"))
            {
                toolStripStatusLabel2.Text = "Auto";
                btnStartDrehzahlVersuch.PerformClick();
                toolStripStatusLabel3.Text = experimentalcount.ToString();
            }
            if (!checkBox1.Checked)
            {
                toolStripStatusLabel2.Text = "Manuell";
                toolStripStatusLabel3.Text = experimentalcount.ToString();
                experimentalcount = 1;
            }

        }

    }
}
