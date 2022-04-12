using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calendar
{
    class ApplicationViewUser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user = new User();

        public DateTime Birthdate
        {
            get { return _user.Birthdate; }
            set
            {
                _user.Birthdate = value;
                // Console.WriteLine(_user.Birthdate);
                OnPropertyChanged("Date");
            }
        }
        public int Age
        {
            get
            {
                return _user.Age;
            }
            set
            {
                _user.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public String WesternZodiac
        {
            get
            {
                return _user.WestZodiac;

            }
            set
            {
                _user.WestZodiac = value;
                OnPropertyChanged("WesternZodiac");
            }
        }
        public String ChineseZodiac
        {
            get
            {
                return _user.ChineZodiac;
            }
            set
            {
                _user.ChineZodiac = value;
                OnPropertyChanged("ChineseZodiac");
            }
        }


        private String[] WestAstrology = {
            "Aries",
            "Taurus" ,
            "Gemini" ,
            "Cancer" ,
            "Leo"  ,
            "Virgo" ,
            "Libro",
            "Scorpion" ,
            "Sagittarius" ,
            "Capricorn" ,
            "Aquarius" ,
            "Pisces"
        };

        /* {
             Aries = 0,
             Taurus ,
             Gemini ,
             Cancer ,
             Leo  ,
             Virgo ,
             Libro,
             Scorpion ,
             Sagittarius ,
             Capricorn ,
             Aquarius ,
             Pisces 
         }

        */

        private string[] ChineAstrology = {
            "Rat",
            "Ox" ,
            "Tiger" ,
            "Rabbit" ,
            "Dragon"  ,
            "Snake" ,
            "Horse",
            "Sheep" ,
            "Monkey" ,
            "Rooster" ,
            "Dog" ,
            "Pig"
        };

        private RelayCommand _calculateCommand;
        public RelayCommand CalculateCommand
        {
            get
            {
                return _calculateCommand ??
                    (_calculateCommand = new RelayCommand(_ => calculateAll(_user.Birthdate), CanExecute));


            }
        }

        private void calculateAll(DateTime dateTime)
        {

            calculateWesternZodiac(dateTime);
            calculateChineseZodiac(dateTime);
            calculateAge(dateTime);

        }

        private void calculateAge(DateTime dateTime)
        {


            int age = ( (dateTime.Month > DateTime.Now.Month) || ((dateTime.Month == DateTime.Now.Month) && dateTime.Day >= DateTime.Now.Day)) ? ((DateTime.Now.Year - dateTime.Year)-1) : ((DateTime.Now.Year - dateTime.Year));
          

            if (age < 0)
            {
                MessageBox.Show("I hope you will born soon");
                Age = 0;
                return;
            }
            if (age > 135) 
            {
                MessageBox.Show("Sorry, you are dead");
                Age = 0;
                return;
            };
            if (dateTime == DateTime.Now)
            {
                MessageBox.Show("Sorry, you are dead");
            }
            Age = age;
            return;
        }

        private void calculateChineseZodiac(DateTime dateTime)
        {
            int countYear = Math.Abs(dateTime.Year - 4) % 12;

            ChineseZodiac = ChineAstrology[countYear];

            return;
        }

        private bool CanExecute(object obj)
        {
          return true;
        }

        private void calculateWesternZodiac(DateTime date)
        {
            int day = date.Month * 100 + date.Day;

            switch(day)
            {
                case < 22:
                    WesternZodiac = WestAstrology[8];
                    break;

                case < 121:
                    WesternZodiac = WestAstrology[9];
                    break;
                case < 221:
                    WesternZodiac = WestAstrology[10];
                    break;
                case < 321:
                    WesternZodiac = WestAstrology[11];
                    break;
                case < 421:
                    WesternZodiac = WestAstrology[0];
                    break;
                case < 522:
                    WesternZodiac = WestAstrology[1];
                    break;
                case < 622:
                    WesternZodiac = WestAstrology[2];
                    break;
                case < 723:
                    WesternZodiac = WestAstrology[3];
                    break;
                case < 824:
                    WesternZodiac = WestAstrology[4];
                    break;
                case < 923:
                    WesternZodiac = WestAstrology[5];
                    break;
                case < 1024:
                    WesternZodiac = WestAstrology[6];
                    break;
                case < 1123:
                    WesternZodiac = WestAstrology[7];
                    break;
              
            }

            
           
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }




}


