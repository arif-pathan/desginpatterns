using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._41OtherPatterns
{
    class ClientSideLibraries
    {
        //optimization
        //amd vs commonjs https://addyosmani.com/writing-modular-js/
        /*Moudlarity 
        When we say an application is modular, we generally mean it's composed of a set of highly decoupled, 
        distinct pieces of functionality stored in modules. As you probably know, loose coupling facilitates 
        easier maintainability of apps by removing dependencies where possible. 
        When this is implemented efficiently, its quite easy to see how changes to one part of a system may affect another.
        
        writing modular JavaScript: AMD, CommonJS and Harmony-proposals for the next version of JavaScript, .

        The overall goal for the AMD (Asynchronous Module Definition) format is to provide a solution for modular JavaScript
        The AMD module format itself is a proposal for defining modules where 
        both the module and dependencies can be asynchronously loaded
        It has a number of distinct advantages including being both asynchronous and highly flexible by nature 
        which removes the tight coupling one might commonly find between code and module identity.

        The two key concepts you need to be aware of here are 
        the idea of a define method for facilitating module definition and 
        a require method for handling dependency loading. 
        define is used to define named or unnamed modules based on the proposal using the following signature:
                        define(
                    module_id   -optional, 
                    [dependencies] -optional, 
                    definition function -function for instantiating the module or object
                );

        Why Is AMD A Better Choice For Writing Modular JavaScript?
        Provides a clear proposal for how to approach defining flexible modules.
        It's possible to lazy load scripts if this is needed.
        Significantly cleaner than the present global namespace and <script> tag solutions many of us rely on. 
        There's a clean way to declare stand-alone modules and dependencies they may have.
        Module definitions are encapsulated, helping us to avoid pollution of the global namespace.
        Works better than some alternative solutions (eg. CommonJS, which we'll be looking at shortly). 
        Doesn't have issues with cross-domain, local or debugging and doesn't have a reliance on server-side tools to be used. 
        Most AMD loaders support loading modules in the browser without a build process.
        Provides a 'transport' approach for including multiple modules in a single file. 
        Other approaches like CommonJS have yet to agree on a transport format.
        

        There are a number of great loaders for handling module loading in the AMD and CJS formats, 
        but my personal preferences are RequireJS and curl.js. option is also almond shim
        From a production perspective, the use of optimization tools (like the RequireJS optimizer) 
        to concatenate scripts is recommended for deployment when working with such modules. 
        Interestingly, with the Almond AMD shim, RequireJS doesn't need to be rolled in the deployed site and 
        what you might consider a script loader can be easily shifted outside of development.
        */
        //requirejs
        //bundling optimization
        //nodejs
        /*
            Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine. 
                Node.js uses an event-driven, non-blocking I/O model that makes it lightweight and efficient.
                Because nothing blocks,users of Node are free from worries of dead-locking the process and
                scalable systems are very reasonable to develop in Node.
                Almost no function in Node directly performs I/O, so the process never blocks. 
                 
                This is in contrast to today's more common concurrency model where OS threads are employed. 
                Thread-based networking is relatively inefficient and very difficult to use. 

                Upon each connection the callback is fired, but if there is no work to be done Node is sleeping.
        */
        //nuget
        /*NuGet is the package manager for the Microsoft development platform including.NET.
            //Includes server as well as client side libraries
            The NuGet client tools provide the ability to produce and consume packages.*/

        //npm
        /*Node.js' package ecosystem, npm, is the largest ecosystem of open source libraries
        npm is the package manager for JavaScript.Only client side librarires. 
                Find, share, and reuse packages of code from hundreds of thousands of developers, Harness the power of npm inside 
                large teams.
                Securely manage private code with the same workflow as open source projects, Host your own private npm registry and 
                securely integrate with your workflow and tools.
               Publish and control access to your own scope
               Foster code discovery and re-use within teams
       */

        //bower
        /*
        //uses a flat dependency list in contrast with npm which uses recursive, 
        npm fetches multiple times same dependencies for different modules
        Keeping track of all these packages and making sure they are up to date (or set to the specific versions you need) is tricky. 
        Bower to the rescue!
        Bower can manage components that contain HTML, CSS, JavaScript, fonts or even image files 
        it just installs the right versions of the packages you need and their dependencies.
        Bower is a command line utility. Install it with npm. 
        $ npm install -g bower 
        A package can be a GitHub shorthand, a Git endpoint, a URL, and more.Read more about bower install.
        How you use packages is up to you. We recommend you 
        use Bower together with Grunt, RequireJS, Yeoman, and lots of other tools or build your own workflow with the API*/

        //yeomen
        //task automator - grunt,gulp
        /*grunt and gulp are task runners to automate everything that can be automated
        (i.e.compile CSS/Sass, optimize images, make a bundle and minify/transpile it).
        grunt vs. gulp (is like configuration vs. code). 
        Grunt is based on configuring separate independent tasks, each task opens/handles/closes file. 
        Gulp requires less amount of code and is based on Node streams, which allows it to build pipe chains 
        (w/o reopening the same file) and makes it faster*/
        //github
        /*
        GitHub is a development platform inspired by the way you work. 
        Host code, manage projects, and build software alongside millions of other developers.
        Collaboration made perfect. The conversations and code reviews 
        that happen in Pull Requests help your team share the weight of your work and improve the software you build.
        */

        //jquery
        //knockout

        //angularjs
        //reactjs

        //web perofrmance
        //load balancing

        //multi tenant

        //aspdotnet
        //Caching
        //entity framework basics
        //ORM-object relational model
        //relational database
        //no sql database

        //Data binding MVVM - angularjs and knockout
        //SPA
        //Unit Tests  -moq, nunit
        //CI-VFNext templates
        //TFS builds

        //Concepts implemented in project
        //HTML5 Local storage
        //Anti Forgery Token - Cross site scripting attacks
        //OWaSP
        //Event system - Signal R
        //OTP-Login in users role by doing mapping

        //IDP and SSO

    }
}
