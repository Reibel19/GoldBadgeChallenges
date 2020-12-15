using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB1_ClassLibrary
{
    public class MenuRepo
    {
        private List<Menu> _menuList = new List<Menu>();

        //Create
        public void AddMenuItem(Menu menu)
        {
            _menuList.Add(menu);
        }

        //Read
        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        //Delete
        public bool DeleteMenuItem(string name) 
        {
            Menu menu = GetMenuItemByName(name);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _menuList.Count;
            _menuList.Remove(menu);

            if (initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method for searching menu list by name
        public Menu GetMenuItemByName(string name)
        {
            foreach (Menu menu in _menuList)
            {
                if(menu.Name.ToLower() == name.ToLower())
                {
                    return menu;
                }
            }

            return null;
        }


    }
}
