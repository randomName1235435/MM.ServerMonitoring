using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Services.Tests;

[TestClass]
public class MonitorProviderTests
{
    private Mock<IActionProvider> actionProviderMock;
    private Mock<IMonitorConfiguration> monitorConfigurationMock;
    private Mock<IMonitorFactory> monitorFactoryMock;

    [TestInitialize]
    public void Initialize()
    {
        this.monitorConfigurationMock = new Mock<IMonitorConfiguration>();
        this.actionProviderMock = new Mock<IActionProvider>();
        this.monitorFactoryMock = new Mock<IMonitorFactory>();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new MonitorProvider(this.monitorConfigurationMock.Object, this.actionProviderMock.Object,
            this.monitorFactoryMock.Object);
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Instance_NullParam_ShouldThrow()
    {
        var instance = new MonitorProvider(null, null, null);
    }

    [TestMethod]
    public async Task ProvideAllAsync_ValidParam_ShouldReturnValidMonitor()
    {
        var monitorConfigurationServiceMockParam = new List<MonitorConfiguration>
        {
            new()
        };

        this.monitorConfigurationMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<IEnumerable<MonitorConfiguration>>(monitorConfigurationServiceMockParam));

        var actionProviderMockParam = new Mock<IAction>();

        this.actionProviderMock.Setup(x => x.Provide(It.IsAny<ActionConfiguration>()))
            .Returns(actionProviderMockParam.Object);

        this.monitorConfigurationMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<IEnumerable<MonitorConfiguration>>(monitorConfigurationServiceMockParam));

        var monitorFactoryMockParam = new Mock<IMonitor>();

        this.monitorFactoryMock
            .Setup(x => x.Create(It.IsAny<IAction>(), It.IsAny<ActionConfiguration>(), It.IsAny<Guid>()))
            .Returns(monitorFactoryMockParam.Object);


        var cancellationTokenSource = new CancellationTokenSource();

        var instance = new MonitorProvider(this.monitorConfigurationMock.Object, this.actionProviderMock.Object,
            this.monitorFactoryMock.Object);
        var result = await instance.ProvideAllAsync(cancellationTokenSource.Token);
        Assert.IsNotNull(result);
        Assert.AreEqual(result.First(), monitorFactoryMockParam.Object);
    }
}