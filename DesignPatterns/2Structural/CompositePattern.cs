using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    public class CompositePattern
    {

        public CompositePattern()
        {
            Console.WriteLine("A tree structure of simple and composite objects,"+
                "Composite lets clients treat individual objects and compositions of objects uniformly");

        Menu mainMenu = new Menu("mainMenu","/mainMenu");

        MenuItem mainMenuItem = new MenuItem("mainMenuItem","/mainMenuItem");
        mainMenu.addMenuItem(mainMenuItem);

         Menu subMenu = new Menu("subMenu","/subMenu");
         mainMenu.addMenuItem(subMenu);

        MenuItem subMenuItem = new MenuItem("subMenuItem","/subMenuItem");
        subMenu.addMenuItem(subMenuItem);

        Menu childMenu = new Menu("childMenu", "/childMenu");
        subMenu.addMenuItem(childMenu);

        MenuItem childMenuItem = new MenuItem("childMenuItem", "/childMenuItem");
        childMenu.addMenuItem(childMenuItem);

        Console.WriteLine(mainMenu.ToString());
        }

    }

    abstract class MenuComponent
    {
        public string name;
        public string url;

        public List<MenuComponent> menucomponents = new List<MenuComponent>();

        public string getName()
        {
            return name;
        }

        public string getURL()
        {
            return url;
        }

        public abstract string ToString();

        public string print(MenuComponent menuComponent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n" + menuComponent.name + ":");
            stringBuilder.Append("\n " + menuComponent.url);
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }
    }

    class Menu : MenuComponent
    {
        public Menu(string name, string url)
        {
            base.name = name;
            base.url = url;
        }

        public MenuComponent addMenuItem(MenuComponent menuItem)
        {
            menucomponents.Add(menuItem);
            return menuItem;
        }

        public MenuComponent removeMenuItem(MenuComponent menuItem)
        {
            menucomponents.Remove(menuItem);
            return menuItem;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(print(this));

            var menuIterator = menucomponents.GetEnumerator();  //Iterator();

            while (menuIterator.MoveNext())
            {
                stringBuilder.Append("\n" + menuIterator.Current.ToString());
            }

            //foreach (var menuItem in menucomponents)
            //{
            //    stringBuilder.Append("\n" + menuItem.ToString());
            //}

            return stringBuilder.ToString();
        }
    }

    class MenuItem : MenuComponent
    { 
        public MenuItem(string name, string url)
        {
            base.name = name;
            base.url = url;
        }

        public override string ToString()
        {
            return print(this);
        }
    }
}
