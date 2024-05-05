using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._41OtherPatterns
{
    class MVC_MVVM_MVP
    {
        public MVC_MVVM_MVP()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Other Patterns");
            stringBuilder.Append("\nMVC-Model View Controller");
            stringBuilder.Append("\nMVVM-Movdel View View Model");
            stringBuilder.Append("\nMVP-Model View Presenter");

            //https://msdn.microsoft.com/en-in/library/hh848246.aspx

            stringBuilder.Append("\n\nMVVM");
            stringBuilder.Append("\nThe model in MVVM is an implementation of the application's domain model" +
                "that includes a data model along with business and validation logic");
            stringBuilder.Append("\nThe view is responsible for defining the layout, and appearance of what the user sees on the screen.");
            stringBuilder.Append("\nThe view model acts as an intermediary between the view and the model, and is responsible for handling the view logic." +
                "Typically, the view model interacts with the model by invoking methods in the model classes.");

            stringBuilder.Append("\n\nMVVM-Pros");
            stringBuilder.Append("\nUnit Testing-Support for TDD, As view interacts with view model,same view unit test can interact and test the same behavior");
            stringBuilder.Append("\nEase of maintainance, It is easy to redesign the UI of the application without touching the code"+ 
                "A new version of the view should work with the existing view model.");
            stringBuilder.Append("\nSeperation of Concerns- View and Behaviour,");
            stringBuilder.Append("\nParallel Development-Loose coupling between UI and behaviour promotes Paraller Dev");
            



            //https://www.codeproject.com/articles/620195/learning-mvc-part-introduction-to-mvc-architectu
            https://msdn.microsoft.com/en-us/library/dd381412(v=vs.108).aspx
            stringBuilder.Append("\n\nMVC-Pros");
            stringBuilder.Append("\nUnit Testing-Support for TDD-All core contracts in the MVC framework are interface-based and can be tested by"+ 
                "using mock objects, which are simulated objects that imitate the behavior of actual objects in the application. ");
            stringBuilder.Append("\nMaintainance - Ease of maintainance, It is easy to redesign the UI of the application without touching" + 
                "the code because the view is implemented entirely in XAML.A new version of the view should work with the existing view model.");
            stringBuilder.Append("\nSeperation of Concerns- View and Behaviour");
            stringBuilder.Append("\nParallel Development");
            stringBuilder.Append("\nExtensibility"+
                "\nAn extensible and pluggable framework.The components of the ASP.NET MVC framework are designed so"+ 
                "that they can be easily replaced or customized. You can plug in your own view engine, URL routing policy, "+
                "action-method parameter serialization, and other components. ");

            stringBuilder.Append("\nExtensive support for ASP.NET routing, which is a powerful URL - mapping component that "+
                "lets you build applications that have comprehensible and searchable URLs");
            stringBuilder.Append("\nSupport for existing ASP.NET features.ASP.NET MVC lets you use features such as "+
                "forms authentication and Windows authentication, URL authorization, membership and roles, "+
                "output and data caching, session and profile state management, "+
                "health monitoring, the configuration system, and the provider architecture");
            stringBuilder.Append("\nSupport for using the markup in existing ASP.NET page (.aspx files), user control (.ascx files),"+
                "and master page(.master files) markup files as view templates.");

           stringBuilder.Append("\nThe model in MVVM is an implementation of the application's domain model that includes a data model along with business and validation logic");
            stringBuilder.Append("\nThe view is responsible for defining the structure, layout, and appearance of what the user sees on the screen.");
            stringBuilder.Append("\nHandles a request from a view and updates the model that results a change in Model’s state.");


            //https://www.linkedin.com/pulse/difference-between-mvc-mvp-mvvm-swapneel-salunkhe
            //            When to use which

            //                When to use which?

            //MVP
            //Use in situations where binding via a datacontext is not possible.
            //Windows Forms is a perfect example of this.In order to separate the view from the model, a presenter is needed.
            //Since the view cannot directly bind to the presenter, information must be passed to it via an interface (IView).

            //MVVM
            //Use in situations where binding via a datacontext is possible.Why? The various IView interfaces for each view are removed which means less code to maintain.
            //Some examples where MVVM is possible include WPF and javascript projects using Knockout.

            //MVC
            //Use in situations where the connection between the view and the rest of the program is not always available
            //(and you can’t effectively employ MVVM or MVP).
            //This clearly describes the situation where a web API is separated from the data sent to the client browsers.
            //Microsoft’s ASP.NET MVC is a great tool for managing such situations and provides a very clear MVC framework.


    //http://stackoverflow.com/questions/667781/what-is-the-difference-between-mvc-and-mvvm

        }
    }
}
