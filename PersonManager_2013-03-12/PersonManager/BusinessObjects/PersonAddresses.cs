using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;

namespace BusinessObjects
{
    public class PersonAddresses
    {
        #region "Declarations"

        int id;
        Collection<PersonAddress> personAddresses = null; 

        #endregion

        #region "Constructors"

        public PersonAddresses(int ID) 
        {
            id = ID;
        }

        #endregion

        #region "Properties"

        public Collection<PersonAddress> Addresses
        {
            get
            {
                if (personAddresses == null)
                {
                    DataPortal.PersonAddresses dp = new DataPortal.PersonAddresses();
                    DataSet ds = dp.Fetch(id);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PersonAddress pa = new PersonAddress(dr);
                        personAddresses.Add(pa);
                    }
                }
                return personAddresses;
            }
        }

        public int Count
        {
            get
            {
                return personAddresses.Count;
            }
        }

        #endregion

        #region "Public Methods"

        public void Save()
        {
        }

        public void Delete()
        {
        }

        #endregion

        #region "Private Methods"
        #endregion
    }
}
