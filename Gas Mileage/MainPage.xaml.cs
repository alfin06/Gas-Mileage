/***************************************************************/
/*                                                             */
/* Name:     Alfin Rahardja                                    */
/* Class:    CS 364 - .NET Programming                         */
/* Due-date: Februray 23, 2016                                 */
/*                                                             */
/***************************************************************/

/***************************************************************/
/*                                                             */
/* This program gets the cost of fuel, the distance, and the   */
/* number gallons of fuel from 2 vehicles; then, calculates    */
/* and compares the Cost per Mile and the Miles per Gallon     */
/* between both vehicles.                                      */
/*                                                             */
/***************************************************************/

using System;
using Windows.UI.Xaml.Controls;

namespace Gas_Mileage
{
    public sealed partial class MainPage : Page
    {
        // Member Variables
        Fuel vehicleA;                // Object of vehicle A
        Fuel vehicleB;                // Object of vehicle B
        float costOfGasA = 0.0f;      // Total cost of gas for vehicle A
        float costOfGasB = 0.0f;      // Total cost of gas for vehicle B
        float distanceA = 0.0f;       // Total distance of vehicle A
        float distanceB = 0.0f;       // Total distance of vehicle B
        int gallonsOfFuelA = 0;       // Total gallons of fuel for vehicle A
        int gallonsOfFuelB = 0;       // Total gallons of fuel for vehicle B
        float milesPerGallonA = 0.0f; // Vehicle A's MPG
        float milesPerGallonB = 0.0f; // Vehicle B's MPG
        float costPerMileA = 0.0f;    // Vehicle A's CPM
        float costPerMileB = 0.0f;    // Vehicle B's CPM

        // Main function where the initialization happens
        public MainPage()
        {
            this.InitializeComponent();
            vehicleA = new Fuel();
            vehicleB = new Fuel();
            cpmA.Text = "$" + costPerMileA.ToString("#0.00");
            mpgA.Text = milesPerGallonA.ToString("#0.00") + " mile";
            cpmB.Text = "$" + costPerMileB.ToString("#0.00");
            mpgB.Text = milesPerGallonB.ToString("#0.00") + " mile";
        }

        // Check the cost of gas for vehicle A whether it is a numeric value or not
        private void costA_TextChanged(object sender, TextChangedEventArgs e)
        {
            String costVehicleA = costA.Text.Trim();
            float costAValid;
            bool isCostAValid = float.TryParse(costVehicleA, out costAValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isCostAValid)
                {
                    if (float.Parse(costA.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("The cost must greater than 0!");
                    }
                    errorCostA.Text = "";
                    costOfGasA = float.Parse(costA.Text);
                    cpmMpgACalculation();
                }
                else if (costA.Text.Length == 0)
                {
                    errorCostA.Text = "";
                    costOfGasA = 0.0f;
                    cpmMpgACalculation();
                }
                else
                {
                    errorCostA.Text = "You enter invalid input! Please enter a numeric value.";
                    costOfGasA = 0.0f;
                    cpmMpgACalculation();
                }
            }
            catch (Exception ex)
            {
                errorCostA.Text = ex.Message;
            }
        }

        // Check the cost of gas for vehicle B whether it is a numeric value or not
        private void costB_TextChanged(object sender, TextChangedEventArgs e)
        {
            String costVehicleB = costB.Text.Trim();
            float costBValid;
            bool isCostBValid = float.TryParse(costVehicleB, out costBValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isCostBValid)
                {
                    if (float.Parse(costB.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("The cost must greater than 0!");
                    }
                    errorCostB.Text = "";
                    costOfGasB = float.Parse(costB.Text);
                    cpmMpgBCalculation();
                }
                else if (costB.Text.Length == 0)
                {
                    errorCostB.Text = "";
                    costOfGasB = 0.0f;
                    cpmMpgBCalculation();
                }
                else
                {
                    errorCostB.Text = "You enter invalid input! Please enter a numeric value.";
                    costOfGasB = 0.0f;
                    cpmMpgBCalculation();
                }
            }
            catch (Exception ex)
            {
                errorCostB.Text = ex.Message;
            }
        }

        // Check the distance for vehicle A whether it is a numeric value or not
        private void mileA_TextChanged(object sender, TextChangedEventArgs e)
        {
            String mileVehicleA = mileA.Text.Trim();
            float mileAValid;
            bool isMileAValid = float.TryParse(mileVehicleA, out mileAValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isMileAValid)
                {
                    if (float.Parse(mileA.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("The distance must greater than 0!");
                    }
                    errorMileA.Text = "";
                    distanceA = float.Parse(mileA.Text);
                    cpmMpgACalculation();
                }
                else if (mileA.Text.Length == 0)
                {
                    errorMileA.Text = "";
                    distanceA = 0.0f;
                    cpmMpgACalculation();
                }
                else
                {
                    errorMileA.Text = "You enter invalid input! Please enter a numeric value.";
                    distanceA = 0.0f;
                    cpmMpgACalculation();
                }
            }
            catch (Exception ex)
            {
                errorMileA.Text = ex.Message;
            }
        }

