using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package_Distribution_App
{
    internal class Package
    {
        //Backing fields
        private string _packageID;
        private string _destinationCity;
        private string _destinationState;

        //Properties
        public string PackageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        public string DestinationCity
        {
            get { return _destinationCity; }
            set { 
                _destinationCity = value;
                }

        }
        public string DestinationState
        {
            get { return _destinationState; }
            set {
                    if (value == "IL" || value == "MO" || value == "WI")
                    {
                        _destinationState = value;
                    }
                    else
                    {
                        _destinationState = "??";
                    }
                }
        }

        //Constructor
        public Package(string packageID, string destinationCity, string destinationState)
        {
            PackageID = packageID;
            DestinationCity = destinationCity;
            DestinationState = destinationState;
        }


    }
}
