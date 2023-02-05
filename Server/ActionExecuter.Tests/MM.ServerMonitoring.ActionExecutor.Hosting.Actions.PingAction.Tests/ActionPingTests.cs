using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Actions.PingAction.Tests;

[TestClass]
public class ActionPingTests
{
    private Mock<IActionParameterMapper<ActionPingParameter>> actionParameterMapperMock;

    [TestInitialize]
    public void Initialize()
    {
        this.actionParameterMapperMock = new Mock<IActionParameterMapper<ActionPingParameter>>();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new ActionPing(new ActionConfiguration(), this.actionParameterMapperMock.Object);
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ExecuteAsync_NullParam_ShouldThrow()
    {
        var instance = new ActionPing(null, this.actionParameterMapperMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public async Task ExecuteAsync_MissingParam_ShouldThrow()
    {
        this.actionParameterMapperMock.Setup(x =>
                x.Map(It.IsAny<ActionConfiguration>()))
            .Returns(new ActionPingParameter { PingTarget = string.Empty });

        var instance = new ActionPing(new ActionConfiguration(), this.actionParameterMapperMock.Object);
        var result = await instance.ExecuteAsync(new CancellationToken());
    }

    [TestMethod]
    public async Task ExecuteAsync_TargetLocalHost_ShouldSuccess()
    {
        this.actionParameterMapperMock.Setup(x =>
                x.Map(It.IsAny<ActionConfiguration>()))
            .Returns(new ActionPingParameter { PingTarget = "127.0.0.1" });

        var instance = new ActionPing(
            new ActionConfiguration
            {
                Timeout = TimeSpan.FromMilliseconds(500)
            }
            , this.actionParameterMapperMock.Object);

        var result = await instance.ExecuteAsync(new CancellationToken());
        Assert.IsTrue(result.Success);
    }
}