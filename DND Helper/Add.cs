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


namespace DND_Helper
{
    public partial class Add : Form
    {
        public Add(int ID_log)
        {
            InitializeComponent();
            ID_lb.Text = ID_log.ToString();
            getBoxes("select name_race from race",race_Cb);
            getBoxes("select name_w from worldview", world_Cb);
            getBoxes("select name_class from classes", class_Cb);
            getBoxes("select name_history from history", history_Cb);
            getBoxes("select typew from type_weapon", weapon_Cb);
            getBoxes("select typea from type_armor", armor_Cb);
            getList("select name_skill from skills;",skill_CBL);
            
        }
       
        private void Add_Load(object sender, EventArgs e)
        {
            groupBox1.Parent = this;
            groupBox1.BackColor = Color.Transparent;
            groupBox8.Parent = this;
            groupBox8.BackColor = Color.Transparent;
            DGV("select weapon.id_weapon, type_weapon.typew as 'Тип', name_weapon as 'Название',  desc_weapon as 'Описание' from weapon join type_weapon on weapon.id_typew = type_weapon.id_typew;", weapon_DGV);
            DGV("select armor.id_armor, type_armor.typea as 'Тип', name_armor as 'Название',  desc_armor as 'Описание' from armor join type_armor on armor.id_typea = type_armor.id_typea;", armor_DGV);
        }
        public void getBoxes(string query, ComboBox box)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        box.Items.Add(rd.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибочка!" + Environment.NewLine + ex.Message);
            }
        }

