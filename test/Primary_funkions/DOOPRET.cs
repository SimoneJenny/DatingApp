using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using static test.Databaseconnection;
using System.Windows;

namespace test.Primary_funkions //pga. mappestruktur
{
    public class DOOPRET : INotifyPropertyChanged //primært den der arbejder
    {
        private string _adgangskode;
        public string Adgangskode {
            get { return _adgangskode;  }
            set { _adgangskode = value; OnPropertyChanged("adgangskode"); }
        }
        public string email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("email"); }
        }
        private string _id;
        public string Id {
            get { return _id; }
                set { _id = value; OnPropertyChanged("id"); }
        }
        private string _hvemerjeg;
        public string Hvemerjeg {
            get { return _hvemerjeg; }
            set { _hvemerjeg = value;OnPropertyChanged("hvemerjeg"); }
                }
        private string _ditfuldenavn;
        public string Ditfuldenavn {
            get { return _ditfuldenavn; }
            set { _ditfuldenavn = value; OnPropertyChanged("ditfuldenavn"); }
                }
        private int _alder;
        public int Alder {
            get { return _alder; }
            set { _alder = value; OnPropertyChanged("alder"); }
                }
        private string _by;
        public string By {
            get { return _by; }
            set { _by = value; OnPropertyChanged("by"); }
                }
        private string _soger;
        public string Soger {
            get { return _soger; }
            set { _soger = value; OnPropertyChanged("soge"); }
        }
        private string _interesser;
        public string Interesser {
            get { return _interesser; }
            set { _interesser = value; OnPropertyChanged("interesser"); }
        }
        private string _login;
        public string Login {
            get { return _login; }
            set { _login = value; OnPropertyChanged("login"); }
        }
        private string _sex;
        public string Sex {
            get { return _sex; }
            set { _sex = value; OnPropertyChanged("sex"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //constructor callled to set designtime data if necesary

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool InitialLogin(string bNavn, string pWord)
        {
            string searchQuery = $"SELECT * FROM userAccount WHERE username='{bNavn}' AND [password]='{pWord}'";
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public string GetCurrentUserId(string bNavn)
        {
            string searchForIdWithPasswordQuery = $"SELECT userID FROM userAccount WHERE username='{bNavn}'";
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(searchForIdWithPasswordQuery, sqlCon);
                sda.Fill(dt);
                return dt.Rows[0]["userID"].ToString();
            }
        }
        public void Loginuser() //her er vores loginuser
        {
            string bNavn = Login.Trim(), pWord = Adgangskode;
            if (bNavn != "" && pWord != "")
            {
                DOOPRET bOpret = new DOOPRET();
                if (bOpret.InitialLogin(bNavn, pWord))
                {
                    loginuser login = new loginuser(bOpret.GetCurrentUserId(bNavn));
                    login.Show();
                    App.Current.Windows[0].Close();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("fail :(");
                }

            }
            else
            {
                // TODO
                MessageBox.Show("PLACEHOLDER: FUCKED");
            }


            //loginuser log = new loginuser();
            //log.Show();
            //this.Close();
        }


    }
}
