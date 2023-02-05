using Microsoft.Extensions.Logging;
using MM.ServerMonitoring.ActionExecuter.Hosting.BackgroundService.Worker;
using MM.ServerMonitoring.ActionExecutor.Interface;
using Moq;

namespace MM.ServerMonitoring.ActionExecutor.Hosting.BackgroundService.Tests;

[TestClass]
public class WorkerTests
{
    private Mock<ILogger<Worker>> loggerMock;
    private Mock<IMonitor> monitorMock;

    [TestInitialize]
    public void TesInitializae()
    {
        this.loggerMock = new Mock<ILogger<Worker>>();
        this.monitorMock = new Mock<IMonitor>();
    }

    [TestMethod]
    public void InstanceTest()
    {
        var instance = new Worker(this.loggerMock.Object, this.monitorMock.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InstanceTest_NullParam_ShouldThrow()
    {
        var instance = new Worker(null, null);
    }

    [TestMethod]
    public async Task ExecuteAsync_ValidParam_ShouldRunMonitor()
    {
        var source = new CancellationTokenSource(100000);
        var instance = new Worker(this.loggerMock.Object, this.monitorMock.Object);
        var calledRunAsync = false;
        this.monitorMock.Setup(x => x.RunAsync(It.IsAny<CancellationToken>()))
            .Callback<CancellationToken>(c =>
            {
                calledRunAsync = true;
                source.Cancel();
            });
        // someone throws cancel exception :|
        try
        {
            instance.StartAsync(source.Token).GetAwaiter().GetResult();
        }
        catch (TaskCanceledException e)
        {
        }

        Assert.IsTrue(calledRunAsync);
    }
}