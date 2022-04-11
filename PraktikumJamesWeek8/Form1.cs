using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumJamesWeek8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string sqlConnection = "server=139.255.11.84;uid=student;pwd=isbmantap;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;
        DataTable penampung_combobox1 = new DataTable();
        DataTable penampung_combobox2 = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            //sqlConnect.Open();
            sqlQuery = "SELECT team_id as `id`, team_name as `team` , manager_id as `manager` , captain_id as `captain` , home_stadium as `stadium` , capacity as `capacity` FROM premier_league.team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(penampung_combobox1);
            comboBox1.DataSource = penampung_combobox1;
            comboBox1.DisplayMember = "team";
            comboBox1.ValueMember = "id";

            sqlQuery = "SELECT team_id as `id`, team_name as `team` , manager_id as `manager` , captain_id as `captain` , home_stadium as `stadium` , capacity as `capacity` FROM premier_league.team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(penampung_combobox2);
            comboBox2.DataSource = penampung_combobox2;
            comboBox2.DisplayMember = "team";
            comboBox2.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sqlQuery = "SELECT m.manager_name as `manager`, t.team_id as `id`, team_name as `team` , t.manager_id as `manager_id` , captain_id as `captain` , home_stadium as `stadium` , capacity as `capacity` , p.player_name as `player` FROM manager m, team t, player p where m.manager_id = t.manager_id and p.player_id = t.captain_id and t.team_id = '" + comboBox1.SelectedValue.ToString() + "'";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                DataTable penampung2 = new DataTable();
                sqlAdapter.Fill(penampung2);
                Manager1Output.Text = penampung2.Rows[0]["manager"].ToString();
                Captain1Output.Text = penampung2.Rows[0]["player"].ToString();
                StadiumOutput.Text = penampung2.Rows[0]["stadium"].ToString();
                CapacityOuput.Text = penampung2.Rows[0]["capacity"].ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sqlQuery = "SELECT m.manager_name as `manager`, t.team_id as `id`, team_name as `team` , t.manager_id as `manager_id` , captain_id as `captain` , home_stadium as `stadium` , capacity as `capacity` , p.player_name as `player` FROM manager m, team t, player p where m.manager_id = t.manager_id and p.player_id = t.captain_id and t.team_id = '" + comboBox2.SelectedValue.ToString() + "'";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                DataTable penampung3 = new DataTable();
                sqlAdapter.Fill(penampung3);
                Manager2Output.Text = penampung3.Rows[0]["manager"].ToString();
                Captain2Output.Text = penampung3.Rows[0]["player"].ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
