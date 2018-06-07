using LTQATools.labtechDataSetTableAdapters;
using LTQATools.Properties;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WUApiLib;

namespace LTQATools
{
	public class Form1 : Form
	{
		private IContainer components = null;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private TabPage tabPage5;

		private Button btn_unset_all_flags;

		private Button btn_set_all_flags;

		private Button btn_refresh_flags;

		private TextBox txt_flagsvalue;

		private Label label23;

		private Label label16;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private Button btn_set_processfilter;

		private Button btn_set_fastalk;

		private Label label26;

		private Label label24;

		private Button btn_unset_tunnelsvpn;

		private Button btn_unset_tunnels;

		private Button btn_unset_dst;

		private Button btn_unset_vh;

		private Button btn_unset_vm;

		private Button btn_unset_reboot;

		private Button btn_unset_indicator;

		private Button btn_unset_shadowprotect;

		private Button btn_unset_probe;

		private Button btn_unset_systemaccount;

		private Button btn_unset_monitor;

		private Button btn_unset_master;

		private Button btn_unset_eventfilter;

		private Button btn_unset_locked;

		private Button btn_unset_processfilter;

		private Button btn_unset_fastalk;

		private Button btn_set_tunnelsvpn;

		private Button btn_set_tunnels;

		private Button btn_set_dst;

		private Button btn_set_vh;

		private Button btn_set_vm;

		private Button btn_set_reboot;

		private Button btn_set_indicator;

		private Button btn_set_shadowprotect;

		private Button btn_set_probe;

		private Button btn_set_systemaccount;

		private Button btn_set_monitor;

		private Button btn_set_master;

		private Button btn_set_eventfilter;

		private Button btn_set_locked;

		private Button btn_unset_startup_wizard;

		private Button btn_unset_usage_tips;

		private Button btn_set_startup_wizard;

		private Button btn_set_usage_tips;

		private GroupBox groupBox3;

		private TabPage tabPage7;

		private GroupBox groupBox5;

		private GroupBox groupBox4;

		private GroupBox groupBox6;

		private RadioButton radioButton3;

		private Button btn_create_asa_class;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Button btn_unset_all_feature_flags;

		private Button btn_set_all_feature_flags;

		private Button btn_refresh_feature_flags;

		private TextBox txt_fflagsvalue;

		private Label label27;

		private Button btn_unset_heartbeatresponse;

		private Button btn_unset_heartbeatrunning;

		private Button btn_unset_intelvpro;

		private Button btn_unset_hpilo;

		private Button btn_unset_intelamt;

		private Button btn_set_heartbeatresponse;

		private Button btn_set_heartbeatrunning;

		private Button btn_set_intelvpro;

		private Button bt_set_hpilo;

		private Button btn_set_intelAMT;

		private Label label21;

		private Label label20;

		private Label label19;

		private Label label18;

		private Label label17;

		private TabPage tabPage4;

		private ListBox lst_logging_window;

		private Button btn_clear_logs;

		private GroupBox groupBox1;

		private Button btn_create_user;

		private RadioButton radioButton6;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private CheckBox checkBox5;

		private CheckBox checkBox4;

		private CheckBox checkBox3;

		private CheckBox checkBox2;

		private CheckBox checkBox1;

		private Label label28;

		private ComboBox cmb_agentfeatureflags;

		private LTQATools.labtechDataSet labtechDataSet;

		private BindingSource computersBindingSource;

		private LTQATools.labtechDataSetTableAdapters.computersTableAdapter computersTableAdapter;

		private Label label33;

		private ComboBox cmd_agentflags;

		private TextBox txt_connectionstring;

		private Label label29;

		private Label label32;

		private Button btn_set_startup_webpage;
        private TabControl tabControl;
        private TabPage tabPage1;
        private GroupBox groupBox7;
        private GroupBox groupBox2;
        private Button button2;
        private Label label31;
        private Label label30;
        private Label label25;
        private Label label22;
        private Button button1;
        private ListBox listBox3;
        private ListBox listBox4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private ListBox listBox2;
        private ListBox listBox1;
        private TextBox textBox2;
        private TextBox textBox1;

		private Button btn_unset_startup_webpage;

		public Form1()
		{
			this.InitializeComponent();
		}

		private void bt_set_hpilo_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("FeatureFlags", "HP iLO", 4);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_clear_logs_Click(object sender, EventArgs e)
		{
			this.lst_logging_window.Items.Clear();
		}

