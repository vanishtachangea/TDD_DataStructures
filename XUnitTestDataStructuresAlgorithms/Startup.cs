using DS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;



//Here you need to specify an assembly attribute to let xUnit find the test entry and use the custom test framework
//The first parameter of the testframework is the fullname (including the namespace) of the startup class, and the second parameter is the assembly name of the test project
//[assembly: TestFramework("XUnitTestDataStructuresAlgorithms.Startup", "XUnitTestDataStructuresAlgorithms")]

namespace XUnitTestDataStructuresAlgorithms
{
    //Startup needs to inherit from the dependency injection test framework
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddTransient<ITrappingWater, TrappingWater>();
            services.AddTransient<IBinarySearch, BinarySearch>();
        }
    }
}