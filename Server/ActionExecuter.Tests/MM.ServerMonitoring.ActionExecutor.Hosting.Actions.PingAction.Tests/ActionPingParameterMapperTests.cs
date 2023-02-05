using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.PingAction.Tests;

[TestClass]
public class ActionPingParameterMapperTests
{
    [TestInitialize]
    public void Initialize()
    {
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new ActionPingParameterMapper();
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ExecuteAsync_NullParam_ShouldThrow()
    {
        var instance = new ActionPingParameterMapper();
        var result = instance.Map(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ExecuteAsync_ParamWithoutTarget_ShouldThrow()
    {
        var instance = new ActionPingParameterMapper();
        var result = instance.Map(new ActionConfiguration());
    }

    [TestMethod]
    public void ExecuteAsync_ValidParam_ShouldSuccess()
    {
        var instance = new ActionPingParameterMapper();

        var param = new ActionConfiguration
        {
            ParameterCollection = new Dictionary<string, string>
            {
                { Constants.ParameterNames.IP, "Sample" }
            }
        };

        var result = instance.Map(param);
        Assert.IsTrue(result.PingTarget == "Sample");
    }
}