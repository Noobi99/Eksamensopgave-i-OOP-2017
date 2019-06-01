using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    public class User : IComparable
    {
        private int _id;
        private string _username;
        private float _money;

        public float Money
        {
            get => _money;
            set => _money = value;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            set
            {
                if (value != null)
                {
                    _username = value;
                }
            }
            get { return _username; }
        }

        public override string ToString()
        {
            return Id + " " + Username;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
            {
                return false;
            }

            if(_id.Equals(((User) obj).Id))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked // only needed if you're compiling with arithmetic checks enabled
            { // (the default compiler behaviour is *disabled*, so most folks won't need this)
                int hash = 13;
                hash = (hash * 7) + _id.GetHashCode();
                //hash = (hash * 7) + field2.GetHashCode();
                
                return hash;
            }
        }

        public int CompareTo(object obj)
        {
            return this._id.CompareTo(((User) obj).Id);
        }
    }

    class CompareUserByUsernameReverse : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            return -(String.Compare(x.Username, y.Username, StringComparison.Ordinal));
        }
    }
    
}