		private void btn_create_asa_class_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			string randomFileName = string.Empty;
			string str = "8934384919677763566";
			string str1 = "4485869464436223";
			try
			{
				if ((this.radioButton1.Checked || this.radioButton2.Checked ? false : !this.radioButton3.Checked))
				{
					MessageBox.Show("No options selected, please make a choice", "Create Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				if (this.radioButton1.Checked)
				{
					randomFileName = "Almost Super Admin";
				}
				if (this.radioButton2.Checked)
				{
					randomFileName = Path.GetRandomFileName();
					randomFileName = randomFileName.Replace(".", "");
					randomFileName = randomFileName.Substring(0, 8);
				}
				if (this.radioButton3.Checked)
				{
					do
					{
						randomFileName = Interaction.InputBox("Enter Class Name (alpha-numeric only):", "Create Class", "", -1, -1);
					}
					while (!Regex.IsMatch(randomFileName, "^[a-zA-Z0-9_ ]+$"));
				}
				string[] strArrays = new string[] { "INSERT INTO labtech.userclasses (Name, Permissions, PermissionsHigh) VALUES ('", randomFileName, "','", str, "','", str1, "')" };
				string str2 = string.Concat(strArrays);
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str2, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				MessageBox.Show(string.Concat("Created user class:", randomFileName), "Create Class", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				empty = string.Concat(DateTime.Now, "\tCreated user class:", randomFileName);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Create Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_create_user_Click(object sender, EventArgs e)
		{
			bool flag;
			string empty = string.Empty;
			string randomFileName = string.Empty;
			string str = "123";
			string str1 = "test@automation.com";
			int num = 1;
			int num1 = 2;
			string str2 = "4";
			try
			{
				if ((this.radioButton4.Checked || this.radioButton5.Checked ? false : !this.radioButton6.Checked))
				{
					MessageBox.Show("No options selected, please make a choice", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				if (this.radioButton4.Checked)
				{
					randomFileName = "TestUser";
				}
				if (this.radioButton5.Checked)
				{
					randomFileName = Path.GetRandomFileName();
					randomFileName = randomFileName.Replace(".", "");
					randomFileName = randomFileName.Substring(0, 8);
				}
				if (this.radioButton6.Checked)
				{
					do
					{
						randomFileName = Interaction.InputBox("Enter User Name (alpha-numeric only):", "Create User", "", -1, -1);
						flag = (!Regex.IsMatch(randomFileName, "^[a-zA-Z0-9_]+$") ? true : randomFileName == null);
					}
					while (flag);
				}
				if (!this.checkBox1.Checked)
				{
					num = 0;
				}
				if (!this.checkBox2.Checked)
				{
					num1 = 0;
				}
				if (!this.checkBox5.Checked)
				{
					do
					{
						str = Interaction.InputBox("Enter Password (alpha-numeric only):", "Create User", "", -1, -1);
					}
					while (!Regex.IsMatch(str, "^[a-zA-Z0-9]+$"));
				}
				if (!this.checkBox4.Checked)
				{
					do
					{
						str1 = Interaction.InputBox("Enter Email Address:", "Create User", "", -1, -1);
					}
					while (!Regex.IsMatch(str1, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$"));
				}
				int num2 = num + num1;
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				string str3 = "SELECT ClassID FROM labtech.userclasses WHERE Permissions = '8934384919677763566' LIMIT 1";
				mySqlConnection.Open();
				if (this.checkBox3.Checked)
				{
					MySqlCommand mySqlCommand = new MySqlCommand(str3, mySqlConnection);
					str2 = Convert.ToString(mySqlCommand.ExecuteScalar());
				}
				object[] objArray = new object[] { "INSERT INTO labtech.users (ClientID, Name, Password, Email, Permissions, Flags, TicketLevel, OpenTickets, NewTickets, Secondary, MapiProfile, CommandLevel, Manager, LoginReport, LogoutReport, AuditLevel, TicketRouter, RegionID, GroupSecurity, FolderID, ImageID) VALUES ('", str2, ",', '", randomFileName, "', '", str, "', '", str1, "', '0,', ", num2, ", 1, 0, 0, '5', 'Disable', 4, 1, 0, 0, 1, 1, 0, 0, 0, 0)" };
				string str4 = string.Concat(objArray);
				(new MySqlCommand(str4, mySqlConnection)).ExecuteReader();
				mySqlConnection.Close();
				MessageBox.Show(string.Concat("Created user:", randomFileName), "Create User", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				empty = string.Concat(DateTime.Now, "\tCreated user:", randomFileName);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Create User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_refresh_feature_flags_Click(object sender, EventArgs e)
		{
			try
			{
				string str = string.Concat("SELECT FeatureFlags FROM labtech.computers WHERE Name = '", this.cmb_agentfeatureflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				this.txt_fflagsvalue.Text = Convert.ToString(mySqlCommand.ExecuteScalar());
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Feature Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				string.Concat(DateTime.Now, "\t", exception);
			}
		}

		private void btn_refresh_flags_Click(object sender, EventArgs e)
		{
			try
			{
				string str = string.Concat("SELECT Flags FROM labtech.computers WHERE Name = '", this.cmd_agentflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				this.txt_flagsvalue.Text = Convert.ToString(mySqlCommand.ExecuteScalar());
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				string str1 = string.Concat(DateTime.Now, "\t", exception);
				this.lst_logging_window.Items.Add(str1);
			}
		}

		private void btn_set_all_feature_flags_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = string.Concat("UPDATE labtech.computers SET FeatureFlags='131' WHERE Name='", this.cmd_agentflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				object[] now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- Set ALL FeatureFlags to max value 131" };
				empty = string.Concat(now);
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Set Feature Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_set_all_flags_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = string.Concat("UPDATE labtech.computers SET Flags='65535' WHERE Name='", this.cmd_agentflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				object[] now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- Set ALL Flags to max value 65535" };
				empty = string.Concat(now);
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Set Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_set_dst_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Daylight Savings", 8192);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_eventfilter_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Event Filter", 8);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_fastalk_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Fastalk", 1);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_heartbeatresponse_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("FeatureFlags", "Heartbeats Received", 64);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_heartbeatrunning_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("FeatureFlags", "Heartbeats Sent", 32);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_indicator_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Indicator", 512);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_intelAMT_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("FeatureFlags", "intelAMT", 2);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_intelvpro_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("FeatureFlags", "Intel vPro", 16);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_locked_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "LockDown", 4);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_master_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Master", 16);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_monitor_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Monitor", 32);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_probe_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Network Probe", 128);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_processfilter_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Process Filter", 2);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_reboot_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Reboot Needed", 1024);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_shadowprotect_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Shadow Protect", 256);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_startup_webpage_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.properties SET Value = 'False' WHERE Name = 'OpenStartupWebpage'";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tStartup Webpage set to False (Disabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_set_startup_wizard_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.properties SET Value = 'False' WHERE Name = 'ShowStartWizard'";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tStartup Wizard set to False (Disabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_set_systemaccount_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "System Account", 64);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_tunnels_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Tunnels", 16384);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_tunnelsvpn_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Tunnels VPN", 32768);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_usage_tips_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.controlcenterconfig SET ShowToolTips = '0' ";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tUsage Tips set to 0 (Disabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_set_vh_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Virtual Host", 4096);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_set_vm_Click(object sender, EventArgs e)
		{
			try
			{
				this.setFlag("Flags", "Virtual Machine", 2048);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_all_feature_flags_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = string.Concat("UPDATE labtech.computers SET FeatureFlags='0' WHERE Name='", this.cmd_agentflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				object[] now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- Unset ALL FeatureFlags to min value 0" };
				empty = string.Concat(now);
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Unset Feature Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_unset_all_flags_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = string.Concat("UPDATE labtech.computers SET Flags='0' WHERE Name='", this.cmd_agentflags.SelectedValue, "'");
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				object[] now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- Unset ALL Flags to min value 0" };
				empty = string.Concat(now);
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Unset Flags", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_unset_dst_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Daylight Savings", 8192);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_eventfilter_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Event Filter", 8);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_fastalk_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Fastalk", 1);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_heartbeatresponse_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("FeatureFlags", "Heartbeats Received", 64);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_heartbeatrunning_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("FeatureFlags", "Heartbeats Sent", 32);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_hpilo_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("FeatureFlags", "HP iLO", 4);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_indicator_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Indicator", 512);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_intelamt_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("FeatureFlags", "intelAMT", 2);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_intelvpro_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("FeatureFlags", "Intel vPro", 16);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_locked_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "LockDown", 4);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_master_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Master", 16);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_monitor_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Monitor", 32);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_probe_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Network Probe", 128);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_processfilter_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Process Filter", 2);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_reboot_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Reboot Needed", 1024);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_shadowprotect_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Shadow Protect", 256);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_startup_webpage_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.properties SET Value = 'True' WHERE Name = 'OpenStartupWebpage'";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tStartup Webpage set to True (Enabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_unset_startup_wizard_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.properties SET Value = 'True' WHERE Name = 'ShowStartWizard'";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tStartup Wizard set to True (Enabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_unset_systemaccount_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "System Account", 64);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_tunnels_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Tunnels", 16384);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_tunnelsvpn_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Tunnels VPN", 32768);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_usage_tips_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			try
			{
				string str = "UPDATE labtech.controlcenterconfig SET ShowToolTips = '-1' ";
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				mySqlCommand.ExecuteReader();
				mySqlConnection.Close();
				empty = string.Concat(DateTime.Now, "\tUsage Tips set to -1 (Enabled)");
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception), "Update Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void btn_unset_vh_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Virtual Host", 4096);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		private void btn_unset_vm_Click(object sender, EventArgs e)
		{
			try
			{
				this.unsetFlag("Flags", "Virtual Machine", 2048);
			}
			catch (Exception exception)
			{
				MessageBox.Show(Convert.ToString(exception));
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				this.computersTableAdapter.Fill(this.labtechDataSet.computers);
				this.txt_connectionstring.Text = Settings.Default.DBConn;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat("Connection error: ", Convert.ToString(exception)), "Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				string str = string.Concat(DateTime.Now, "\t", exception);
				this.lst_logging_window.Items.Add(str);
			}
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_connectionstring = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btn_set_startup_webpage = new System.Windows.Forms.Button();
            this.btn_unset_startup_webpage = new System.Windows.Forms.Button();
            this.btn_unset_startup_wizard = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btn_unset_usage_tips = new System.Windows.Forms.Button();
            this.btn_set_usage_tips = new System.Windows.Forms.Button();
            this.btn_set_startup_wizard = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_create_user = new System.Windows.Forms.Button();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btn_create_asa_class = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.cmd_agentflags = new System.Windows.Forms.ComboBox();
            this.computersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_unset_tunnelsvpn = new System.Windows.Forms.Button();
            this.btn_unset_tunnels = new System.Windows.Forms.Button();
            this.btn_unset_dst = new System.Windows.Forms.Button();
            this.btn_unset_vh = new System.Windows.Forms.Button();
            this.btn_unset_vm = new System.Windows.Forms.Button();
            this.btn_unset_reboot = new System.Windows.Forms.Button();
            this.btn_unset_indicator = new System.Windows.Forms.Button();
            this.btn_unset_shadowprotect = new System.Windows.Forms.Button();
            this.btn_unset_probe = new System.Windows.Forms.Button();
            this.btn_unset_systemaccount = new System.Windows.Forms.Button();
            this.btn_unset_monitor = new System.Windows.Forms.Button();
            this.btn_unset_master = new System.Windows.Forms.Button();
            this.btn_unset_eventfilter = new System.Windows.Forms.Button();
            this.btn_unset_locked = new System.Windows.Forms.Button();
            this.btn_unset_processfilter = new System.Windows.Forms.Button();
            this.btn_unset_fastalk = new System.Windows.Forms.Button();
            this.btn_set_tunnelsvpn = new System.Windows.Forms.Button();
            this.btn_set_tunnels = new System.Windows.Forms.Button();
            this.btn_set_dst = new System.Windows.Forms.Button();
            this.btn_set_vh = new System.Windows.Forms.Button();
            this.btn_set_vm = new System.Windows.Forms.Button();
            this.btn_set_reboot = new System.Windows.Forms.Button();
            this.btn_set_indicator = new System.Windows.Forms.Button();
            this.btn_set_shadowprotect = new System.Windows.Forms.Button();
            this.btn_set_probe = new System.Windows.Forms.Button();
            this.btn_set_systemaccount = new System.Windows.Forms.Button();
            this.btn_set_monitor = new System.Windows.Forms.Button();
            this.btn_set_master = new System.Windows.Forms.Button();
            this.btn_set_eventfilter = new System.Windows.Forms.Button();
            this.btn_set_locked = new System.Windows.Forms.Button();
            this.btn_set_processfilter = new System.Windows.Forms.Button();
            this.btn_set_fastalk = new System.Windows.Forms.Button();
            this.btn_unset_all_flags = new System.Windows.Forms.Button();
            this.btn_set_all_flags = new System.Windows.Forms.Button();
            this.btn_refresh_flags = new System.Windows.Forms.Button();
            this.txt_flagsvalue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.cmb_agentfeatureflags = new System.Windows.Forms.ComboBox();
            this.btn_unset_all_feature_flags = new System.Windows.Forms.Button();
            this.btn_set_all_feature_flags = new System.Windows.Forms.Button();
            this.btn_refresh_feature_flags = new System.Windows.Forms.Button();
            this.txt_fflagsvalue = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_unset_heartbeatresponse = new System.Windows.Forms.Button();
            this.btn_unset_heartbeatrunning = new System.Windows.Forms.Button();
            this.btn_unset_intelvpro = new System.Windows.Forms.Button();
            this.btn_unset_hpilo = new System.Windows.Forms.Button();
            this.btn_unset_intelamt = new System.Windows.Forms.Button();
            this.btn_set_heartbeatresponse = new System.Windows.Forms.Button();
            this.btn_set_heartbeatrunning = new System.Windows.Forms.Button();
            this.btn_set_intelvpro = new System.Windows.Forms.Button();
            this.bt_set_hpilo = new System.Windows.Forms.Button();
            this.btn_set_intelAMT = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lst_logging_window = new System.Windows.Forms.ListBox();
            this.btn_clear_logs = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computersBindingSource)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.txt_connectionstring);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.ToolTipText = "Connection string is Read-only and is read from LTQATools.exe.config.";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(112, 13);
            this.label29.TabIndex = 36;
            this.label29.Text = "Connection String:";
            // 
            // txt_connectionstring
            // 
            this.txt_connectionstring.Location = new System.Drawing.Point(134, 14);
            this.txt_connectionstring.Name = "txt_connectionstring";
            this.txt_connectionstring.ReadOnly = true;
            this.txt_connectionstring.Size = new System.Drawing.Size(446, 20);
            this.txt_connectionstring.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.btn_set_startup_webpage);
            this.groupBox3.Controls.Add(this.btn_unset_startup_webpage);
            this.groupBox3.Controls.Add(this.btn_unset_startup_wizard);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.btn_unset_usage_tips);
            this.groupBox3.Controls.Add(this.btn_set_usage_tips);
            this.groupBox3.Controls.Add(this.btn_set_startup_wizard);
            this.groupBox3.Location = new System.Drawing.Point(16, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 143);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Annoying Stuff on Startup";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(141, 90);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(91, 13);
            this.label32.TabIndex = 40;
            this.label32.Text = "Startup Webpage";
            // 
            // btn_set_startup_webpage
            // 
            this.btn_set_startup_webpage.Location = new System.Drawing.Point(79, 85);
            this.btn_set_startup_webpage.Name = "btn_set_startup_webpage";
            this.btn_set_startup_webpage.Size = new System.Drawing.Size(56, 22);
            this.btn_set_startup_webpage.TabIndex = 37;
            this.btn_set_startup_webpage.Text = "Disable";
            this.btn_set_startup_webpage.UseVisualStyleBackColor = true;
            this.btn_set_startup_webpage.Click += new System.EventHandler(this.btn_set_startup_webpage_Click);
            // 
            // btn_unset_startup_webpage
            // 
            this.btn_unset_startup_webpage.Location = new System.Drawing.Point(16, 85);
            this.btn_unset_startup_webpage.Name = "btn_unset_startup_webpage";
            this.btn_unset_startup_webpage.Size = new System.Drawing.Size(57, 22);
            this.btn_unset_startup_webpage.TabIndex = 33;
            this.btn_unset_startup_webpage.Text = "Enable";
            this.btn_unset_startup_webpage.UseVisualStyleBackColor = true;
            this.btn_unset_startup_webpage.Click += new System.EventHandler(this.btn_unset_startup_webpage_Click);
            // 
            // btn_unset_startup_wizard
            // 
            this.btn_unset_startup_wizard.Location = new System.Drawing.Point(16, 57);
            this.btn_unset_startup_wizard.Name = "btn_unset_startup_wizard";
            this.btn_unset_startup_wizard.Size = new System.Drawing.Size(57, 22);
            this.btn_unset_startup_wizard.TabIndex = 32;
            this.btn_unset_startup_wizard.Text = "Enable";
            this.btn_unset_startup_wizard.UseVisualStyleBackColor = true;
            this.btn_unset_startup_wizard.Click += new System.EventHandler(this.btn_unset_startup_wizard_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(141, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Tool Tips";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(141, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Startup Wizard";
            // 
            // btn_unset_usage_tips
            // 
            this.btn_unset_usage_tips.Location = new System.Drawing.Point(16, 29);
            this.btn_unset_usage_tips.Name = "btn_unset_usage_tips";
            this.btn_unset_usage_tips.Size = new System.Drawing.Size(57, 22);
            this.btn_unset_usage_tips.TabIndex = 30;
            this.btn_unset_usage_tips.Text = "Enable";
            this.btn_unset_usage_tips.UseVisualStyleBackColor = true;
            this.btn_unset_usage_tips.Click += new System.EventHandler(this.btn_unset_usage_tips_Click);
            // 
            // btn_set_usage_tips
            // 
            this.btn_set_usage_tips.Location = new System.Drawing.Point(79, 28);
            this.btn_set_usage_tips.Name = "btn_set_usage_tips";
            this.btn_set_usage_tips.Size = new System.Drawing.Size(56, 22);
            this.btn_set_usage_tips.TabIndex = 34;
            this.btn_set_usage_tips.Text = "Disable";
            this.btn_set_usage_tips.UseVisualStyleBackColor = true;
            this.btn_set_usage_tips.Click += new System.EventHandler(this.btn_set_usage_tips_Click);
            // 
            // btn_set_startup_wizard
            // 
            this.btn_set_startup_wizard.Location = new System.Drawing.Point(79, 57);
            this.btn_set_startup_wizard.Name = "btn_set_startup_wizard";
            this.btn_set_startup_wizard.Size = new System.Drawing.Size(56, 22);
            this.btn_set_startup_wizard.TabIndex = 36;
            this.btn_set_startup_wizard.Text = "Disable";
            this.btn_set_startup_wizard.UseVisualStyleBackColor = true;
            this.btn_set_startup_wizard.Click += new System.EventHandler(this.btn_set_startup_wizard_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(702, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Users & Classes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(357, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(321, 285);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Users";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_create_user);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Location = new System.Drawing.Point(20, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add User";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(17, 133);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(128, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "Use 123 as password";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(17, 110);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(195, 17);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "Use test@automation.com as email ";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(17, 202);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(169, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Add Almost Super Admin class";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(17, 179);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(123, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Enable HTTP tunnel";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(17, 156);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Enable Web access";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_create_user
            // 
            this.btn_create_user.Location = new System.Drawing.Point(181, 65);
            this.btn_create_user.Name = "btn_create_user";
            this.btn_create_user.Size = new System.Drawing.Size(75, 23);
            this.btn_create_user.TabIndex = 13;
            this.btn_create_user.Text = "Create";
            this.btn_create_user.UseVisualStyleBackColor = true;
            this.btn_create_user.Click += new System.EventHandler(this.btn_create_user_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(17, 68);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(91, 17);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Custom Name";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(17, 44);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(96, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Random Name";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(17, 20);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(68, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "TestUser";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(22, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 285);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Classes";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton3);
            this.groupBox6.Controls.Add(this.btn_create_asa_class);
            this.groupBox6.Controls.Add(this.radioButton2);
            this.groupBox6.Controls.Add(this.radioButton1);
            this.groupBox6.Location = new System.Drawing.Point(18, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(279, 100);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Add Almost Super Admin";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(22, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Custom Name";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // btn_create_asa_class
            // 
            this.btn_create_asa_class.Location = new System.Drawing.Point(179, 62);
            this.btn_create_asa_class.Name = "btn_create_asa_class";
            this.btn_create_asa_class.Size = new System.Drawing.Size(75, 23);
            this.btn_create_asa_class.TabIndex = 3;
            this.btn_create_asa_class.Text = "Create";
            this.btn_create_asa_class.UseVisualStyleBackColor = true;
            this.btn_create_asa_class.Click += new System.EventHandler(this.btn_create_asa_class_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(22, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Random Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Almost Super Admin";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label33);
            this.tabPage5.Controls.Add(this.cmd_agentflags);
            this.tabPage5.Controls.Add(this.btn_unset_tunnelsvpn);
            this.tabPage5.Controls.Add(this.btn_unset_tunnels);
            this.tabPage5.Controls.Add(this.btn_unset_dst);
            this.tabPage5.Controls.Add(this.btn_unset_vh);
            this.tabPage5.Controls.Add(this.btn_unset_vm);
            this.tabPage5.Controls.Add(this.btn_unset_reboot);
            this.tabPage5.Controls.Add(this.btn_unset_indicator);
            this.tabPage5.Controls.Add(this.btn_unset_shadowprotect);
            this.tabPage5.Controls.Add(this.btn_unset_probe);
            this.tabPage5.Controls.Add(this.btn_unset_systemaccount);
            this.tabPage5.Controls.Add(this.btn_unset_monitor);
            this.tabPage5.Controls.Add(this.btn_unset_master);
            this.tabPage5.Controls.Add(this.btn_unset_eventfilter);
            this.tabPage5.Controls.Add(this.btn_unset_locked);
            this.tabPage5.Controls.Add(this.btn_unset_processfilter);
            this.tabPage5.Controls.Add(this.btn_unset_fastalk);
            this.tabPage5.Controls.Add(this.btn_set_tunnelsvpn);
            this.tabPage5.Controls.Add(this.btn_set_tunnels);
            this.tabPage5.Controls.Add(this.btn_set_dst);
            this.tabPage5.Controls.Add(this.btn_set_vh);
            this.tabPage5.Controls.Add(this.btn_set_vm);
            this.tabPage5.Controls.Add(this.btn_set_reboot);
            this.tabPage5.Controls.Add(this.btn_set_indicator);
            this.tabPage5.Controls.Add(this.btn_set_shadowprotect);
            this.tabPage5.Controls.Add(this.btn_set_probe);
            this.tabPage5.Controls.Add(this.btn_set_systemaccount);
            this.tabPage5.Controls.Add(this.btn_set_monitor);
            this.tabPage5.Controls.Add(this.btn_set_master);
            this.tabPage5.Controls.Add(this.btn_set_eventfilter);
            this.tabPage5.Controls.Add(this.btn_set_locked);
            this.tabPage5.Controls.Add(this.btn_set_processfilter);
            this.tabPage5.Controls.Add(this.btn_set_fastalk);
            this.tabPage5.Controls.Add(this.btn_unset_all_flags);
            this.tabPage5.Controls.Add(this.btn_set_all_flags);
            this.tabPage5.Controls.Add(this.btn_refresh_flags);
            this.tabPage5.Controls.Add(this.txt_flagsvalue);
            this.tabPage5.Controls.Add(this.label23);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(702, 331);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Flags";
            this.tabPage5.ToolTipText = "Setting and Unsetting Flags are temporary.  The temporary value will be overwritt" +
                "en by the DBAgent.";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(250, 12);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 13);
            this.label33.TabIndex = 111;
            this.label33.Text = "Agent:";
            // 
            // cmd_agentflags
            // 
            this.cmd_agentflags.DataSource = this.computersBindingSource;
            this.cmd_agentflags.DisplayMember = "Name";
            this.cmd_agentflags.FormattingEnabled = true;
            this.cmd_agentflags.Location = new System.Drawing.Point(300, 6);
            this.cmd_agentflags.Name = "cmd_agentflags";
            this.cmd_agentflags.Size = new System.Drawing.Size(121, 21);
            this.cmd_agentflags.TabIndex = 23;
            this.cmd_agentflags.ValueMember = "Name";
            // 
            // computersBindingSource
            // 
            this.computersBindingSource.DataMember = "computers";
            // 
            // btn_unset_tunnelsvpn
            // 
            this.btn_unset_tunnelsvpn.Location = new System.Drawing.Point(398, 132);
            this.btn_unset_tunnelsvpn.Name = "btn_unset_tunnelsvpn";
            this.btn_unset_tunnelsvpn.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_tunnelsvpn.TabIndex = 64;
            this.btn_unset_tunnelsvpn.Text = "Unset";
            this.btn_unset_tunnelsvpn.UseVisualStyleBackColor = true;
            this.btn_unset_tunnelsvpn.Click += new System.EventHandler(this.btn_unset_tunnelsvpn_Click);
            // 
            // btn_unset_tunnels
            // 
            this.btn_unset_tunnels.Location = new System.Drawing.Point(398, 110);
            this.btn_unset_tunnels.Name = "btn_unset_tunnels";
            this.btn_unset_tunnels.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_tunnels.TabIndex = 63;
            this.btn_unset_tunnels.Text = "Unset";
            this.btn_unset_tunnels.UseVisualStyleBackColor = true;
            this.btn_unset_tunnels.Click += new System.EventHandler(this.btn_unset_tunnels_Click);
            // 
            // btn_unset_dst
            // 
            this.btn_unset_dst.Location = new System.Drawing.Point(398, 87);
            this.btn_unset_dst.Name = "btn_unset_dst";
            this.btn_unset_dst.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_dst.TabIndex = 62;
            this.btn_unset_dst.Text = "Unset";
            this.btn_unset_dst.UseVisualStyleBackColor = true;
            this.btn_unset_dst.Click += new System.EventHandler(this.btn_unset_dst_Click);
            // 
            // btn_unset_vh
            // 
            this.btn_unset_vh.Location = new System.Drawing.Point(398, 64);
            this.btn_unset_vh.Name = "btn_unset_vh";
            this.btn_unset_vh.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_vh.TabIndex = 61;
            this.btn_unset_vh.Text = "Unset";
            this.btn_unset_vh.UseVisualStyleBackColor = true;
            this.btn_unset_vh.Click += new System.EventHandler(this.btn_unset_vh_Click);
            // 
            // btn_unset_vm
            // 
            this.btn_unset_vm.Location = new System.Drawing.Point(398, 41);
            this.btn_unset_vm.Name = "btn_unset_vm";
            this.btn_unset_vm.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_vm.TabIndex = 60;
            this.btn_unset_vm.Text = "Unset";
            this.btn_unset_vm.UseVisualStyleBackColor = true;
            this.btn_unset_vm.Click += new System.EventHandler(this.btn_unset_vm_Click);
            // 
            // btn_unset_reboot
            // 
            this.btn_unset_reboot.Location = new System.Drawing.Point(43, 270);
            this.btn_unset_reboot.Name = "btn_unset_reboot";
            this.btn_unset_reboot.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_reboot.TabIndex = 59;
            this.btn_unset_reboot.Text = "Unset";
            this.btn_unset_reboot.UseVisualStyleBackColor = true;
            this.btn_unset_reboot.Click += new System.EventHandler(this.btn_unset_reboot_Click);
            // 
            // btn_unset_indicator
            // 
            this.btn_unset_indicator.Location = new System.Drawing.Point(43, 246);
            this.btn_unset_indicator.Name = "btn_unset_indicator";
            this.btn_unset_indicator.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_indicator.TabIndex = 58;
            this.btn_unset_indicator.Text = "Unset";
            this.btn_unset_indicator.UseVisualStyleBackColor = true;
            this.btn_unset_indicator.Click += new System.EventHandler(this.btn_unset_indicator_Click);
            // 
            // btn_unset_shadowprotect
            // 
            this.btn_unset_shadowprotect.Location = new System.Drawing.Point(43, 223);
            this.btn_unset_shadowprotect.Name = "btn_unset_shadowprotect";
            this.btn_unset_shadowprotect.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_shadowprotect.TabIndex = 57;
            this.btn_unset_shadowprotect.Text = "Unset";
            this.btn_unset_shadowprotect.UseVisualStyleBackColor = true;
            this.btn_unset_shadowprotect.Click += new System.EventHandler(this.btn_unset_shadowprotect_Click);
            // 
            // btn_unset_probe
            // 
            this.btn_unset_probe.Location = new System.Drawing.Point(43, 200);
            this.btn_unset_probe.Name = "btn_unset_probe";
            this.btn_unset_probe.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_probe.TabIndex = 56;
            this.btn_unset_probe.Text = "Unset";
            this.btn_unset_probe.UseVisualStyleBackColor = true;
            this.btn_unset_probe.Click += new System.EventHandler(this.btn_unset_probe_Click);
            // 
            // btn_unset_systemaccount
            // 
            this.btn_unset_systemaccount.Location = new System.Drawing.Point(43, 177);
            this.btn_unset_systemaccount.Name = "btn_unset_systemaccount";
            this.btn_unset_systemaccount.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_systemaccount.TabIndex = 55;
            this.btn_unset_systemaccount.Text = "Unset";
            this.btn_unset_systemaccount.UseVisualStyleBackColor = true;
            this.btn_unset_systemaccount.Click += new System.EventHandler(this.btn_unset_systemaccount_Click);
            // 
            // btn_unset_monitor
            // 
            this.btn_unset_monitor.Location = new System.Drawing.Point(43, 154);
            this.btn_unset_monitor.Name = "btn_unset_monitor";
            this.btn_unset_monitor.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_monitor.TabIndex = 54;
            this.btn_unset_monitor.Text = "Unset";
            this.btn_unset_monitor.UseVisualStyleBackColor = true;
            this.btn_unset_monitor.Click += new System.EventHandler(this.btn_unset_monitor_Click);
            // 
            // btn_unset_master
            // 
            this.btn_unset_master.Location = new System.Drawing.Point(43, 131);
            this.btn_unset_master.Name = "btn_unset_master";
            this.btn_unset_master.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_master.TabIndex = 53;
            this.btn_unset_master.Text = "Unset";
            this.btn_unset_master.UseVisualStyleBackColor = true;
            this.btn_unset_master.Click += new System.EventHandler(this.btn_unset_master_Click);
            // 
            // btn_unset_eventfilter
            // 
            this.btn_unset_eventfilter.Location = new System.Drawing.Point(43, 109);
            this.btn_unset_eventfilter.Name = "btn_unset_eventfilter";
            this.btn_unset_eventfilter.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_eventfilter.TabIndex = 52;
            this.btn_unset_eventfilter.Text = "Unset";
            this.btn_unset_eventfilter.UseVisualStyleBackColor = true;
            this.btn_unset_eventfilter.Click += new System.EventHandler(this.btn_unset_eventfilter_Click);
            // 
            // btn_unset_locked
            // 
            this.btn_unset_locked.Location = new System.Drawing.Point(43, 86);
            this.btn_unset_locked.Name = "btn_unset_locked";
            this.btn_unset_locked.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_locked.TabIndex = 51;
            this.btn_unset_locked.Text = "Unset";
            this.btn_unset_locked.UseVisualStyleBackColor = true;
            this.btn_unset_locked.Click += new System.EventHandler(this.btn_unset_locked_Click);
            // 
            // btn_unset_processfilter
            // 
            this.btn_unset_processfilter.Location = new System.Drawing.Point(43, 63);
            this.btn_unset_processfilter.Name = "btn_unset_processfilter";
            this.btn_unset_processfilter.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_processfilter.TabIndex = 50;
            this.btn_unset_processfilter.Text = "Unset";
            this.btn_unset_processfilter.UseVisualStyleBackColor = true;
            this.btn_unset_processfilter.Click += new System.EventHandler(this.btn_unset_processfilter_Click);
            // 
            // btn_unset_fastalk
            // 
            this.btn_unset_fastalk.Location = new System.Drawing.Point(43, 40);
            this.btn_unset_fastalk.Name = "btn_unset_fastalk";
            this.btn_unset_fastalk.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_fastalk.TabIndex = 49;
            this.btn_unset_fastalk.Text = "Unset";
            this.btn_unset_fastalk.UseVisualStyleBackColor = true;
            this.btn_unset_fastalk.Click += new System.EventHandler(this.btn_unset_fastalk_Click);
            // 
            // btn_set_tunnelsvpn
            // 
            this.btn_set_tunnelsvpn.Location = new System.Drawing.Point(364, 132);
            this.btn_set_tunnelsvpn.Name = "btn_set_tunnelsvpn";
            this.btn_set_tunnelsvpn.Size = new System.Drawing.Size(33, 22);
            this.btn_set_tunnelsvpn.TabIndex = 42;
            this.btn_set_tunnelsvpn.Text = "Set";
            this.btn_set_tunnelsvpn.UseVisualStyleBackColor = true;
            this.btn_set_tunnelsvpn.Click += new System.EventHandler(this.btn_set_tunnelsvpn_Click);
            // 
            // btn_set_tunnels
            // 
            this.btn_set_tunnels.Location = new System.Drawing.Point(364, 110);
            this.btn_set_tunnels.Name = "btn_set_tunnels";
            this.btn_set_tunnels.Size = new System.Drawing.Size(33, 22);
            this.btn_set_tunnels.TabIndex = 41;
            this.btn_set_tunnels.Text = "Set";
            this.btn_set_tunnels.UseVisualStyleBackColor = true;
            this.btn_set_tunnels.Click += new System.EventHandler(this.btn_set_tunnels_Click);
            // 
            // btn_set_dst
            // 
            this.btn_set_dst.Location = new System.Drawing.Point(364, 87);
            this.btn_set_dst.Name = "btn_set_dst";
            this.btn_set_dst.Size = new System.Drawing.Size(33, 22);
            this.btn_set_dst.TabIndex = 40;
            this.btn_set_dst.Text = "Set";
            this.btn_set_dst.UseVisualStyleBackColor = true;
            this.btn_set_dst.Click += new System.EventHandler(this.btn_set_dst_Click);
            // 
            // btn_set_vh
            // 
            this.btn_set_vh.Location = new System.Drawing.Point(364, 64);
            this.btn_set_vh.Name = "btn_set_vh";
            this.btn_set_vh.Size = new System.Drawing.Size(33, 22);
            this.btn_set_vh.TabIndex = 39;
            this.btn_set_vh.Text = "Set";
            this.btn_set_vh.UseVisualStyleBackColor = true;
            this.btn_set_vh.Click += new System.EventHandler(this.btn_set_vh_Click);
            // 
            // btn_set_vm
            // 
            this.btn_set_vm.Location = new System.Drawing.Point(364, 41);
            this.btn_set_vm.Name = "btn_set_vm";
            this.btn_set_vm.Size = new System.Drawing.Size(33, 22);
            this.btn_set_vm.TabIndex = 38;
            this.btn_set_vm.Text = "Set";
            this.btn_set_vm.UseVisualStyleBackColor = true;
            this.btn_set_vm.Click += new System.EventHandler(this.btn_set_vm_Click);
            // 
            // btn_set_reboot
            // 
            this.btn_set_reboot.Location = new System.Drawing.Point(9, 270);
            this.btn_set_reboot.Name = "btn_set_reboot";
            this.btn_set_reboot.Size = new System.Drawing.Size(33, 22);
            this.btn_set_reboot.TabIndex = 37;
            this.btn_set_reboot.Text = "Set";
            this.btn_set_reboot.UseVisualStyleBackColor = true;
            this.btn_set_reboot.Click += new System.EventHandler(this.btn_set_reboot_Click);
            // 
            // btn_set_indicator
            // 
            this.btn_set_indicator.Location = new System.Drawing.Point(9, 246);
            this.btn_set_indicator.Name = "btn_set_indicator";
            this.btn_set_indicator.Size = new System.Drawing.Size(33, 22);
            this.btn_set_indicator.TabIndex = 36;
            this.btn_set_indicator.Text = "Set";
            this.btn_set_indicator.UseVisualStyleBackColor = true;
            this.btn_set_indicator.Click += new System.EventHandler(this.btn_set_indicator_Click);
            // 
            // btn_set_shadowprotect
            // 
            this.btn_set_shadowprotect.Location = new System.Drawing.Point(9, 223);
            this.btn_set_shadowprotect.Name = "btn_set_shadowprotect";
            this.btn_set_shadowprotect.Size = new System.Drawing.Size(33, 22);
            this.btn_set_shadowprotect.TabIndex = 35;
            this.btn_set_shadowprotect.Text = "Set";
            this.btn_set_shadowprotect.UseVisualStyleBackColor = true;
            this.btn_set_shadowprotect.Click += new System.EventHandler(this.btn_set_shadowprotect_Click);
            // 
            // btn_set_probe
            // 
            this.btn_set_probe.Location = new System.Drawing.Point(9, 200);
            this.btn_set_probe.Name = "btn_set_probe";
            this.btn_set_probe.Size = new System.Drawing.Size(33, 22);
            this.btn_set_probe.TabIndex = 34;
            this.btn_set_probe.Text = "Set";
            this.btn_set_probe.UseVisualStyleBackColor = true;
            this.btn_set_probe.Click += new System.EventHandler(this.btn_set_probe_Click);
            // 
            // btn_set_systemaccount
            // 
            this.btn_set_systemaccount.Location = new System.Drawing.Point(9, 177);
            this.btn_set_systemaccount.Name = "btn_set_systemaccount";
            this.btn_set_systemaccount.Size = new System.Drawing.Size(33, 22);
            this.btn_set_systemaccount.TabIndex = 33;
            this.btn_set_systemaccount.Text = "Set";
            this.btn_set_systemaccount.UseVisualStyleBackColor = true;
            this.btn_set_systemaccount.Click += new System.EventHandler(this.btn_set_systemaccount_Click);
            // 
            // btn_set_monitor
            // 
            this.btn_set_monitor.Location = new System.Drawing.Point(9, 154);
            this.btn_set_monitor.Name = "btn_set_monitor";
            this.btn_set_monitor.Size = new System.Drawing.Size(33, 22);
            this.btn_set_monitor.TabIndex = 32;
            this.btn_set_monitor.Text = "Set";
            this.btn_set_monitor.UseVisualStyleBackColor = true;
            this.btn_set_monitor.Click += new System.EventHandler(this.btn_set_monitor_Click);
            // 
            // btn_set_master
            // 
            this.btn_set_master.Location = new System.Drawing.Point(9, 131);
            this.btn_set_master.Name = "btn_set_master";
            this.btn_set_master.Size = new System.Drawing.Size(33, 22);
            this.btn_set_master.TabIndex = 31;
            this.btn_set_master.Text = "Set";
            this.btn_set_master.UseVisualStyleBackColor = true;
            this.btn_set_master.Click += new System.EventHandler(this.btn_set_master_Click);
            // 
            // btn_set_eventfilter
            // 
            this.btn_set_eventfilter.Location = new System.Drawing.Point(9, 109);
            this.btn_set_eventfilter.Name = "btn_set_eventfilter";
            this.btn_set_eventfilter.Size = new System.Drawing.Size(33, 22);
            this.btn_set_eventfilter.TabIndex = 30;
            this.btn_set_eventfilter.Text = "Set";
            this.btn_set_eventfilter.UseVisualStyleBackColor = true;
            this.btn_set_eventfilter.Click += new System.EventHandler(this.btn_set_eventfilter_Click);
            // 
            // btn_set_locked
            // 
            this.btn_set_locked.Location = new System.Drawing.Point(9, 86);
            this.btn_set_locked.Name = "btn_set_locked";
            this.btn_set_locked.Size = new System.Drawing.Size(33, 22);
            this.btn_set_locked.TabIndex = 29;
            this.btn_set_locked.Text = "Set";
            this.btn_set_locked.UseVisualStyleBackColor = true;
            this.btn_set_locked.Click += new System.EventHandler(this.btn_set_locked_Click);
            // 
            // btn_set_processfilter
            // 
            this.btn_set_processfilter.Location = new System.Drawing.Point(9, 63);
            this.btn_set_processfilter.Name = "btn_set_processfilter";
            this.btn_set_processfilter.Size = new System.Drawing.Size(33, 22);
            this.btn_set_processfilter.TabIndex = 28;
            this.btn_set_processfilter.Text = "Set";
            this.btn_set_processfilter.UseVisualStyleBackColor = true;
            this.btn_set_processfilter.Click += new System.EventHandler(this.btn_set_processfilter_Click);
            // 
            // btn_set_fastalk
            // 
            this.btn_set_fastalk.Location = new System.Drawing.Point(9, 40);
            this.btn_set_fastalk.Name = "btn_set_fastalk";
            this.btn_set_fastalk.Size = new System.Drawing.Size(33, 22);
            this.btn_set_fastalk.TabIndex = 27;
            this.btn_set_fastalk.Text = "Set";
            this.btn_set_fastalk.UseVisualStyleBackColor = true;
            this.btn_set_fastalk.Click += new System.EventHandler(this.btn_set_fastalk_Click);
            // 
            // btn_unset_all_flags
            // 
            this.btn_unset_all_flags.Location = new System.Drawing.Point(610, 4);
            this.btn_unset_all_flags.Name = "btn_unset_all_flags";
            this.btn_unset_all_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_unset_all_flags.TabIndex = 26;
            this.btn_unset_all_flags.Text = "Unset All";
            this.btn_unset_all_flags.UseVisualStyleBackColor = true;
            this.btn_unset_all_flags.Click += new System.EventHandler(this.btn_unset_all_flags_Click);
            // 
            // btn_set_all_flags
            // 
            this.btn_set_all_flags.Location = new System.Drawing.Point(525, 4);
            this.btn_set_all_flags.Name = "btn_set_all_flags";
            this.btn_set_all_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_set_all_flags.TabIndex = 25;
            this.btn_set_all_flags.Text = "Set All";
            this.btn_set_all_flags.UseVisualStyleBackColor = true;
            this.btn_set_all_flags.Click += new System.EventHandler(this.btn_set_all_flags_Click);
            // 
            // btn_refresh_flags
            // 
            this.btn_refresh_flags.Location = new System.Drawing.Point(439, 4);
            this.btn_refresh_flags.Name = "btn_refresh_flags";
            this.btn_refresh_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_refresh_flags.TabIndex = 24;
            this.btn_refresh_flags.Text = "Refresh";
            this.btn_refresh_flags.UseVisualStyleBackColor = true;
            this.btn_refresh_flags.Click += new System.EventHandler(this.btn_refresh_flags_Click);
            // 
            // txt_flagsvalue
            // 
            this.txt_flagsvalue.Location = new System.Drawing.Point(100, 5);
            this.txt_flagsvalue.Name = "txt_flagsvalue";
            this.txt_flagsvalue.Size = new System.Drawing.Size(120, 20);
            this.txt_flagsvalue.TabIndex = 22;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 13);
            this.label23.TabIndex = 22;
            this.label23.Text = "Current Value:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(446, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Tunnels VPN";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(446, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Tunnels";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(446, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Daylight Savings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(446, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Virtual Host";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(446, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Virtual Machine";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(93, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Reboot Needed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Indicator";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Shadow Protect";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Network Probe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "System Account Agent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Monitor Enabled";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Master";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Event Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Locked Down";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Process Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FasTalk";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label28);
            this.tabPage7.Controls.Add(this.cmb_agentfeatureflags);
            this.tabPage7.Controls.Add(this.btn_unset_all_feature_flags);
            this.tabPage7.Controls.Add(this.btn_set_all_feature_flags);
            this.tabPage7.Controls.Add(this.btn_refresh_feature_flags);
            this.tabPage7.Controls.Add(this.txt_fflagsvalue);
            this.tabPage7.Controls.Add(this.label27);
            this.tabPage7.Controls.Add(this.btn_unset_heartbeatresponse);
            this.tabPage7.Controls.Add(this.btn_unset_heartbeatrunning);
            this.tabPage7.Controls.Add(this.btn_unset_intelvpro);
            this.tabPage7.Controls.Add(this.btn_unset_hpilo);
            this.tabPage7.Controls.Add(this.btn_unset_intelamt);
            this.tabPage7.Controls.Add(this.btn_set_heartbeatresponse);
            this.tabPage7.Controls.Add(this.btn_set_heartbeatrunning);
            this.tabPage7.Controls.Add(this.btn_set_intelvpro);
            this.tabPage7.Controls.Add(this.bt_set_hpilo);
            this.tabPage7.Controls.Add(this.btn_set_intelAMT);
            this.tabPage7.Controls.Add(this.label21);
            this.tabPage7.Controls.Add(this.label20);
            this.tabPage7.Controls.Add(this.label19);
            this.tabPage7.Controls.Add(this.label18);
            this.tabPage7.Controls.Add(this.label17);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(702, 331);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Feature Flags";
            this.tabPage7.ToolTipText = "Setting and Unsetting Feature Flags are temporary.  The temporary value will be o" +
                "verwritten by the DBAgent.";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(250, 12);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 13);
            this.label28.TabIndex = 109;
            this.label28.Text = "Agent:";
            // 
            // cmb_agentfeatureflags
            // 
            this.cmb_agentfeatureflags.DataSource = this.computersBindingSource;
            this.cmb_agentfeatureflags.DisplayMember = "Name";
            this.cmb_agentfeatureflags.FormattingEnabled = true;
            this.cmb_agentfeatureflags.Location = new System.Drawing.Point(300, 6);
            this.cmb_agentfeatureflags.Name = "cmb_agentfeatureflags";
            this.cmb_agentfeatureflags.Size = new System.Drawing.Size(121, 21);
            this.cmb_agentfeatureflags.TabIndex = 91;
            this.cmb_agentfeatureflags.ValueMember = "Name";
            // 
            // btn_unset_all_feature_flags
            // 
            this.btn_unset_all_feature_flags.Location = new System.Drawing.Point(610, 4);
            this.btn_unset_all_feature_flags.Name = "btn_unset_all_feature_flags";
            this.btn_unset_all_feature_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_unset_all_feature_flags.TabIndex = 94;
            this.btn_unset_all_feature_flags.Text = "Unset All";
            this.btn_unset_all_feature_flags.UseVisualStyleBackColor = true;
            this.btn_unset_all_feature_flags.Click += new System.EventHandler(this.btn_unset_all_feature_flags_Click);
            // 
            // btn_set_all_feature_flags
            // 
            this.btn_set_all_feature_flags.Location = new System.Drawing.Point(525, 4);
            this.btn_set_all_feature_flags.Name = "btn_set_all_feature_flags";
            this.btn_set_all_feature_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_set_all_feature_flags.TabIndex = 93;
            this.btn_set_all_feature_flags.Text = "Set All";
            this.btn_set_all_feature_flags.UseVisualStyleBackColor = true;
            this.btn_set_all_feature_flags.Click += new System.EventHandler(this.btn_set_all_feature_flags_Click);
            // 
            // btn_refresh_feature_flags
            // 
            this.btn_refresh_feature_flags.Location = new System.Drawing.Point(439, 4);
            this.btn_refresh_feature_flags.Name = "btn_refresh_feature_flags";
            this.btn_refresh_feature_flags.Size = new System.Drawing.Size(75, 20);
            this.btn_refresh_feature_flags.TabIndex = 92;
            this.btn_refresh_feature_flags.Text = "Refresh";
            this.btn_refresh_feature_flags.UseVisualStyleBackColor = true;
            this.btn_refresh_feature_flags.Click += new System.EventHandler(this.btn_refresh_feature_flags_Click);
            // 
            // txt_fflagsvalue
            // 
            this.txt_fflagsvalue.Location = new System.Drawing.Point(100, 5);
            this.txt_fflagsvalue.Name = "txt_fflagsvalue";
            this.txt_fflagsvalue.Size = new System.Drawing.Size(120, 20);
            this.txt_fflagsvalue.TabIndex = 90;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 13);
            this.label27.TabIndex = 107;
            this.label27.Text = "Current Value:";
            // 
            // btn_unset_heartbeatresponse
            // 
            this.btn_unset_heartbeatresponse.Location = new System.Drawing.Point(43, 132);
            this.btn_unset_heartbeatresponse.Name = "btn_unset_heartbeatresponse";
            this.btn_unset_heartbeatresponse.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_heartbeatresponse.TabIndex = 105;
            this.btn_unset_heartbeatresponse.Text = "Unset";
            this.btn_unset_heartbeatresponse.UseVisualStyleBackColor = true;
            this.btn_unset_heartbeatresponse.Click += new System.EventHandler(this.btn_unset_heartbeatresponse_Click);
            // 
            // btn_unset_heartbeatrunning
            // 
            this.btn_unset_heartbeatrunning.Location = new System.Drawing.Point(43, 109);
            this.btn_unset_heartbeatrunning.Name = "btn_unset_heartbeatrunning";
            this.btn_unset_heartbeatrunning.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_heartbeatrunning.TabIndex = 104;
            this.btn_unset_heartbeatrunning.Text = "Unset";
            this.btn_unset_heartbeatrunning.UseVisualStyleBackColor = true;
            this.btn_unset_heartbeatrunning.Click += new System.EventHandler(this.btn_unset_heartbeatrunning_Click);
            // 
            // btn_unset_intelvpro
            // 
            this.btn_unset_intelvpro.Location = new System.Drawing.Point(43, 86);
            this.btn_unset_intelvpro.Name = "btn_unset_intelvpro";
            this.btn_unset_intelvpro.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_intelvpro.TabIndex = 103;
            this.btn_unset_intelvpro.Text = "Unset";
            this.btn_unset_intelvpro.UseVisualStyleBackColor = true;
            this.btn_unset_intelvpro.Click += new System.EventHandler(this.btn_unset_intelvpro_Click);
            // 
            // btn_unset_hpilo
            // 
            this.btn_unset_hpilo.Location = new System.Drawing.Point(43, 63);
            this.btn_unset_hpilo.Name = "btn_unset_hpilo";
            this.btn_unset_hpilo.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_hpilo.TabIndex = 102;
            this.btn_unset_hpilo.Text = "Unset";
            this.btn_unset_hpilo.UseVisualStyleBackColor = true;
            this.btn_unset_hpilo.Click += new System.EventHandler(this.btn_unset_hpilo_Click);
            // 
            // btn_unset_intelamt
            // 
            this.btn_unset_intelamt.Location = new System.Drawing.Point(43, 40);
            this.btn_unset_intelamt.Name = "btn_unset_intelamt";
            this.btn_unset_intelamt.Size = new System.Drawing.Size(44, 22);
            this.btn_unset_intelamt.TabIndex = 101;
            this.btn_unset_intelamt.Text = "Unset";
            this.btn_unset_intelamt.UseVisualStyleBackColor = true;
            this.btn_unset_intelamt.Click += new System.EventHandler(this.btn_unset_intelamt_Click);
            // 
            // btn_set_heartbeatresponse
            // 
            this.btn_set_heartbeatresponse.Location = new System.Drawing.Point(9, 132);
            this.btn_set_heartbeatresponse.Name = "btn_set_heartbeatresponse";
            this.btn_set_heartbeatresponse.Size = new System.Drawing.Size(33, 22);
            this.btn_set_heartbeatresponse.TabIndex = 99;
            this.btn_set_heartbeatresponse.Text = "Set";
            this.btn_set_heartbeatresponse.UseVisualStyleBackColor = true;
            this.btn_set_heartbeatresponse.Click += new System.EventHandler(this.btn_set_heartbeatresponse_Click);
            // 
            // btn_set_heartbeatrunning
            // 
            this.btn_set_heartbeatrunning.Location = new System.Drawing.Point(9, 109);
            this.btn_set_heartbeatrunning.Name = "btn_set_heartbeatrunning";
            this.btn_set_heartbeatrunning.Size = new System.Drawing.Size(33, 22);
            this.btn_set_heartbeatrunning.TabIndex = 98;
            this.btn_set_heartbeatrunning.Text = "Set";
            this.btn_set_heartbeatrunning.UseVisualStyleBackColor = true;
            this.btn_set_heartbeatrunning.Click += new System.EventHandler(this.btn_set_heartbeatrunning_Click);
            // 
            // btn_set_intelvpro
            // 
            this.btn_set_intelvpro.Location = new System.Drawing.Point(9, 86);
            this.btn_set_intelvpro.Name = "btn_set_intelvpro";
            this.btn_set_intelvpro.Size = new System.Drawing.Size(33, 22);
            this.btn_set_intelvpro.TabIndex = 97;
            this.btn_set_intelvpro.Text = "Set";
            this.btn_set_intelvpro.UseVisualStyleBackColor = true;
            this.btn_set_intelvpro.Click += new System.EventHandler(this.btn_set_intelvpro_Click);
            // 
            // bt_set_hpilo
            // 
            this.bt_set_hpilo.Location = new System.Drawing.Point(9, 63);
            this.bt_set_hpilo.Name = "bt_set_hpilo";
            this.bt_set_hpilo.Size = new System.Drawing.Size(33, 22);
            this.bt_set_hpilo.TabIndex = 96;
            this.bt_set_hpilo.Text = "Set";
            this.bt_set_hpilo.UseVisualStyleBackColor = true;
            this.bt_set_hpilo.Click += new System.EventHandler(this.bt_set_hpilo_Click);
            // 
            // btn_set_intelAMT
            // 
            this.btn_set_intelAMT.Location = new System.Drawing.Point(9, 40);
            this.btn_set_intelAMT.Name = "btn_set_intelAMT";
            this.btn_set_intelAMT.Size = new System.Drawing.Size(33, 22);
            this.btn_set_intelAMT.TabIndex = 95;
            this.btn_set_intelAMT.Text = "Set";
            this.btn_set_intelAMT.UseVisualStyleBackColor = true;
            this.btn_set_intelAMT.Click += new System.EventHandler(this.btn_set_intelAMT_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(91, 141);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 93;
            this.label21.Text = "Heartbeat Response";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(91, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 13);
            this.label20.TabIndex = 92;
            this.label20.Text = "Heartbeat Running";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(91, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 91;
            this.label19.Text = "Intel vPro";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(91, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 90;
            this.label18.Text = "HP iLO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(91, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 89;
            this.label17.Text = "Intel AMT";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lst_logging_window);
            this.tabPage4.Controls.Add(this.btn_clear_logs);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(702, 331);
            this.tabPage4.TabIndex = 7;
            this.tabPage4.Text = "Logging";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lst_logging_window
            // 
            this.lst_logging_window.FormattingEnabled = true;
            this.lst_logging_window.HorizontalScrollbar = true;
            this.lst_logging_window.Location = new System.Drawing.Point(19, 19);
            this.lst_logging_window.Name = "lst_logging_window";
            this.lst_logging_window.Size = new System.Drawing.Size(658, 264);
            this.lst_logging_window.TabIndex = 89;
            // 
            // btn_clear_logs
            // 
            this.btn_clear_logs.Location = new System.Drawing.Point(19, 293);
            this.btn_clear_logs.Name = "btn_clear_logs";
            this.btn_clear_logs.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_logs.TabIndex = 90;
            this.btn_clear_logs.Text = "Clear Log";
            this.btn_clear_logs.UseVisualStyleBackColor = true;
            this.btn_clear_logs.Click += new System.EventHandler(this.btn_clear_logs_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(710, 357);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 331);
            this.tabPage1.TabIndex = 8;
            this.tabPage1.Text = "Patching";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBox3);
            this.groupBox7.Controls.Add(this.listBox4);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.textBox4);
            this.groupBox7.Controls.Add(this.label34);
            this.groupBox7.Controls.Add(this.label35);
            this.groupBox7.Controls.Add(this.label36);
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Location = new System.Drawing.Point(357, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(305, 295);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Automate Database";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(9, 217);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(290, 69);
            this.listBox3.TabIndex = 16;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(9, 96);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(290, 69);
            this.listBox4.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(135, 168);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(135, 48);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 20);
            this.textBox4.TabIndex = 13;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 200);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(96, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "Available Updates:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 175);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(122, 13);
            this.label35.TabIndex = 11;
            this.label35.Text = "Available Update Count:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 79);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(92, 13);
            this.label36.TabIndex = 10;
            this.label36.Text = "Installed Updates:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 55);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(118, 13);
            this.label37.TabIndex = 9;
            this.label37.Text = "Installed Update Count:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 25);
            this.button2.TabIndex = 0;
            this.button2.Text = "Get Update Info";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(22, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 295);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Windows Update Agent";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(7, 216);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(290, 69);
            this.listBox2.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 95);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(290, 69);
            this.listBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 167);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(4, 199);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 13);
            this.label31.TabIndex = 4;
            this.label31.Text = "Available Updates:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 174);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(122, 13);
            this.label30.TabIndex = 3;
            this.label30.Text = "Available Update Count:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "Installed Updates:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Installed Update Count:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Update Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(746, 381);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AutomateQATools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computersBindingSource)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		private void setFlag(string flagType, string flagName, int setValue)
		{
			int num = 0;
			string empty = string.Empty;
			try
			{
				object[] now = new object[] { "SELECT ", flagType, " FROM labtech.computers WHERE Name = '", this.cmd_agentflags.SelectedValue, "'" };
				string str = string.Concat(now);
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				int num1 = Convert.ToInt32(mySqlCommand.ExecuteScalar());
				if ((setValue & num1) != 0)
				{
					now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- ", flagType, ": ", flagName, "(Value=", setValue, ") is already set. (", flagType, "=", num1, ")" };
					empty = string.Concat(now);
				}
				else
				{
					num = setValue + num1;
					now = new object[] { "UPDATE labtech.computers SET ", flagType, "='", num, "' WHERE Name='", this.cmd_agentflags.SelectedValue, "'" };
					string str1 = string.Concat(now);
					(new MySqlCommand(str1, mySqlConnection)).ExecuteReader();
					now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- ", flagType, ": ", flagName, "(Value=", setValue, ") SET from ", num1, " to ", num };
					empty = string.Concat(now);
				}
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception));
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

		private void unsetFlag(string flagType, string flagName, int setValue)
		{
			int num = 0;
			string empty = string.Empty;
			try
			{
				object[] now = new object[] { "SELECT ", flagType, " FROM labtech.computers WHERE Name = '", this.cmd_agentflags.SelectedValue, "'" };
				string str = string.Concat(now);
				MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DBConn);
				MySqlCommand mySqlCommand = new MySqlCommand(str, mySqlConnection);
				mySqlConnection.Open();
				int num1 = Convert.ToInt32(mySqlCommand.ExecuteScalar());
				if ((setValue & num1) == 0)
				{
					now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- ", flagType, ": ", flagName, "(Value=", setValue, ") is already unset. (", flagType, "=", num1, ")" };
					empty = string.Concat(now);
				}
				else
				{
					num = num1 - setValue;
					now = new object[] { "UPDATE labtech.computers SET ", flagType, "='", num, "' WHERE Name='", this.cmd_agentflags.SelectedValue, "'" };
					string str1 = string.Concat(now);
					(new MySqlCommand(str1, mySqlConnection)).ExecuteReader();
					now = new object[] { DateTime.Now, "\t", this.cmd_agentflags.SelectedValue, " -- ", flagType, ": ", flagName, "(Value=", setValue, ") UNSET from ", num1, " to ", num };
					empty = string.Concat(now);
				}
				mySqlConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(Convert.ToString(exception));
				empty = string.Concat(DateTime.Now, "\t", exception);
			}
			this.lst_logging_window.Items.Add(empty);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = (MessageBox.Show("This process could take a few minutes.  Please be patient.","AutomateQATools", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning));

            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (result == DialogResult.OK)
            {

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                string content1 = string.Empty;
                string content2 = string.Empty;
                UpdateSession updateSession = new UpdateSession();
                IUpdateSearcher updateSearchResult = updateSession.CreateUpdateSearcher();
                updateSearchResult.Online = true;//checks for updates online
                ISearchResult searchResultsInstalled = updateSearchResult.Search("IsInstalled=1 AND IsHidden=0");
                ISearchResult searchResultsAvailable = updateSearchResult.Search("IsInstalled=0 AND IsPresent=0");
                //for the above search criteria refer to 
                //http://msdn.microsoft.com/en-us/library/windows/desktop/aa386526(v=VS.85).aspx
                //Check the remarks section
                textBox1.Text = searchResultsInstalled.Updates.Count.ToString();
                foreach (IUpdate z in searchResultsInstalled.Updates)
                {
                    //listBox1.Text = "testing";
                    listBox1.Items.Add(z.Title);
                }
                textBox2.Text = searchResultsAvailable.Updates.Count.ToString();
                foreach (IUpdate y in searchResultsAvailable.Updates)
                {
                    // listBox2.Text = "testing";
                    listBox2.Items.Add(y.Title);
                }                
            }
        }
	}
}