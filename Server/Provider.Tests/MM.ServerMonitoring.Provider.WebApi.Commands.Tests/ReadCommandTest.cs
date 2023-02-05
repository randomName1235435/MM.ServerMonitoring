using MM.ServerMonitoring.Provider.WebApi.Commands.Crud;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Moq;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Tests;

[TestClass]
public class ReadCommandTest
{
    private readonly CancellationToken cancellationToken = CancellationToken.None;
    private Mock<ICrudServiceAsync<MonitorActionExecution>> crudServiceMock;

    [TestInitialize]
    public void Initialize()
    {
        this.crudServiceMock = new Mock<ICrudServiceAsync<MonitorActionExecution>>();
    }

    private ReadCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>> CreateInstance()
    {
        return new ReadCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(this.crudServiceMock
            .Object);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Ctor_NullParam_ShouldThrow()
    {
        var instance = new ReadCommand<MonitorActionExecution, ICrudServiceAsync<MonitorActionExecution>>(null);
    }

    private async Task<IEnumerable<MonitorActionExecution>> CreateAndExecuteAsync()
    {
        var instance = this.CreateInstance();
        return await instance.ExecuteAsync(this.cancellationToken);
    }

    private IEnumerable<MonitorActionExecution> CreateAndExecute()
    {
        var instance = this.CreateInstance();
        return instance.Execute();
    }

    private void SetupRead(MonitorActionExecution item = null)
    {
        this.crudServiceMock.Setup(m => m.Read()).Returns(new List<MonitorActionExecution> { item });
        this.crudServiceMock.Setup(m => m.ReadAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<MonitorActionExecution> { item });
    }

    [TestMethod]
    public void Execute_ValidParam_ShouldSucceed()
    {
        var item = new MonitorActionExecution();
        this.SetupRead(item);
        var result = this.CreateAndExecute();
        Assert.AreEqual(result.First(), item);
    }

    [TestMethod]
    public async Task ExecuteAsync_ValidParam_ShouldSucceed()
    {
        var item = new MonitorActionExecution();
        this.SetupRead(item);
        var result = await this.CreateAndExecuteAsync();
        Assert.AreEqual(result.First(), item);
    }
}