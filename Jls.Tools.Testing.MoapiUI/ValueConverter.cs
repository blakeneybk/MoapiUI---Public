using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jls.Tools.Testing.MoapiClient.Models;
using Jls.Tools.Testing.MoapiUI;
using Telerik.WinControls.UI;

namespace Jls.Tools.Testing.MoapiUI
{
    public class ValueConverter
    {
        public int ConvertProgressToPrice(int progress) {

            int price = 0;

            int x = 0;

            if (progress >= 20) {

                price = 20*25000;                                                                            

                x = progress-20;

                if (x >= 20) {

                    price += 20*50000;                                                         

                    x-=20;

                    if (x >= 20) price += 20*500000;

                    else price += x*500000;

                }

                else

                    price += x*50000;

            }

            else

                price = progress*25000;                                                                                               

                               

            return price;

        }
        public decimal ConvertProgressToAcres(int progress) {

            decimal acres = 0;

            if (progress > 3) {

                acres = (progress-3);

            }

            else

                acres = progress * .25M;

            return acres;

        }
        public decimal ConvertProgressToBaths(int progress)
        {
            return (decimal)progress / 4;
        }
        public int ConvertProgressToSqFt(int progress)
        {
            return progress * 500;
        }

        //Convert real values to trackbar progress values
        public int ConvertSqFtToProgress(int sqft, int maxProgress)
        {
            int progress = sqft / 500;
            if (progress > maxProgress)
                return maxProgress;
            return sqft / 500;
        }
        public int ConvertAcresToProgress(decimal acres, int maxProgress)
        {

            if (acres > maxProgress)
                return maxProgress;
            int progress;
                             
            if (acres >= 1) {

                progress = (int)acres / 1+3;

            }

            else {

                progress = (int)(acres / (decimal) .25);

            }                 

            return progress;

        }
        public int ConvertPriceToProgress(int price, int maxProgress) {
            
            int progress = 0;

            int x = 20*25000;                         
            
            if (price >= x) {

                progress += 20;                

                x += 20*50000;

                if (price >= x) {

                    progress += 20;

                    x += 20*500000;

                    if (progress >= x)

                        progress += 20;

                    else

                        x = price - ((20*50000) + 20*25000);

                    progress += x / 500000;

                }

                else

                    progress += (price - (20*25000)) / 50000;                                                              

            }

            else

                progress = price / 25000;

            if (progress > maxProgress)
                return maxProgress;

            return progress;

        }
        public int ConvertBathsToProgress(decimal baths, int maxProgress)
        {
            if (baths > (decimal)maxProgress/4)
            {
                return maxProgress;
            }
            return (int)(baths * 4);
        }

        //Generic 1:1 converter
        public int ConvertRealValueToUiValue(decimal searchRequestValue, int minValue, int maxValue)
        {
            if (searchRequestValue > Int32.MaxValue)
                searchRequestValue = Int32.MaxValue;
            if (searchRequestValue < minValue)
                return minValue;
            if (searchRequestValue > maxValue)
                return maxValue;
            return (int)searchRequestValue;
        }

    }
}
