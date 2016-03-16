/***************************************************************/
/*                      Class Definition                       */
/***************************************************************/

namespace Gas_Mileage
{
    class Fuel
    {
        // Field
        float totalCost;  // Total cost of the fill-up
        float totalMiles; // Total miles driven
        int totalGallons; // Total gallons purchased

        // Constructor that takes no parameter
        public Fuel()
        {
            totalCost = 0.0f;
            totalMiles = 0.0f;
            totalGallons = 0;
        }

        // Constructor that takes parameters
        public Fuel(float fuelCost, float vehicleMiles, int fuelGallons)
        {
            TotalCost = fuelCost;
            TotalMiles = vehicleMiles;
            TotalGallons = fuelGallons;
        }

        // Class' properties such as mutators and accessors
        public float TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public float TotalMiles
        {
            get { return totalMiles; }
            set { totalMiles = value; }
        }

        public int TotalGallons
        {
            get { return totalGallons; }
            set { totalGallons = value; }
        }

        public float MPG
        {
            get { return totalMiles / totalGallons; }
        }

        public float CPM
        {
            get { return totalCost / totalMiles; }
        }
    }
}