        // Check the distance for vehicle B whether it is a numeric value or not
        private void mileB_TextChanged(object sender, TextChangedEventArgs e)
        {
            String mileVehicleB = mileB.Text.Trim();
            float mileBValid;
            bool isMileBValid = float.TryParse(mileVehicleB, out mileBValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isMileBValid)
                {
                    if (float.Parse(mileB.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("The distance must greater than 0!");
                    }
                    errorMileB.Text = "";
                    distanceB = float.Parse(mileB.Text);
                    cpmMpgBCalculation();
                }
                else if (mileB.Text.Length == 0)
                {
                    errorMileB.Text = "";
                    distanceB = 0.0f;
                    cpmMpgBCalculation();
                }
                else
                {
                    errorMileB.Text = "You enter invalid input! Please enter a numeric value.";
                    distanceB = 0.0f;
                    cpmMpgBCalculation();
                }
            }
            catch (Exception ex)
            {
                errorMileB.Text = ex.Message;
            }
        }

        // Check the number of gallons for vehicle A whether it is a numeric value or not
        private void gallonsA_TextChanged(object sender, TextChangedEventArgs e)
        {
            String gallonsVehicleA = gallonsA.Text.Trim();
            int gallonsAValid;
            bool isGallonsAValid = int.TryParse(gallonsVehicleA, out gallonsAValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isGallonsAValid)
                {
                    if (int.Parse(gallonsA.Text) < 0)
                    {
                        throw new ArgumentOutOfRangeException("The number of gallons must greater than 0!");
                    }
                    errorGallonA.Text = "";
                    gallonsOfFuelA = int.Parse(gallonsA.Text);
                    cpmMpgACalculation();
                }
                else if (gallonsA.Text.Length == 0)
                {
                    errorGallonA.Text = "";
                    gallonsOfFuelA = 0;
                    cpmMpgACalculation();
                }
                else
                {
                    errorGallonA.Text = "You enter invalid input! Please enter a numeric value.";
                    gallonsOfFuelA = 0;
                    cpmMpgACalculation();
                }
            }
            catch (Exception ex)
            {
                errorGallonA.Text = ex.Message;
            }
        }

        // Check the number of gallons for vehicle B whether it is a numeric value or not
        private void gallonsB_TextChanged(object sender, TextChangedEventArgs e)
        {
            String gallonsVehicleB = gallonsB.Text.Trim();
            int gallonsBValid;
            bool isGallonsBValid = int.TryParse(gallonsVehicleB, out gallonsBValid);
            try
            {
                question.Text = "";
                bestVehicle.Text = "";
                if (isGallonsBValid)
                {
                    if (int.Parse(gallonsB.Text) < 0)
                    {
                        throw new ArgumentOutOfRangeException("The number of gallons must greater than 0!");
                    }
                    errorGallonB.Text = "";
                    gallonsOfFuelB = int.Parse(gallonsB.Text);
                    cpmMpgBCalculation();
                }
                else if (gallonsB.Text.Length == 0)
                {
                    errorGallonB.Text = "";
                    gallonsOfFuelB = 0;
                    cpmMpgBCalculation();
                }
                else
                {
                    errorGallonB.Text = "You enter invalid input! Please enter a numeric value.";
                    gallonsOfFuelB = 0;
                    cpmMpgBCalculation();
                }
            }
            catch (Exception ex)
            {
                errorGallonB.Text = ex.Message;
            }
        }

        // Print the cost per mile and miles per gallon for vehicle A
        private void cpmMpgACalculation()
        {
            vehicleA = new Fuel(costOfGasA, distanceA, gallonsOfFuelA);
            if (distanceA == 0.0f)
            {
                costPerMileA = 0.0f;
                cpmA.Text = "$" + costPerMileA.ToString("#0.00");
            }
            else
            {
                costPerMileA = vehicleA.CPM;
                cpmA.Text = "$" + costPerMileA.ToString("###,##0.00");
            }
            if (gallonsOfFuelA == 0)
            {
                milesPerGallonA = 0.0f;
                mpgA.Text = milesPerGallonA.ToString("#0.00") + " mile";
            }
            else
            {
                milesPerGallonA = vehicleA.MPG;
                mpgA.Text = milesPerGallonA.ToString("###,##0.00") + " mile";
            }
        }

        // Print the cost per mile and miles per gallon for vehicle B
        private void cpmMpgBCalculation()
        {
            vehicleB = new Fuel(costOfGasB, distanceB, gallonsOfFuelB);
            if (distanceB == 0.0f)
            {
                costPerMileB = 0.0f;
                cpmB.Text = "$" + costPerMileB.ToString("#0.00");
            }
            else
            {
                costPerMileB = vehicleB.CPM;
                cpmB.Text = "$" + costPerMileB.ToString("###,##0.00");
            }
            if (gallonsOfFuelB == 0)
            {
                milesPerGallonB = 0.0f;
                mpgB.Text = milesPerGallonB.ToString("#0.00") + " mile";
            }
            else
            {
                milesPerGallonB = vehicleB.MPG;
                mpgB.Text = milesPerGallonB.ToString("###,##0.00") + " mile";
            }
        }

        // Print the result of comparison
        private void compare_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            question.Text = "Which vehicle does have better economy fuel?";
            compareVehicle();
        }

        // Compare MPG from both vehicles to determine which vehicle has better economy fuel
        private void compareVehicle()
        {
            if(milesPerGallonA > milesPerGallonB)
            {
                bestVehicle.Text = "Vehicle A";
            }
            else if(milesPerGallonA < milesPerGallonB)
            {
                bestVehicle.Text = "Vehicle B";
            }
            else
            {
                if(costPerMileA > costPerMileB)
                {
                    bestVehicle.Text = "Vehicle B";
                }
                else if(costPerMileA < costPerMileB)
                {
                    bestVehicle.Text = "Vehicle A";
                }
                else
                { 
                    bestVehicle.Text = "Vehicle A and Vehicle B have same quality.";
                }
            }
        }
    }
}
