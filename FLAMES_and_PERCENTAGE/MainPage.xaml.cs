using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FLAMES_and_PERCENTAGE
{
    enum FLAMES
    {//Friends, Lovers, Affectionate, Marriage, Enemies, Siblings
        FRIEND,
        LOVER,
        AFFECTIONATE,
        MARRIAGAE,
        ENEMY,
        SIBLING
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        

        //Calculate Button Code
        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            //Get Both Partner's names
            string name_1 = Txt_Name_1.Text;
            string name_2 = Txt_Name_2.Text;

            //FLAMES Logic
            name_1 = Name_Validation(name_1);
            name_2 = Name_Validation(name_2);

            int FLAME_NUM = GetFlamesNumber(name_1, name_2);
            string FLAME = GetFlame(FLAME_NUM);
            Txt_FLAMES.Text = FLAME;

            //PERCENTAGE calculator Logic

        }

        private int GetFlamesNumber(String name_1, String name_2)
        {
            string bothNames = name_1 + name_2;
            
            int flameNum = 0;
            foreach (char c in bothNames)
            {
                if (bothNames.IndexOf(c) == bothNames.LastIndexOf(c))
                {
                    flameNum++;
                }
            }
            return flameNum;
        }

        private string Name_Validation(string name)
        {
            if (name.Contains(" "))
            {
                return name.Substring(0, name.IndexOf(' '));
            }
            else return name;
            
        }

        private string GetFlame(int num)
        {
            int flameNum;
            string FLAME;

            if (num % 6 == 0)
            {
                flameNum = 6;
            }
            else
            {
                flameNum = num%6;
            }
            
            switch (flameNum)
            {
                case 1:
                    FLAME = "FRIEND";
                    break;
                case 2:
                    FLAME = "LOVERS";
                    break;
                case 3:
                    FLAME = "AFFECTION";
                    break;
                case 4:
                    FLAME = "MARRIAGE";
                    break;
                case 5:
                    FLAME = "ENEMY";
                    break;
                case 6:
                    FLAME = "SIBLINGS";
                    break;
                default:
                    FLAME = "ERROR";
                    break;
            }
            
            return FLAME;
        }
    }
}
