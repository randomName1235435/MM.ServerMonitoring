using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Services.Tests;

[TestClass]
public class MonitorTests
{
    private ActionConfiguration actionConfiguration;
    private Mock<IAction> actionMock;
    private CancellationTokenSource cancellationTokenSource;
    private Mock<IMinimalRepository<ActionExecutionResult>> repositoryMock;

    [TestInitialize]
    public void Initialize()
    {
        this.actionMock = new Mock<IAction>();
        this.repositoryMock = new Mock<IMinimalRepository<ActionExecutionResult>>();
        this.actionConfiguration = new ActionConfiguration();
        this.cancellationTokenSource = new CancellationTokenSource();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new Monitor(this.actionConfiguration, this.actionMock.Object, this.repositoryMock.Object,
            Guid.NewGuid());
        Assert.IsNotNull(instance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Instance_NullParam_ShouldThrow()
    {
        var instance = new Monitor(null, null, null, Guid.Empty);
    }

    [TestMethod]
    public async Task RunAsync_ShouldExecuteAction()
    {
        var executedAction = false;
        this.actionMock.Setup(x => x.ExecuteAsync(this.cancellationTokenSource.Token))
            .Callback(() => executedAction = true)
            .Returns(Task.FromResult(new ActionExecutionResult(true, DateTime.Now)));

        var instance = new Monitor(this.actionConfiguration, this.actionMock.Object, this.repositoryMock.Object,
            Guid.NewGuid());
        var result = await instance.RunAsync(this.cancellationTokenSource.Token);
        Assert.IsTrue(executedAction);
    }

    [TestMethod]
    public async Task RunAsync_ShouldInsertInRepository()
    {
        this.actionMock.Setup(x => x.ExecuteAsync(this.cancellationTokenSource.Token))
            .Returns(Task.FromResult(new ActionExecutionResult(true, DateTime.Now)));

        var executedAction = false;
        this.repositoryMock.Setup(x => x.InsertAsync(It.IsAny<ActionExecutionResult>()
                , It.IsAny<CancellationToken>()))
            .Callback(() => executedAction = true);

        var instance = new Monitor(this.actionConfiguration, this.actionMock.Object, this.repositoryMock.Object,
            Guid.NewGuid());
        var result = await instance.RunAsync(this.cancellationTokenSource.Token);
        Assert.IsTrue(executedAction);
    }
}