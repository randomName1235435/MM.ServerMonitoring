using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Services.Tests;

[TestClass]
public class MonitorFactoryTests
{
    private Mock<IAction> actionMock;
    private Mock<IMinimalRepository<ActionExecutionResult>> repositoryMock;

    [TestInitialize]
    public void Initialize()
    {
        this.repositoryMock = new Mock<IMinimalRepository<ActionExecutionResult>>();
        this.actionMock = new Mock<IAction>();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new MonitorFactory(this.repositoryMock.Object);
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InstanceTest_NullParam_Shouldthrow()
    {
        var instance = new MonitorFactory(null);
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Create_NullParam_Shouldthrow()
    {
        var instance = new MonitorFactory(this.repositoryMock.Object);
        var result = instance.Create(null, null, Guid.Empty);
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    public void Create_ValidParam_ShouldReturnValidMonitor()
    {
        var instance = new MonitorFactory(this.repositoryMock.Object);
        var result = instance.Create(this.actionMock.Object, new ActionConfiguration(), Guid.NewGuid());
        Assert.IsNotNull(result);
    }
}