        public void getList(string query, CheckedListBox listbox)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        listbox.Items.Add(rd.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибочка!" + Environment.NewLine + ex.Message);
            }
        }

        public void Info_TB(string query, TextBox box)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        box.Text=rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошли технические накладки!" + Environment.NewLine + ex.Message);
            }
        }
        private void world_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Info_TB("select desc_w from worldview where name_w = '" + world_Cb.Text + "';", world_Tb);
        }

        private void class_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Info_TB("select desc_class from classes where name_class = '" + class_Cb.Text + "';", class_Tb);
            label("select hitpoint from classes where name_class = '" + class_Cb.Text + "';", hitpoint_lb);
            DGVS("select name_spell as 'Название заклинания', desc_spell as 'Описание' from spells where id_class = (select id_class from classes where name_class = '"+ class_Cb.Text + "');", spell_DGV);
            txba("select (select typea from type_armor where id_typea = tenure_armor.id_typea) from tenure_armor where id_class = (select id_class from classes where name_class = '"+ class_Cb.Text + "');", ability_Tb,"Владение бронёй(" + class_Cb.Text + "): ");
            txba("select (select typew from type_weapon where id_typew = tenure_weapon.id_typew) from tenure_weapon where id_class = (select id_class from classes where name_class = '" + class_Cb.Text + "');", ability_Tb, "Владение оружием(" + class_Cb.Text + "): ");
        }

        private void race_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            height_Track.Visible = true;
            age_Track.Visible = true;
            Info_TB("select desc_race from race where name_race = '" + race_Cb.Text + "';", race_Tb);
            label("select speed from race where name_race = '"+race_Cb.Text+"';",speed_lb);
            label("select min_height from race where name_race = '"+race_Cb.Text+"';", hiwei_lb);
            int min_height = Int32.Parse(hiwei_lb.Text);
            height_lb.Text = min_height.ToString();
            height_Track.Minimum = min_height;
            label("select max_height from race where name_race = '" + race_Cb.Text + "';", hiwei_lb);
            int max_height = Int32.Parse(hiwei_lb.Text);
            height_Track.Maximum = max_height;
            label("select min_age from race where name_race = '" + race_Cb.Text + "';", hiwei_lb);
            int min_age = Int32.Parse(hiwei_lb.Text);
            age_lb.Text = min_age.ToString();
            age_Track.Minimum = min_age;
            label("select max_age from race where name_race = '" + race_Cb.Text + "';", hiwei_lb);
            int max_age = Int32.Parse(hiwei_lb.Text);
            age_Track.Maximum = max_age;

        }

        private void history_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Info_TB("select desc_history from history where name_history = '"+history_Cb.Text+"';",history_Tb);
            txbh("select equipment from equip_his where id_history = (select id_history from history where name_history ='" + history_Cb.Text + "');", invent_Tb);
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label("select min(id_trait) from trait where id_history =(select id_history from history where name_history ='"+history_Cb.Text+"');", num_lb) ;
            int min = Int32.Parse(num_lb.Text)-1;
            label("select max(id_trait) from trait where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int max = Int32.Parse(num_lb.Text) + 1;
            Random random = new Random();
            int i = random.Next(min, max);
            Info_TB("select desc_trait from trait where id_trait = "+i+"",trait_Tb);

            label("select min(id_ideal) from ideal where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int min2 = Int32.Parse(num_lb.Text) - 1;
            label("select max(id_ideal) from ideal where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int max2 = Int32.Parse(num_lb.Text) + 1;
            Random random2 = new Random();
            int i2 = random.Next(min2, max2);
            Info_TB("select desc_ideal from ideal where id_ideal = " + i2 + "", ideal_Tb);

            label("select min(id_weakness) from weakness where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int min3 = Int32.Parse(num_lb.Text) - 1;
            label("select max(id_weakness) from weakness where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int max3 = Int32.Parse(num_lb.Text) + 1;
            Random random3 = new Random();
            int i3 = random.Next(min3, max3);
            Info_TB("select desc_weakness from weakness where id_weakness = " + i3 + "", weakness_Tb);

            label("select min(id_devotion) from devotion where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int min4 = Int32.Parse(num_lb.Text) - 1;
            label("select max(id_devotion) from devotion where id_history =(select id_history from history where name_history ='" + history_Cb.Text + "');", num_lb);
            int max4 = Int32.Parse(num_lb.Text) + 1;
            Random random4 = new Random();
            int i4 = random.Next(min4, max4);
            Info_TB("select desc_devotion from devotion where id_devotion = " + i4 + "", devotion_Tb);
        }
        public void label(string query, Label label)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        label.Text = rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузкb!" + Environment.NewLine + ex.Message);
            }
        }

        private void height_Track_Scroll(object sender, EventArgs e)
        {
           height_lb.Text= height_Track.Value.ToString();
        }

        private void age_Track_Scroll(object sender, EventArgs e)
        {
            age_lb.Text = age_Track.Value.ToString();
        }

        private void weapon_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV("select weapon.id_weapon, type_weapon.typew as 'Тип', name_weapon as 'Название',  desc_weapon as 'Описание' from weapon join type_weapon on weapon.id_typew = type_weapon.id_typew where typew = '" + weapon_Cb.Text + "';", weapon_DGV);
        }

        private void armor_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV("select armor.id_armor, type_armor.typea as 'Тип', name_armor as 'Название',  desc_armor as 'Описание' from armor join type_armor on armor.id_typea = type_armor.id_typea where typea = '" + armor_Cb.Text+"';", armor_DGV);
        }
        public void DGV(string query, DataGridView dgv)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.ClearSelection();
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].ReadOnly = true;
                dgv.Columns[2].ReadOnly = true;
                dgv.Columns[3].ReadOnly = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        public void DGVS(string query, DataGridView dgv)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.ClearSelection();
                dgv.Columns[0].ReadOnly = true;
                dgv.Columns[1].ReadOnly = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        public void txbh(string query, TextBox text)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        text.Text = text.Text + Environment.NewLine + rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузкb!" + Environment.NewLine + ex.Message);
            }
        }
        public void txba(string query, TextBox text, string thing)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        text.Text = text.Text + Environment.NewLine + thing + rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        public void txb(string query, TextBox text)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                       text.Text = text.Text + Environment.NewLine + rd.GetString(0);
                        text.Text = text.Text + "("+ rd.GetString(1);
                        text.Text = text.Text + ", " + rd.GetString(2) + ")";
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузкb!" + Environment.NewLine + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            txb("select weapon.name_weapon, type_weapon.typew, desc_weapon from weapon join type_weapon on weapon.id_typew=type_weapon.id_typew where id_weapon = " + weapon_DGV[0, weapon_DGV.CurrentRow.Index].Value.ToString() + ";", invent_Tb);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txb("select armor.name_armor, type_armor.typea, desc_armor from armor join type_armor on armor.id_typea=type_armor.id_typea where id_armor = " + armor_DGV[0, armor_DGV.CurrentRow.Index].Value.ToString() + ";", invent_Tb);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            weapon_DGV.Columns.Clear();
            armor_DGV.Columns.Clear();
            weapon_Cb.SelectedIndex = -1;
            armor_Cb.SelectedIndex = -1;
            DGV("select weapon.id_weapon, type_weapon.typew as 'Тип', name_weapon as 'Название',  desc_weapon as 'Описание' from weapon join type_weapon on weapon.id_typew = type_weapon.id_typew;", weapon_DGV);
            DGV("select armor.id_armor, type_armor.typea as 'Тип', name_armor as 'Название',  desc_armor as 'Описание' from armor join type_armor on armor.id_typea = type_armor.id_typea;", armor_DGV);
            
        }

        private void skill_CBL_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (skill_CBL.CheckedItems.Count > 3)
            {
                if (e.NewValue == CheckState.Unchecked) return;
                for (int i = 0; i < skill_CBL.Items.Count; i++)
                {
                    if (i != e.Index)
                        skill_CBL.SetItemChecked(i, false);
                }
            }
            
        }

        private void pstr_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + pstr_lb.Text + ";", str_lb);
        }

        private void strp_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(pstr_lb.Text);
            if (results < 15)
            {
                results += 1;
                pstr_lb.Text= results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                pstr_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                strp_btn.Enabled = false;
            }
        }

        private void strm_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(pstr_lb.Text);
            if (results > 1)
            {
                results -= 1;
                pstr_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                pstr_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                strm_btn.Enabled = false;
            }
        }

        private void chap_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + chap_lb.Text + ";", cha_lb);
        }

        private void wisp_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + wisp_lb.Text + ";", wis_lb);
        }

        private void intp_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + intp_lb.Text + ";", int_lb);
        }

        private void conp_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + conp_lb.Text + ";", con_lb);
        }

        private void dexp_lb_TextChanged(object sender, EventArgs e)
        {
            label("select mod_po from modificator where stat_point = " + dexp_lb.Text + ";", dex_lb);
        }

        private void dexm_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(dexp_lb.Text);
            if (results > 1)
            {
                results -= 1;
                dexp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number + 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                dexp_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                dexm_btn.Enabled = false;
            }
        }

        private void dexp_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(dexp_lb.Text);
            if (results < 15)
            {
                results += 1;
                dexp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                dexp_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                dexp_btn.Enabled = false;
            }
        }

        private void conm_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(conp_lb.Text);
            if (results > 1)
            {
                results -= 1;
                conp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number + 1;
                point_lb.Text = number.ToString();
            }
            else
            {
               conp_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                conm_btn.Enabled = false;
            }
        }

        private void conp_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(conp_lb.Text);
            if (results < 15)
            {
                results += 1;
                conp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                conp_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                conp_btn.Enabled = false;
            }
        }

        private void intm_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(intp_lb.Text);
            if (results > 1)
            {
                results -= 1;
                intp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number + 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                intp_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                intm_btn.Enabled = false;
            }
        }

        private void intp_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(intp_lb.Text);
            if (results < 15)
            {
                results += 1;
                intp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                intp_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                intp_btn.Enabled = false;
            }
        }

        private void wism_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(wisp_lb.Text);
            if (results > 1)
            {
                results -= 1;
                wisp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number + 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                wisp_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                wism_btn.Enabled = false;
            }
        }

        private void wisp_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(wisp_lb.Text);
            if (results < 15)
            {
                results += 1;
                wisp_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                wisp_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                wisp_btn.Enabled = false;
            }
        }

        private void cham_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(chap_lb.Text);
            if (results > 1)
            {
                results -= 1;
                chap_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number + 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                chap_lb.Text = "1";
                MessageBox.Show("При создании минимальное значение 1.");
                cham_btn.Enabled = false;
            }
        }

        private void chap_btn_Click(object sender, EventArgs e)
        {
            int results = Int32.Parse(chap_lb.Text);
            if (results < 15)
            {
                results += 1;
                chap_lb.Text = results.ToString();
                int number = Int32.Parse(point_lb.Text);
                number = number - 1;
                point_lb.Text = number.ToString();
            }
            else
            {
                chap_lb.Text = "15";
                MessageBox.Show("При создании максимальное значение 15.");
                chap_btn.Enabled = false;
            }
        }

        private void point_lb_TextChanged(object sender, EventArgs e)
        {
            int result = Int32.Parse(point_lb.Text);
            switch (result)
            {
                case 0:
                    strp_btn.Enabled = false;
                    dexp_btn.Enabled = false;
                    conp_btn.Enabled = false;
                    intp_btn.Enabled = false;
                    wisp_btn.Enabled = false;
                    chap_btn.Enabled = false;
                    break;
                default:
                    strp_btn.Enabled = true;
                    dexp_btn.Enabled = true;
                    conp_btn.Enabled = true;
                    intp_btn.Enabled = true;
                    wisp_btn.Enabled = true;
                    chap_btn.Enabled = true;
                    break;
            }
        }

        public void doAction(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошли технические накладки!" + Environment.NewLine + ex.Message);
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int str = Int32.Parse(pstr_lb.Text);
                int dex = Int32.Parse(dexp_lb.Text);
                int con = Int32.Parse(conp_lb.Text);
                int inte = Int32.Parse(intp_lb.Text);
                int wis = Int32.Parse(wisp_lb.Text);
                int cha = Int32.Parse(chap_lb.Text);
                string res = race_Cb.Text;
                switch (res)
                {
                    case "Человек":
                        str += 1;
                        dex += 1;
                        con += 1;
                        inte += 1;
                        wis += 1;
                        cha += 1;
                        doAction("insert into stat (strenght, dextery, constilution, intelligence, wisdom, charisma) values (" + str  +", " + dex + ", " + con  + ", " + inte + ", " + wis  + ", " + cha  + ");");
                        break;
                    case "Полуэльф":
                        dex += 1;
                        cha += 2;
                        inte += 1;
                        doAction("insert into stat (strenght, dextery, constilution, intelligence, wisdom, charisma) values (" + str +  ", " + dex +", " + con +  ", " + inte  +", " + wis + ", " + cha  + ");");
                        break;
                    case "Полурослик":
                        dex += 2;
                        doAction("insert into stat (strenght, dextery, constilution, intelligence, wisdom, charisma) values (" + str + ", " + dex + ", " + con + ", " + inte +  ", " + wis + ", " + cha + ");");
                        break;
                }    
                
                doAction("insert into hero (name_c, age, height, eye, skin, hair, id_class, id_race, id_history, id_stat, trait, ideal, devotion, weakness, id_world, bio, equipment, abilites, date_create) values ('" + name_Tb.Text + "', " + age_lb.Text + ", " + height_lb.Text + ", '" + eye_Tb.Text + "', " +
                    "'"+skin_Tb.Text+"', '"+hair_Tb.Text+"', (select id_class from classes where name_class = '"+class_Cb.Text+ "'), (select id_race from race where name_race = '" + race_Cb.Text + "')," +
                    "(select id_history from history where name_history = '" + history_Cb.Text + "'), (select max(id_stat) from stat), '"+trait_Tb.Text+"', '"+ideal_Tb.Text+"', " +
                    "'"+devotion_Tb.Text+"', '"+weakness_Tb.Text+ "', (select id_world from worldview where name_w = '" + world_Cb.Text + "'), '"+bio_Tb.Text+"', '"+invent_Tb.Text+"', '"+ability_Tb.Text+"', (select curdate()));");



                foreach (var item in skill_CBL.CheckedItems)
                {
                    label31.Text = item.ToString();
                    doAction("insert into skill_list values ((select id_skill from skills where name_skill = '" + label31.Text + "'), (select max(id_char) from hero));");
                }
                doAction("insert into char_list values ("+ID_lb.Text+",(select max(id_char) from hero));");
                MessageBox.Show("Герой успешно создан!");
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("По каким-то причинам героя создать не удалось." + Environment.NewLine + ex.Message);
            }
        }
    }
}
