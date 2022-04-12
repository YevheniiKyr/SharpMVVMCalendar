using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class User 
    {
        
        private DateTime _birthdate;
        private int _age;
        private String _westZodiac;
        private String _chineZodiac;
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }
        
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public String WestZodiac
        {
            get
            {
                return _westZodiac;
            }
            set
            {
                _westZodiac = value;
            }
        }
        public String ChineZodiac
        {
            get
            {
                return _chineZodiac;
            }
            set
            {
                _chineZodiac = value;
            }
        }


   
    }
}
