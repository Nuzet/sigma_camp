﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t9
{
    internal class MenuService
    {
         static public bool TryGetMenuTotalSum(Menu menu, Price priceKurant, out double menuTotalSum)
        {
            menuTotalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceKurant, out double sumPrice))
                {
                    return false;
                }
                menuTotalSum += sumPrice;
            }
            return true;
        }
        static public bool TryGetDishPrice(Dish dish, Price priceKurant, out double sumPrice)
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!priceKurant.TryGetProductPrice(key, out double poductPrice))
                {
                    return false;
                }
                sumPrice += poductPrice * dish[key]/1000;
            }
            return true;

        }
    }
}
